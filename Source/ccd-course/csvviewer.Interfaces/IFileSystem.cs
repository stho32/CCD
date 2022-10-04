namespace csvviewer.Interfaces
{
    public interface IFileSystem
    {
        ResultOrError<string[]?> ReadFile(string filename);
    }
}