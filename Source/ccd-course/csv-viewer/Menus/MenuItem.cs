namespace csv_viewer.Menus;

public class MenuItem
{
    public string Name { get; }
    public string Hotkey { get; }
    public Action Action { get; }

    public MenuItem(string name, string hotkey, Action action)
    {
        Name = name;
        Hotkey = hotkey;
        Action = action;
    }
}