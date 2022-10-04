using csvviewer.BL.Displays;
using csvviewer.BL.Tables;
using NUnit.Framework;

namespace csvviewer.BL.Tests.TableExtensionMethods;

[TestFixture]
public class SortByTests
{
    private Table GetTestTable()
    {
        var rows = new List<TableRow>();
        rows.Add(new TableRow(new[] { "No.", "Name" }));
        rows.Add(new TableRow(new[] { "1", "C" }));
        rows.Add(new TableRow(new[] { "3", "A" }));
        rows.Add(new TableRow(new[] { "2", "B" }));
        return new Table(rows.ToArray());
    }

    [Test]
    public void SortAscendingInts()
    {
        var table = GetTestTable();

        table = table.SortBy(new OrderByDescription("No.", SortModeEnum.Int, SortDirectionEnum.Ascending));

        Assert.AreEqual("1", table.Rows[1].Columns[0]);
        Assert.AreEqual("2", table.Rows[2].Columns[0]);
        Assert.AreEqual("3", table.Rows[3].Columns[0]);
    }

    [Test]
    public void SortDescendingInts()
    {
        var table = GetTestTable();

        table = table.SortBy(new OrderByDescription("No.", SortModeEnum.Int, SortDirectionEnum.Descending));

        Assert.AreEqual("3", table.Rows[1].Columns[0]);
        Assert.AreEqual("2", table.Rows[2].Columns[0]);
        Assert.AreEqual("1", table.Rows[3].Columns[0]);
    }

    [Test]
    public void SortDescendingStrings()
    {
        var table = GetTestTable();

        table = table.SortBy(new OrderByDescription("Name", SortModeEnum.String, SortDirectionEnum.Descending));

        Assert.AreEqual("C", table.Rows[1].Columns[1]);
        Assert.AreEqual("B", table.Rows[2].Columns[1]);
        Assert.AreEqual("A", table.Rows[3].Columns[1]);
    }

    [Test]
    public void SortAscendingStrings()
    {
        var table = GetTestTable();

        table = table.SortBy(new OrderByDescription("Name", SortModeEnum.String, SortDirectionEnum.Ascending));

        Assert.AreEqual("A", table.Rows[1].Columns[1]);
        Assert.AreEqual("B", table.Rows[2].Columns[1]);
        Assert.AreEqual("C", table.Rows[3].Columns[1]);
    }
}