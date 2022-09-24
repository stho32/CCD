using csvviewer.Interfaces;

namespace csvviewer.BL.Csv;

public class CsvConverter : IDataConverter
{
    public string[] Parse(string row)
    {
        return row.Split(';');
    }
}