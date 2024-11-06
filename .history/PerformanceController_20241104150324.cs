[ApiController]
[Route("api/[controller]")]
public class PerformanceController : ControllerBase
{
    private readonly IPerformanceService _performanceService;

    public PerformanceController(IPerformanceService performanceService)
    {
        _performanceService = performanceService;
    }

    [HttpPost("calculate")]
    public IActionResult CalculatePerformance([FromBody] PerformanceRequest request)
    {
        try
        {
            double performance = _performanceService.GetPerformance(request.Dataset, request.FromDate, request.ToDate);
            return Ok(performance);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

public class PerformanceRequest
{
    public (DateTime date, double value)[] Dataset { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}

using Microsoft.AspNetCore.Mvc;
using System;
