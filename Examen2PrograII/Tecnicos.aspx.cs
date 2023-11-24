using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Examen2PrograII
{
    public partial class Tecnicos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos", con))
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            string especialidad = tespecialidad.Text.Trim();
            if (!string.IsNullOrEmpty(especialidad))
            {
                if (Clases.Tecnicos.Agregar(especialidad) > 0)
                {
                    LlenarGrid();
                    alertas("Especialidad ingresada con éxito");
                }
                else
                {
                    alertas("Error al ingresar la especialidad");
                }
            }
            else
            {
                alertas("Por favor, ingrese una especialidad válida");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tcodigo.Text, out int codigo))
            {
                if (Clases.Tecnicos.Borrar(codigo) > 0)
                {
                    LlenarGrid();
                    alertas("Especialidad borrada con éxito");
                }
                else
                {
                    alertas("Error al borrar la especialidad");
                }
            }
            else
            {
                alertas("Por favor, ingrese un código de técnico válido");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tcodigo.Text, out int codigo))
            {
                string especialidad = tespecialidad.Text.Trim();
                if (!string.IsNullOrEmpty(especialidad))
                {
                    if (Clases.Tecnicos.Modificar(codigo, especialidad) > 0)
                    {
                        LlenarGrid();
                        alertas("Especialidad modificada con éxito");
                    }
                    else
                    {
                        alertas("Error al modificar la especialidad");
                    }
                }
                else
                {
                    alertas("Por favor, ingrese una especialidad válida");
                }
            }
            else
            {
                alertas("Por favor, ingrese un código de técnico válido");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tcodigo.Text, out int codigo))
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos WHERE TecnicoID = @Codigo", con))
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
                alertas("Por favor, ingrese un código de técnico válido");
            }
        }

        protected void tdescripcion_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }

        protected void tcodigo_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }

        protected void tfecha_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }
    }
}