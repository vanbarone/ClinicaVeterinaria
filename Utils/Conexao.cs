using System.Data.SqlClient;

namespace ClinicaVeterinaria.Utils
{
    public static class Conexao
    {

        private static string connectionString = "Data Source=DESKTOP-690C72D\\SQLEXPRESS;Initial Catalog=ClinicaVeterinaria;User ID=sa; Password=Sql123@;encrypt=false";

        public static SqlConnection GetConection()
        {
            SqlConnection conexao = new SqlConnection(connectionString);

            return conexao;
        }


    }
}
