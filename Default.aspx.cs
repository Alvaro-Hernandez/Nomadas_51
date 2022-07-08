using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(
            @"Data Source=ALVARO-HERNANDE\ALVAROHERNANDEZ;
            Initial Catalog=NomadasDB;Integrated Security=True;"
        );

        SqlCommand cmd = new SqlCommand("Select * FROM tb_habitacion;SELECT * FROM tb_negocio", cn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        ReportDocument rp = new ReportDocument();
        rp.Load(Server.MapPath("ReporteHabitacion.rpt"));
        rp.SetDataSource(ds.Tables["table"]);
        rp.Subreports[0].SetDataSource(ds.Tables["table1"]);

        rp.SetParameterValue("Renta", int.Parse(Request["Costo"]));
        CrystalReportViewer1.ReportSource = rp;
        rp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Informe de habitaciones");
        Response.End();
    }
}