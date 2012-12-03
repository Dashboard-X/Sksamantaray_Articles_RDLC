using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Configuration;

public partial class _Default : System.Web.UI.Page 
{
    string connn = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           getData();
        }
    }
    protected void getData()
    {


        //SqlConnection con = new SqlConnection("database=northwind;uid=sa;pwd=enter;server=.\\mssqlserver2008");
        //con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from Employees where city='London'", connn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        ReportDataSource rdc = new ReportDataSource("DataSet1_Employees", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rdc);
        ReportViewer1.Visible = true;
        ReportViewer1.LocalReport.Refresh();
        


    }
}
