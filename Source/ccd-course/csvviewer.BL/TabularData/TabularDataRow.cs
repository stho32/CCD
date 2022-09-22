namespace csvviewer.BL.TabularData;

public class TabularDataRow
{
    public readonly string[] Columns;

    public TabularDataRow(string[] columns)
    {
        Columns = columns;
    }
}