public class PerformanceServiceTests
{
    private readonly IPerformanceService _service;

    public PerformanceServiceTests()
    {
        _service = new PerformanceService();
    }

    [Fact]
    public void GetPerformance_ValidDataset_ReturnsCorrectPerformance()
    {
        var dataset = new[]
        {
            (new DateTime(2023, 1, 1), 100.0),
            (new DateTime(2023, 6, 1), 150.0),
            (new DateTime(2023, 12, 31), 200.0)
        };

        double result = _service.GetPerformance(dataset, new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));

        Assert.Equal(1.0, result, precision: 2);
    }

    [Fact]
    public void GetPerformance_EmptyDataset_ThrowsArgumentException()
    {
        var dataset = Array.Empty<(DateTime, double)>();

        Assert.Throws<ArgumentException>(() => _service.GetPerformance(dataset, DateTime.Now, DateTime.Now));
    }

    
}
