using System.Windows;
using System.Windows.Input;
using System.Linq;


namespace Project3._1
{
    /// <summary>
    /// Interaction logic for Lohout.xaml
    /// </summary>
    public partial class Lohout : Window
    {

        public Lohout()
        {
            InitializeComponent();
       
        }

        private void clbtn(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void move(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ys_btn(object sender, RoutedEventArgs e)
        {

            DialogResult = true;
            this.Close();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
