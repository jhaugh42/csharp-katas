using System;
using System.Collections.Generic;
using System.Threading;
using Examples.MultiThreading;

namespace Examples
{
    class Program
    {
        private const int size = 30000;
        private static List<int> _things = new List<int>(size);
        
        static void Main(string[] args)
        {
            ResetTestList();
            TestProcessor();
            ResetTestList();
            Console.WriteLine();
            TestConcurrentProcessor();

            Console.ReadLine();
        }

        private static void ConcurrentPostProcess(ConcurrentBatchProcessorState concurrentBatchProcessorState, TimeSpan timeSpan)
        {
           Thread.Sleep(10);
        }

        private static void PostProcess(BatchProcessorState batchProcessorState, TimeSpan timeSpan)
        {
            Thread.Sleep(10);
        }
        

        private static void ProcessOnePage(List<int> chunkOfThings)
        {
            for (int i = 0; i < chunkOfThings.Count; ++i)
            {
                int indexToManipulate = chunkOfThings[i];

                if (_things[indexToManipulate] == -1)
                    throw new Exception("Already been here");

                _things[indexToManipulate] = -1;
            }
            Thread.Sleep(10);
        }


        private static void ResetTestList()
        {
            _things = new List<int>();
            for (int i = 0; i < size; ++i)
            {
                _things.Add(i);
            }
        }

        private static void TestConcurrentProcessor()
        {
            var processor = new ConcurrentBatchProcessor();

            var concurrentResult = processor.ProcessInPages(13, _things, ProcessOnePage, ConcurrentPostProcess);

            for (int i = 0; i < size; ++i)
            {
                if (_things[i] != -1)
                {
                    Console.WriteLine("Somehow we did not visit everything.");
                }
            }
            Console.WriteLine("Concurrent Result: " + concurrentResult);
        }

        private static void TestProcessor()
        {
            var result = BatchProcessor.ProcessInPages(13, _things, ProcessOnePage, PostProcess);

            for (int i = 0; i < size; ++i)
            {
                if (_things[i] != -1)
                {
                    Console.WriteLine("Somehow we did not visit everything.");
                }
            }
            Console.WriteLine("NonConcurrent Result: " + result);
        }
    }
}
