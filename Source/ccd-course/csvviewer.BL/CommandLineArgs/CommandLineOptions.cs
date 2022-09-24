namespace csvviewer.BL.CommandLineArgs;

public class CommandLineOptions
{
    public string Filename { get; }
    public int PageSize { get; }

    public CommandLineOptions(string filename, int pageSize)
    {
        Filename = filename;
        PageSize = pageSize;
    }
}