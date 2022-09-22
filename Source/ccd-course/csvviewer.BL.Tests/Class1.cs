using csvviewer.BL.CommandLineArgs;
using NUnit.Framework;

namespace csvviewer.BL.Tests
{
    [TestFixture]
    public class CommandLineParserTests
    {
        [Test]
        public void Wenn_kein_Wert_angegeben_ist_ist_die_Liste_der_geparsten_Werte_am_Ende_leer()
        {
            var args = Array.Empty<string>();

            var parser = new CommandLineParser();

            Assert.AreEqual(0, parser.ParsedValues.Count);
        }
    }
}