namespace csvviewer.Interfaces;

public interface IDataConverter
{
    public string[] Parse(string row);
}