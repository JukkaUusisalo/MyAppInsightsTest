using System;
using System.Net.Http;

namespace TestApi.models
{
    public class TestResult
    {
        public DateTimeOffset CurrentTime { get; set; }
        public string Message { get; set; } 
    }
}