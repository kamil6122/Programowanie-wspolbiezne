using Kalkulator;
using System.Windows;

namespace KalkulatorTests
{
    [Apartment(ApartmentState.STA)]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        { 
            Calculator calculator = new Calculator();
            int x = 5;
            int y = 5;
            int expected = 10;
            int actual = calculator.add(x, y);
            Assert.AreEqual(actual, expected);

        }

    }
}