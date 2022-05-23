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
    /// Interaction logic for editplan.xaml
    /// </summary>
    public partial class editplan : Window
    {
        public int uid;
        public editplan(int val)
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
                string commandstring = "select  dt , STUFF(RIGHT('0' + CONVERT(VarChar(7), stime, 0), 7), 6, 0, ' ') AS st, STUFF(RIGHT('0' + CONVERT(VarChar(7), etime, 0), 7), 6, 0, ' ') AS et, pln from pbplan where id = @a";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;


                SqlDataReader read = sqlcmd.ExecuteReader();
                while (read.Read())
                {
                    pdate.Text = read["dt"].ToString();
                    stime.Text = read["st"].ToString();
                    etime.Text = read["et"].ToString();
                    plan.Text = read["pln"].ToString();
                    
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
            if (pdate.Text.Length == 0)
            {
                massage masse = new massage("Set Plan Date !!");
                masse.ShowDialog();
            }
            else if (stime.Text == null)
            {
                massage masse = new massage("Set Plan Start Time !!");
                masse.ShowDialog();
            }
            else if (etime.Text == null)
            {
                massage masse = new massage("Set Plan End Time !!");
                masse.ShowDialog();
            }
            else if (plan.Text == "")
            {
                massage masse = new massage("Set Your Plan Detail !!");
                masse.ShowDialog();
            }
            else
            {
                DateTime P_date = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", pdate.Text));
                TimeSpan S_time = DateTime.Parse(string.Format("{0:hh:mm tt}", stime.Text)).TimeOfDay;
                TimeSpan E_time = DateTime.Parse(string.Format("{0:hh:mm tt}", etime.Text)).TimeOfDay;
                string Pln = plan.Text;
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();
                    SqlCommand cmd = new SqlCommand("UPDATE pbplan SET dt = @b, stime = @c, etime = @d, pln = @e WHERE Id=@a", sqlcon);

                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    cmd.Parameters.Add("@b", SqlDbType.Date).Value = P_date;
                    cmd.Parameters.Add("@c", SqlDbType.Time).Value = S_time;
                    cmd.Parameters.Add("@d", SqlDbType.Time).Value = E_time;
                    cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = Pln;

                    sqlcon.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        massage mass = new massage("Plan Set Successful !!");
                        mass.ShowDialog();
                        this.Close();
                    }

                    sqlcon.Close();

                }
                catch (Exception)
                {
                    massage mass = new massage("Connection Error !!");
                    mass.ShowDialog();
                }
            }
        }
    }
}
