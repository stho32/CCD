using csvviewer.BL.Tables;

namespace csvviewer.BL.Displays;

public record OrderByDescription(string ColumnName, SortModeEnum SortMode, SortDirectionEnum SortDirection);