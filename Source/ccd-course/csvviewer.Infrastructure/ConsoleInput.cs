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

    public int GetIntBetween(string prompt, int minimumIncluding, int maximumIncluding)
    {
        while (true)
        {
            Console.Write(prompt);
            var inputAsString = Console.ReadLine();
            if (!int.TryParse(inputAsString, out int result))
                continue;

            if (result < minimumIncluding)
            {
                Console.WriteLine($"Sorry, but your number is too low. The lowest minimum is {minimumIncluding}.");
                continue;
            }

            if (result > maximumIncluding)
            {
                Console.WriteLine($"Sorry, but your number is too high. The highest maximum is {maximumIncluding}.");
                continue;
            }

            return result;
        }
    }

    public string GetElementFromSet(string prompt, string[] options)
    {
        var optionsList = new List<string>(options);

        while (true)
        {
            Console.Write(prompt);
            var inputAsString = Console.ReadLine();

            if (optionsList.IndexOf(inputAsString??"") == -1)
            {
                Console.WriteLine("Choose one of the following options: ");
                foreach (var option in options)
                {
                    Console.WriteLine("    " + option);
                }
                Console.WriteLine("");
                continue;
            }

            return inputAsString??"";
        }
    }
}