namespace csvviewer.BL.CommandLineArgs;

public class CommandLineParser
{
    private readonly CommandLineOptions _defaultOptions;

    public CommandLineParser(CommandLineOptions defaultOptions)
    {
        _defaultOptions = defaultOptions;
    }

    public bool TryParse(string[] args, out CommandLineOptions result)
    {
        result = _defaultOptions;
        var filename = _defaultOptions.Filename;
        var pageSize = _defaultOptions.PageSize;

        if (args.Length > 0)
            filename = args[0];

        if (args.Length > 1)
        {
            if (!int.TryParse(args[1], out int pageSizeFromCommandLine))
                return false;
            pageSize = pageSizeFromCommandLine;
        }

        result = new CommandLineOptions(filename, pageSize);
        return true;
    }
}