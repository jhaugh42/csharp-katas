using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.MultiThreading
{
    public class ConcurrentBatchProcessor
    {
        private readonly List<Thread> _threads;
        private const int MaxThreads = 7;

        public ConcurrentBatchProcessor()
        {
            _threads = new List<Thread>(MaxThreads);


        }

        public ConcurrentBatchProcessorResult ProcessInPages<T>(int pageSize, List<T> allThingsToProcess,
                                                            Action<List<T>> processOnePage,
                                                            Action<ConcurrentBatchProcessorState, TimeSpan> postProcess)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var processorState = new ConcurrentBatchProcessorState(pageSize, allThingsToProcess.Count);

            for (int t = 0; t < MaxThreads; ++t)
            {
                Thread toAdd = new Thread(() => DoWork(processorState, allThingsToProcess, processOnePage, postProcess)) {Name = "I am thread " + t};
                _threads.Add(toAdd);
                _threads[t].Start();
            }

            for (int t = 0; t < MaxThreads; ++t)
            {
                _threads[t].Join();
            }
            timer.Stop();

            return new ConcurrentBatchProcessorResult
                {
                    ConcurrentBatchProcessorState = processorState,
                    TotalTime = timer.Elapsed
                };
        }

        private void DoWork<T>(ConcurrentBatchProcessorState processorState,
                                      List<T> allThingsToProcess,
                                      Action<List<T>> processOnePage,
                                      Action<ConcurrentBatchProcessorState, TimeSpan> postProcess)
        {
            CurrentPageBounds bounds;
            while (processorState.ShouldContinueProcessing(out bounds))
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                processOnePage(allThingsToProcess.GetRange(bounds.StartIndex, bounds.EndIndex));
                timer.Stop();
                processorState.AddToAggregateProcessingTime(timer.Elapsed);
                postProcess(processorState, timer.Elapsed);
            }
        }






    }




}
