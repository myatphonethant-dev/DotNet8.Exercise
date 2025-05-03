namespace DotNet8.ConsoleApp.Features.Dapper;

public class DapperExercise : IBlogService
{
    private readonly string _connection;

    public DapperExercise(DbService dbService)
    {
        _connection = dbService.GetConnectionString();
    }

    public List<BlogModel> GetBlogs()
    {
        using IDbConnection db = new SqlConnection(_connection);
        try
        {
            return db.Query<BlogModel>(SqlQueries.SelectQuery).ToList();
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return new List<BlogModel>();
        }
    }

    public BlogModel? GetBlogById(int blogId)
    {
        using IDbConnection db = new SqlConnection(_connection);
        try
        {
            return db.Query<BlogModel>(SqlQueries.EditQuery, new { BlogId = blogId }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return null;
        }
    }

    public bool CreateBlog(BlogModel blog)
    {
        using IDbConnection db = new SqlConnection(_connection);
        try
        {
            var affected = db.Execute(SqlQueries.CreateQuery, blog);
            return affected > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }

    public bool UpdateBlog(BlogModel blog)
    {
        using IDbConnection db = new SqlConnection(_connection);
        try
        {
            var affected = db.Execute(SqlQueries.UpdateQuery, blog);
            return affected > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }

    public bool DeleteBlog(int blogId)
    {
        using IDbConnection db = new SqlConnection(_connection);
        try
        {
            var affected = db.Execute(SqlQueries.DeleteQuery, new { BlogId = blogId });
            return affected > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }
}