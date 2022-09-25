namespace csvviewer.BL.Menus;

public class MenuItemCollection
{
    private readonly MenuItem[] _menuItems;

    public MenuItemCollection(MenuItem[] menuItems)
    {
        _menuItems = menuItems;
    }

    public override string ToString()
    {
        var names = _menuItems.Select(x => x.Name).ToArray();
        return string.Join(", ", names);
    }

    public MenuItem? GetMatchingMenuItemForInput(string input)
    {
        foreach (var menuItem in _menuItems)
        {
            if (menuItem.Hotkey.ToLower() == input.ToLower()) 
                return menuItem;
        }

        return null;
    }
}