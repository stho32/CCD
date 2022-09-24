using csv_viewer;
using csvviewer.Infrastructure;

var textOutput = new TextOutput();
var fileSystem = new FileSystem();
var consoleInput = new ConsoleInput();

Process.Run(args, consoleInput, textOutput, fileSystem);