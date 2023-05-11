using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CRUD3.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOp = "";

        public object TbNombre { get; private set; }
        public object TbEdad { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {

                    sID = Request.QueryString["id"].ToString();
                    cargarDatos();

                }
                sOp=Request.QueryString["op"].ToString();
                switch(sOp)
                {
                    case "C":
                        lbltitulo.Text = "Crear nuevo registro";
                        this.BtnCreate.Visible = true;
                        break;

                        case "R":
                        lbltitulo.Text = "Consultar Registro";
                        this.nombre.Enabled = false;
                        this.edad.Enabled = false;
                        this.correo.Enabled = false;
                        this.fecha_nacimiento.Enabled = false;
                        break ;

                        case "U":
                        lbltitulo.Text = "Actualizar Registro";
                        this.BtnUpdate.Visible = true;
                        break;

                }
            }
        }
        protected void Create_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CREATE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
                cmd.Parameters.Add("@edad", SqlDbType.Int).Value = edad.Text;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo.Text;
                cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.VarChar).Value = fecha_nacimiento.Text;
                cmd.ExecuteNonQuery();
                Response.Redirect("~/Pages/index.aspx");
            
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(con != null) { con.Close(); }
            }


        }
        protected void Update_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = sID;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
                cmd.Parameters.Add("@edad", SqlDbType.Int).Value = edad.Text;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo.Text;
                cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.VarChar).Value = fecha_nacimiento.Text;
                cmd.ExecuteNonQuery();
                Response.Redirect("~/Pages/index.aspx");

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null) { con.Close(); }
            }


        }
        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/index.aspx");
        }
        private void cargarDatos()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID_USUARIO", System.Data.SqlDbType.Int).Value = sID;
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                nombre.Text = row[0].ToString();
                edad.Text = row[1].ToString();
                correo.Text = row[2].ToString();
                fecha_nacimiento.Text = row[3].ToString();


            }
            catch (Exception)
            {

            }
            finally
            {
                if (con != null) { con.Close(); }
            }
        }
    }
}

