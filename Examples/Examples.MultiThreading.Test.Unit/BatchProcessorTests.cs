using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Examples.MultiThreading.Test.Unit
{
    [TestClass]
    public class BatchProcessorTests
    {
        private readonly List<int> _processThis;
        private readonly int _pageSize;
        private readonly int _numPagesInBatch;

        public BatchProcessorTests()
        {
            _pageSize = 5;
            _processThis = new List<int>
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22
                };

            var numWholePages = _processThis.Count / _pageSize;
            var numPartialPages = _processThis.Count % _pageSize != 0 ? 1 : 0;
            _numPagesInBatch = numWholePages + numPartialPages;
        }


        [TestMethod]
        public void BatchProcessor_ProcessInPages_WithPostProcessMethod()
        {
            var endState = BatchProcessor.ProcessInPages(_pageSize, _processThis, ProcessOnePage, PostProcess);
            AssertionExtensions.ShouldBeEquivalentTo<int>(endState.CurrentPage, _numPagesInBatch);
        }

        [TestMethod]
        public void BatchProcessor_ProcessInPages_WithoutPostProcess()
        {
            var endState = BatchProcessor.ProcessInPages(_pageSize, _processThis, ProcessOnePage);
            AssertionExtensions.ShouldBeEquivalentTo<int>(endState.CurrentPage, _numPagesInBatch);
        }


        private void ProcessOnePage(List<int> singlePage)
        {

        }

        private void PostProcess(BatchProcessorState state, TimeSpan timeElapsed)
        {

        }

    }
}
