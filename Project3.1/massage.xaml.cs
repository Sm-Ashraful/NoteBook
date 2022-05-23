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

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for massage.xaml
    /// </summary>
    public partial class massage : Window
    {
        public massage(String valu)
        {
            InitializeComponent();
            mass.Content = valu;
        }

        private void cbtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clbtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void down(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
