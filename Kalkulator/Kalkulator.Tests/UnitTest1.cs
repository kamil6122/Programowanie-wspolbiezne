using System.Windows;

namespace Kalkulator.Tests
{

    public class UnitTest1
    {y
        [StaTheory]
        [InlineData(1, 1, 2)]
        [InlineData(270, 1, 271)]
        [InlineData(5, 6, 11)]
        public void AddTest(int x, int y, int expected)
        {
            Calculator calculator = new Calculator();
            int actual = calculator.add(x, y);
            Assert.Equal(actual, expected);
        }

        
        [StaTheory]
        [InlineData(1, 1, 0)]
        [InlineData(270, 1, 269)]
        [InlineData(5, 6, -1)]
        public void SubstructTest(int x, int y, int expected)
        {
            Calculator calculator = new Calculator();
            int actual = calculator.substruct(x, y);
            Assert.Equal(actual, expected);
        }

        [StaTheory]
        [InlineData(1, 1, 1)]
        [InlineData(270, 2, 540)]
        [InlineData(5, -6, -30)]
        public void MultiplicationTest(int x, int y, int expected)
        {
            Calculator calculator = new Calculator();
            int actual = calculator.multiplication(x, y);
            Assert.Equal(actual, expected);
        }

        [StaTheory]
        [InlineData(1, 1, 1)]
        [InlineData(270, 2, 135)]
        [InlineData(5, 6, 0)]
        public void DivideTest(int x, int y, int expected)
        {
            Calculator calculator = new Calculator();
            int actual = calculator.divide(x, y);
            Assert.Equal(actual, expected);
        }

        [StaFact]
        public void DivideByZeroTest()
        {
            Calculator calculator = new Calculator();
            try
            {
                calculator.divide(2, 0);

            } catch(DivideByZeroException ex)
            {
                Assert.Equal(0, calculator.divide(2, 0));
            }
        }
    }
}