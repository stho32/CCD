namespace csv_viewer.TabularData;

public class TabularDataFile
{
    public TabularDataRow[] Rows;

    public TabularDataFile(TabularDataRow[] rows)
    {
        Rows = rows;
    }

    public int NumberOfColumns()
    {
        if (Rows.Length == 0)
            return 0;

        return Rows[0].Columns.Length;
    }

    public void RemoveRowsWithInvalidLength()
    {
        var rows = new List<TabularDataRow>(Rows);
        var numberOfColumns = NumberOfColumns();

        for (var i = rows.Count - 1; i >= 0; i--)
        {
            var row = rows[i];
            if (row.Columns.Length != numberOfColumns)
                rows.RemoveAt(i);
        }

        Rows = rows.ToArray();
    }
}