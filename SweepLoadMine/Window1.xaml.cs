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

namespace SweepLoadMine
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartWindow("小黑", 600, 400);
            StartWindow("小白", 0, 0);
        }

        private void StartWindow(string userName, int left, int top)
        {
            MainWindow w = new MainWindow();
            w.Left = left;
            w.Top = top;
            w.UserName = userName;
            w.Owner = this;
            w.Closed += (sender, e) => this.Activate();
            w.Show();
        }

    }
}
