namespace DotNet8.ConsoleApp.Features.Common;

public class ConsoleUI
{
    private readonly IBlogService _blogService;

    public ConsoleUI(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public bool Run()
    {
        while (true)
        {
            ConsoleHelper.PrintTitle("Choose an operation:");
            Console.WriteLine("1. Change DB Access");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Edit");
            Console.WriteLine("4. Create");
            Console.WriteLine("5. Update");
            Console.WriteLine("6. Delete");
            Console.WriteLine("7. Exit");

            string input = ConsoleHelper.Prompt("Enter your choice: ");
            ConsoleHelper.PrintDivider();

            switch (input)
            {
                case "1": return true;
                case "2": Read(); break;
                case "3": Edit(); break;
                case "4": Create(); break;
                case "5": Update(); break;
                case "6": Delete(); break;
                case "7": return false;
                default:
                    ConsoleHelper.PrintMessage("Invalid input.");
                    break;
            }
        }
    }

    private void Read()
    {
        var blogs = _blogService.GetBlogs();
        foreach (var blog in blogs)
        {
            Console.WriteLine($"{"Id",-10}: {blog.BlogId}");
            Console.WriteLine($"{"Title",-10}: {blog.BlogTitle}");
            Console.WriteLine($"{"Author",-10}: {blog.BlogAuthor}");
            Console.WriteLine($"{"Content",-10}: {blog.BlogContent}");
            ConsoleHelper.PrintDivider();
        }
    }

    private void Edit()
    {
        int id = GetValidInt("Enter the Blog Id: ");
        var blog = _blogService.GetBlogById(id);
        if (blog is null)
        {
            ConsoleHelper.PrintMessage("No blog found.");
            return;
        }

        Console.WriteLine($"{"Title",-10}: {blog.BlogTitle}");
        Console.WriteLine($"{"Author",-10}: {blog.BlogAuthor}");
        Console.WriteLine($"{"Content",-10}: {blog.BlogContent}");
        ConsoleHelper.PrintDivider();
    }

    private void Create()
    {
        var blog = new BlogModel
        {
            BlogTitle = GetRequiredInput("Enter the Blog Title: "),
            BlogAuthor = GetRequiredInput("Enter the Blog Author: "),
            BlogContent = GetRequiredInput("Enter the Blog Content: ")
        };

        var result = _blogService.CreateBlog(blog);
        ConsoleHelper.PrintMessage(result ? "Create Successful." : "Create Failed.");
    }

    private void Update()
    {
        var blog = new BlogModel
        {
            BlogId = GetValidInt("Enter the Blog Id: "),
            BlogTitle = GetRequiredInput("Enter the Blog Title: "),
            BlogAuthor = GetRequiredInput("Enter the Blog Author: "),
            BlogContent = GetRequiredInput("Enter the Blog Content: ")
        };

        var result = _blogService.UpdateBlog(blog);
        ConsoleHelper.PrintMessage(result ? "Update Successful." : "Update Failed.");
    }

    private void Delete()
    {
        int id = GetValidInt("Enter the Blog Id: ");
        var result = _blogService.DeleteBlog(id);
        ConsoleHelper.PrintMessage(result ? "Delete Successful." : "Delete Failed.");
    }

    private static int GetValidInt(string prompt)
    {
        while (true)
        {
            string input = ConsoleHelper.Prompt(prompt);
            if (int.TryParse(input, out int result))
                return result;
            ConsoleHelper.PrintMessage("Invalid integer input.");
        }
    }

    private static string GetRequiredInput(string prompt)
    {
        string? input;
        do
        {
            input = ConsoleHelper.Prompt(prompt);
            if (string.IsNullOrWhiteSpace(input))
                ConsoleHelper.PrintMessage("Input cannot be empty.");
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }
}