using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen2PrograII
{
    public partial class Usuarios : System.Web.UI.Page
    {
        //En esta parte es para cargar la pagina web correctamente
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        //En esta parte es para transferir los datos del sql management studio al visual studio en c#
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt; // se carga la tabla
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        //En esta parte son las alertas cuya funcion es cuando el usuario digita un numero para saber si lo ingreso correctamente o no
        public void alertas(String texto)
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

        //En esta parte es para que el boton de consultar funcione correctamente
        protected void Button2_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tcodigo.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE UsuarioID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // actualizar el grid view
                    }
                }
            }
        }

        //En esta parte es para que el boton de modificar funcione correctamente
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Clases.Usuarios.Modificar(int.Parse(tcodigo.Text), tcorreoelectronico.Text) > 0)
            {
                LlenarGrid();
                alertas("Usuario modificado con exito");
            }
            else
            {
                alertas("Error al modificado el usuario");
            }
        }

        //En esta parte es para que el boton de borrar funcione correctamente

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Clases.Usuarios.Borrar(int.Parse(tcodigo.Text)) > 0)
            {
                LlenarGrid(); // actualizar el grid
                alertas("Usuario borrado con exito");
            }
            else
            {
                alertas("Error al borrar el usuario");
            }
        }

        //En esta parte es para que el boton agregar funcione correctamente
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Clases.Usuarios.Agregar(tcorreoelectronico.Text) > 0)
            {
                LlenarGrid();
                alertas("Usuario ingresado con exito");
            }
            else
            {
                alertas("Error al ingresar el usuario");
            }
        }

        //En esta parte es para que la descripcion funcione correctamente
        protected void tdescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        //En esta parte es para que el codigo funcione correctamente
        protected void tcodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}