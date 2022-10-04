using csvviewer.BL.Tables;
using csvviewer.Interfaces;

namespace csvviewer.BL.Csv;

/* ehem. CsvFileReader */
/*
 * Beinhält 2 Aufgaben:
 * - Laden der Datei
 * - Konvertieren der Inhalte in einen anderen Datentyp
 * => 2 unterschiedliche Operationen ...
 *
 * Besser wäre es, nicht vom Dateinamen auszugehen, das
 * reduziert die Testbarkeit.
 */

public static class StringArrayExtensions
{
    public static Table ToTable(this string[] content, IDataConverter converter)
    {
        var rows = new List<TableRow>();

        foreach (var row in content)
        {
            var split = converter.Parse(row);
            rows.Add(new TableRow(split));
        }

        var table = new Table(rows.ToArray());

        return table;
    }
}

