using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for viewnot.xaml
    /// </summary>
    public partial class viewnot : Page
    {
        public string uid;
        public viewnot(string val)
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
                    string sqlquery = "Select * from note where unam = @a And title like '%' + @b + '%' ORDER BY id desc";
                    SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                    sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = valu;
                    SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
                    DataTable dt = new DataTable("note");
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
                    string sqlquery = "Select * from note where unam = @a ORDER BY id desc";
                    SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                    sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
                    DataTable dt = new DataTable("note");
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
      
            

        private void clbtn(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            config cn = new config();
            SqlConnection sqlcon = cn.cunnection();
            string commandstring = "delete from note where id= @a";
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

        private void editbtn(object sender, RoutedEventArgs e)
        {
            var Value = ((Button)sender).Tag;
            int id = Convert.ToInt32(Value);

            editnots edi = new editnots(id);
            edi.ShowDialog();
            this.Refresh(shbx.Text);
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
