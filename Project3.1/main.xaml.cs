using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;



namespace Project3._1
{
    /// <summary>
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Window
    {
        public string uid;

        public main(string val)
        {
            InitializeComponent();
            uid = val;

            slid.Navigate(new Notes(uid));

            config cn = new config();
            SqlConnection sqlcon = cn.cunnection();
            sqlcon.Open();
            string commandstring = "select nam from regis where unam = @a";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = val;
            SqlDataReader read = sqlcmd.ExecuteReader();


            while (read.Read())
            {

                nmlbl.Content = read["nam"].ToString();

            }

            sqlcon.Close();
            
        }


        private void move(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void clsbtn(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void logbtn(object sender, RoutedEventArgs e)
        {
           Lohout mi = new Lohout();         
           if((bool)mi.ShowDialog())
            {
                MainWindow ma = new MainWindow();
                ma.Show();
                this.Close();
            }
        }

   

        private void ntclk(object sender, RoutedEventArgs e)
        {
            slid.Navigate(new Notes(uid));
        }

        private void clplans(object sender, RoutedEventArgs e)
        {
            slid.Navigate(new Plans(uid));
        }

        private void clsplans(object sender, RoutedEventArgs e)
        {
            slid.Navigate(new Splans(uid));
        }

        private void clcontacts(object sender, RoutedEventArgs e)
        {
            slid.Navigate(new Contacts(uid));
        }

        private void clbank(object sender, RoutedEventArgs e)
        {
            slid.Navigate(new Bank(uid));
        }

        private void clpaswod(object sender, RoutedEventArgs e)
        {
            slid.Navigate(new PasswordBook(uid));
        }

        private void cngpasclk(object sender, RoutedEventArgs e)
        {
            slid.Navigate(new ChangePassword(uid));
        }

        private void mini(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
