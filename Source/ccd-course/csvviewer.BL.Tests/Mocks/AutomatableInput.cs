using csvviewer.Interfaces;

namespace csvviewer.BL.Tests.Mocks;

public class AutomatableInput : IInput
{
    private Queue<string> _inputQueue = new Queue<string>();

    public void SendKeys(string sequence)
    {
        _inputQueue.Enqueue(sequence);
    }

    public string GetNextKeyPressInLowercase()
    {
        return _inputQueue.Dequeue().ToLower();
    }
}