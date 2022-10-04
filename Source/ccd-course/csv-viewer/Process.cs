using csvviewer.BL.CommandLineArgs;
using csvviewer.BL.Csv;
using csvviewer.BL.Displays;
using csvviewer.BL.Menus;
using csvviewer.BL.Tables;

namespace csv_viewer;

public static class Process
{
    public static void Run(string[] args, ExecutionEnvironment environment)
    {
        var parseResult = CommandLineParameters.TryParse(args);
        if (!parseResult.Success)
        {
            environment.Output.WriteLine(parseResult.Message);
            return;
        }

        var content = environment.FileSystem.ReadFile(parseResult.Options.Filename);
        var table = content.ToTable(new CsvConverter());
        table = table.AddNumbersToRows();
        var tableDisplay = new TableDisplay(table, parseResult.Options.PageSize, environment);

        var navigationMenu = new NavigationMenu(
            tableDisplay.PageCount, 
            environment, 
            table.Rows[0].Columns);

        navigationMenu.Run(navigation => tableDisplay.Display(navigation.CurrentPage, navigation.OrderByDescription));
    }
}