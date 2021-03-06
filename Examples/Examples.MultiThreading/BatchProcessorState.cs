﻿using System;

namespace Examples.MultiThreading
{
    public class BatchProcessorState
    {
        private readonly int _totalNumToProcess;
        private readonly int _numPages;
        private int _currentPageSize;
        private TimeSpan _aggregateProcessingTime;

        /// <summary>
        /// This is a stateful class that is used to encapsulate the state of a batch process
        ///  that is currently being executed by the BatchProcessor
        /// </summary>
        /// <param name="initialPageSize">Initialize with an initial page size.  This is the page size the processor expcets to work with.</param>
        /// <param name="totalNumToProcess">Initialize with the actual count of items passed into the processor.</param>
        public BatchProcessorState(int initialPageSize, int totalNumToProcess)
        {
            _currentPageSize = initialPageSize;
            _totalNumToProcess = totalNumToProcess;
            _numPages = (int)Math.Ceiling(_totalNumToProcess / (decimal)initialPageSize);
            StartIndex = 0;
            CurrentPage = 0;
            _aggregateProcessingTime = new TimeSpan();
        }

        public int CurrentPage { get; private set; }

        public int StartIndex { get; private set; }

        public int CurrentPageSize
        {
            get
            {
                if (IsOnLastPage)
                {
                    _currentPageSize = _totalNumToProcess - StartIndex;
                }
                return _currentPageSize;
            }
        }

        public int NumPages
        {
            get { return _numPages; }
        }

        public int TotalNumToProcess
        {
            get { return _totalNumToProcess; }
        }

        private bool IsOnLastPage
        {
            get { return StartIndex + _currentPageSize > _totalNumToProcess; }
        }

        public bool ShouldContinueProcessing
        {
            get { return StartIndex < _totalNumToProcess; }
        }

        public string PercentCompleted
        {
            get
            {
                decimal percentComplete = NumPages == 0 ? 1 : CurrentPage / (decimal)NumPages;
                return percentComplete.ToString("P");
            }
        }

        internal void MoveToNextPage()
        {
            CurrentPage++;
            StartIndex += CurrentPageSize;
        }

        internal void AddToTotalProcessingTime(TimeSpan timeToAdd)
        {
            _aggregateProcessingTime += timeToAdd;
        }

        public TimeSpan AggregateProcessingTime
        {
            get { return _aggregateProcessingTime; }
        }

        public override string ToString()
        {
            return string.Format("{0}NumPages: {1}" +
                                 "{0}AggregateProcessingTime: {2}" +
                                 "{0}CurrentPage: {3}" +
                                 "{0}IsOnLastPage: {4}" +
                                 "{0}StartIndex: {5}",
                                 Environment.NewLine,
                                 NumPages,
                                 AggregateProcessingTime.ToString(@"hh\:mm\:ss\.fff"),
                                 CurrentPage, IsOnLastPage, StartIndex);
        }
    }
}