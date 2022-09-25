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
}