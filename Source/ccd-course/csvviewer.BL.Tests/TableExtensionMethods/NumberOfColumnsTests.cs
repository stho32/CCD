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