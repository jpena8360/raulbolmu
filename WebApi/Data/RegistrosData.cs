using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using model.entity;
using Newtonsoft.Json;

namespace WebApi.Data
{
    public class estado
    {
        //Iniciamos la variable valestado en False;
        public static bool valestado = false;
        public static string valerror;
    }

    public class RegistrosData
    {
        public static bool LoginUsuarios(Login oEstudiantes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Codigo_Cliente", oEstudiantes.Codigo_Cliente);

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
        public static bool Registrar(Registros oEstudiantes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PaisNombre", oEstudiantes.PaisNombre);
                cmd.Parameters.AddWithValue("@Nombre", oEstudiantes.Nombre);
                cmd.Parameters.AddWithValue("@PaisID", oEstudiantes.PaisID);
                cmd.Parameters.AddWithValue("@UsuarioID", oEstudiantes.UsuarioID);
                cmd.Parameters.AddWithValue("@Tipo", oEstudiantes.Tipo);
                cmd.Parameters.AddWithValue("@Arranque", oEstudiantes.Arranque);
                cmd.Parameters.AddWithValue("@Envion", oEstudiantes.Envion);
                cmd.Parameters.AddWithValue("@TotalPeso", oEstudiantes.TotalPeso);
                cmd.Parameters.AddWithValue("@RegistroID", oEstudiantes.RegistroID);

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

        //public static bool Modificar(Registros oEstudiantes)
        public static bool Modificar(Registros oEstudiantes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PaisNombre", oEstudiantes.PaisNombre);
                cmd.Parameters.AddWithValue("@Nombre", oEstudiantes.Nombre);
                cmd.Parameters.AddWithValue("@PaisID", oEstudiantes.PaisID);
                cmd.Parameters.AddWithValue("@UsuarioID", oEstudiantes.UsuarioID);
                cmd.Parameters.AddWithValue("@Tipo", oEstudiantes.Tipo);
                cmd.Parameters.AddWithValue("@Arranque", oEstudiantes.Arranque);
                cmd.Parameters.AddWithValue("@Envion", oEstudiantes.Envion);
                cmd.Parameters.AddWithValue("@TotalPeso", oEstudiantes.TotalPeso);
                cmd.Parameters.AddWithValue("@RegistroID", oEstudiantes.RegistroID);
               
                var NumIntentos= oEstudiantes.NumIntentos + 1;
                cmd.Parameters.AddWithValue("@NumIntentos", NumIntentos);

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

        public static List<Registros> Listar()
        {
            List<Registros> oListaUsuario = new List<Registros>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {

                try
                {

                    using (var cmd = new SqlCommand("usp_listar", oConexion))

                    {
                        oConexion.Open();
                        var jsonResult = new StringBuilder();
                        var reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            jsonResult.Append("[]");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                jsonResult.Append(reader.GetValue(0).ToString());
                            }
                        }

                        StringBuilder jsonResults = new StringBuilder();
                        jsonResult.Append(jsonResults);

                        // Convierte el StringBuilder a una cadena
                        string jsonString = jsonResult.ToString();

                        List<Registros> competidores = JsonConvert.DeserializeObject<List<Registros>>(jsonString);

                        foreach (Registros competidor in competidores)
                        {
                            oListaUsuario.Add(new Registros()
                            {
                                PaisNombre = competidor.PaisNombre,
                                Nombre = competidor.Nombre,
                                //PaisID = Convert.ToInt32(dr["PaisID"]),
                                //UsuarioID = Convert.ToInt32(dr["UsuarioID"]),
                                Tipo = competidor.Tipo,
                                Arranque = competidor.Arranque,
                                Envion = competidor.Envion,
                                TotalPeso = competidor.TotalPeso,
                                NumIntentos = competidor.NumIntentos,
                                PaisID = competidor.PaisID,
                                UsuarioID = competidor.UsuarioID,
                                RegistroID = competidor.RegistroID

                            });
                        }
                    }

                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return oListaUsuario;
                }
            }
        }

        
      
        public static List<Registros> Obtener(int PaisID)
        {
            List<Registros> oListaUsuario = new List<Registros>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                //cmd.CommandType = CommandType.StoredProcedure;


                try
                {

                    using (var cmd = new SqlCommand("usp_obtener", oConexion))

                    {
                        cmd.CommandType = CommandType.StoredProcedure;               
                        var jsonResult = new StringBuilder();
                        cmd.Parameters.AddWithValue("@PaisID", PaisID);
                        oConexion.Open();
                        var reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            jsonResult.Append("[]");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                jsonResult.Append(reader.GetValue(0).ToString());
                            }
                        }

                        StringBuilder jsonResults = new StringBuilder();
                        jsonResult.Append(jsonResults);

                        // Convierte el StringBuilder a una cadena
                        string jsonString = jsonResult.ToString();

                        List<Registros> competidores = JsonConvert.DeserializeObject<List<Registros>>(jsonString);

                        foreach (Registros competidor in competidores)
                        {
                            oListaUsuario.Add(new Registros()
                            {
                                PaisNombre = competidor.PaisNombre,
                                Nombre = competidor.Nombre,
                                Tipo = competidor.Tipo,
                                Arranque = competidor.Arranque,
                                Envion = competidor.Envion,
                                TotalPeso = competidor.TotalPeso,
                                NumIntentos = competidor.NumIntentos,
                                PaisID = competidor.PaisID,
                                UsuarioID = competidor.UsuarioID,
                                RegistroID = competidor.RegistroID

                            });
                        }
                    }

                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return oListaUsuario;
                }
            }
        }
   

    }
}