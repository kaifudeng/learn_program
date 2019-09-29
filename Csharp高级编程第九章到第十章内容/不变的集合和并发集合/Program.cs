using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Drawing;
namespace 不变的集合和并发集合
{
    class Account
    {
        public string name { get; set; }
        public decimal Amount { get; set; }
    }
    public class Info
    {
        public string Word { get; set; }
        public int Count { get; set; }

        public string Color { get; set; }
    }
    public class ConsoleHelper//向控制台写入信息，可以改变控制台颜色
    {
        private static object syncOutput = new object();
        public static void WriteLine(string message)
        {
            lock (syncOutput)
            {
                Console.WriteLine(message);
            }
        }
        public static void WriteLine(string message,string color)
        {
            lock (syncOutput)
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        
    }
    public class PipelineStages
    {
       
        //第一阶段
        public static Task ReadFilenamesAsync(string path, BlockingCollection<string> output)
        {
            return Task.Run(() =>
           {
               foreach (string filename in Directory.EnumerateFiles(path, ".cs", SearchOption.AllDirectories))
               {
                   output.Add(filename);
                   ConsoleHelper.WriteLine(string.Format("stage 1: added {0}", filename));
               }
               output.CompleteAdding();
           });
        }
        //第二阶段
        public static async Task LoadContentAsync(BlockingCollection<string> input,BlockingCollection<string> output)
        {
            foreach(var filename in input.GetConsumingEnumerable())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    var reader = new StreamReader(stream);
                    string line = null;
                    while ((line=await reader.ReadLineAsync())!=null)
                    {
                        output.Add(line);
                        ConsoleHelper.WriteLine(string.Format("stage 2:added {0}", line));
                    }
                }
            }
            output.CompleteAdding();
        }
        //第三阶段
        public static Task ProcessContentAsync(BlockingCollection<string> input,ConcurrentDictionary<string,int> output)
        {
            return Task.Run(() =>
            {
                foreach (var line in input.GetConsumingEnumerable())
                {
                    string[] words = line.Split(' ', ';', '\t', '{', '}', '(', ')', ':', ',', '"');
                    foreach (var word in words.Where(w => !string.IsNullOrEmpty(w)))
                    {
                        output.AddOrIncrementValue(word);
                        ConsoleHelper.WriteLine(string.Format("stage 3:added{0}", word));
                    }
                }
            }
            );
        }
        //
        public static Task TransferContentAsync(ConcurrentDictionary<string, int> input, BlockingCollection<Info> output)
        {
            return Task.Run(() =>
            {
                foreach (var word in input.Keys)
                {
                    int value;
                    if (input.TryGetValue(word, out value))
                    {
                        var info = new Info { Word = word, Count = value };
                        output.Add(info);
                        ConsoleHelper.WriteLine(string.Format("stage 4: added {0}", info));
                    }
                }
                output.CompleteAdding();
            }
                );
        }
        public static Task AddColorAsync(BlockingCollection<Info> input,BlockingCollection<Info> output)
        {
            return Task.Run(() =>
            {

                foreach (var item in input.GetConsumingEnumerable())
                {
                    if (item.Count > 40)
                    {
                        item.Color = "Red";
                    }
                    else if (item.Count > 20)
                    {
                        item.Color = "Yellow";
                    }
                    else
                    {
                        item.Color = "Green";
                    }
                    output.Add(item);
                    ConsoleHelper.WriteLine(string.Format("stage 5: added color {1} to {0}", item, item.Color));
                }
                output.CompleteAdding();
            });
        }
        public static Task ShowContentAsync(BlockingCollection<Info> input)
        {
            return Task.Run(() =>
            {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    ConsoleHelper.WriteLine(string.Format("stage 6:{0}", item), item.Color);
                }
            });
        }

    }
    public static class ConcurrentDictionaryExtension
    {
        public static void AddOrIncrementValue(this ConcurrentDictionary<string,int> dict,string key)
        {
            bool success = false;
            while (!success)
            {
                int value;
                if(dict.TryGetValue(key,out value))
                {
                    if (dict.TryUpdate(key, value + 1, value))
                    {
                        success = true;
                    }
                }
                else
                {
                    if (dict.TryAdd(key, 1))
                    {
                        success = true;
                    }
                }
            }
        }
    }
    class Program
    {
        private static async void StartPipeline()
        {
            var fileNames = new BlockingCollection<string>();
            var lines = new BlockingCollection<string>();
            var words = new ConcurrentDictionary<string, int>();
            var items = new BlockingCollection<Info>();
            var colorsitems = new BlockingCollection<Info>();
            Task t1 = PipelineStages.ReadFilenamesAsync(@"../../..",fileNames);
            Console.WriteLine("started stage 1");
            Task t2 = PipelineStages.LoadContentAsync(fileNames,lines);
            Console.WriteLine("started stage 2");
            Task t3 = PipelineStages.ProcessContentAsync(lines, words);
            await Task.WhenAll(t1, t2, t3);
            ConsoleHelper.WriteLine("stages 1,2,3 completed");
            Task t4 = PipelineStages.TransferContentAsync(words, items);
            Task t5 = PipelineStages.AddColorAsync(items, colorsitems);
            Task t6 = PipelineStages.ShowContentAsync(colorsitems);
            ConsoleHelper.WriteLine("stages 4,5,6 started");

            await Task.WhenAll(t4, t5, t6);
            ConsoleHelper.WriteLine("all stages finished");


        }
        static void Main(string[] args)
        {
            //不变集合
            ImmutableArray<string> a1 = ImmutableArray.Create<string>();
            ImmutableArray<string> a2 = a1.Add("Williams");
            ImmutableArray<string> a3 = a2.Add("Ferrari").Add("red bule racing");

            List<Account> accounts = new List<Account>
            {
                new Account
                {
                    name = "Scrooge Mcduck",
                    Amount = 667377678765m
                },
                new Account
                {
                    name = "Donald Duck",
                    Amount = -200m
                },
                new Account
                {
                    name = "Ludwig von Drake",
                    Amount = 20000m
                }
            };
            ImmutableList<Account> immutableAccounts = accounts.ToImmutableList();

            ImmutableList<Account>.Builder builder = immutableAccounts.ToBuilder();
            for (int i = 0; i < builder.Count; i++)
            {
                Account a = builder[i];
                if (a.Amount > 0)
                {
                    builder.Remove(a);
                }
            }
            ImmutableList<Account> overrawnAccounts = builder.ToImmutable();
            foreach (var item in overrawnAccounts)
            {
                Console.WriteLine("{0}  {1}", item.name, item.Amount);
            }

            Console.WriteLine();
            //并发集合
            StartPipeline();
        }
    }
}
