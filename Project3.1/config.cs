using System.Configuration;
using System.Data.SqlClient;

namespace Project3._1
{
    public class config
    {
        public SqlConnection cunnection()
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Project3._1.Properties.Settings.DatabaseConnectionString"].ConnectionString);
            
            return sqlcon;
        }
    }
}
