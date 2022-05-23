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
using System.Windows.Shapes;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for editpass.xaml
    /// </summary>
    public partial class editpass : Window
    {
        public int uid;
        public editpass(int val)
        {
            InitializeComponent();
            uid = val;
            conain();
        }

        public void conain()
        {
            try
            {
                config cn = new config();
                SqlConnection sqlcon = cn.cunnection();
                sqlcon.Open();
                string commandstring = "select * from Password where Id = @a";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;


                SqlDataReader read = sqlcmd.ExecuteReader();
                while (read.Read())
                {

                    pname.Text = read["Pname"].ToString();
                    url.Text = read["URL"].ToString();
                    emun.Text = read["EMUN"].ToString();
                    passw.Text = read["Password"].ToString();
                }


                sqlcon.Close();
            }
            catch (Exception)
            {
                massage mass = new massage("Errore cunnection");
                mass.ShowDialog();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
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
                    SqlCommand cmd = new SqlCommand("UPDATE Password SET Pname = @b, URL = @c, EMUN = @d, Password = @e WHERE Id=@a ", sqlcon);

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
                        this.Close();
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

        private void down(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
