using csvviewer.Interfaces;

namespace csvviewer.Infrastructure
{
    public class TextOutput : IOutput
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}