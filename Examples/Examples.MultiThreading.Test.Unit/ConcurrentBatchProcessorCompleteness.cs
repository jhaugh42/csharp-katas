using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples.MultiThreading.Test.Unit
{
    [TestClass]
    public class ConcurrentBatchProcessorCompleteness
    {
        private const int size = 20000;
        private static List<int> _things = new List<int>(size);
        private readonly int _pageSize;
        private readonly int _numPagesInBatch;


        public ConcurrentBatchProcessorCompleteness()
        {
            _pageSize = 5;
            _things = new List<int>();
            for (int i = 0; i < size; ++i)
            {
                _things.Add(i);
            }

            var numWholePages = _things.Count / _pageSize;
            var numPartialPages = _things.Count % _pageSize != 0 ? 1 : 0;
            _numPagesInBatch = numWholePages + numPartialPages;
        }

        [TestMethod]
        public void ConcurrentBatchProcessor_VisitsAllItemsOnlyOnce()
        {
            var processor = new ConcurrentBatchProcessor();
            var endState = processor.ProcessInPages(_pageSize, _things, ProcessOnePage, PostProcess);
            endState.ConcurrentBatchProcessorState.CurrentPage.ShouldBeEquivalentTo(_numPagesInBatch);


            _things.All(t => t == -1).Should().BeTrue();

        }



        private static void ProcessOnePage(List<int> chunkOfThings)
        {
            foreach (int indexToManipulate in chunkOfThings)
            {
                _things[indexToManipulate].Should().NotBe(-1);
                _things[indexToManipulate] = -1;
            }
            Thread.Sleep(1);
        }

        private static void PostProcess(ConcurrentBatchProcessorState concurrentBatchProcessorState, TimeSpan timeSpan)
        {
            Thread.Sleep(1);
        }


    }
}
