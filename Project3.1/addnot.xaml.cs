using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for addnot.xaml
    /// </summary>

    public partial class addnot : Page
    {
        public string uid;
        public addnot(string val)
        {
            InitializeComponent();
            uid = val;
        }

        private void svcl(object sender, RoutedEventArgs e)
        {
            string title = ftit.Text;
            string mass = nd.Text;
            if (title != "" && mass != "")
            {
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();
                    SqlCommand cmd = new SqlCommand("insert into note values(@a,@b,@c)", sqlcon);

                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = title;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = mass;



                    sqlcon.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        massage masse = new massage("Save Successful !!");
                        masse.ShowDialog();
                        ftit.Text = "";
                        nd.Text = "";
                    }

                    sqlcon.Close();
                }
                catch (Exception)
                {
                    massage masse = new massage("Title And Note Must 200 & 700 !!");
                    masse.ShowDialog();
                }
            }
            else
            {
                massage masse = new massage("Opps input all fields!!");
                masse.ShowDialog();
            }

            


        }
    }
}
