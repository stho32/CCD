using csvviewer.Interfaces;

namespace csvviewer.Infrastructure;

public class FileSystem : IFileSystem
{
    public ResultOrError<string[]?> ReadFile(string filename)
    {
        string[] lines;
        try
        {
            lines = File.ReadAllLines(filename);
            return new ResultOrError<string[]?>(true, lines, "");
        }
        catch (Exception e)
        {
            return new ResultOrError<string[]?>(false, null, e.Message);
        }
    }
}