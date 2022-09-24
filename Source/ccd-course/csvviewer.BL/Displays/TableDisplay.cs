using csvviewer.BL.TabularData;
using csvviewer.Interfaces;

namespace csvviewer.BL.Displays;

public class TableDisplay
{
    private readonly Table _table;
    private readonly int _pageSize;
    private readonly IOutput _output;
    private List<int> _maxWidthsPerColumn;
    private bool _isPrepared = false;

    public TableDisplay(Table table, int pageSize, IOutput output)
    {
        _table = table;
        _pageSize = pageSize;
        _output = output;
    }

    public int PageCount => CalculatePageCount();

    private int CalculatePageCount()
    {
        var fileLengthWithoutHeaderRow = _table.Rows.Length - 1;
        var pageCountAsDecimal = (decimal)fileLengthWithoutHeaderRow / _pageSize;
        var pageCountAsWholeNumber = (int)Math.Floor(pageCountAsDecimal);

        return pageCountAsWholeNumber;
    }
    
    protected void PrepareDisplay()
    {
        var numberOfColumns = _table.NumberOfColumns();

        InitMaxWidthsPerColumn(numberOfColumns);

        foreach (var row in _table.Rows)
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
        var startIndex = firstDataRow + page * _pageSize;

        for (var i = startIndex; i < startIndex + _pageSize; i++)
        {
            if (i > _table.Rows.Length - 1)
                continue;

            var row = _table.Rows[i];
            DisplayRow(row.Columns);
        }
    }

    private void DisplayRow(string[] columns, string divider = "|")
    {
        for (var i = 0; i < columns.Length; i++)
        {
            var column = columns[i];
            var columnPadded = column.PadRight(_maxWidthsPerColumn[i]);
            _output.Write(columnPadded + divider);
        }
        _output.WriteLine("");
    }

    private void DisplayHeader()
    {
        DisplayRow(_table.Rows[0].Columns);
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