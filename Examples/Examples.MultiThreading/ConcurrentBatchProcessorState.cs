using System;
using System.Runtime.CompilerServices;

namespace Examples.MultiThreading
{
    public class ConcurrentBatchProcessorState
    {
        private readonly object _lock = new object();

        private readonly int _totalNumToProcess;
        private bool _stopSignaled = false;
        private readonly int _numPages;
        private int _currentPageSize;
        private TimeSpan _aggregateProcessingTime;

        /// <summary>
        /// This is a stateful class that is used to encapsulate the state of a batch process
        ///  that is currently being executed by the BatchProcessor
        /// </summary>
        /// <param name="initialPageSize">Initialize with an initial page size.  This is the page size the processor expcets to work with.</param>
        /// <param name="totalNumToProcess">Initialize with the actual count of items passed into the processor.</param>
        public ConcurrentBatchProcessorState(int initialPageSize, int totalNumToProcess)
        {
            _currentPageSize = initialPageSize;
            _totalNumToProcess = totalNumToProcess;
            _numPages = (int)Math.Ceiling(_totalNumToProcess / (decimal)initialPageSize);
            StartIndex = -1;
            CurrentPage = -1;
            _aggregateProcessingTime = new TimeSpan();
        }

        public void SignalStop()
        {
            _stopSignaled = true;
        }

        public int CurrentPage { get; private set; }

        public int StartIndex { get; private set; }

        public int CurrentPageSize
        {
            get
            {
                lock (_lock)
                {
                    if (IsOnLastPage)
                    {
                        _currentPageSize = _totalNumToProcess - StartIndex;
                    }
                    return _currentPageSize;
                }
            }
        }

        private CurrentPageBounds MoveToNextPage()
        {
            CurrentPage++;
            StartIndex = StartIndex < 0 ? 0 : StartIndex + CurrentPageSize;

            return new CurrentPageBounds
                {
                    StartIndex = this.StartIndex,
                    EndIndex = this.CurrentPageSize
                };
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
            get
            {
                return StartIndex + _currentPageSize > _totalNumToProcess;
            }
        }

        public bool ShouldContinueProcessing(out CurrentPageBounds currentBounds)
        {
            lock (_lock)
            {
                bool moreToDo = StartIndex < _totalNumToProcess && !_stopSignaled;
                currentBounds = moreToDo ? MoveToNextPage() : null;
                return moreToDo;
            }
        }

        public string PercentCompleted
        {
            get
            {
                decimal percentComplete = NumPages == 0 ? 1 : CurrentPage / (decimal)NumPages;
                return percentComplete.ToString("P");
            }
        }

        

        internal void AddToAggregateProcessingTime(TimeSpan timeToAdd)
        {
            lock (_lock)
            {
                _aggregateProcessingTime += timeToAdd;
            }
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

    public class CurrentPageBounds
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}