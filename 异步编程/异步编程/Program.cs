using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
namespace 异步编程
{
    class Program
    {
      
        static void Main(string[] args)
        {
            CallerWithAsync();
            CallerWithAsync2();
            MultipLeAsyncMethodsWithCombinators1();
            MultipLeAsyncMethodsWithCombinators2();


        }
        static string Greeting(string name)
        {
            Thread.Sleep(3000);
            return string.Format("Hello,{0}", name);
        }
        static Task<string>GreetingAsync(string name)
        {
            return Task.Run<string> ( () =>
             {
                 return Greeting(name);
             });
        }
        private async static void CallerWithAsync()
        {
            string result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
        }
        private async static void CallerWithAsync2()
        {
            Console.WriteLine(await GreetingAsync("Stephanie"));
        }
        private static void CallerWithContinuationTask()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);
            });
        }
        private async static void MultipleAsyncMethods()
        {
            string s1 = await GreetingAsync("Stephanie");
            string s2 = await GreetingAsync("Matthias");
            Console.WriteLine("Finished both methods.\n" +
                "Result 1:{0}\n Result 2:{1}", s1, s2);
        }
        private async static void MultipLeAsyncMethodsWithCombinators1()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            await Task.WhenAll(t1, t2);
            Console.WriteLine("Finish both methods.\n "+
                "Result 1:{0}\n Result 2:{1}",t1.Result, t2.Result);
        }
        private async static void MultipLeAsyncMethodsWithCombinators2()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            string[] result = await Task.WhenAll(t1, t2);
            Console.WriteLine("Finished both methods.\n" +
                "Result 1:{0}\n Result 2:{1}", result[0], result[1]);
        }
    }
}
