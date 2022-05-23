using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for registation.xaml
    /// </summary>
    public partial class registation : Window
    {
        public registation()
        {
            InitializeComponent();
        }
        private void clbtn(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void logbtn(object sender, RoutedEventArgs e)
        {
            MainWindow mi = new MainWindow();
            mi.Show();
            this.Close();
        }

        private void regclk(object sender, RoutedEventArgs e)
        {
            
            string u_nam = unam.Text;
            string name = nam.Text;
            string f_key = fkey.Text;
            string pass1 = pass.Password;
            string pass2 = cpass.Password;
            if(u_nam == "")
            {
                massage mass = new massage("Input User Name..");
                mass.ShowDialog();
                
            }
            else if(name == "")
            {
                massage mass = new massage("Input Name..");
                mass.ShowDialog();
            }
            else if (f_key == "")
            {
                massage mass = new massage("Input Forgot key..");
                mass.ShowDialog();
            }
            else if (pass1 == "")
            {
                massage mass = new massage("Input Password..");
                mass.ShowDialog();
            }
            else if (pass2 == "")
            {
                massage mass = new massage("Input Confirm Password..");
                mass.ShowDialog();
            }
            else
            {
                if (pass1 == pass2)
                {
                    try
                    {
                        config cn = new config();
                        SqlConnection sqlcon = cn.cunnection();
                        SqlCommand cmd = new SqlCommand("insert into regis values(@a,@b,@c,@d)", sqlcon);

                        cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = u_nam;
                        cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = f_key;
                        cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = pass1;


                        sqlcon.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            massage mass = new massage("Registration Successful !!");
                            mass.ShowDialog();
                            main mi = new main(u_nam);
                            mi.Show();
                            this.Close();
                        }
              
                        sqlcon.Close();
                    }
                    catch (Exception)
                    {
                        massage mass = new massage("This User Name is Alrady Used !!");
                        mass.ShowDialog();
                    }



                }
                else
                {
                    massage mass = new massage("Password does not Match !!");
                    mass.ShowDialog();
                }
                   

            }

        }

        private void mini(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
