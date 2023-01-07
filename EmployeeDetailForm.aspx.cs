using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;

namespace AWS_Task
{
    public partial class EmployeeDetailForm : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["AWSwebformDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           // Page prev_page = Page.PreviousPage;
           // if (prev_page != null)
           // {
           //string empid = Request.QueryString["ID"];
                if (Session["user"] != null)
                {
                    lbl_welcome.Text += Session["user"].ToString();
                    int id = Convert.ToInt32(Session["Employeeid"]);

                    using (SqlConnection dbconn = new SqlConnection(cs))
                    {
                        dbconn.Open();
                        SqlCommand cmd = new SqlCommand("select * from EmployeeTable where emp_id = " + id, dbconn);
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            txt_empid.Text = sdr.GetValue(0).ToString();
                            txt_fname.Text = sdr.GetValue(1).ToString();
                            txt_lname.Text = sdr.GetValue(2).ToString();
                            txt_nationality.Text = sdr.GetValue(3).ToString();
                            txt_doj.Text = sdr.GetValue(4).ToString();
                        }
                        dbconn.Close();
                    }

                }
                else
                {
                    Response.Redirect("LoginForm.aspx");
                }
            //}
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["Employeeid"]);
            using (SqlConnection dbconn = new SqlConnection(cs))
            {
                dbconn.Open();
                SqlCommand cmd = new SqlCommand("select * from EmployeeTable where emp_id ="+id, dbconn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                
                ReportDocument reportdoc = new ReportDocument();
                reportdoc.Load(Server.MapPath("EmployeeReport.rpt"));
                reportdoc.SetDataSource(ds.Tables["table"]);
                crv_emp.ReportSource = reportdoc;
                reportdoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Employee Information");
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("LoginForm.aspx");
        }
    }

    
}