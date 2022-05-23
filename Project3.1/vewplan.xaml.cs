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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for vewplan.xaml
    /// </summary>
    public partial class vewplan : Page
    {
        public string uid;
        public vewplan(string val)
        {
            InitializeComponent();
            uid = val;
            frame.Navigate(new today(uid));
        }

        private void today_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new today(uid));
        }

        private void upcoming_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new upcoming(uid));
        }

        private void perivious_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new perivious(uid));
        }
    }
}
