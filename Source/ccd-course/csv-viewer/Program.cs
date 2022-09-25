using csv_viewer;
using csvviewer.BL.Menus;
using csvviewer.Infrastructure;

var environment = new ExecutionEnvironment(
    new ConsoleInput(),
    new TextOutput(),
    new FileSystem()
);

Process.Run(args, environment);