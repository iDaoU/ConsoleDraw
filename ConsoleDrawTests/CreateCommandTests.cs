using ConsoleDraw.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ConsoleDrawTests
{
    public class CreateCommandTests
    {
        [Test]
        public void Execute_CreatesCorrectSizeCanvas()
        {
            //Arrange
            var commandUnderTest = new CreateCommand();
            commandUnderTest.CommandValidation(new List<string>() { "20", "4" });
            
            //Act
            var canvas = commandUnderTest.ExecuteCommand();

            //Assert
            Assert.That(canvas.Width, Is.EqualTo(20));
            Assert.That(canvas.Height, Is.EqualTo(4));
        }

        [Test]
        public void CommandValidation_NullArgumentsOrEmpty_Throw()
        {
            //Arrange
            var commandUnderTest = new CreateCommand();

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => commandUnderTest.CommandValidation(new List<string>()));
        }
    }
}
