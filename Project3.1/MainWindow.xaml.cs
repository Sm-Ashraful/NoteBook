using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int c = 0;
        public MainWindow()
        {
           InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
            
        }

        private void clbtn(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void regbtn(object sender, RoutedEventArgs e)
        {
            registation re = new registation();
            re.Show();
            this.Close();
        }

        private void logbtn(object sender, RoutedEventArgs e)
        {
            string u_nam = uname.Text;
            string pass = passw.Password;
            int count = 0;
            try
            {
                config cn = new config();
                SqlConnection sqlcon = cn.cunnection();
                sqlcon.Open();
                string commandstring = "select * from regis where unam = @a and pass = @b";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = u_nam;
                sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = pass;

                SqlDataReader read = sqlcmd.ExecuteReader();
                    while (read.Read())
                    {
                    count++;

                    if (read["unam"].ToString() == u_nam && read["pass"].ToString() == pass)
                        {
                            massage mass = new massage("Login Successful !!");
                            mass.ShowDialog();
                            main ma = new main(read["unam"].ToString());
                            ma.Show();
                            this.Close();
                    }
                    
                   }
                if(count == 0)
                {
                    massage mass = new massage("Invalid Username And Password");
                    mass.ShowDialog();
                }
             
                sqlcon.Close();
            }
            catch(Exception)
            {
                massage mass = new massage("Invalid Username And Password");
                mass.ShowDialog();
            }


            
        }

        private void btnfp(object sender, RoutedEventArgs e)
        {
            forgot re = new forgot();
            re.ShowDialog();
            
        }

        
       

        private void good(object sender, MouseEventArgs e)
        {
            
                if ( c < 2)
            {
                
                Fontend fo = new Fontend();
                fo.ShowDialog();
                

            }
                
            
        }

        private void go(object sender, EventArgs e)
        {
            c++;
        }

        private void mini(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
