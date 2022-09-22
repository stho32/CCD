namespace csv_viewer.TabularData;

public class TabularDataRow
{
    public readonly string[] Columns;

    public TabularDataRow(string[] columns)
    {
        Columns = columns;
    }
}