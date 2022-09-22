namespace csvviewer.BL.TabularData;

public class TabularDataFile
{
    public TabularDataRow[] Rows;

    public TabularDataFile(TabularDataRow[] rows)
    {
        Rows = rows;
    }

    // Könnte ein Problem sein, weil das sonst-DTO keine Funktion enthalten sollte
    public int NumberOfColumns()
    {
        if (Rows.Length == 0)
            return 0;

        return Rows[0].Columns.Length;
    }

}