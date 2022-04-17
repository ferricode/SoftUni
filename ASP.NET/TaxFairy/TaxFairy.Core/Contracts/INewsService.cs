using TaxFairy.Core.Models;

namespace TaxFairy.Core.Contracts
{
    public interface INewsService
    {
        Task<IEnumerable<NewsViewModel>> GetNewsList();
        Task<NewsViewModel> GetNewsToEdit(string id);
        Task<bool> EditNews(NewsViewModel model);
    }
}
