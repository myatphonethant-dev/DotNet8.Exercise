namespace DotNet8.ConsoleApp.Features.EFCore;

public class EFCoreExercise : IBlogService
{
    private readonly AppDbContext _db;

    public EFCoreExercise(DbService dbService)
    {
        _db = new AppDbContext(dbService.GetDbContextOptions());
    }

    public List<BlogModel> GetBlogs()
    {
        try
        {
            return _db.Blogs.ToList();
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return new List<BlogModel>();
        }
    }

    public BlogModel? GetBlogById(int blogId)
    {
        try
        {
            return _db.Blogs.FirstOrDefault(x => x.BlogId == blogId);
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return null;
        }
    }

    public bool CreateBlog(BlogModel blog)
    {
        try
        {
            _db.Blogs.Add(blog);
            return _db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }

    public bool UpdateBlog(BlogModel blog)
    {
        try
        {
            var entity = _db.Blogs.FirstOrDefault(x => x.BlogId == blog.BlogId);
            if (entity is null) return false;

            entity.BlogTitle = blog.BlogTitle;
            entity.BlogAuthor = blog.BlogAuthor;
            entity.BlogContent = blog.BlogContent;

            return _db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }

    public bool DeleteBlog(int blogId)
    {
        try
        {
            var blog = _db.Blogs.FirstOrDefault(x => x.BlogId == blogId);
            if (blog is null) return false;

            _db.Blogs.Remove(blog);
            return _db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }
}