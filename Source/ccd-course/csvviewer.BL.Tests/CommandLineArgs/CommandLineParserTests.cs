using System.Security.AccessControl;
using csvviewer.BL.CommandLineArgs;
using NUnit.Framework;

namespace csvviewer.BL.Tests.CommandLineArgs;

[TestFixture]
public class CommandLineParserTests
{
    private CommandLineParser GetParser(string defaultFilename, int defaultPageSize)
    {
        var defaultValues = new CommandLineOptions(defaultFilename, defaultPageSize);
        var parser = new CommandLineParser(defaultValues);
        return parser;
    }

    [Test]
    public void Wenn_keine_Args_uebergeben_werden_dann_werden_die_Defaultwerte_zurueckgegeben()
    {
        var parser = GetParser("defaultFilename", 123);

        Assert.True(parser.TryParse(new string[]{}, out var result));
        Assert.AreEqual("defaultFilename", result.Filename);
        Assert.AreEqual(123, result.PageSize);
    }

    [Test]
    public void Wenn_ein_Arg_angegeben_wird_dann_ersetzt_dies_den_Dateinamen()
    {
        var parser = GetParser("defaultFilename", 123);

        Assert.True(parser.TryParse(new[] { "anotherFilename" }, out var result));
        Assert.AreEqual("anotherFilename", result.Filename);
    }

    [Test]
    public void Wenn_zwei_Args_angegeben_werden_dann_ist_das_zweite_die_PageSize()
    {
        var parser = GetParser("defaultFilename", 123);

        Assert.True(parser.TryParse(new[] { "anotherFilename", "999" }, out var result));
        Assert.AreEqual(999, result.PageSize);
    }

    [Test]
    public void Wenn_im_zweiten_Arg_keine_gueltige_Zahl_angegeben_wird_dann_klappt_das_Parsen_nicht()
    {
        var parser = GetParser("defaultFilename", 123);
        Assert.False(parser.TryParse(new[] { "anotherFilename", "NotANumber" }, out _));
    }
}