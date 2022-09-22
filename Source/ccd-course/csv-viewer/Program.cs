using csvviewer.BL.CommandLineArgs;
using csvviewer.BL.Csv;
using csvviewer.BL.Displays;
using csvviewer.BL.Menus;

var arguments = new CommandLineParser(@"C:\Projekte\CCD\Documentation\csv-viewer\example.csv", 3);

var csvFileReader = new CsvFileReader();

var tabularDataFile = csvFileReader.ReadFrom(arguments.Filename);

var tableDisplay = new TableDisplay(tabularDataFile, arguments.PageSize);


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