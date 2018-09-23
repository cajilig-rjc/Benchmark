using Benchmark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BenchmarkIntegrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
         
        BenchmarkService Service = new BenchmarkService();
        List<BenchmarkTask> Task = new List<BenchmarkTask>
        {
           new BenchmarkTask {Taskname="Task1",Description="ForLoop",Action=Task1,Iterations=100,Quantity=500 },
           new BenchmarkTask {Taskname="Task2",Description="WhileLoop",Action=Task2,Iterations=100,Quantity=500 }
        };
            Service.CreateTask(Task);
            Console.WriteLine("Benchmark Starting");
            Service.StartBenchmark();
            Console.WriteLine("Benchmark Finished");
            Console.WriteLine("Benchmark Computing Result");
            Thread.Sleep(1000);
            Console.WriteLine("Benchmark Result \n");
       
                foreach(var item in Service.ComputedResult())
                {
                    Console.WriteLine("Taskname: "+item.Taskname);
                   Console.WriteLine("Description: " + item.Description);
                   Console.WriteLine("Iterations: " + item.Iterations);
                    Console.WriteLine("TotalExecution: " + item.TotalExecution);
                Console.WriteLine("TotalTimeElapsed: " + item.TotalElapsedTime+"ms");
                Console.WriteLine("AverageTimeElapsed: " + item.AverageElapsedTime+"ms\n");

            }
            Console.ReadLine();
           
       }
        public static void Task1()
        {
            for (int i = 0; i < 10000; i++)
            {

            }
        }
        public static void Task2()
        {
            int i = 10000;
            while (i != 0)
            {
                i--;
            }
        }
    }
}
