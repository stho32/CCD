namespace csvviewer.BL.Menus;

public class NavigationMenu
{
    private readonly int _maximumPageNumber;
    public int CurrentPage { get; private set; } = 1;
    public bool ExitRequested { get; private set; } = false;

    private readonly ExecutionEnvironment _environment;
    private readonly MenuItemCollection _menuItems;

    public NavigationMenu(int maximumPageNumber, ExecutionEnvironment environment)
    {
        _maximumPageNumber = maximumPageNumber;
        _environment = environment;

        var menuItems = new List<MenuItem>();
        menuItems.Add(new MenuItem("F)irst page", "f", FirstPage));
        menuItems.Add(new MenuItem("P)revious page", "p", PreviousPage));
        menuItems.Add(new MenuItem("N)ext page", "n", NextPage));
        menuItems.Add(new MenuItem("L)ast page", "l", LastPage));
        menuItems.Add(new MenuItem("J)ump to page", "j", JumpToPage));
        menuItems.Add(new MenuItem("E)xit", "e", Exit));

        _menuItems = new MenuItemCollection(menuItems.ToArray());
    }

    private void JumpToPage()
    {
        var pageNumber = _environment.Input.GetIntBetween($"Please enter the page number you wish to jump to (1..{_maximumPageNumber}): ", 1, _maximumPageNumber);
        CurrentPage = pageNumber;
    }

    public void Exit()
    {
        ExitRequested = true;
    }

    public void LastPage()
    {
        CurrentPage = _maximumPageNumber;
    }

    public void NextPage()
    {
        if (CurrentPage < _maximumPageNumber)
            CurrentPage += 1;
    }

    public void PreviousPage()
    {
        if (CurrentPage > 1)
            CurrentPage -= 1;
    }

    public void FirstPage()
    {
        CurrentPage = 1;
    }

    public void Run(Action<NavigationMenu>? contextAction = null)
    {
        while (!ExitRequested)
        {
            if (contextAction != null)
                contextAction(this);

            Display();
            GetAndPerformNextMenuAction();
        }
    }

    private void GetAndPerformNextMenuAction()
    {
        var input = _environment.Input.GetNextKeyPressInLowercase();
        var selectedMenuItem = _menuItems.GetMatchingMenuItemForInput(input);

        if (selectedMenuItem != null)
            selectedMenuItem.Action();
    }

    private void Display()
    {
        _environment.Output.Write(_menuItems.ToString());
    }
}