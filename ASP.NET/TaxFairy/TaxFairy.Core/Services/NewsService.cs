using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.ViewModels;
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
        public async Task<bool> EditNews(NewsViewModel model)
        {
            bool result = false;
            var news = await repo.GetByIdAsync<News>(model.Id);

            if (news != null)
            {
                news.Content = model.Content;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<IEnumerable<NewsViewModel>> GetNewsList()
        {

            return await repo.All<News>()
                .Select(n => new NewsViewModel()
                {
                    Id = n.Id,
                    Content = n.Content,
                    IssueDate = n.IssueDate,

                })
                .ToListAsync();

        }

        public async Task<NewsViewModel> GetNewsToEdit(string id)
        {
            var news = await repo.GetByIdAsync<News>(id);

            return new NewsViewModel()
            {
                Id = news.Id,
                Content = news.Content,
                IssueDate = news.IssueDate.Date
            };
        }
        public async Task<bool> CreateNews(NewsCreateViewModel model)
        {
            bool created = false;


            var news = new News()
            {
                Id = Guid.NewGuid().ToString(),
                Content = model.Content,
                IssueDate = DateTime.Now.Date,
            };

            if (news != null)
            {

                await repo.AddAsync(news);
                await repo.SaveChangesAsync();
                created = true;
            }

            return created;
        }
    }
}