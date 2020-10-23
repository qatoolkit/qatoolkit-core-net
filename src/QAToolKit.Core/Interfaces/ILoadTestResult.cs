namespace QAToolKit.Core.Interfaces
{
    public interface ILoadTestResult : IResult
    {
        public string Command { get; set; }
        public int Counter1xx { get; set; }
        public int Counter2xx { get; set; }
        public int Counter3xx { get; set; }
        public int Counter4xx { get; set; }
        public int Counter5xx { get; set; }
        public decimal AverageLatency { get; set; }
        public decimal AverageRequestsPerSecond { get; set; }
        public decimal MaxLatency { get; set; }
        public decimal MaxRequestsPerSecond { get; set; }
        public decimal StdevLatency { get; set; }
        public decimal StdevRequestsPerSecond { get; set; }
        public string ToString();
    }
}
