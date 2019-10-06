using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace 并行Linq
{
    class Program
    {


        static IEnumerable<int> SampleData()
        {
            const int arraySize = 100000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
        }
        static void Main(string[] args)
        {
            var res = (from x in data.AsParallel()
                       where Math.Log(x) < 4
                       select x).avergae();
            var res2 = data.AsParallel().where(x => Math.Log(x) < 4).
                select(x => x).Average();



            //分区器
            var result = (from x in Partitioner.Create(data, true).AsParallel()
                          where Math.Log(x) < 4
                          select x).Average();

            //取消
            var cts = new CancellationTokenSource();
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var res3 = (from x in data.AsParallel().WithCancellation(cts.Token)
                                where Math.Log(x) < 4
                                select x).Average();
                    Console.WriteLine("query finished,sum:{0}", res3);
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
            Console.WriteLine("query started");
            Console.WriteLine("cancel?");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                cts.Cancel();
            }
        }
    }
}
