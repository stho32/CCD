using csvviewer.BL.Displays;
using csvviewer.BL.Menus;
using csvviewer.BL.Tables;
using csvviewer.BL.Tests.Mocks;
using NUnit.Framework;

namespace csvviewer.BL.Tests;

[TestFixture]
public class TableDisplayTests
{
    private Table GetTestTable()
    {
        var tableRows = new List<TableRow>();
        tableRows.Add(new TableRow(new[] { "Hello", "World" }));
        tableRows.Add(new TableRow(new[] { "1", "Eins" }));
        tableRows.Add(new TableRow(new[] { "2", "Zwei" }));
        tableRows.Add(new TableRow(new[] { "3", "Drei" }));
        tableRows.Add(new TableRow(new[] { "4", "Vier" }));
        tableRows.Add(new TableRow(new[] { "5", "Fünf" }));

        return new Table(tableRows.ToArray());
    }

    private void TabellenanzeigeTestSetup(
        out TableDisplay display, 
        out InMemoryTextOutput output, 
        int pageSize,
        Table? testdaten = null)
    {
        if (testdaten == null)
            testdaten = GetTestTable();

        output = new InMemoryTextOutput();
        display = new TableDisplay(testdaten, pageSize, new ExecutionEnvironment(null, output, null));
    }

    [Test]
    public void Anzeige_der_ersten_Seite_bei_3_Zeilen_pro_Seite()
    {
        TabellenanzeigeTestSetup(out var display, out var output, 3);

        display.Display(1);

        string[] result = output.GetResult().Trim().Split(Environment.NewLine);

        Assert.AreEqual(5, result.Length);
        Assert.AreEqual("Hello|World|", result[0]);
        Assert.AreEqual("-----+-----+", result[1]);
        Assert.AreEqual("1    |Eins |", result[2]);
        Assert.AreEqual("2    |Zwei |", result[3]);
        Assert.AreEqual("3    |Drei |", result[4]);
    }

    [Test]
    public void Bei_3_Zeilen_pro_Seite_ist_die_maximale_Seitenanzahl_2()
    {
        TabellenanzeigeTestSetup(out var display, out _, 3);

        Assert.AreEqual(2, display.PageCount);
    }

    [Test]
    public void Anzeige_der_zweiten_Seite_bei_3_Zeilen_pro_Seite()
    {
        TabellenanzeigeTestSetup(out var display, out var output, 3);

        display.Display(2);

        string[] result = output.GetResult().Trim().Split(Environment.NewLine);

        Assert.AreEqual(4, result.Length);
        Assert.AreEqual("Hello|World|", result[0]);
        Assert.AreEqual("-----+-----+", result[1]);
        Assert.AreEqual("4    |Vier |", result[2]);
        Assert.AreEqual("5    |Fünf |", result[3]);
    }

    [TestCase("Kurz", "1   ")]
    [TestCase("Wow ist das lang", "1               ")]
    public void Die_Spaltenbreiten_passen_sich_an_den_Inhalt_der_Spalte_an(string header, string erwarteterInhaltDerSichAufBreiteAngepasstHat)
    {
        var table = new Table(new[]
        {
            new TableRow(new[] { header }),
            new TableRow(new[] { "1" })
        });

        TabellenanzeigeTestSetup(out var display, out var output, 3, table);

        display.Display(1);

        string[] result = output.GetResult().Trim().Split(Environment.NewLine);

        Assert.AreEqual(erwarteterInhaltDerSichAufBreiteAngepasstHat + "|", result[2]);
    }

}