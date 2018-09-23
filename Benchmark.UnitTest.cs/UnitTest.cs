using Benchmark;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.UnitTest.cs
{
    [TestFixture]
    public class UnitTest
    {
        public static void Task1()
        {
            for(int i = 0;i<10000; i++)
            {

            }
        }
        public static void Task2()
        {
            int i = 10000;
            while(i!=0)
            {
                i--;
            }
        }

        BenchmarkService Service = new BenchmarkService();
        List<BenchmarkTask> Task = new List<BenchmarkTask>
        {
           new BenchmarkTask {Taskname="Task1",Description="ForLoop",Action=Task1,Iterations=10,Quantity=200 },
           new BenchmarkTask {Taskname="Task1",Description="WhileLoop",Action=Task2,Iterations=10,Quantity=200 }
        };
        [Test]
        public void CreateTask()
        {
            Service.CreateTask(Task);
        }
        [Test]
        public void StartBenchmark()
        {
            Service.StartBenchmark();
        }
       
        [Test]
        public void ComputedResult()
        {
            foreach(var item in Service.ComputedResult())
            {
                //Get result
            }
        }

    }
}
