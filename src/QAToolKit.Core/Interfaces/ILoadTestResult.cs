namespace QAToolKit.Core.Interfaces
{
    /// <summary>
    /// Load test result interface
    /// </summary>
    public interface ILoadTestResult : IResult
    {
        /// <summary>
        /// Load test command
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// Counter for 1xx HTTP status codes
        /// </summary>
        public int Counter1xx { get; set; }
        /// <summary>
        /// Counter for 2xx HTTP status codes
        /// </summary>
        public int Counter2xx { get; set; }
        /// <summary>
        /// Counter for 3xx HTTP status codes
        /// </summary>
        public int Counter3xx { get; set; }
        /// <summary>
        /// Counter for 4xx HTTP status codes
        /// </summary>
        public int Counter4xx { get; set; }
        /// <summary>
        /// Counter for 5xx HTTP status codes
        /// </summary>
        public int Counter5xx { get; set; }
        /// <summary>
        /// Average latency
        /// </summary>
        public decimal AverageLatency { get; set; }
        /// <summary>
        /// Average requests per second
        /// </summary>
        public decimal AverageRequestsPerSecond { get; set; }
        /// <summary>
        /// Maximum latency
        /// </summary>
        public decimal MaxLatency { get; set; }
        /// <summary>
        /// Maximum requests per second
        /// </summary>
        public decimal MaxRequestsPerSecond { get; set; }
        /// <summary>
        /// Standard deviation latency
        /// </summary>
        public decimal StdevLatency { get; set; }
        /// <summary>
        /// Standard deviation requests per second
        /// </summary>
        public decimal StdevRequestsPerSecond { get; set; }
        /// <summary>
        /// Set object to string
        /// </summary>
        /// <returns></returns>
        public string ToString();
    }
}
