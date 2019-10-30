using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 样式和资源
{
    /// <summary>
    /// 资源.xaml 的交互逻辑
    /// </summary>
    public partial class 资源 : Window
    {
        public 资源()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Control ctr1 = sender as Control;
            ctr1.Background = ctr1.FindResource("myGradientBrush") as Brush;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myContainer.Resources.Clear();
            var b = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };
            b.GradientStops = new GradientStopCollection()
            {
                new GradientStop(Colors.White,0.0),
                new GradientStop(Colors.AliceBlue,0.3),
                new GradientStop(Colors.YellowGreen,0.8)
            };
            myContainer.Resources.Add("myGradientBrush", b);
        }
    }
}
