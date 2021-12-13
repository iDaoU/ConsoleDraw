using ConsoleDraw.Models;
using NUnit.Framework;
using System.Diagnostics;

namespace ConsoleDrawTests.Models
{
    public class Single2DArrayTests
    {
        private Single2DArray<char> _testSingle2DArray;
        private char[,] _test2Darray;
        private const int _rows = 10_000;
        private const int _columns = 10_000;

        [SetUp]
        public void Setup()
        {
            _testSingle2DArray = new Single2DArray<char>(_rows, _columns);
            _test2Darray = new char[_rows, _columns];
        }

        [Test]
        public void SequentialAccessTimeTest()
        {
            //Arrange
            var repetitions = 100;
            var watch = new Stopwatch();

            //Act
            watch.Start();
            for (int i = 0; i < repetitions; ++i)
            {
                for (int row = 0; row < _rows; ++row)
                {
                    for (int column = 0; column < _columns; ++column)
                    {
                        _testSingle2DArray.Get(row, column);
                    }
                }
            }
            watch.Stop();
            var single2DArrayTime = watch.ElapsedMilliseconds;

            watch.Restart();
            for (int i = 0; i < repetitions; ++i)
            {
                for (int row = 0; row < _rows; ++row)
                {
                    for (int column = 0; column < _columns; ++column)
                    {
                        var value = _test2Darray[row, column];
                    }
                }
            }
            watch.Stop();
            var normal2DArrayTime = watch.ElapsedMilliseconds;

            //Assert
            Assert.That(normal2DArrayTime, Is.LessThan(single2DArrayTime));
        }
    }
}