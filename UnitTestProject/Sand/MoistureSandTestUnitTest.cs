using ProjectCommon.Models.Material.Sand;

namespace UnitTestProject.Sand
{
    [TestClass]
    public class MoistureSandTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0)]
        [DataRow(66.0, 54.0)]
        [DataRow(52.0, 44.0)]
        [DataRow(57.0, 49.0)]
        public void TestCalculateMethodEquals(double sandWetMass, double sandDryMass)
        {
            MoistureSandTest moistureSandTest = new MoistureSandTest();
            moistureSandTest.SandWetMass.DimensionValue = sandWetMass;
            moistureSandTest.SandDryMass.DimensionValue = sandDryMass;

            moistureSandTest.Calculate();

            var expectedResult = (sandWetMass - sandDryMass) / sandDryMass * 100.0;

            Assert.AreEqual(expectedResult, moistureSandTest.SandMoisture.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0)]
        [DataRow(10.0, 0.0)]
        [DataRow(-55.0, 7.0)]
        [DataRow(10.0, -64.0)]
        [DataRow(36.0, 47.0)]
        public void TestCalculateMethodException(double sandWetMass, double sandDryMass)
        {
            MoistureSandTest moistureSandTest = new MoistureSandTest();
            moistureSandTest.SandWetMass.DimensionValue = sandWetMass;
            moistureSandTest.SandDryMass.DimensionValue = sandDryMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { moistureSandTest.Calculate(); });
        }
    }
}
