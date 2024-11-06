public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Configuration des services
        services.AddControllers();
        services.AddScoped<IPerformanceService, PerformanceService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
