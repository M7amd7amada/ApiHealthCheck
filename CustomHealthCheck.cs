using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ApiHealthCheck;

public class CustomHealthCheck : IHealthCheck
{
    private readonly Random _random = new();

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var responseTime = _random.Next(1, 300);
        if (responseTime < 100)
        {
            return Task.FromResult(HealthCheckResult.Healthy("Healthy result from CustomHealthCheck"));
        }
        else if (responseTime < 200)
        {
            return Task.FromResult(HealthCheckResult.Degraded("Degraded result from CustomHealthCheck"));
        }

        return Task.FromResult(HealthCheckResult.Unhealthy("Unhealthy result from CustomHealthCheck"));
    }
}