using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;



namespace Project3._1
{
    /// <summary>
    /// Interaction logic for addplan.xaml
    /// </summary>
    public partial class addplan : Page
    {
        
        public string uid;
        
        public addplan(string val)
        {
            InitializeComponent();
            uid = val;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (pdate.Text.Length == 0)
            {
                massage masse = new massage("Set Plan Date !!");
                masse.ShowDialog();
            }
            else if(stime.Text == null)
            {
                massage masse = new massage("Set Plan Start Time !!");
                masse.ShowDialog();
            }
            else if(etime.Text == null)
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
                    SqlCommand cmd = new SqlCommand("insert into pbplan (unam, dt, stime, etime, pln, sec) values (@a, @b, @c, @d, @e, @f);", sqlcon);

                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    cmd.Parameters.Add("@b", SqlDbType.Date).Value = P_date;
                    cmd.Parameters.Add("@c", SqlDbType.Time).Value = S_time;
                    cmd.Parameters.Add("@d", SqlDbType.Time).Value = E_time;
                    cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = Pln;
                    cmd.Parameters.Add("@f", SqlDbType.VarChar).Value = "no";

                    sqlcon.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        massage mass = new massage("Plan Set Successful !!");
                        mass.ShowDialog();
                        pdate.Text = "";
                        stime.Text = "";
                        etime.Text = "";
                        plan.Text = "";
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
    

