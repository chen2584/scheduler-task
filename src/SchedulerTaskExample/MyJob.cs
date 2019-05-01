using System;
using FluentScheduler;

namespace SchedulerTaskExample
{
    public class MyJob : IJob
    {
        public void Execute()
        {
            Console.WriteLine("Executed MyJob Task");
        }

    }
}