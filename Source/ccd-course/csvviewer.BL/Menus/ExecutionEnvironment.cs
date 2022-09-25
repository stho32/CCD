using csvviewer.Interfaces;

namespace csvviewer.BL.Menus;

public class ExecutionEnvironment
{
    public IInput Input { get; }
    public IOutput Output { get; }

    public ExecutionEnvironment(IInput input, IOutput output)
    {
        Input = input;
        Output = output;
    }
}