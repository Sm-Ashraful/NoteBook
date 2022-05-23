using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for forgot.xaml
    /// </summary>
    public partial class forgot : Window
    {
        public forgot()
        {
            InitializeComponent();
        }

        private void move(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            this.DragMove();
        }

        private void clbtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btncls(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void savebtn(object sender, RoutedEventArgs e)
        {
            string u_nam = uname.Text;
            string f_key = fkey.Text;
            string pass1 = pass.Password;
            string pass2 = cpass.Password;
            if (pass1 == pass2)
            {
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();

                    string commandstring = "update regis set pass=@pre where unam = @a and fkey = @b";
                    SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                    sqlcmd.Parameters.Add("@pre", SqlDbType.VarChar).Value = pass1;
                    sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = u_nam;
                    sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = f_key;


                    sqlcon.Open();
                    int rows = sqlcmd.ExecuteNonQuery();
                    sqlcon.Close();

                    if (rows == 1)
                    {
                        massage mass = new massage("Password Changed Successfully..");
                        mass.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        massage mass = new massage("User Name And Forgot key does not Match..");
                        mass.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    massage mass = new massage("User Name And Forgot key does not Match..");
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
}
