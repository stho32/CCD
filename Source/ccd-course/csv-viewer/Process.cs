using csvviewer.BL.Csv;
using csvviewer.BL.Displays;
using csvviewer.BL.Menus;
using csvviewer.Interfaces;

namespace csv_viewer;

public static class Process
{
    public static void Run(string[] args, IInput input, IOutput output, IFileSystem filesystem)
    {
        if (!CommandLineParameters.TryParse(args, output, out var options))
            return;

        var content = filesystem.ReadFile(options.Filename);
        var table = content.ToTable(new CsvConverter());
        var tableDisplay = new TableDisplay(table, options.PageSize, output);

        var navigationMenu = new NavigationMenu(tableDisplay.PageCount, new ExecutionEnvironment(input, output));
        navigationMenu.Run(navigation => tableDisplay.Display(navigation.CurrentPage));
    }
}