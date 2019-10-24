using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 异步编程Z
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallerWithAsync();
            //CallerWithAsync2();

            //MultipleAsyncMethods();

            //MultipLeAsyncMethodsWithCombinators1();
            //MultipLeAsyncMethodsWithCombinators2();

            //CallerWithContinuationTask();
            ConvertingAsyncPattern();
            Console.ReadLine();
        }
        static string Greeting(string name)
        {
            Console.WriteLine("running greeting in thread {0} and task {1}",
                Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            Thread.Sleep(3000);
            return string.Format("Hello,{0}", name);
        }
        Task<string> GreetingAsync(string name)
        {
            return Task.Run<string>(() =>
            {
                Console.WriteLine("running greetingasync in thread {0} and task {1}"
                , Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                return Greeting(name);
            });
        }
        private async void CallerWithAsync()
        {
            string result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
        }
        private async void CallerWithAsync2()
        {
            Console.WriteLine(await GreetingAsync("Stephanie"));
        }
        private void CallerWithContinuationTask()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);
            });
        }
        private async void MultipleAsyncMethods()
        {
            string s1 = await GreetingAsync("Stephanie");
            string s2 = await GreetingAsync("Matthias");
            Console.WriteLine("Finished both methods.\n" +
                "Result 1:{0}\n Result 2:{1}", s1, s2);
        }
        private async void MultipLeAsyncMethodsWithCombinators1()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            await Task.WhenAll(t1, t2);
            Console.WriteLine("Finish both methods.\n " +
                "Result 1:{0}\n Result 2:{1}", t1.Result, t2.Result);
        }
        private async void MultipLeAsyncMethodsWithCombinators2()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            string[] result = await Task.WhenAll(t1, t2);
            Console.WriteLine("Finished both methods.\n" +
                "Result 1:{0}\n Result 2:{1}", result[0], result[1]);
        }
        private static Func<string, string> greetingInvoker = Greeting;
        static IAsyncResult BeginGreeting(string name, AsyncCallback callback,
            object state)
        {
            return greetingInvoker.BeginInvoke(name, callback, state);
        }
        static string EndGreeting(IAsyncResult ar)
        {
            return greetingInvoker.EndInvoke(ar);
        }
        private async static void ConvertingAsyncPattern()
        {
            string s = await Task<string>.Factory.FromAsync<string>(
                BeginGreeting, EndGreeting, "Angela", null);
            Console.WriteLine(s);
        }
    }
}
