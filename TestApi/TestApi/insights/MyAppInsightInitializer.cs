using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace TestApi.insights
{
    public class MyAppInsightInitializer:ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            var request = telemetry as RequestTelemetry;
            if (request == null)
            {
                return;
            } 
            if (request.ResponseCode.Equals("499"))
            {
                request.Success = true;
            } 
        }
    }
    
    
}