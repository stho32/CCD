using csv_viewer.TabularData;

namespace csv_viewer.Model;

public class CsvFileReader
{
    public TabularDataFile ReadFrom(string filename)
    {
        var rows = new List<TabularDataRow>();
        var inhalt = File.ReadAllLines(filename);

        foreach (var zeile in inhalt)
        {
            var split = InEinzelwerteZerlegen(zeile);
            rows.Add(new TabularDataRow(split));
        }

        var tabularDataFile = new TabularDataFile(rows.ToArray());
        tabularDataFile.RemoveRowsWithInvalidLength();

        return tabularDataFile;
    }

    private string[] InEinzelwerteZerlegen(string zeile)
    {
        return zeile.Split(";");
    }
}