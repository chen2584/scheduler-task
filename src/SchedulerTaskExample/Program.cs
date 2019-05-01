using System;
using FluentScheduler;

namespace SchedulerTaskExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RunTask(5);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        static void RunTask(int seconds)
        {
            var registry = new Registry();
            registry.NonReentrantAsDefault(); // ให้ทุก Schedule ต้องจบ Task อันเก่าของตัวเองก่อน ถึงจะเริ่มนับเวลาใหม่
            registry.Schedule(() =>
            {
                Console.WriteLine("Executed Anonymous Task");
                // System.Threading.Thread.Sleep(5000);
                // Console.WriteLine("Finished Task");
            }).ToRunNow().AndEvery(seconds).Seconds();
            registry.Schedule<MyJob>().ToRunNow().AndEvery(seconds).Seconds();
            JobManager.Initialize(registry);
        }
    }
}
