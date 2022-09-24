using csvviewer.BL.CommandLineArgs;
using csvviewer.BL.Csv;
using csvviewer.BL.Displays;
using csvviewer.BL.Menus;
using csvviewer.Interfaces;

namespace csv_viewer;

public static class Process
{
    public static void Run(string[] args, IOutput output, IFileSystem filesystem)
    {
        if (!TryParseCommandLineParameters(args, output, out var options))
            return;

        var content = filesystem.ReadFile(options.Filename);
        var table = content.ToTable(new CsvConverter());
        var tableDisplay = new TableDisplay(table, options.PageSize, output);

        var page = 0;
        var menu = new TextMenu();

        tableDisplay.Display(page);

        menu.AddMenuItem("F)irst page", "f", () =>
        {
            page = 0;

            tableDisplay.Display(page);
        });

        menu.AddMenuItem("P)revious page", "p", () =>
        {
            if (page > 0)
                page -= 1;

            tableDisplay.Display(page);
        });

        menu.AddMenuItem("N)ext page", "n", () =>
        {
            if (page < tableDisplay.PageCount)
                page += 1;

            tableDisplay.Display(page);
        });

        menu.AddMenuItem("L)ast page", "l", () =>
        {
            page = tableDisplay.PageCount;

            tableDisplay.Display(page);
        });

        menu.AddMenuItem("E)xit", "e", () =>
        {
            menu.Exit();
        });

        menu.Execute();

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