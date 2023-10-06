using ProjectCommon.Models.Material.Soil;

namespace UnitTestProject
{
    [TestClass]
    public class MoistureSoilTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0, 2.0)]
        [DataRow(66.0, 54.0, 8.0)]
        [DataRow(52.0, 44.0, 7.0)]
        [DataRow(57.0, 49.0, 12.0)]
        public void TestCalculateMethodEquals(double soilWetMass, double soilDryMass, double boxMass)
        {
            MoistureSoilTest moistureSoilTest = new MoistureSoilTest();
            moistureSoilTest.SoilWetMassWithBox.DimensionValue = soilWetMass;
            moistureSoilTest.SoilDryMassWithBox.DimensionValue = soilDryMass;
            moistureSoilTest.BoxMass.DimensionValue = boxMass;

            moistureSoilTest.Calculate();

            var expectedResult = ((soilWetMass - soilDryMass) / (soilDryMass - boxMass)) * 100.0;

            Assert.AreEqual(expectedResult, moistureSoilTest.Moisture.DimensionValue);
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
            MoistureSoilTest moistureSoilTest = new MoistureSoilTest();
            moistureSoilTest.SoilWetMassWithBox.DimensionValue = soilWetMass;
            moistureSoilTest.SoilDryMassWithBox.DimensionValue = soilDryMass;
            moistureSoilTest.BoxMass.DimensionValue = boxMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { moistureSoilTest.Calculate(); });
        }
    }
}
