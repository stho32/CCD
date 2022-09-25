using csvviewer.BL.Menus;
using csvviewer.BL.Tests.Mocks;
using NUnit.Framework;

namespace csvviewer.BL.Tests;

[TestFixture]
public class NavigationMenuTests
{
    private void GetTestSetup(
        out NavigationMenu navigationMenu, 
        out AutomatableInput input,
        out InMemoryTextOutput output)
    {
        input = new AutomatableInput();
        output = new InMemoryTextOutput();
        var environment = new ExecutionEnvironment(input, output);

        navigationMenu = new NavigationMenu(2, environment);
    }

    [Test]
    public void Wenn_das_Menu_gestartet_und_sofort_verlassen_wird_erhalten_wir_nur_einmal_die_Ausgabe_des_Menues()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("e");
        navigationMenu.Run();

        var result = output.GetResult();
        Assert.AreEqual("F)irst page, P)revious page, N)ext page, L)ast page, E)xit", result);
    }

    [Test]
    public void Bei_einfachem_Menustart_ist_die_aktuelle_Seite_immer_1()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("e");
        navigationMenu.Run();

        Assert.AreEqual(1, navigationMenu.CurrentPage);
    }

    [Test]
    public void Wenn_die_naechste_Seite_aufgeblaettert_wird_dann_ist_das_die_2()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("n");
        input.SendKeys("e");
        navigationMenu.Run();

        Assert.AreEqual(2, navigationMenu.CurrentPage);
    }

    [Test]
    public void Wenn_wir_2_mal_die_naechste_Seite_aufrufen_bleibt_die_aktuelle_Seite_2()
    {
        // ... weil wir nur 2 Seiten in unserer Teststellung haben.
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("n");
        input.SendKeys("n");
        input.SendKeys("e");
        navigationMenu.Run();

        Assert.AreEqual(2, navigationMenu.CurrentPage);
    }

    [Test]
    public void Wenn_wir_Next_und_dann_Previous_Page_aufrufen_sind_wir_wieder_bei_der_1()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("n");
        input.SendKeys("p");
        input.SendKeys("e");
        navigationMenu.Run();

        Assert.AreEqual(1, navigationMenu.CurrentPage);
    }
    
    [Test]
    public void Wenn_wir_aus_Seite_1_PreviousPage_aufrufen_bleiben_wir_bei_Seite_1()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("p");
        input.SendKeys("e");
        navigationMenu.Run();

        Assert.AreEqual(1, navigationMenu.CurrentPage);
    }

    [Test]
    public void LastPage_springt_direkt_zu_Seite_2()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("l");
        input.SendKeys("e");
        navigationMenu.Run();

        Assert.AreEqual(2, navigationMenu.CurrentPage);
    }

    [Test]
    public void Wenn_wir_zur_letzten_Seite_gehen_und_dann_FirstPage_aufrufen_sind_wir_wieder_auf_Seite_1()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("l");
        input.SendKeys("f");
        input.SendKeys("e");
        navigationMenu.Run();

        Assert.AreEqual(1, navigationMenu.CurrentPage);
    }

    [Test]
    public void In_der_Kontextfunktion_koennen_wir_auf_den_Status_des_Navigationsmenues_zugreifen()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);
        var currentPage = -1;

        input.SendKeys("e");
        navigationMenu.Run(navigation => currentPage = navigation.CurrentPage);

        Assert.AreEqual(1, currentPage);
    }

    [Test]
    public void Quatsch_im_Input_wird_toleriert_und_aendert_nichts()
    {
        GetTestSetup(out NavigationMenu navigationMenu, out AutomatableInput input, out InMemoryTextOutput output);

        input.SendKeys("quatsch");
        input.SendKeys("e");
        navigationMenu.Run();

        Assert.AreEqual(1, navigationMenu.CurrentPage);
    }
}