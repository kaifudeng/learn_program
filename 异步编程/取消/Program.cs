using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace 取消
{
    public partial class MainWindow : Window
    {
        private SearchInfo searchInfo;
        private object lockList = new object();
        private CancellationTokenSource cts;
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
