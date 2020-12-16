#nullable enable
using System;
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
        
        public TestController(ILogger<TestController> logger)
        {
            Logger = logger;
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
    }
    
}