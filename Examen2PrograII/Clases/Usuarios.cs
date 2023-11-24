using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen2PrograII.Clases
{
    // Aqui funciona la clase usuarios
    public class Usuarios
    {
        public int Id { get; set; }
        public string CorreoElectronico { get; set; }

        // Boton modificar de la clase usuarios
        public Usuarios(int id, string correoElectronico)
        {
            Id = id;
            CorreoElectronico = correoElectronico;
        }

        // Constructor de la clase usuarios con datos 
        public Usuarios(string correoelectronico)
        {
            CorreoElectronico = correoelectronico;
        }

        // Constructor de la clase usuarios sin datos 
        public Usuarios()
        {
        }

        // Nuevos datos en la clase usuarios
        public static int Agregar(string correoelectronico)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CORREOELECTRONICO", correoelectronico));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        // Borrar los datos en la clase usuarios
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }


        // Consultar los datos en la clase usuarios
        public void Consultar() { }

        // Modificar los datos en la clase usuarios
        public static int Modificar(int codigo, string correoelectronico)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CORREOELECTRONICO", correoelectronico));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        // Consultar los datos en la clase equipos
        public static List<Equipos> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Equipos> Equipos = new List<Equipos>();
            try
            {

                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTAR_FILTROEQUIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Equipos Equipo = new Equipos(reader.GetInt32(0), reader.GetString(1));  // instancia
                            Equipos.Add(Equipo);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Equipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Equipos;
        }


        public static List<Usuarios> ObtenerEquipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Usuarios> Usuarios = new List<Usuarios>();
            try
            {

                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("consultar ", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios Usuario = new Usuarios(reader.GetInt32(0), reader.GetString(1));  // instancia
                            Usuarios.Add(Usuario);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Usuarios;
        }
    }

}