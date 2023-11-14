using ProjectCommon.Models.Material.Soil;

namespace UnitTestProject.Soil
{
    [TestClass]
    public class RollingBoundarySoilTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0, 2.0)]
        [DataRow(66.0, 54.0, 8.0)]
        [DataRow(52.0, 44.0, 7.0)]
        [DataRow(57.0, 49.0, 12.0)]
        public void TestCalculateMethodEquals(double soilWetMass, double soilDryMass, double boxMass)
        {
            RollingBoundarySoilTest rollingBoundarySoilTest = new RollingBoundarySoilTest();
            rollingBoundarySoilTest.SoilWetMassWithBox.DimensionValue = soilWetMass;
            rollingBoundarySoilTest.SoilDryMassWithBox.DimensionValue = soilDryMass;
            rollingBoundarySoilTest.BoxMass.DimensionValue = boxMass;

            rollingBoundarySoilTest.Calculate();

            var expectedResult = (soilWetMass - soilDryMass) / (soilDryMass - boxMass) * 100.0;

            Assert.AreEqual(expectedResult, rollingBoundarySoilTest.RollingBoundary.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0, 2.0)]
        [DataRow(10.0, 0.0, 2.0)]
        [DataRow(10.0, 7.0, 0.0)]
        [DataRow(-55.0, 7.0, 2.0)]
        [DataRow(10.0, -64.0, 2.0)]
        [DataRow(10.0, 7.0, -53.0)]
        [DataRow(36.0, 47.0, -53.0)]
        [DataRow(36.0, 26.0, 27.0)]
        public void TestCalculateMethodException(double soilWetMass, double soilDryMass, double boxMass)
        {
            RollingBoundarySoilTest rollingBoundarySoilTest = new RollingBoundarySoilTest();
            rollingBoundarySoilTest.SoilWetMassWithBox.DimensionValue = soilWetMass;
            rollingBoundarySoilTest.SoilDryMassWithBox.DimensionValue = soilDryMass;
            rollingBoundarySoilTest.BoxMass.DimensionValue = boxMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { rollingBoundarySoilTest.Calculate(); });
        }
    }
}
