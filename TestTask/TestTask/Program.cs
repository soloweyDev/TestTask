using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Tests();

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => test.Test1()));
            tasks.Add(Task.Run(() => test.Test2()));
            tasks.Add(Task.Run(() => test.Test3(args)));
            tasks.Add(Task.Run(() => test.Test4()));
            Task.WaitAll(tasks.ToArray());

            foreach (Task t in tasks)
                Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);

            Console.WriteLine("Tests end");
        }
    }
}
