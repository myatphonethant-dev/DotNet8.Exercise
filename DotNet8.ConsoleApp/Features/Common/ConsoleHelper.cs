namespace DotNet8.ConsoleApp.Features.AdoDotNet.Common;

public static class ConsoleHelper
{
    public static void PrintDivider() => Console.WriteLine(new string('=', 35));

    public static void PrintTitle(string title)
    {
        PrintDivider();
        Console.WriteLine(title);
        PrintDivider();
    }

    public static string Prompt(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? string.Empty;
    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
        PrintDivider();
    }

    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
        PrintDivider();
    }
}