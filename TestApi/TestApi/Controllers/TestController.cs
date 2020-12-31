#nullable enable
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestApi.models;

namespace TestApi.Controllers
{
    [ApiController]
    public class TestController
    {
        private readonly ILogger<TestController> Logger;
        private readonly IHttpClientFactory HttpClientFactory;
        
        public TestController(ILogger<TestController> logger, IHttpClientFactory httpClientFactory)
        {
            Logger = logger;
            HttpClientFactory = httpClientFactory;

        }
        
        [HttpGet]
        [Route("/Test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(499)]
        public ActionResult<TestResult> Result([FromQuery] string? msg)
        {
            if (msg is null)
            {
                return new StatusCodeResult(499);
            }
            return new TestResult() {CurrentTime = DateTimeOffset.Now, Message = msg};
        }

        
        [HttpGet]
        [Route("/Dependency")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DependencyResult>> DependencyTest([FromQuery] string? endpoint)
        {
            var dependencyReq = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var httpClient = HttpClientFactory.CreateClient();
            var response = await httpClient.SendAsync(dependencyReq);
            return new DependencyResult()
            {
                CurrentTime = DateTimeOffset.Now, Endpoint = endpoint,
                Message = $"{response.StatusCode} : {response.RequestMessage.ToString()}"
            };
        }
    }
    
}