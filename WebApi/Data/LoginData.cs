using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using model.entity;
using WebApi.Security;
using System.Web.Http;

namespace WebApi.Data
{
    public class estados
    {
        //Iniciamos la variable valestado en False;
        public static bool valestado = false;
        public static string valerror;
    }

    public class LoginData
    {
        public static string LoginUsuarios(Login oEstudiantes)

        {
            List<Login> oListaUsuario = new List<Login>();
            string token = "";
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarUsuarios", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Usuario", oEstudiantes.Nombre);
                cmd.Parameters.AddWithValue("@Contrasena", oEstudiantes.Contrasena);
                //var result = false;
                string result = "";
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        int Total = 0;

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Login()
                            {
                                Nombre = dr["Nombre"].ToString(),
                                Contrasena = dr["Contrasena"].ToString(),

                            });
                        }
                    }

                    foreach (var user in oListaUsuario)
                    {
                        var ValuUsuario = user.Nombre;
                        var ValContrasena = user.Contrasena;

                        var isUserValid = (oEstudiantes.Nombre == ValuUsuario && oEstudiantes.Contrasena == ValContrasena);
                        if (isUserValid)
                        {
                            var rolename = "Developer";
                            token = TokenGenerator.GenerateTokenJwt(ValuUsuario, rolename);
                            result = token;
                        }
                        else
                        {
                            result = "Error 401 - Not authorized";
                        }

                    }

                    oListaUsuario.Add(new Login()
                    {
                        Token = token

                    });

                    if (token == "")
                    {
                        result = "Error 401 - Not authorized";
                    }

                    return result;

                }
                catch (Exception ex)
                {
                    result = "Error 401 - Not authorized";
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();

                    return result;
                }
            }
        }

        public static bool RegistrarUsuarios(Login oEstudiantes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrarUsuarios", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Usuario", oEstudiantes.Nombre);
                cmd.Parameters.AddWithValue("@Contrasena", oEstudiantes.Contrasena);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    // Validamos el estado de la ejecucion
                    estado.valestado = true;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();

                    return true;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();

                    return false;
                }
            }
        }


    }
}