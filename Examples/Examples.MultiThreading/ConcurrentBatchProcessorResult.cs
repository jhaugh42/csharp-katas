using System;

namespace Examples.MultiThreading
{
    public class ConcurrentBatchProcessorResult
    {
        public ConcurrentBatchProcessorState ConcurrentBatchProcessorState { get; set; }
        public TimeSpan TotalTime { get; set; }

        public override string ToString()
        {
            return ConcurrentBatchProcessorState + Environment.NewLine + "Total Time: " + TotalTime.ToString(@"hh\:mm\:ss\.fff");
        }
    }
}