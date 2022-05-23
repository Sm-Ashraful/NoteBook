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
    /// Interaction logic for Bank.xaml
    /// </summary>
    public partial class Bank : Page
    {
        public string uid;
        public Bank(string val)
        {
            InitializeComponent();
            uid = val;
            frame.Navigate(new vewbank(uid));
        }

        private void logout_Copy_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new addbank(uid));
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new vewbank(uid));
        }
    }
}
