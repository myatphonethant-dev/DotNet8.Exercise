namespace DotNet8.ConsoleApp.Features.AdoDotNet;

public static class ExecuteAdoDotNet
{
    public static void AdoDotNetExecuter()
    {
        DbService dbService = new();
        string connection = dbService.GetConnectionString();

        AdoDotNetExercise adoDotNetExercise = new(connection);

        adoDotNetExercise.Run();
    }
}