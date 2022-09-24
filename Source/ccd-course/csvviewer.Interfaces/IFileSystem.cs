namespace csvviewer.Interfaces
{
    public interface IFileSystem
    {
        string[] ReadFile(string filename);
    }
}