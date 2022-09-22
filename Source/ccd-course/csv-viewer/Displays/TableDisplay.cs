using csv_viewer.TabularData;

namespace csv_viewer.Displays;

public class TableDisplay
{
    private readonly TabularDataFile _file;
    private List<int> _maxWidthsPerColumn;
    private bool _isPrepared = false;
    private const int PageSize = 3;

    public TableDisplay(TabularDataFile file)
    {
        _file = file;
    }

    public int PageCount => (int)Math.Floor((decimal)FileLengthWithoutHeaderRow() / PageSize);

    private int FileLengthWithoutHeaderRow()
    {
        return _file.Rows.Length - 1;
    }

    protected void PrepareDisplay()
    {
        var numberOfColumns = _file.NumberOfColumns();

        InitMaxWidthsPerColumn(numberOfColumns);

        foreach (var row in _file.Rows)
        {
            for (int i = 0; i < numberOfColumns; i++)
            {
                if (_maxWidthsPerColumn[i] < row.Columns[i].Length)
                    _maxWidthsPerColumn[i] = row.Columns[i].Length;
            }
        }

        _isPrepared = true;
    }

    private void InitMaxWidthsPerColumn(int numberOfColumns)
    {
        _maxWidthsPerColumn = new List<int>();
        for (var i = 0; i < numberOfColumns; i++)
            _maxWidthsPerColumn.Add(0);
    }

    public void Display(int page)
    {
        if (!_isPrepared)
            PrepareDisplay();

        DisplayHeader();
        DisplayPage(page);
    }

    private void DisplayPage(int page)
    {
        var firstDataRow = 1;
        var startIndex = firstDataRow + page * PageSize;

        for (var i = startIndex; i < startIndex + PageSize; i++)
        {
            if (i > _file.Rows.Length - 1)
                continue;

            var row = _file.Rows[i];
            DisplayRow(row.Columns);
        }
    }

    private void DisplayRow(string[] columns, string divider = "|")
    {
        for (var i = 0; i < columns.Length; i++)
        {
            var column = columns[i];
            var columnPadded = column.PadRight(_maxWidthsPerColumn[i]);
            Console.Write(columnPadded + divider);
        }
        Console.WriteLine();
    }

    private void DisplayHeader()
    {
        DisplayRow(_file.Rows[0].Columns);
        DisplayHeaderDivider();
    }

    private void DisplayHeaderDivider()
    {
        var columns = new List<string>();

        foreach (var maxWidth in _maxWidthsPerColumn)
        {
            columns.Add("".PadRight(maxWidth, '-'));
        }

        DisplayRow(columns.ToArray(), "+");
    }
}