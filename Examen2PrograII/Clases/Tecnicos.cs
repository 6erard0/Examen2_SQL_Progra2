using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen2PrograII.Clases
{
    // Aqui van a funcionar la clase tecnicos
    public class Tecnicos
    {
        public int Id { get; set; }

        public string Especialidad { get; set; }

        // En el constructor de la clase tecnicos para el boton modificar
        public Tecnicos(int id, string especialidad)
        {
            Id = id;
            Especialidad = especialidad;
        }

        // Constructor de la clase tecnicos con datos 
        public Tecnicos(string especialidad)
        {
            Especialidad = especialidad;
        }

        // Constructor de la clase tecnicos sin datos 
        public Tecnicos()
        {

        }

        //Aqui agrega nuevos datos en la clase tecnicos
        public static int Agregar(string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGARTECNICOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));

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

        // Aqui se borran los datos en la clase tecnicos
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRARTECNICOS", Conn)
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

        // Aqui se consultan los datos en la clase usuarios
        public void Consultar() { }

        // Aqui se modifican los datos en la clase tecnicos
        public static int Modificar(int codigo, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DB_CONN.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICARTECNICOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));
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

        // Funcion para consultar los datos en la clase equipos
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


        public static List<Tecnicos> ObtenerTecnicos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Tecnicos> Tecnicos = new List<Tecnicos>();
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
                            Tecnicos Tecnico = new Tecnicos(reader.GetInt32(0), reader.GetString(1));  // instancia
                            Tecnicos.Add(Tecnico);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Tecnicos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Tecnicos;
        }
    }
}