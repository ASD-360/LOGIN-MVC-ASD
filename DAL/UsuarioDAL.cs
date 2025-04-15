using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LOGIN_MVC_ASD.Models;

namespace LOGIN_MVC_ASD.DAL
{
    public class UsuarioDAL
    {
        private readonly string _connectionString;

        public UsuarioDAL()
        {
            // Aquí cogemos la cadena directamente del appsettings
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Método para obtener usuario por username y password
        public Usuario GetUsuarioLogin(string userName, string pwd)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"SELECT * FROM Usuario
                                               WHERE UserName = @UserName AND Pwd = @pwd", connection);

                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@pwd", pwd);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = (int)reader["IdUsuario"],
                            UserName = (string)reader["UserName"],
                            Pwd = (string)reader["Pwd"],
                            Apellido = (string)reader["Apellido"],
                            Email = reader["Email"] as string,
                            FechaNacimiento = reader["FechaNacimiento"] as DateTime?,
                            Telefono = reader["Telefono"] as string,
                            Direccion = reader["Direccion"] as string,
                            Ciudad = reader["Ciudad"] as string,
                            Estado = reader["Estado"] as string,
                            CodigoPostal = reader["CodigoPostal"] as string,
                            FechaRegistro = (DateTime)reader["FechaRegistro"],
                            Activo = (bool)reader["Activo"]
                        };
                    }
                }
            }

            return null;
        }
    }
}