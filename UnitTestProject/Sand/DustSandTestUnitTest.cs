using ProjectCommon.Models.Material.Sand;

namespace UnitTestProject.Sand
{
    [TestClass]
    public class DustSandTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0)]
        [DataRow(66.0, 54.0)]
        [DataRow(52.0, 44.0)]
        [DataRow(57.0, 49.0)]
        public void TestCalculateMethodEquals(double sandMass, double sandWithoutDustMass)
        {
            DustSandTest dustSandTest = new DustSandTest();
            dustSandTest.SandMass.DimensionValue = sandMass;
            dustSandTest.SandWithoutDustMass.DimensionValue = sandWithoutDustMass;

            dustSandTest.Calculate();

            var expectedResult = (sandMass - sandWithoutDustMass) / sandMass * 100.0;

            Assert.AreEqual(expectedResult, dustSandTest.SandDust.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0)]
        [DataRow(10.0, 0.0)]
        [DataRow(-55.0, 7.0)]
        [DataRow(10.0, -64.0)]
        [DataRow(36.0, 47.0)]
        public void TestCalculateMethodException(double sandMass, double sandWithoutDustMass)
        {
            DustSandTest dustSandTest = new DustSandTest();
            dustSandTest.SandMass.DimensionValue = sandMass;
            dustSandTest.SandWithoutDustMass.DimensionValue = sandWithoutDustMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { dustSandTest.Calculate(); });
        }
    }
}
