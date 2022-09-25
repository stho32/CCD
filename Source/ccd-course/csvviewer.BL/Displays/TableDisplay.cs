using csvviewer.BL.Menus;
using csvviewer.BL.Tables;

namespace csvviewer.BL.Displays;

public class TableDisplay
{
    private Table _table;
    private readonly int _pageSize;
    private readonly ExecutionEnvironment _environment;
    private List<int> _maxWidthsPerColumn;
    private bool _isPrepared = false;
    private OrderByDescription? _currentOrderBy;

    public TableDisplay(Table table, int pageSize, ExecutionEnvironment environment)
    {
        _table = table;
        _pageSize = pageSize;
        _environment = environment;
    }

    public int PageCount => CalculatePageCount();

    private int CalculatePageCount()
    {
        var fileLengthWithoutHeaderRow = _table.Rows.Length - 1;
        var pageCountAsDecimal = (decimal)fileLengthWithoutHeaderRow / _pageSize;
        var pageCountAsWholeNumber = (int)Math.Floor(pageCountAsDecimal);

        // +1 weil die Funktion PageCount und nicht MaximumPageIndex heißt...
        return pageCountAsWholeNumber + 1;
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

    public void Display(int page, OrderByDescription? orderBy = null)
    {
        if (!_isPrepared)
            PrepareDisplay();

        if (orderBy != null && _currentOrderBy != orderBy)
        {
            OrderBy(orderBy);
        }

        DisplayHeader();
        DisplayPage(page);
    }

    private void OrderBy(OrderByDescription? orderByDescription)
    {
        _table = _table.SortBy(orderByDescription);
        _currentOrderBy = orderByDescription;
    }

    private void DisplayPage(int page)
    {
        var firstDataRow = 1;
        var startIndex = firstDataRow + (page-1) * _pageSize;

        for (var i = startIndex; i < startIndex + _pageSize; i++)
        {
            if (i > _table.Rows.Length - 1)
                continue;

            var row = _table.Rows[i];
            DisplayRow(row.Columns);
        }

        DisplayPageNumber(page);
    }

    private void DisplayPageNumber(int page)
    {
        _environment.Output.WriteLine("Page " + page + " of " + PageCount);
    }

    private void DisplayRow(string[] columns, string divider = "|")
    {
        for (var i = 0; i < columns.Length; i++)
        {
            var column = columns[i];
            var columnPadded = column.PadRight(_maxWidthsPerColumn[i]);
            _environment.Output.Write(columnPadded + divider);
        }
        _environment.Output.WriteLine("");
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

