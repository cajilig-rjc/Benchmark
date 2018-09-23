using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public struct BenchmarkResult
    {
        public string Taskname { get; set; }
        public string Description { get; set; }
        public int Iterations { get; set; }
        public int TotalExecution { get; set; }
        public double TotalElapsedTime { get; set; }
        public double AverageElapsedTime { get; set; }
    }
}
