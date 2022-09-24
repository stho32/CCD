using csvviewer.BL.Menus;
using csvviewer.Interfaces;

namespace csvviewer.BL.Displays;

public static class TableDisplayExtension
{
    public static TextMenu CreateNavigationMenu(this TableDisplay tableDisplay, IInput input, IOutput output)
    {
        var page = 0;
        var menu = new TextMenu(input, output);

        tableDisplay.Display(page);

        menu.AddMenuItem("F)irst page", "f", () =>
        {
            page = 0;

            tableDisplay.Display(page);
        });

        menu.AddMenuItem("P)revious page", "p", () =>
        {
            if (page > 0)
                page -= 1;

            tableDisplay.Display(page);
        });

        menu.AddMenuItem("N)ext page", "n", () =>
        {
            if (page < tableDisplay.PageCount)
                page += 1;

            tableDisplay.Display(page);
        });

        menu.AddMenuItem("L)ast page", "l", () =>
        {
            page = tableDisplay.PageCount;

            tableDisplay.Display(page);
        });

        menu.AddMenuItem("E)xit", "e", () =>
        {
            menu.Exit();
        });

        return menu;
    }
}