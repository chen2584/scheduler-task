using System;
using FluentScheduler;

namespace SchedulerTaskExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RunTask(2);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        static void RunTask(int seconds)
        {
            var registry = new Registry();
            registry.Schedule(() =>
            {
                Console.WriteLine("Executed Anonymous Task");
            }).ToRunNow().AndEvery(seconds).Seconds();
            registry.Schedule<MyJob>().ToRunNow().AndEvery(seconds).Seconds();
            JobManager.Initialize(registry);
        }
    }
}
