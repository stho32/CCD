namespace csvviewer.BL.CommandLineArgs;

public class CommandLineParseResult
{
    public bool Success { get; }
    public string Message { get; }
    public CommandLineOptions Options { get; }

    public CommandLineParseResult(bool success, string message, CommandLineOptions options)
    {
        Success = success;
        Message = message;
        Options = options;
    }
}