using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace Project3._1
{
    /// <summary>
    /// Interaction logic for editnots.xaml
    /// </summary>
    public partial class editnots : Window
    {
        public int uid;
        public editnots(int val)
        {
            InitializeComponent();
            uid = val;
            conain();
        }
        
        public void conain ()
        {
            try
            {
                config cn = new config();
                SqlConnection sqlcon = cn.cunnection();
                sqlcon.Open();
                string commandstring = "select * from note where Id = @a";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;


                SqlDataReader read = sqlcmd.ExecuteReader();
                while (read.Read())
                {

                    title.Text = read["title"].ToString();
                    note.Text = read["notes"].ToString();
                }


                sqlcon.Close();
            }
            catch (Exception)
            {
                massage mass = new massage("Errore cunnection");
                mass.ShowDialog();
            }
        }

        private void clbtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string tit = title.Text;
            string mass = note.Text;
            if (tit != "" && mass != "")
            {
                try
                {
                    config cn = new config();
                    SqlConnection sqlcon = cn.cunnection();
                    SqlCommand cmd = new SqlCommand("UPDATE note SET title = @b, notes = @c WHERE Id=@a ", sqlcon);

                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = uid;
                    cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = tit;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = mass;



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
                    massage masse = new massage("Title And Note Must 150 & 500 !!");
                    masse.ShowDialog();
                }
            }
            else
            {
                massage masse = new massage("Opps input all fields!!");
                masse.ShowDialog();
            }
        }

        private void down(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
