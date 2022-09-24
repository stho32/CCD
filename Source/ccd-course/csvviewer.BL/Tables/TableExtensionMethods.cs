namespace csvviewer.BL.Tables;

public static class TableExtensionMethods
{
    public static int NumberOfColumns(this Table table)
    {
        if (table.Rows.Length == 0)
            return 0;

        return table.Rows[0].Columns.Length;
    }
}