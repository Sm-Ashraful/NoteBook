using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for Splans.xaml
    /// </summary>
    public partial class Splans : Page
    {
        public string uid;
        public Splans(string val)
        {
            InitializeComponent();
            uid = val;
            Refresh("");
        }
        public void Refresh(string valu)
        {
            if (valu != "")
            {
                DateTime date = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", valu));
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();
                    
                    sqlcon.Open();
                    string sqlquery = "Select  id, dt , STUFF(RIGHT('0' + CONVERT(VarChar(7), stime, 0), 7), 6, 0, ' ') AS st, STUFF(RIGHT('0' + CONVERT(VarChar(7), etime, 0), 7), 6, 0, ' ') AS et ,pln from pbplan where unam = @a and sec = @c And dt like  @b  ORDER BY dt asc";
                    SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                    sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    sqlcmd.Parameters.Add("@b", SqlDbType.Date).Value = date;
                    sqlcmd.Parameters.Add("@c", SqlDbType.VarChar).Value = "ok";
                    SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
                    DataTable dt = new DataTable("pbplan");


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
                    string sqlquery = "Select id, dt , STUFF(RIGHT('0' + CONVERT(VarChar(7), stime, 0), 7), 6, 0, ' ') AS st, STUFF(RIGHT('0' + CONVERT(VarChar(7), etime, 0), 7), 6, 0, ' ') AS et,pln from pbplan where unam = @a and sec = @b ORDER BY dt asc";
                    SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                    sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = "ok";
                    SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
                    DataTable dt = new DataTable("pbplan");
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

        private void del_clk(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            config cn = new config();
            SqlConnection sqlcon = cn.cunnection();
            string commandstring = "delete from pbplan where id= @a";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = myValue;
            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows > 0)
            {
                massage mass = new massage("delete successfully...");
                mass.ShowDialog();
                this.Refresh(search.Text);
            }
        }


        private void clcls(object sender, RoutedEventArgs e)
        {
           this.Refresh(search.Text);
        }

        private void down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.Refresh("");
                search.Text = "";
                e.Handled = true;
            }
        }
    }
}
