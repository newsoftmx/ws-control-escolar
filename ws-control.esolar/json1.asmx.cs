using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//añadimos estas librerias
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ws_control.esolar
{
    /// <summary>
    /// Descripción breve de json1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class json1 : System.Web.Services.WebService
    {
        #region "variables"
        SqlConnection cn = new SqlConnection("Data Source=vibecohack; Initial Catalog=db_controlEscolar; User ID=sa; Password=spartaco17;");
        string jsonReturn;
        #endregion

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public void DataTableToJson()
        {
            DataTable dt = new DataTable();
            //añadimos columnas del dataTable
            //DataColumn 
            SqlCommand buscar = new SqlCommand("spSelecAlumnos", cn);
            buscar.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter datos = new SqlDataAdapter();
            datos.SelectCommand = buscar;
            DataSet conjunto = new DataSet();
            try
            {
                cn.Open();
                datos.Fill(conjunto, "DatosGenerales");
                cn.Close();
                dt = conjunto.Tables[0];
                Context.Response.Write(JsonConvert.SerializeObject(dt, Formatting.Indented));
                //return conjunto;
            }
            catch (Exception)
            {
                cn.Close();
                //return conjunto;
            }
        }
        [WebMethod]
        public string DataTableToJsonR()
        {
            DataTable dt = new DataTable();
            //añadimos columnas del dataTable
            //DataColumn 
            SqlCommand buscar = new SqlCommand("spSelecAlumnos", cn);
            buscar.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter datos = new SqlDataAdapter();
            datos.SelectCommand = buscar;
            DataSet conjunto = new DataSet();
            try
            {
                cn.Open();
                datos.Fill(conjunto, "DatosGenerales");
                cn.Close();
                dt = conjunto.Tables[0];
                jsonReturn = JsonConvert.SerializeObject(dt, Formatting.Indented);
                return jsonReturn;
            }
            catch (Exception)
            {
                cn.Close();
                return jsonReturn;
            }
        }
    }
}
