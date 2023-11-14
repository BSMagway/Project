using ProjectCommon.Models.Material.Geotextile;

namespace UnitTestProject.Geotextile
{
    [TestClass]
    public class FiltrationPlaneGeotextileTestUnitTest
    {
        [TestMethod]
        [DataRow(15.0, 25.0, 5.0, 15.0)]
        [DataRow(14.0, 54.0, 6.0, 21.0)]
        [DataRow(18.0, 30.0, 5.0, 17.0)]
        [DataRow(19.0, 48.0, 7.0, 16.0)]
        public void TestCalculateMethodEquals(double waterVolume, double timeWaterFiltration, double thicknessPackage, double actualTemperature)
        {
            FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTest = new FiltrationPlaneGeotextileTest();
            filtrationPlaneGeotextileTest.WaterVolume.DimensionValue = waterVolume;
            filtrationPlaneGeotextileTest.TimeWaterFiltration.DimensionValue = timeWaterFiltration;
            filtrationPlaneGeotextileTest.ThicknessPackage.DimensionValue = thicknessPackage;
            filtrationPlaneGeotextileTest.ActualTemperature.DimensionValue = actualTemperature;

            filtrationPlaneGeotextileTest.Calculate();

            var expectedResult = (864 * waterVolume * 16.5) /
                                 (timeWaterFiltration * 10 * thicknessPackage * 10 *
                                 (0.7 + 0.03 * actualTemperature));

            Assert.AreEqual(expectedResult, filtrationPlaneGeotextileTest.GeotextileFiltration.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 37.0, 5.0, 15.0)]
        [DataRow(19.0, 0.0, 5.0, 15.0)]
        [DataRow(19.0, 37.0, 0.0, 15.0)]
        [DataRow(19.0, 37.0, 5.0, 0.0)]
        [DataRow(-19.0, 37.0, 5.0, 15.0)]
        [DataRow(19.0, -37.0, 5.0, 15.0)]
        [DataRow(19.0, 37.0, -5.0, 15.0)]
        [DataRow(19.0, 37.0, 5.0, -15.0)]
        public void TestCalculateMethodException(double waterVolume, double timeWaterFiltration, double thicknessPackage, double actualTemperature)
        {
            FiltrationPlaneGeotextileTest filtrationPlaneGeotextileTest = new FiltrationPlaneGeotextileTest();
            filtrationPlaneGeotextileTest.WaterVolume.DimensionValue = waterVolume;
            filtrationPlaneGeotextileTest.TimeWaterFiltration.DimensionValue = timeWaterFiltration;
            filtrationPlaneGeotextileTest.ThicknessPackage.DimensionValue = thicknessPackage;
            filtrationPlaneGeotextileTest.ActualTemperature.DimensionValue = actualTemperature;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { filtrationPlaneGeotextileTest.Calculate(); });
        }
    }
}
