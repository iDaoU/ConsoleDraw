using ConsoleDraw.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDrawTests
{
    public class IntegrationTests
    {
        [Test]
        public void DemoTestCase()
        {
            // Create the canvas
            var createCommand = new CreateCommand();
            createCommand.CommandValidation(new List<string>() { "20", "4"});
            var canvas = createCommand.ExecuteCommand();
            Assert.That(canvas.ToString(), Is.EqualTo(
                "--------------------\r\n" +
                "--------------------\r\n"));

        }
    }
}
