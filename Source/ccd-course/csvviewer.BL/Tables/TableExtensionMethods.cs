using System.ComponentModel;
using System.Runtime.CompilerServices;
using csvviewer.BL.Displays;

namespace csvviewer.BL.Tables;

public static class TableExtensionMethods
{
    public static int NumberOfColumns(this Table table)
    {
        if (table.Rows.Length == 0)
            return 0;

        return table.Rows[0].Columns.Length;
    }

    public static Table AddNumbersToRows(this Table sourceTable)
    {
        var resultingRows = new List<TableRow>();

        var currentLineNumber = 0;

        foreach (var row in sourceTable.Rows)
        {
            var columns = new List<string>(row.Columns);
            if (currentLineNumber == 0)
                columns.Insert(0, "No.");
            else
                columns.Insert(0, currentLineNumber.ToString());

            resultingRows.Add(new TableRow(columns.ToArray()));

            currentLineNumber++;
        }

        return new Table(resultingRows.ToArray());
    }

    public static Table SortBy(this Table table, OrderByDescription? orderByDescription)
    {
        var headerColumns = new List<string>(table.Rows[0].Columns);
        var columnIndex = headerColumns.IndexOf(orderByDescription.ColumnName);

        var rows = new List<TableRow>(table.Rows);
        rows.RemoveAt(0); // Header-Row entfernen vor der Sortierung

        var direction = 1;
        if (orderByDescription.SortDirection == SortDirectionEnum.Descending)
            direction = -1;

        switch (orderByDescription.SortMode)
        {
            case SortModeEnum.String:
                rows.Sort((x, y) => direction * string.CompareOrdinal(x.Columns[columnIndex], y.Columns[columnIndex]));
                break;
            case SortModeEnum.Int:
                rows.Sort((x, y) => direction * int.Parse(x.Columns[columnIndex]).CompareTo(int.Parse(y.Columns[columnIndex])));
                break;
        }

        rows.Insert(0, table.Rows[0]); // Header-Row nach dem Sortieren wieder einfügen
        return new Table(rows.ToArray());
    }
}