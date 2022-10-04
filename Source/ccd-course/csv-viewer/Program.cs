using csv_viewer;
using csvviewer.BL.Menus;
using csvviewer.Infrastructure;

var environment = new ExecutionEnvironment(
    new ConsoleInput(),
    new TextOutput(),
    new FileSystem()
);

try
{
    Process.Run(args, environment);
}
catch (Exception ex)
{
    Console.WriteLine("An error occured!");
    Console.WriteLine("");
    Console.WriteLine(ex.ToString());
}
