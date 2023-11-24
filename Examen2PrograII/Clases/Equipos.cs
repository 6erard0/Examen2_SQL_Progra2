using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen2PrograII.Clases
{
    // En esta parte funciona la clase equipos
    public class Equipos
    {
        public int Id { get; set; }
        public string TipoEquipo { get; set; }

        public Equipos(int id, string tipoEquipo)
        {
            Id = id;
            TipoEquipo = tipoEquipo;
        }

        // Este es el constructor de la clase equipos con los datos 
        public Equipos(string tipoequipo)
        {
            TipoEquipo = tipoequipo;
        }

        // Este es el constructor de la clase equipos sin los datos 
        public Equipos() { }

        // Aqui se agregan nuevos datos en la clase equipos
        public static int Agregar(string tipoequipo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAREQUIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TIPOEQUIPO", tipoequipo));


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

        // Aqui se borran los datos en la clase equipos
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAREQUIPOS", Conn)
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

        // Aqui se consultan los datos en la clase equipos
        public void Consultar() { }

        // Aqui se modifican los datos en la clase equipos
        public static int Modificar(int codigo, string tipoequipo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICAREQUIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TIPOEQUIPO", tipoequipo));
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

        // Aqui se consultan los datos en la clase equipos
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

        public static List<Equipos> ObtenerEquipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Equipos> Equipos = new List<Equipos>();
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
    }
}