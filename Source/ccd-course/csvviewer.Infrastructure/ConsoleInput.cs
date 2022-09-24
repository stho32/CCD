using csvviewer.Interfaces;

namespace csvviewer.Infrastructure;

public class ConsoleInput : IInput
{
    public string GetNextKeyPressInLowercase()
    {
        var input = Console.ReadKey().KeyChar.ToString().ToLower();
        Console.WriteLine();
        return input;
    }
}