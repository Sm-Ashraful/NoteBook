using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for addpass.xaml
    /// </summary>
    public partial class addpass : Page
    {
        public string uid;
        public addpass(string val)
        {
            InitializeComponent();
            uid = val;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string P_name = pname.Text;
            string URL = url.Text;
            string EMUN = emun.Text;
            string Passw = passw.Text;
            if (P_name != "")
            {
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();
                    SqlCommand cmd = new SqlCommand("insert into Password values(@a,@b,@c,@d,@e)", sqlcon);

                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = P_name;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = URL;
                    cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = EMUN;
                    cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = Passw;


                    sqlcon.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        massage masse = new massage("Save Successful !!");
                        masse.ShowDialog();
                        pname.Text = "";
                        url.Text = "";
                        emun.Text = "";
                        passw.Text = "";
                    }

                    sqlcon.Close();
                }
                catch (Exception)
                {
                    massage masse = new massage("Connection Error !!");
                    masse.ShowDialog();
                }
            }
            else
            {
                massage masse = new massage("Name Must be Requerd !!");
                masse.ShowDialog();
            }
        }
    }
}
