using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Benchmark
{
    public class BenchmarkService
    {
        #region Global Variables
        List<BenchmarkTask> Task = new List<BenchmarkTask>();
        List<BenchmarkResultSet> ResultSet = new List<BenchmarkResultSet>();
        List<BenchmarkResult> Result = new List<BenchmarkResult>();
        #endregion
        #region Methods
        public void CreateTask(List<BenchmarkTask>task)
        {
            foreach (var item in task)
            {
                Task.Add(new BenchmarkTask
                {
                    Taskname = item.Taskname,
                    Description = item.Description,
                    Action = item.Action,
                    Iterations = item.Iterations,
                    Quantity = item.Quantity
                });
            }
        }
        public void StartBenchmark()
        {
            foreach(var item in Task)
            {
                for(int ex = 0;ex<item.Quantity;ex++)
                {

                            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
                            Thread.CurrentThread.Priority = ThreadPriority.Highest;
                            item.Action();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            GC.Collect();
                            item.Watch.Start();
                            for (int i = 0; i < item.Iterations; i++)
                            {
                                item.Action();
                            }
                            item.Watch.Stop();

                            ResultSet.Add(new BenchmarkResultSet
                            {
                                Taskname = item.Taskname,
                                Description = item.Description,
                                Iterations = item.Iterations,
                                ElapsedTime = item.Watch.ElapsedMilliseconds
                            });
                            item.Watch.Reset();                       
                  
                }
            }
        }
      
       
        public List<BenchmarkResult>ComputedResult()
        {
           
            var result = ResultSet.GroupBy(_ => new { _.Taskname })
                       .Select(g => new BenchmarkResult
                       {
                           Taskname = g.First().Taskname,
                           Description = g.First().Description,
                           Iterations = g.First().Iterations,
                           TotalElapsedTime = g.Sum(_ => _.ElapsedTime),
                           TotalExecution = g.Count(),
                           AverageElapsedTime = g.Average(_ => _.ElapsedTime)
                       }).ToList();

            foreach (var item in result)
            {
                Result.Add(new BenchmarkResult
                {
                    Taskname = item.Taskname,
                    Description = item.Description,
                    Iterations = item.Iterations,
                    TotalExecution = item.TotalExecution,
                    TotalElapsedTime = item.TotalElapsedTime,
                    AverageElapsedTime = item.AverageElapsedTime
                });

            }
            return Result;
        }
        #endregion
    }
}
