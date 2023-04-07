using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestClass]
    public class ModelApiTest
    {
        [TestMethod]
        public void _ModelApiTest()
        {
            AbstractLogicApi logic = AbstractLogicApi.Api();
            AbstractModelApi model = AbstractModelApi.Api(logic);
            model.StartUpdating(20);
            ObservableCollection<Ball> balls = model.GetBalls();

            Assert.IsNotNull(balls);
            Assert.AreEqual(20, balls.Count);
            Assert.AreEqual(20, balls[0].Radius);
        }
    }
}
