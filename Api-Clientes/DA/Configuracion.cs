using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DA
{
    public class Configuracion
    {
        public string ConnectionString { get; }
        public Configuracion(string connectionstring) 
        {
            ConnectionString = connectionstring;
        }


        public string Server 
        {
            get
            {
                var connectStringBuilder = new SqlConnectionStringBuilder(ConnectionString);
                return connectStringBuilder.DataSource;
            }
        }
    }
}
