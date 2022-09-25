namespace csvviewer.Interfaces;

public interface IInput
{
    string GetNextKeyPressInLowercase();
    int GetIntBetween(string prompt, int minimumIncluding, int maximumIncluding);
    string GetElementFromSet(string prompt, string[] options);
}