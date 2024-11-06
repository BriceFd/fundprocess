public interface IPerformanceService
{
    double GetPerformance((DateTime date, double value)[] dataset, DateTime fromDate, DateTime toDate);
}
