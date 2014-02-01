using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Examples.MultiThreading
{
    /// <summary>
    /// A class containing some useful methods for batch processing of collections and/or simply calling a process iteratively.
    /// </summary>
    public static class BatchProcessor
    {
        /// <summary>
        /// Subdivides a list and performs the specified action on each part of the list.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="pageSize">The size of each subdivision.</param>
        /// <param name="allThingsToProcess">A list of everything you want to peform an action on.</param>
        /// <param name="processOnePage">The action to perform.</param>
        /// <param name="postProcess">An action to perform after a single page has completed.</param>
        public static BatchProcessorState ProcessInPages<T>(int pageSize, List<T> allThingsToProcess,
                                                            Action<List<T>> processOnePage,
                                                            Action<BatchProcessorState, TimeSpan> postProcess)
        {
            if (allThingsToProcess == null) throw new ArgumentNullException("allThingsToProcess");
            if (processOnePage == null) throw new ArgumentNullException("processOnePage");
            if (postProcess == null) throw new ArgumentNullException("postProcess");
            if (pageSize <= 0) throw new ArgumentException("pageSize must be greater than 0.", "pageSize");

            var processorState = new BatchProcessorState(pageSize, allThingsToProcess.Count);
            do
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                processOnePage(allThingsToProcess.GetRange(processorState.StartIndex, processorState.CurrentPageSize));
                processorState.MoveToNextPage();
                timer.Stop();
                processorState.AddToTotalProcessingTime(timer.Elapsed);

                postProcess(processorState, timer.Elapsed);

            } while (processorState.ShouldContinueProcessing);

            return processorState;
        }

        /// <summary>
        /// Subdivides a list and performs the specified action on each part of the list.
        /// This overload does not have provide state information.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="pageSize">The size of each subdivision.</param>
        /// <param name="allThingsToProcess">A list of everything you want to peform an action on.</param>
        /// <param name="pageProcessorAction">The action to perform.</param>
        public static BatchProcessorState ProcessInPages<T>(int pageSize, List<T> allThingsToProcess, Action<List<T>> pageProcessorAction)
        {
            if (allThingsToProcess == null) throw new ArgumentNullException("allThingsToProcess");
            if (pageProcessorAction == null) throw new ArgumentNullException("pageProcessorAction");
            if (pageSize <= 0) throw new ArgumentException("pageSize must be greater than 0.", "pageSize");

            var processorState = new BatchProcessorState(pageSize, allThingsToProcess.Count);
            do
            {
                pageProcessorAction(allThingsToProcess.GetRange(processorState.StartIndex, processorState.CurrentPageSize));
                processorState.MoveToNextPage();

            } while (processorState.ShouldContinueProcessing);

            return processorState;
        }

        /// <summary>
        /// Loops in pages given initial parameters. Provides a BatchProcessorState.
        /// </summary>
        /// <param name="pageSize">The size of each subdivision.</param>
        /// <param name="totalNumberOfThings">The count of all the items you currently want to deal with</param>
        /// <param name="processOnePage">The action to perform.</param>
        /// <param name="postProcess">An action to perform after a single page has completed.</param>
        public static BatchProcessorState ProcessInPages(int pageSize, int totalNumberOfThings,
                                                         Action<BatchProcessorState> processOnePage,
                                                         Action<BatchProcessorState, TimeSpan> postProcess)
        {
            if (processOnePage == null) throw new ArgumentNullException("processOnePage");
            if (postProcess == null) throw new ArgumentNullException("postProcess");
            if (totalNumberOfThings <= 0) throw new ArgumentException("totalNumberOfThings must be greater than 0.", "totalNumberOfThings");
            if (pageSize <= 0) throw new ArgumentException("pageSize must be greater than 0.", "pageSize");

            var processorState = new BatchProcessorState(pageSize, totalNumberOfThings);
            do
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                processOnePage(processorState);
                processorState.MoveToNextPage();
                timer.Stop();
                processorState.AddToTotalProcessingTime(timer.Elapsed);
                postProcess(processorState, timer.Elapsed);

            } while (processorState.ShouldContinueProcessing);
            return processorState;
        }
    }
}