public class PerformanceService : IPerformanceService
{
    public double GetPerformance((DateTime date, double value)[] dataset, DateTime fromDate, DateTime toDate)
    {
        if (dataset == null || dataset.Length == 0)
            throw new ArgumentException("Dataset is empty or null");

        var filteredData = dataset.Where(d => d.date >= fromDate && d.date <= toDate).OrderBy(d => d.date).ToArray();

        if (filteredData.Length < 2)
            throw new InvalidOperationException("Not enough data points in the specified range");

        double firstValue = filteredData.First().value;
        double lastValue = filteredData.Last().value;

        if (firstValue == 0)
            throw new InvalidOperationException("First value in the dataset is zero, cannot compute performance");

        return (lastValue / firstValue) - 1;
    }
}
