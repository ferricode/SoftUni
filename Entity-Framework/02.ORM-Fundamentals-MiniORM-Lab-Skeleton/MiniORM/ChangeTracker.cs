using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;
        private static IEnumerable<PropertyInfo> primaryKeys;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.added = new List<T>();
            this.removed = new List<T>();

            this.allEntities = CloneEntities(entities);
        }

        //Current state of the entities in the database
        public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();

        //State of added entities(logically, not physicaly)
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();

        //State of removed entitites(logically, not physicaly)
        //They shoul be removed when .SaveChanges( is callled)
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();

        public void Add(T item) => this.added.Add(item);
        public void Remove(T item) => this.removed.Add(item);

        //Db -> DB State
        //AllEntities -> Proxy entities -> Current state -> Locally int he memory
        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            List<T> modifiedEntities = new List<T>();

            //It may be composite primary keys
            //Not primary key values, these are primary key properties!!! PropertyInfo
            PropertyInfo[] primaryKeys = typeof(T)
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in this.AllEntities)
            {
                IEnumerable<object> primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();
                
                T dbEntity = dbSet
                           .Entities
                           .Single(e => GetPrimaryKeyValues(primaryKeys, e)
                           .SequenceEqual(primaryKeyValues));

                bool isModified = IsModified(proxyEntity, dbEntity);
                if (isModified)
                {
                    modifiedEntities.Add(dbEntity);
                }
            }
            return modifiedEntities;
        }
        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            List<T> clonedEntities = new List<T>();

            PropertyInfo[] propertiesToClone = typeof(T)
                            .GetProperties()
                            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                            .ToArray();

            foreach (T entity in entities)
            {
                T clonedEntity = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in propertiesToClone)
                {
                    object value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }
                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)=>primaryKeys.Select(pk=>pk.GetValue(entity));

        private static bool IsModified(T proxyEntity, T dbEntity)
        {
            PropertyInfo[] monitoredProiperties = typeof(T)
                                                  .GetProperties()
                                                  .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                                                  .ToArray();
            PropertyInfo[] modifiedProperties = monitoredProiperties
                        .Where(pi => Equals(pi.GetValue(proxyEntity), pi.GetValue(dbEntity)))
                        .ToArray();
            return modifiedProperties.Any();
        }
        //private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        // {
        //    List<object> values = new List<object>();

        //    foreach (PropertyInfo primaryKey in primaryKeys)
        //    {
        //        object pkValue = primaryKey.GetValue(entity);
        //        values.Add(pkValue);
        //    }
        //    return values;
        //}
    }
}