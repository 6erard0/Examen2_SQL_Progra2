using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Examen2PrograII
{
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();
                        }
                    }
                }
            }
        }

        public void alertas(string texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void tdescripcion_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string tipoequipo = ttipoequipo.Text.Trim();
            if (!string.IsNullOrEmpty(tipoequipo))
            {
                if (Clases.Equipos.Agregar(tipoequipo) > 0)
                {
                    LlenarGrid();
                    alertas("Equipo ingresado con éxito");
                }
                else
                {
                    alertas("Error al ingresar el equipo");
                }
            }
            else
            {
                alertas("Por favor, ingrese un tipo de equipo válido");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tcodigo.Text, out int codigo))
            {
                if (Clases.Equipos.Borrar(codigo) > 0)
                {
                    LlenarGrid();
                    alertas("Equipo borrado con éxito");
                }
                else
                {
                    alertas("Error al borrar el equipo");
                }
            }
            else
            {
                alertas("Por favor, ingrese un código de equipo válido");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tcodigo.Text, out int codigo))
            {
                string tipoequipo = ttipoequipo.Text.Trim();
                if (!string.IsNullOrEmpty(tipoequipo))
                {
                    if (Clases.Equipos.Modificar(codigo, tipoequipo) > 0)
                    {
                        LlenarGrid();
                        alertas("Equipo modificado con éxito");
                    }
                    else
                    {
                        alertas("Error al modificar el equipo");
                    }
                }
                else
                {
                    alertas("Por favor, ingrese un tipo de equipo válido");
                }
            }
            else
            {
                alertas("Por favor, ingrese un código de equipo válido");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tcodigo.Text, out int codigo))
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos WHERE EquipoID = @Codigo", con))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                datagrid.DataSource = dt;
                                datagrid.DataBind();
                            }
                        }
                    }
                }
            }
            else
            {
                alertas("Por favor, ingrese un código de equipo válido");
            }
        }
    }
}