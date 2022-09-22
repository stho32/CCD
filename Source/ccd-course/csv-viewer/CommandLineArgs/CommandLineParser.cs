namespace csv_viewer.CommandLineArgs;

public class CommandLineParser
{
    public int PageSize { get; private set; }
    public string Filename { get; private set; }

    public CommandLineParser(string defaultFilename, int defaultPageSize)
    {
        PageSize = defaultPageSize;
        Filename = defaultFilename;
    }

    public void Parse(string[] args)
    {
        if (args.Length > 1)
            Filename = args[1];
        if (args.Length > 2)
            PageSize = int.Parse(args[2]);
    }
}