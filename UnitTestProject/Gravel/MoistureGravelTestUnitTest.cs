using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Sand;

namespace UnitTestProject.Gravel
{
    [TestClass]
    public class MoistureGravelTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0)]
        [DataRow(66.0, 54.0)]
        [DataRow(52.0, 44.0)]
        [DataRow(57.0, 49.0)]
        public void TestCalculateMethodEquals(double gravelWetMass, double gravelDryMass)
        {
            MoistureGravelTest moistureGravelTest = new MoistureGravelTest();
            moistureGravelTest.GravelWetMass.DimensionValue = gravelWetMass;
            moistureGravelTest.GravelDryMass.DimensionValue = gravelDryMass;

            moistureGravelTest.Calculate();

            var expectedResult = (gravelWetMass - gravelDryMass) / gravelDryMass * 100.0;

            Assert.AreEqual(expectedResult, moistureGravelTest.Moisture.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0)]
        [DataRow(10.0, 0.0)]
        [DataRow(-55.0, 7.0)]
        [DataRow(10.0, -64.0)]
        [DataRow(36.0, 47.0)]
        public void TestCalculateMethodException(double gravelWetMass, double gravelDryMass)
        {
            MoistureGravelTest moistureGravelTest = new MoistureGravelTest();
            moistureGravelTest.GravelWetMass.DimensionValue = gravelWetMass;
            moistureGravelTest.GravelDryMass.DimensionValue = gravelDryMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { moistureGravelTest.Calculate(); });
        }
    }
}
