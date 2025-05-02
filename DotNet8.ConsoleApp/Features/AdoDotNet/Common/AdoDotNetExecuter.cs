namespace DotNet8.ConsoleApp.Features.AdoDotNet.Common;

public static class ExecuteAdoDotNet
{
    public static void Execute()
    {
        DbService dbService = new();
        string connection = dbService.GetConnectionString();

        AdoDotNetExercise adoDotNetExercise = new(connection);

        adoDotNetExercise.Run();
    }
}