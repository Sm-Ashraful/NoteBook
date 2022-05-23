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
    /// Interaction logic for vewcont.xaml
    /// </summary>
    public partial class vewcont : Page
    {
        public string uid;
        public vewcont(string val)
        {
            InitializeComponent();
            uid = val;
            Refresh("");
        }
        public void Refresh(string valu)
        {
            if (valu != "")
            {
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();

                    sqlcon.Open();
                    string sqlquery = "Select * from Contact where unam = @a And Name like  + @b + '%' ORDER BY Name asc";
                    SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                    sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = valu;
                    SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
                    DataTable dt = new DataTable("Contact");
                    data_adapter.Fill(dt);
                    id.ItemsSource = dt.DefaultView;
                    data_adapter.Update(dt);
                    sqlcon.Close();




                }
                catch (Exception)
                {
                    massage mass = new massage("Opps...");
                    mass.ShowDialog();
                }
            }
            else
            {
                try
                {

                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();

                    sqlcon.Open();
                    string sqlquery = "Select * from Contact where unam = @a ORDER BY Name asc";
                    SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                    sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
                    DataTable dt = new DataTable("Contact");
                    data_adapter.Fill(dt);
                    id.ItemsSource = dt.DefaultView;
                    data_adapter.Update(dt);
                    sqlcon.Close();
                }
                catch (Exception)
                {
                    massage mass = new massage("Opps...");
                    mass.ShowDialog();
                }
            }

        }

        private void editclk(object sender, RoutedEventArgs e)
        {
            var Value = ((Button)sender).Tag;
            int id = Convert.ToInt32(Value);

            editcont ed = new editcont(id);
            ed.ShowDialog();
            this.Refresh(shbx.Text);
        }

        private void delclk(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            config cn = new config();
            SqlConnection sqlcon = cn.cunnection();
            string commandstring = "delete from Contact where id= @a";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = myValue;
            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows > 0)
            {
                massage mass = new massage("delete successfully...");
                mass.ShowDialog();
                this.Refresh(shbx.Text);
            }
        }

        private void down(object sender, KeyEventArgs e)
        {
            this.Refresh(shbx.Text);
        }

        private void up(object sender, KeyEventArgs e)
        {
            this.Refresh(shbx.Text);
        }
    }
}
