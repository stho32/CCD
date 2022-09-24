using csvviewer.BL.Csv;
using csvviewer.BL.TabularData;
using NUnit.Framework;

namespace csvviewer.BL.Tests;

[TestFixture]
public class StringArrayExtensionMethodsTabularDataFileTests
{
    [Test]
    public void Wir_koennen_ein_paar_Zeilen_von_CSV_nach_TabularData_konvertieren()
    {
        var someContent = new[]
        {
            "Hello;world",
            "ItIsALotOf;Fun"
        };

        var result = someContent.ToTable(new CsvConverter());

        Assert.AreEqual(2, result.Rows.Length);
        Assert.AreEqual(2, result.NumberOfColumns());
        Assert.AreEqual("Hello", result.Rows[0].Columns[0]);
        Assert.AreEqual("world", result.Rows[0].Columns[1]);
        Assert.AreEqual("ItIsALotOf", result.Rows[1].Columns[0]);
        Assert.AreEqual("Fun", result.Rows[1].Columns[1]);
    }
}