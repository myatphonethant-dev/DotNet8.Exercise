namespace DotNet8.ConsoleApp.Features.AdoDotNet;

public class AdoDotNetExercise : IBlogService
{
    private readonly string _connection;

    public AdoDotNetExercise(DbService dbService)
    {
        _connection = dbService.GetConnectionString();
    }

    public List<BlogModel> GetBlogs()
    {
        var list = new List<BlogModel>();

        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.SelectQuery, connection);
        using var adapter = new SqlDataAdapter(command);
        var dt = new DataTable();

        try
        {
            connection.Open();
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var blog = new BlogModel
                {
                    BlogId = Convert.ToInt32(dr[StaticModel.Id]),
                    BlogTitle = dr[StaticModel.Title].ToString(),
                    BlogAuthor = dr[StaticModel.Author].ToString(),
                    BlogContent = dr[StaticModel.Content].ToString()
                };
                list.Add(blog);
            }
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
        }

        return list;
    }

    public BlogModel? GetBlogById(int blogId)
    {
        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.EditQuery, connection);
        command.Parameters.AddWithValue("@BlogId", blogId);
        var dt = new DataTable();

        try
        {
            connection.Open();
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            if (dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];
            return new BlogModel
            {
                BlogId = blogId,
                BlogTitle = dr["BlogTitle"].ToString(),
                BlogAuthor = dr["BlogAuthor"].ToString(),
                BlogContent = dr["BlogContent"].ToString()
            };
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return null;
        }
    }

    public bool CreateBlog(BlogModel blog)
    {
        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.CreateQuery, connection);
        command.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        command.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
        command.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

        try
        {
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }

    public bool UpdateBlog(BlogModel blog)
    {
        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.UpdateQuery, connection);
        command.Parameters.AddWithValue("@BlogId", blog.BlogId);
        command.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        command.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
        command.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

        try
        {
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }

    public bool DeleteBlog(int blogId)
    {
        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.DeleteQuery, connection);
        command.Parameters.AddWithValue("@BlogId", blogId);

        try
        {
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            return false;
        }
    }
}