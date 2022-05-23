using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for perivious.xaml
    /// </summary>
    public partial class perivious : Page
    {
        public string uid;
        public perivious(string val)
        {
            InitializeComponent();
            uid = val;
            Refresh();
        }
        public void Refresh()
        {
            DateTime thisDay = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            try
            {

                config cn = new config();
                SqlConnection sqlcon = cn.cunnection();
                sqlcon.Open();
                string sqlquery = "Select id, dt , STUFF(RIGHT('0' + CONVERT(VarChar(7), stime, 0), 7), 6, 0, ' ') AS st, STUFF(RIGHT('0' + CONVERT(VarChar(7), etime, 0), 7), 6, 0, ' ') AS et,pln from pbplan where unam = @a and dt < @b and sec = @c ORDER BY dt asc";
                SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                sqlcmd.Parameters.Add("@b", SqlDbType.Date).Value = thisDay;
                sqlcmd.Parameters.Add("@c", SqlDbType.VarChar).Value = "no";
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

        private void success(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            config cn = new config();
            SqlConnection sqlcon = cn.cunnection();
            string commandstring = "UPDATE pbplan SET sec=@b where id= @a";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = myValue;
            sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = "ok";
            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows > 0)
            {
                massage mass = new massage("This Plan Is Successfule...");
                mass.ShowDialog();
                this.Refresh();
            }
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            var Value = ((Button)sender).Tag;
            int id = Convert.ToInt32(Value);
            editplan eb = new editplan(id);
            eb.ShowDialog();
            this.Refresh();
        }
    }
}
