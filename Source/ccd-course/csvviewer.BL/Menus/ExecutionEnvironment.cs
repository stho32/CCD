using csvviewer.Interfaces;

namespace csvviewer.BL.Menus;

public class ExecutionEnvironment
{
    public IInput Input { get; }
    public IOutput Output { get; }
    public IFileSystem FileSystem { get; }

    public ExecutionEnvironment(IInput input, IOutput output, IFileSystem fileSystem)
    {
        Input = input;
        Output = output;
        FileSystem = fileSystem;
    }
}