using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

namespace Tests
{
    [TestClass]
    public class FieldTest
    {
        Field field = new Field(300, 200, 10);
        
        [TestMethod]
        public void GetterTest() 
        {
            Assert.AreEqual(300, field.Width);
            Assert.AreEqual(200, field.Height);
            Assert.AreEqual(10, field.Balls.Count);
        }

        [TestMethod]
        public void SetterTest() 
        {
            field.Width = 200;
            field.Height = 100;

            Assert.AreEqual(200, field.Width);
            Assert.AreEqual(100, field.Height);
        }

    }
}
