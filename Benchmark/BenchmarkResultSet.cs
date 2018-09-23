using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public struct BenchmarkResultSet
    {
        public string Taskname { get; set; }
        public string Description { get; set; }
        public int Iterations { get; set; }
        public double ElapsedTime { get; set; }
       
    }
}
