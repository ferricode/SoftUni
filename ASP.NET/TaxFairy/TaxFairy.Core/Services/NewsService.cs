using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.Models;
using TaxFairy.Infrastructure.Data.Models;
using TaxFairy.Infrastructure.Repositories;

namespace TaxFairy.Core.Services
{
    public class NewsService : INewsService
    {
        private readonly ITaxFairyDbRepository repo;


        public NewsService(ITaxFairyDbRepository _repo)
        {
            repo = _repo;
        }
        public Task<bool> EditNews(NewsViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NewsViewModel>> GetNewsList()
        {

            return await repo.All<News>()
                .Select(n => new NewsViewModel()
                {
                    Id = n.Id.ToString(),
                    Content = n.Content,
                    IssueDate = n.IssueDate,

                })
                .ToListAsync();

        }

        public Task<NewsViewModel> GetNewsToEdit(string id)
        {
            throw new NotImplementedException();
        }
    }
}
