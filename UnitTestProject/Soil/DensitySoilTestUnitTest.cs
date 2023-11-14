using ProjectCommon.Models.Material.Soil;

namespace UnitTestProject.Soil
{
    [TestClass]
    public class DensitySoilTestUnitTest
    {
        [TestMethod]
        [DataRow(20.0, 7.0, 2.0, 10)]
        [DataRow(22.0, 6.0, 3.0, 10)]
        [DataRow(18.0, 6.0, 2.0, 10)]
        [DataRow(25.0, 7.0, 3.0, 10)]
        public void TestCalculateMethodEquals(double soilMassWithRingAndPlate, double ringMass, double plateMass, double internalVolumeRing)
        {
            DensitySoilTest densitySoilTest = new DensitySoilTest();
            densitySoilTest.SoilMassWithRingAndPlate.DimensionValue = soilMassWithRingAndPlate;
            densitySoilTest.RingMass.DimensionValue = ringMass;
            densitySoilTest.PlateMass.DimensionValue = plateMass;
            densitySoilTest.InternalVolumeRing.DimensionValue = internalVolumeRing;

            densitySoilTest.Calculate();

            var expectedResult = (soilMassWithRingAndPlate - ringMass - plateMass) / internalVolumeRing;

            Assert.AreEqual(expectedResult, densitySoilTest.Density.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0, 2.0, 10)]
        [DataRow(10.0, 0.0, 2.0, 10)]
        [DataRow(10.0, 7.0, 0.0, 10)]
        [DataRow(10.0, 2.0, 3.0, 0)]
        [DataRow(-55.0, 7.0, 2.0, 10)]
        [DataRow(10.0, -64.0, 2.0, 10)]
        [DataRow(10.0, 7.0, -53.0, 10)]
        [DataRow(18.0, 7.0, 2.0, -10)]
        [DataRow(10.0, 7.0, 5.0, 10)]
        [DataRow(12.0, 3.0, 10.0, 10)]
        public void TestCalculateMethodException(double soilMassWithRingAndPlate, double ringMass, double plateMass, double internalVolumeRing)
        {
            DensitySoilTest densitySoilTest = new DensitySoilTest();
            densitySoilTest.SoilMassWithRingAndPlate.DimensionValue = soilMassWithRingAndPlate;
            densitySoilTest.RingMass.DimensionValue = ringMass;
            densitySoilTest.PlateMass.DimensionValue = plateMass;
            densitySoilTest.InternalVolumeRing.DimensionValue = internalVolumeRing;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { densitySoilTest.Calculate(); });
        }
    }
}
