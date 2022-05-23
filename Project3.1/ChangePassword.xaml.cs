using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        public string uid;
        public ChangePassword( string val)
        {
            InitializeComponent();
            uid = val;
        }

        private void s_btn(object sender, RoutedEventArgs e)
        {
            string o_pass = opass.Password;
            string pass1 = npass.Password;
            string pass2 = cpass.Password;

            if (pass1 == pass2)
            {

                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();

                    string commandstring = "update regis set pass=@pre where unam = @a and pass = @b";
                    SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                    sqlcmd.Parameters.Add("@pre", SqlDbType.VarChar).Value = pass1;
                    sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = o_pass;


                    sqlcon.Open();
                    int rows = sqlcmd.ExecuteNonQuery();
                    sqlcon.Close();

                    if (rows == 1)
                    {
                        massage mass = new massage("Password Changed Successfully..");
                        mass.ShowDialog();
                    }
                    else
                    {
                        massage mass = new massage("Password does not Match..");
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
            opass.Password = "";
            npass.Password = "";
            cpass.Password = "";
        }
    }
}
