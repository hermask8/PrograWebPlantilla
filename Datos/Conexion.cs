using MySql.Data;

namespace CRUDPractica.Datos
{
    public class Conexion
    {
        private readonly string CadenaMysql= string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaMysql = builder.GetSection("ConnectionStrings:mysqlConnection").Value;
        }

        public string getCadenaMySql()
        { return CadenaMysql; }
    }
}
