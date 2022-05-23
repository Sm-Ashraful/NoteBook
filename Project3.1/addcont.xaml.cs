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
    /// Interaction logic for addcont.xaml
    /// </summary>
    public partial class addcont : Page
    {
        public string uid;
        public addcont(string val)
        {
            InitializeComponent();
            uid = val;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                    SqlCommand cmd = new SqlCommand("insert into Contact values(@a,@b,@c,@d,@e,@f,@g)", sqlcon);

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
                        name.Text = "";
                        number.Text = "";
                        email.Text = "";
                        fb.Text = "";
                        other.Text = "";
                        add.Text = "";
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
