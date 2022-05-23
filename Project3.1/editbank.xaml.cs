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
    /// Interaction logic for editbank.xaml
    /// </summary>
    public partial class editbank : Window
    {
        public int uid;
        public editbank(int val)
        {
            InitializeComponent();
            uid = val;
            contain();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string Bname = bname.Text;
            string Anumber = anumber.Text;
            string Cnumber = cnumber.Text;
            string Cpass = cpass.Text;
            if (Bname != "")
            {
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();
                    SqlCommand cmd = new SqlCommand("UPDATE Bank SET Bname = @b, Anumber = @c, Cnumber = @d, Cpassword = @e WHERE Id=@a", sqlcon);

                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = Bname;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = Anumber;
                    cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = Cnumber;
                    cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = Cpass;


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

        public void contain()
        {
            try
            {
                config cn = new config();
                SqlConnection sqlcon = cn.cunnection();
                sqlcon.Open();
                string commandstring = "select * from Bank where id = @a";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;


                SqlDataReader read = sqlcmd.ExecuteReader();
                while (read.Read())
                {
                    bname.Text = read["Bname"].ToString();
                    anumber.Text = read["Anumber"].ToString();
                    cnumber.Text = read["Cnumber"].ToString();
                    cpass.Text = read["Cpassword"].ToString();
                }


                sqlcon.Close();
            }
            catch (Exception)
            {
                massage mass = new massage("Errore cunnection");
                mass.ShowDialog();
            }
        }

        private void down(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
