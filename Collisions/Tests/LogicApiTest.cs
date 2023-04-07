using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void _LogicApiTest()
        {
            AbstractLogicApi abstractLogicApi = AbstractLogicApi.Api();
            abstractLogicApi.StartUpdating(500, 300, 20);
            Assert.AreEqual(20, abstractLogicApi.GetBalls().Count);
            Assert.AreEqual(20, abstractLogicApi.GetBalls()[0].Radius);
        }
    }
}
