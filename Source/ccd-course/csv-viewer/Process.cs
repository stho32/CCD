using csvviewer.BL.CommandLineArgs;
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
        var parseResult = CommandLineParameters.TryParse(args);
        if (!parseResult.Success)
        {
            environment.Output.WriteLine(parseResult.Message);
            return;
        }

        var readFileResult = environment.FileSystem.ReadFile(parseResult.Options.Filename);
        if (!readFileResult.Success || readFileResult.Result == null)
        {
            environment.Output.WriteLine("Error: " + readFileResult.ErrorMessage);
            return;
        }

        var table = readFileResult.Result.ToTable(new CsvConverter());
        table = table.AddNumbersToRows();
        
        var tableDisplay = new TableDisplay(table, parseResult.Options.PageSize, environment);

        var navigationMenu = new NavigationMenu(
            tableDisplay.PageCount, 
            environment, 
            table.Rows[0].Columns);

        navigationMenu.Run(navigation => tableDisplay.Display(navigation.CurrentPage, navigation.OrderByDescription));
    }
}