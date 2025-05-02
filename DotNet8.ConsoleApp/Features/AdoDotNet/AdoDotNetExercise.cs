namespace DotNet8.ConsoleApp.Features.AdoDotNet;

public class AdoDotNetExercise
{
    private readonly string _connection;

    public AdoDotNetExercise(string connection)
    {
        _connection = connection;
    }

    public void Run()
    {
        while (true)
        {
            ConsoleHelper.PrintTitle("Choose an operation:");
            Console.WriteLine("1. Read");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");

            string input = ConsoleHelper.Prompt("Enter your choice: ");
            ConsoleHelper.PrintDivider();

            switch (input)
            {
                case "1": Read(); break;
                case "2": Edit(); break;
                case "3": Create(); break;
                case "4": Update(); break;
                case "5": Delete(); break;
                case "6": return;
                default:
                    ConsoleHelper.PrintMessage("Invalid input. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    private void Read()
    {
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
                Console.WriteLine($"{"Id",-10}: {dr[StaticModel.Id]}");
                Console.WriteLine($"{"Title",-10}: {dr[StaticModel.Title]}");
                Console.WriteLine($"{"Author",-10}: {dr[StaticModel.Author]}");
                Console.WriteLine($"{"Content",-10}: {dr[StaticModel.Content]}");
                ConsoleHelper.PrintDivider();
            }
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
        }
    }

    private void Edit()
    {
        int id = GetValidInt("Enter the Blog Id: ");

        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.EditQuery, connection);
        command.Parameters.AddWithValue("@BlogId", id);
        var dt = new DataTable();

        try
        {
            connection.Open();
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                ConsoleHelper.PrintMessage("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine($"{"Title",-10}: {dr["BlogTitle"]}");
            Console.WriteLine($"{"Author",-10}: {dr["BlogAuthor"]}");
            Console.WriteLine($"{"Content",-10}: {dr["BlogContent"]}");
            ConsoleHelper.PrintDivider();
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
        }
    }

    private void Create()
    {
        string title = GetRequiredInput("Enter the Blog Title: ");
        string author = GetRequiredInput("Enter the Blog Author: ");
        string content = GetRequiredInput("Enter the Blog Content: ");

        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.CreateQuery, connection);
        command.Parameters.AddWithValue("@BlogTitle", title);
        command.Parameters.AddWithValue("@BlogAuthor", author);
        command.Parameters.AddWithValue("@BlogContent", content);

        try
        {
            connection.Open();
            int result = command.ExecuteNonQuery();
            ConsoleHelper.PrintMessage(result > 0 ? "Saving Successful." : "Saving Failed.");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
        }
    }

    private void Update()
    {
        int id = GetValidInt("Enter the Blog Id: ");
        string title = GetRequiredInput("Enter the Blog Title: ");
        string author = GetRequiredInput("Enter the Blog Author: ");
        string content = GetRequiredInput("Enter the Blog Content: ");

        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.UpdateQuery, connection);
        command.Parameters.AddWithValue("@BlogId", id);
        command.Parameters.AddWithValue("@BlogTitle", title);
        command.Parameters.AddWithValue("@BlogAuthor", author);
        command.Parameters.AddWithValue("@BlogContent", content);

        try
        {
            connection.Open();
            int result = command.ExecuteNonQuery();
            ConsoleHelper.PrintMessage(result > 0 ? "Update Successful." : "Update Failed.");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
        }
    }

    private void Delete()
    {
        int id = GetValidInt("Enter the Blog Id: ");

        using var connection = new SqlConnection(_connection);
        using var command = new SqlCommand(StaticModel.DeleteQuery, connection);
        command.Parameters.AddWithValue("@BlogId", id);

        try
        {
            connection.Open();
            int result = command.ExecuteNonQuery();
            ConsoleHelper.PrintMessage(result > 0 ? "Deleting Successful." : "Deleting Failed.");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError(ex.Message);
        }
    }

    private static int GetValidInt(string prompt)
    {
        int value;
        while (true)
        {
            string input = ConsoleHelper.Prompt(prompt);
            if (int.TryParse(input, out value)) return value;
            ConsoleHelper.PrintMessage("Invalid input. Please enter a valid integer.");
        }
    }

    private static string GetRequiredInput(string prompt)
    {
        string input;
        do
        {
            input = ConsoleHelper.Prompt(prompt);
            if (string.IsNullOrWhiteSpace(input))
                ConsoleHelper.PrintMessage("Input cannot be empty.");
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }
}