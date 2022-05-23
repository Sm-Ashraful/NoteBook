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
    /// Interaction logic for editcont.xaml
    /// </summary>
    public partial class editcont : Window
    {
        public int uid;
        public editcont(int val)
        {
            InitializeComponent();
            uid = val;
            contain();
        }
        public void contain()
        {
            try
            {
                config cn = new config();
                SqlConnection sqlcon = cn.cunnection();
                sqlcon.Open();
                string commandstring = "select * from contact where Id = @a";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;


                SqlDataReader read = sqlcmd.ExecuteReader();
                while (read.Read())
                {
                    name.Text = read["Name"].ToString();
                    number.Text = read["Number"].ToString();
                    email.Text = read["Email"].ToString();
                    fb.Text = read["Fb"].ToString();
                    other.Text = read["Other"].ToString();
                    add.Text = read["Address"].ToString();
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

        private void down(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string Name = name.Text;
            string Number = number.Text;
            string Email = email.Text;
            string Fb = fb.Text;
            string Other = other.Text;
            string Address = add.Text;
            if (Name != "")
            {
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();
                    SqlCommand cmd = new SqlCommand("UPDATE Contact SET Name = @b, Number = @c, Email = @d, Fb = @e, Other = @f, Address = @g WHERE id=@a ", sqlcon);

                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = Name;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = Number;
                    cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = Fb;
                    cmd.Parameters.Add("@f", SqlDbType.VarChar).Value = Other;
                    cmd.Parameters.Add("@g", SqlDbType.VarChar).Value = Address;



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
    }
}
