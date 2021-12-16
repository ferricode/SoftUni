namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            List<GamesExportDto> games = new List<GamesExportDto>();
            var gamesToProcess = context.Games
                            .AsQueryable()
                            .Where(g => genreNames.Contains(g.Genre.Name))
                             .Where(g => g.Purchases.Any())
                            .Include(g => g.GameTags)
                            .ThenInclude(gt => gt.Tag)
                            .Include(g => g.Purchases)
                            .Include(g => g.Genre)
                            .ToList();

            foreach (string genre in genreNames)
            {
                var genreGames = gamesToProcess
                            .Where(g => g.Genre.Name == genre)
                            .ToList();

                if (genreGames.Count == 0)
                {
                    continue;
                }

                var result = new GamesExportDto()
                {
                    Id = genreGames.First().Genre.Id,
                    Genre = genreGames.First().Genre.Name,
                    Games = genreGames
                    .Select(g => new GameExDto()
                    {
                        Id = g.Id,
                        Developer = g.Developer.Name,
                        Title = g.Name,
                        Tags = string.Join(',', g.GameTags.Select(t => t.Tag.Name)),
                        Players = g.Purchases.Count
                    })
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id)
                    .ToArray()
                };

                result.TotalPlayers = result.Games.Sum(g => g.Players);

                games.Add(result);
            }

            games = games
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            string json = JsonConvert.SerializeObject(games, Formatting.Indented);

            return json;

            //Authors solution
            //var genres = context
            //	.Genres
            //	.ToArray()
            //	.Where(g => genreNames.Contains(g.Name))
            //	.Select(g => new
            //	{
            //		Id = g.Id,
            //		Genre = g.Name,
            //		Games = g.Games
            //			.Where(ga => ga.Purchases.Any())
            //			.Select(ga => new
            //			{
            //				Id = ga.Id,
            //				Title = ga.Name,
            //				Developer = ga.Developer.Name,
            //				Tags = String.Join(", ", ga.GameTags
            //					.Select(gt => gt.Tag.Name)
            //					.ToArray()),
            //				Players = ga.Purchases.Count
            //			})
            //			.OrderByDescending(ga => ga.Players)
            //			.ThenBy(ga => ga.Id)
            //			.ToArray(),
            //		TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count)
            //	})
            //	.OrderByDescending(g => g.TotalPlayers)
            //	.ThenBy(g => g.Id)
            //	.ToArray();

            //string json = JsonConvert.SerializeObject(genres, Formatting.Indented);

            //return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			throw new NotImplementedException();
		}
	}
}