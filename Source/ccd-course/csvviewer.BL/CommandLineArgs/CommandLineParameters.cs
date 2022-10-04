namespace csvviewer.BL.CommandLineArgs;

public static class CommandLineParameters
{
    public static CommandLineParseResult TryParse(string[] args)
    {
        var defaultOptions = new CommandLineOptions(@"C:\Projekte\CCD\Documentation\csv-viewer\example.csv", 3);
        var commandLineParser = new CommandLineParser(defaultOptions);

        if (!commandLineParser.TryParse(args, out var commandLineOptions))
        {
            return new CommandLineParseResult(
                false,
                @"
Sie haben einen falschen Parameter übergeben:
usage:
    csvviewer.exe [filename] [pagesize]
".Trim(),
                defaultOptions
            );
        }

        return new CommandLineParseResult(true, "", commandLineOptions);
    }
}