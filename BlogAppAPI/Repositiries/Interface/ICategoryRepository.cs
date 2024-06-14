using BlogAppAPI.Models.Domain;

namespace BlogAppAPI.Repositiries.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();
    }
}
