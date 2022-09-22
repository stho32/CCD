using csv_viewer.TabularData;

namespace csv_viewer.Csv;

public class CsvFileReader
{
    /*
     * Beinhält 2 Aufgaben:
     * - Laden der Datei
     * - Konvertieren der Inhalte in einen anderen Datentyp
     * => 2 unterschiedliche Operationen ...
     *
     * Besser wäre es, nicht vom Dateinamen auszugehen, das
     * reduziert die Testbarkeit.
     */
    public TabularDataFile ReadFrom(string filename)
    {
        var rows = new List<TabularDataRow>();
        var contentInRows = LoadFileAsRows(filename);

        foreach (var csvRow in contentInRows)
        {
            var split = SplitIntoColumns(csvRow);
            rows.Add(new TabularDataRow(split));
        }

        var tabularDataFile = new TabularDataFile(rows.ToArray());

        return tabularDataFile;
    }

    private string[] SplitIntoColumns(string row)
    {
        return row.Split(";");
    }

    private string[] LoadFileAsRows(string filename)
    {
        return File.ReadAllLines(filename);
    }
}