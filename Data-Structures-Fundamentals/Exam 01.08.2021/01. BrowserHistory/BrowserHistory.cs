namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private List<ILink> entities;
        public BrowserHistory()
        {
            entities = new List<ILink>();
        }
        public BrowserHistory(List<ILink> entities)
        {
            this.entities = entities;
        }
        public int Size => entities.Count;

        public void Clear()
        {
            entities.Clear();

        }

        public bool Contains(ILink link)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i] == link)
                {
                    return true;
                }
            }
            return false;
        }

        public ILink DeleteFirst()
        {
            ILink entityToDelete = null;

            if (entities.Count != 0)
            {
                entityToDelete = entities[0];
                entities.RemoveAt(0);
            }
            else
            {
                throw new InvalidOperationException();
            }
            return entityToDelete;
        }

        public ILink DeleteLast()
        {
            ILink entityToDelete;

            if (entities.Count != 0)
            {
                entityToDelete = entities[entities.Count - 1];
                entities.RemoveAt(entities.Count - 1);
            }
            else
            {
                throw new InvalidOperationException();
            }
            return entityToDelete;
        }

        public ILink GetByUrl(string url)
        {
            ILink entityToGet = null;

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Url == url)
                {
                    entityToGet = entities[i];

                }
            }
            return entityToGet;
        }

        public ILink LastVisited()
        {
            ILink lastVisitedEntity;

            if (entities.Count != 0)
            {
                lastVisitedEntity = entities[entities.Count - 1];
            }
            else
            {
                throw new InvalidOperationException();
            }
            return lastVisitedEntity;
        }

        public void Open(ILink link)
        {
            entities.Add(link);
        }

        public int RemoveLinks(string url)
        {

            List<ILink> entitiesRemoved = new List<ILink>();

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Url.ToLower().Contains(url.ToLower()))
                {
                    entitiesRemoved.Add(entities[i]);
                    entities.RemoveAt(i);

                }
            }
            if (entitiesRemoved.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return entities.Count;
            }
        }

        public ILink[] ToArray()
        {
            entities.Reverse();

            ILink[] entitiesToArray = this.entities.ToArray();
            return entitiesToArray;

        }

        public List<ILink> ToList()
        {

            entities.Reverse();

            return entities;
        }

        public string ViewHistory()
        {
            string result = "";
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                result += this.entities[i].ToString();
                result += "\r\n";
            }
            return result;
        }
    }
}
