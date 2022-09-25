using csvviewer.BL.CommandLineArgs;
using csvviewer.BL.Menus;
using csvviewer.Interfaces;

namespace csv_viewer;

public static class CommandLineParameters
{
    public static bool TryParse(string[] args, ExecutionEnvironment environment, out CommandLineOptions options)
    {
        var defaultOptions = new CommandLineOptions(@"C:\Projekte\CCD\Documentation\csv-viewer\example.csv", 3);
        var commandLineParser = new CommandLineParser(defaultOptions);

        if (!commandLineParser.TryParse(args, out var commandLineOptions))
        {
            environment.Output.WriteLine("Sie haben einen falschen Parameter übergeben:");
            environment.Output.WriteLine("usage:");
            environment.Output.WriteLine("    csvviewer.exe [filename] [pagesize]");

            options = defaultOptions;
            return false;
        }

        options = commandLineOptions;
        return true;
    }
}