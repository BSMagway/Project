using ProjectCommon.Models.Material.SandAndGravel;

namespace UnitTestProject.SandAndGravel
{
    [TestClass]
    public class BulkDensitySandAndGravelTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0, 10)]
        [DataRow(66.0, 54.0, 10)]
        [DataRow(52.0, 44.0, 10)]
        [DataRow(57.0, 49.0, 10)]
        public void TestCalculateMethodEquals(double bulkDensityCylinderWithSandAndGravelMass, double bulkDensityCylinderMass, double cylinderVolume)
        {
            BulkDensitySandAndGravelTest bulkDensitySandAndGravelTest = new BulkDensitySandAndGravelTest();
            bulkDensitySandAndGravelTest.BulkDensityCylinderMass.DimensionValue = bulkDensityCylinderMass;
            bulkDensitySandAndGravelTest.BulkDensityCylinderWithSandAndGravelMass.DimensionValue = bulkDensityCylinderWithSandAndGravelMass;
            bulkDensitySandAndGravelTest.CylinderVolume.DimensionValue = cylinderVolume;

            bulkDensitySandAndGravelTest.Calculate();

            var expectedResult = (bulkDensityCylinderWithSandAndGravelMass - bulkDensityCylinderMass) / cylinderVolume;

            Assert.AreEqual(expectedResult, bulkDensitySandAndGravelTest.SandAndGravelBulkDensity.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0, 10)]
        [DataRow(10.0, 0.0, 10)]
        [DataRow(-55.0, 7.0, 0)]
        [DataRow(10.0, -64.0, 10)]
        [DataRow(10.0, 64.0, -10)]
        [DataRow(41.0, 47.0, 10)]
        public void TestCalculateMethodException(double bulkDensityCylinderWithSandAndGravelMass, double bulkDensityCylinderMass, double cylinderVolume)
        {
            BulkDensitySandAndGravelTest bulkDensitySandAndGravelTest = new BulkDensitySandAndGravelTest();
            bulkDensitySandAndGravelTest.BulkDensityCylinderMass.DimensionValue = bulkDensityCylinderMass;
            bulkDensitySandAndGravelTest.BulkDensityCylinderWithSandAndGravelMass.DimensionValue = bulkDensityCylinderWithSandAndGravelMass;
            bulkDensitySandAndGravelTest.CylinderVolume.DimensionValue = cylinderVolume;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { bulkDensitySandAndGravelTest.Calculate(); });
        }
    }
}
