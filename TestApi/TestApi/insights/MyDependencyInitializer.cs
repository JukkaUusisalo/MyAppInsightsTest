using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace TestApi.insights
{
    public class MyDependencyInitializer:ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (!(telemetry is DependencyTelemetry dependencyTelemetry)) return;
            dependencyTelemetry.Name = $"{dependencyTelemetry.Name}.processed";
            dependencyTelemetry.Data = $"Processed data: {dependencyTelemetry.Data}";
        }
    }
}