using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

namespace Tests
{
    [TestClass]
    public class BallTest
    {
        Ball ball = new Ball(20);

        [TestMethod]
        public void SetterGetterTest()
        {
            Assert.AreEqual(20, ball.Radius);

            ball.X = 5;
            ball.Y = 10;
            ball.Radius = 5;
            
            Assert.AreEqual(5, ball.Radius);
            Assert.AreEqual(5, ball.X);
            Assert.AreEqual(10, ball.Y);
        }
    }
}
