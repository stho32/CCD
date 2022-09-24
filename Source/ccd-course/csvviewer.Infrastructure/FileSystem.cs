using csvviewer.Interfaces;

namespace csvviewer.Infrastructure;

public class FileSystem : IFileSystem
{
    public string[] ReadFile(string filename)
    {
        return File.ReadAllLines(filename);
    }
}