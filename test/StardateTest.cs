namespace Stardate.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StardateTest
    {
        [DataTestMethod]
        [DataRow("[-36]9355", StardateTimeline.Main, 86400)]
        public void TestTest(string stardate, StardateTimeline timeline, long ticks)
        {
            DateTime expectation = new DateTime(ticks: ticks);
            Assert.AreEqual(expectation, Stardate.stardateToInternal(stardate, timeline));
        }
    }
}
