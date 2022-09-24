using csv_viewer;
using csvviewer.Infrastructure;

var textOutput = new TextOutput();
var fileSystem = new FileSystem();

Process.Run(args, textOutput, fileSystem);