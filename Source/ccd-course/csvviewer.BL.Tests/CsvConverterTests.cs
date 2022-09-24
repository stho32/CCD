using csvviewer.BL.Csv;
using NUnit.Framework;

namespace csvviewer.BL.Tests;

[TestFixture]
public class CsvConverterTests
{
    [Test]
    public void Semikolonseparierter_Text_wird_in_Spalten_gesplittet()
    {
        var csvConverter = new CsvConverter();
        var elements = csvConverter.Parse("Hello;world;this;is;content");
        Assert.AreEqual(5, elements.Length);
        Assert.AreEqual("Hello", elements[0]);
        Assert.AreEqual("world", elements[1]);
        Assert.AreEqual("this", elements[2]);
        Assert.AreEqual("is", elements[3]);
        Assert.AreEqual("content", elements[4]);
    }
}