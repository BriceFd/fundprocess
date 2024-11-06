public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddScoped<IPerformanceService, PerformanceService>();
}
