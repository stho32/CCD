using csvviewer.BL.CommandLineArgs;
using csvviewer.Interfaces;

namespace csv_viewer;

public static class CommandLineParameters
{
    public static bool TryParse(string[] args, IOutput output, out CommandLineOptions options)
    {
        var defaultOptions = new CommandLineOptions(@"C:\Projekte\CCD\Documentation\csv-viewer\example.csv", 3);
        var commandLineParser = new CommandLineParser(defaultOptions);

        if (!commandLineParser.TryParse(args, out var commandLineOptions))
        {
            output.WriteLine("Sie haben einen falschen Parameter übergeben:");
            output.WriteLine("usage:");
            output.WriteLine("    csvviewer.exe [filename] [pagesize]");

            options = defaultOptions;
            return false;
        }

        options = commandLineOptions;
        return true;
    }
}