namespace csvviewer.BL.Tables;

public class TableRow
{
    public readonly string[] Columns;

    public TableRow(string[] columns)
    {
        Columns = columns;
    }
}