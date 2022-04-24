using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET_EFCoreOct2021
{
    public static class Queries
    {
        public const string CREATE_DB_QUERY = "CREATE DATABASE [ADONETDB2]";

        public const string VILAINS_WITH_MORE_THAN_3_MINIONS = @"SELECT v.[Name], COUNT(mv.VillainId) AS MinionsCount  
                                                                 FROM Villains AS v 
                                                                 JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                                 GROUP BY v.[Id], v.[Name] 
                                                                 HAVING COUNT(mv.VillainId) > 3 
                                                                 ORDER BY COUNT(mv.VillainId) ";

        public const string VILAINS_NAME_BY_ID = @"SELECT [Name] FROM Villains WHERE Id = @Id
                                        SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                                                 m.Name, 
                                                                                 m.Age
                                                                            FROM MinionsVillains AS mv
                                                                            JOIN Minions As m ON mv.MinionId = m.Id
                                                                           WHERE mv.VillainId = @Id
                                                                        ORDER BY m.Name";

        public const string VILAINS_NAME_INFO_BY_ID =  @"SELECT ROW_NUMBER() OVER(ORDER BY m.[Name]) as RowNum,
                                         m.[Name], 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.[Name]";
    }
}
