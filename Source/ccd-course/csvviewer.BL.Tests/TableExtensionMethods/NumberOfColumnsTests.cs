using csvviewer.BL.Tables;
using NUnit.Framework;

namespace csvviewer.BL.Tests.TableExtensionMethods;

[TestFixture]
public class NumberOfColumnsTests
{
    [Test]
    public void NumberOfColumns_ermittelt_die_Anzahl_der_Spalten_in_einem_Table()
    {
        var tableRows = new List<TableRow>();
        tableRows.Add(new TableRow(new[] {"Hello", "World"}));
        var table = new Table(tableRows.ToArray());

        Assert.AreEqual(2, table.NumberOfColumns());
    }

    [Test]
    public void Wenn_ein_Table_keine_Zeilen_enthaelt_ist_die_Anzahl_der_Spalten_0()
    {
        var table = new Table(Array.Empty<TableRow>());
        Assert.AreEqual(0, table.NumberOfColumns());
    }
}

[TestFixture]
public class AddNumbersToRowsTests
{
    private Table GetTestTable()
    {
        var tableRows = new List<TableRow>();
        tableRows.Add(new TableRow(new[] { "Hello", "World" }));
        tableRows.Add(new TableRow(new[] { "Erster", "Datensatz" }));
        tableRows.Add(new TableRow(new[] { "Zweiter", "Datensatz" }));
        var table = new Table(tableRows.ToArray());
        return table;
    }

    [Test]
    public void Im_Header_wird_eine_neue_Spalte_am_Anfang_mit_Namen_No_hinzugefuegt()
    {
        var table = GetTestTable();

        var result = table.AddNumbersToRows();
        Assert.AreEqual("No.", result.Rows[0].Columns[0]);
    }

    [Test]
    public void Die_auf_den_Header_folgenden_Datensaetze_erhalten_jeweils_ihre_Position_als_Ausgangszahl()
    {
        var table = GetTestTable();

        var result = table.AddNumbersToRows();
        Assert.AreEqual("1", result.Rows[1].Columns[0]);
        Assert.AreEqual("2", result.Rows[2].Columns[0]);
    }

    [Test]
    public void Durch_den_Vorgang_wird_die_Quelltabelle_nicht_veraendert()
    {
        var table = GetTestTable();

        table.AddNumbersToRows();
        Assert.AreEqual("Hello", table.Rows[0].Columns[0]);
    }
}