namespace DotNet8.ConsoleApp.Features.Services;

public interface IBlogService
{
    List<BlogModel> GetBlogs();
    BlogModel? GetBlogById(int blogId);
    bool CreateBlog(BlogModel blog);
    bool UpdateBlog(BlogModel blog);
    bool DeleteBlog(int blogId);
}