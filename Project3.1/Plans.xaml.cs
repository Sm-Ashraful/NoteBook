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
    /// Interaction logic for Plans.xaml
    /// </summary>
    public partial class Plans : Page
    {
        public string uid;
        public Plans(string val)
        {
            InitializeComponent();
            uid = val;
            frame.Navigate(new vewplan(uid));
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new vewplan(uid));
        }

        private void logout_Copy_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new addplan(uid));
        }
    }
}
