namespace csv_viewer.Menus;

public class TextMenu
{
    private readonly List<MenuItem?> _menuItems = new();
    private bool _exitIsRequested = false;


    public void AddOption(string name, string hotkey, Action action)
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
        var input = Console.ReadKey().KeyChar.ToString().ToLower();
        Console.WriteLine();

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
        Console.WriteLine();
        Console.Write(string.Join(", ", menu));
    }

    public void Exit()
    {
        _exitIsRequested = true;
    }
}