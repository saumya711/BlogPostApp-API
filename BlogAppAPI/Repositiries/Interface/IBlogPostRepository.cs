using BlogAppAPI.Models.Domain;

namespace BlogAppAPI.Repositiries.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}
