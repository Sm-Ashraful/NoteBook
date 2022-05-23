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
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Page
    {
        public string uid;
        public Notes(string val)
        {
            InitializeComponent();
            uid = val;
            frame.Navigate(new viewnot(uid));
        }

        private void logout_Copy_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new addnot(uid));
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new viewnot(uid));
        }
    }
}
