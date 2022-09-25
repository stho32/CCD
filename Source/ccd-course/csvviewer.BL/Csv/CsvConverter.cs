using csvviewer.Interfaces;

namespace csvviewer.BL.Csv;

public class CsvConverter : IDataConverter
{
    public string[] Parse(string row)
    {
        var split = new List<string>(row.Split(';'));
        for (var i = 0; i < split.Count; i++)
        {
            split[i] = split[i].Trim();
        }

        return split.ToArray();
    }
}