using Xunit; // Assurez-vous d'inclure cette directive
using YourNamespace; // Remplacez par votre espace de noms où se trouve PerformanceController ou autres dépendances

public class ServicePerformanceTest
{
    [Fact] // Utilisez l'attribut Fact pour indiquer un test unitaire
    public void TestPerformanceCalculation()
    {
        // Arrange
        var request = new PerformanceRequest
        {
            Dataset = new (DateTime, double)[] { (new DateTime(2024, 11, 1), 100.0) },
            FromDate = new DateTime(2024, 11, 1),
            ToDate = new DateTime(2024, 11, 2)
        };
        
        var performanceService = new Mock<IPerformanceService>();
        performanceService.Setup(s => s.GetPerformance(It.IsAny<(DateTime date, double value)[]>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(100.0);

        var controller = new PerformanceController(performanceService.Object);

        // Act
        var result = controller.CalculatePerformance(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(100.0, okResult.Value);
    }
}
