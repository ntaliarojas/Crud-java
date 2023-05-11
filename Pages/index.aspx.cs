using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD3.Pages
{
    public partial class index : System.Web.UI.Page
    {
    

        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
          
        }
        protected void Create_Click( object sender, EventArgs e) {
            Response.Redirect("~/Pages/CRUD.aspx?op=C");
        }
        protected void Read_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=R&id=" + getid(sender));
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=U&id=" + getid(sender));
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
       
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DELETE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = this.getid(sender);
            cmd.ExecuteNonQuery();
            Response.Redirect("~/Pages/index.aspx");

        }
        private string getid(object sender)
        {
            String id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            return id;
        }

        private void cargarDatos()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_load", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvusuarios.DataSource = dt;
                gvusuarios.DataBind();
            }
            catch (Exception ex)
            { 
                Response.Write(ex.Message);
            }
            finally { 
                if(con != null) { 
                    con.Close(); 
                }
            }

        }
    }
}