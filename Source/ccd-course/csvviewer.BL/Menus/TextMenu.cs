using csvviewer.Interfaces;

namespace csvviewer.BL.Menus;

public class TextMenu
{
    private readonly IInput _input;
    private readonly IOutput _output;

    private readonly List<MenuItem?> _menuItems = new();
    private bool _exitIsRequested = false;

    public TextMenu(
        IInput input, 
        IOutput output
        )
    {
        _input = input;
        _output = output;
    }

    public void AddMenuItem(string name, string hotkey, Action action)
    {
        _menuItems.Add(new MenuItem(name, hotkey, action));
    }

    public void Execute()
    {
        while (!_exitIsRequested)
        {
            DisplayMenu();
            var userSelectedAction = GetUsersWish();
            if (userSelectedAction != null)
                userSelectedAction.Action();
        }
    }

    private MenuItem? GetUsersWish()
    {
        var input = _input.GetNextKeyPressInLowercase();

        foreach (var item in _menuItems)
        {
            if (item?.Hotkey.ToLower() == input)
                return item;
        }

        return null;
    }

    private void DisplayMenu()
    {
        var menu = _menuItems.Select(x => x?.Name).ToArray();
        _output.WriteLine("");
        _output.Write(string.Join(", ", menu));
    }

    public void Exit()
    {
        _exitIsRequested = true;
    }
}