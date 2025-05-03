while (true)
{
    var dbService = new DbService();

    ConsoleHelper.PrintTitle("Choose DB Access:");
    Console.WriteLine("1 = ADO.NET");
    Console.WriteLine("2 = Dapper");
    Console.WriteLine("3 = EF Core");
    ConsoleHelper.PrintDivider();

    string? choice;
    do
    {
        choice = ConsoleHelper.Prompt("Enter your choice: ");
    } while (string.IsNullOrWhiteSpace(choice));

    IBlogService blogService = choice switch
    {
        "1" => new AdoDotNetExercise(dbService),
        "2" => new DapperExercise(dbService),
        "3" => new EFCoreExercise(dbService),
        _ => throw new InvalidOperationException("Invalid option selected.")
    };

    var ui = new ConsoleUI(blogService);
    var goBack = ui.Run();

    if (!goBack)
        break;
}

ConsoleHelper.PrintMessage("Thank you for using the application!");