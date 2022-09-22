using csv_viewer.Displays;
using csv_viewer.Menus;
using csv_viewer.Model;

var filename = @"C:\Projekte\CCD\Documentation\csv-viewer\example.csv";

var csvFileReader = new CsvFileReader();

var tabularDataFile = csvFileReader.ReadFrom(filename);

var tableDisplay = new TableDisplay(tabularDataFile);


var page = 0;
var menu = new TextMenu();

tableDisplay.Display(page);

menu.AddOption("F)irst page", "f", () =>
{
    page = 0;
    
    tableDisplay.Display(page);
});

menu.AddOption("P)revious page", "p", () =>
{
    if (page > 0)
        page -= 1;

    tableDisplay.Display(page);
});

menu.AddOption("N)ext page", "n", () =>
{
    if (page < tableDisplay.PageCount)
        page += 1;

    tableDisplay.Display(page);
});

menu.AddOption("L)ast page", "l", () =>
{
    page = tableDisplay.PageCount;

    tableDisplay.Display(page);
});

menu.AddOption("E)xit", "e", () =>
{
    menu.Exit();
});

menu.Execute();