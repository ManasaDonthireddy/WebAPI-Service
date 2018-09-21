using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBench;
using NBench.Util;

namespace Capsule_TaskManager_NBench.Controllers
{
    public class TaskManagerController : Controller
    {/// <summary>
     /// Test to see if we can achieve max throughput on a <see cref="AtomicCounter"/>
     /// </summary>
        public class CounterPerfSpecs
        {
            private readonly Dictionary<int, int> dictionary = new Dictionary<int, int>();

            private const string AddCounterName = "AddCounter";
            private Counter addCounter;
            private int key;

            private const int AcceptableMinAddThroughput = 20000000;

            [PerfSetup]
            public void Setup(BenchmarkContext context)
            {
                addCounter = context.GetCounter(AddCounterName);
                key = 0;
            }


            [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
            [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
            public void GetTaskDetails(BenchmarkContext context)
            {
                for (var i = 0; i < AcceptableMinAddThroughput; i++)
                {
                    dictionary.Add(i, i);
                    addCounter.Increment();
                }
            }

            [PerfCleanup]
            public void Cleanup(BenchmarkContext context)
            {
                dictionary.Clear();
            }
        }
    }
}