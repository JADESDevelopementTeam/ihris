using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BahteraAdhiguna
{
    class Config
    {
        public SqlConnection ConnectSQL()
        {
            string id = "sa";
            string pwd = "abc123";
            SqlConnection con = new SqlConnection(
                "Data Source = DESKTOP-7HGP386\\DEVELOPMENT; Initial Catalog = SDMBA; User Id = " + id+"; Password = "+pwd+"");
            return con;
        }
    }
}
