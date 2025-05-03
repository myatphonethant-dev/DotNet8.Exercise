namespace DotNet8.ConsoleApp.Features.Common;

public static class ConsoleHelper
{
    public static void PrintTitle(string title)
    {
        Console.WriteLine();
        Console.WriteLine(title);
        Console.WriteLine(new string('-', title.Length));
    }

    public static void PrintDivider()
    {
        Console.WriteLine(new string('=', 30));
    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine();
    }

    public static void PrintError(string message)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ForegroundColor = currentColor;
    }

    public static string Prompt(string label)
    {
        Console.Write(label);
        return Console.ReadLine() ?? string.Empty;
    }
}