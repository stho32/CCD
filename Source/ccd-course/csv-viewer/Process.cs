using csvviewer.BL.Csv;
using csvviewer.BL.Displays;
using csvviewer.BL.Menus;
using csvviewer.BL.Tables;
using csvviewer.Interfaces;

namespace csv_viewer;

public static class Process
{
    public static void Run(string[] args, ExecutionEnvironment environment)
    {
        if (!CommandLineParameters.TryParse(args, environment, out var options))
            return;

        var content = environment.FileSystem.ReadFile(options.Filename);
        var table = content.ToTable(new CsvConverter());
        table = table.AddNumbersToRows();
        var tableDisplay = new TableDisplay(table, options.PageSize, environment);

        var navigationMenu = new NavigationMenu(tableDisplay.PageCount, environment);
        navigationMenu.Run(navigation => tableDisplay.Display(navigation.CurrentPage));
    }
}