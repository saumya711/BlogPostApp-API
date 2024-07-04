using BlogAppAPI.Models.Domain;
using BlogAppAPI.Models.DTO;
using BlogAppAPI.Repositiries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto request)
        {
            // Convert DTO to Domain
            var blogPost = new BlogPost
            {
                Title = request.Title,
                Content = request.Content,
                ShortDescription = request.ShortDescription,
                FeaturedImageUrl = request.FeaturedImageUrl,
                PublishedDate = request.PublishedDate,
                Author = request.Author,
                UrlHandle = request.UrlHandle,
                IsVisible = request.IsVisible
            };

            blogPost = await blogPostRepository.CreateAsync(blogPost);

            //Convert Domain Model to DTO
            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                ShortDescription = blogPost.ShortDescription,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                UrlHandle = blogPost.UrlHandle,
                IsVisible = blogPost.IsVisible
            };

            return Ok(response);

        }
    }
}
