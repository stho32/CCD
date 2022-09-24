using System.Text;
using csvviewer.Interfaces;

namespace csvviewer.BL.Tests.Mocks;

public class InMemoryTextOutput : IOutput
{
    private StringBuilder _result = new(); 

    public void WriteLine(string text)
    {
        _result.AppendLine(text);
    }

    public void Write(string text)
    {
        _result.Append(text);
    }

    public string GetResult()
    {
        return _result.ToString();
    }
}