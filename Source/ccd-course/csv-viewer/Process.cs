using csvviewer.BL.CommandLineArgs;
using csvviewer.BL.Csv;
using csvviewer.BL.Displays;
using csvviewer.Interfaces;

namespace csv_viewer;

public static class Process
{
    public static void Run(string[] args, IInput input, IOutput output, IFileSystem filesystem)
    {
        if (!TryParseCommandLineParameters(args, output, out var options))
            return;

        var content = filesystem.ReadFile(options.Filename);
        var table = content.ToTable(new CsvConverter());
        var tableDisplay = new TableDisplay(table, options.PageSize, output);

        var navigationMenu = tableDisplay.CreateNavigationMenu(input, output);
        navigationMenu.Execute();
    }

    private static bool TryParseCommandLineParameters(string[] args, IOutput output, out CommandLineOptions options)
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