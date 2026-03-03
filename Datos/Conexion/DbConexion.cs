using System.Data;
using System.Data.SqlClient;

namespace Datos.Conexion
{
    public class DbConexion
    {
        private readonly string concadena;

        public DbConexion()
        {

            concadena = "Server=localhost;Database=PRUEBA;Trusted_Connection=True; Integrated Security = True; TrustServerCertificate = True; ";
        }

        public IDbConnection ObtenerConexion() => new SqlConnection(concadena);
    }
}