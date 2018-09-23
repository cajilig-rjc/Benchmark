using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmark
{
    public class BenchmarkTask
    {
        public string Taskname { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public int Iterations { get; set; }
        public int Quantity { get; set; }
        public Stopwatch Watch = new Stopwatch();
    }
}
