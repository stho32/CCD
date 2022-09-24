using csvviewer.BL.TabularData;
using NUnit.Framework;

namespace csvviewer.BL.Tests.TabularData;

[TestFixture]
public class TableExtensionsTests
{
    [Test]
    public void NumberOfColumns_ermittelt_die_Anzahl_der_Spalten_in_einem_Table()
    {
        var tableRows = new List<TableRow>();
        tableRows.Add(new TableRow(new[] {"Hello", "World"}));
        var table = new Table(tableRows.ToArray());

        Assert.AreEqual(2, table.NumberOfColumns());
    }
}