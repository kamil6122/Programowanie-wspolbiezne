using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;

namespace Tests
{
    [TestClass]
    public class ModelBallTest
    {
        [TestMethod]
        public void GetterBall() 
        {
            Dane.Ball ball = new Dane.Ball(20);
            BallLogic logicBall = new BallLogic(ball);
            Model.Ball _ball = new Model.Ball(logicBall);

            Assert.AreEqual(_ball.X, ball.X);
            Assert.AreEqual(_ball.Y, ball.Y);
            Assert.AreEqual(_ball.Radius, ball.Radius);
        }
    }
}
