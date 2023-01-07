using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services.Description;

namespace AWS_Task
{
    public partial class LoginForm : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["AWSwebformDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               using (SqlConnection dbconn = new SqlConnection(cs))
                {

                    dbconn.Open();
                    string qry= "select * from CompanyTable";
                   SqlCommand cmd = new SqlCommand(qry, dbconn);
                   
                    drp_companyname.DataSource = cmd.ExecuteReader();
                    drp_companyname.DataTextField = "companyname";
                    drp_companyname.DataValueField = "company_id";
                    drp_companyname.DataBind();
                    drp_companyname.Items.Insert(0,new ListItem("--Select Company--","0"));
               }
              
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
         using(SqlConnection dbconn=new SqlConnection(cs))
            {
                dbconn.Open();
                string uqry = "select count(*) from LoginTable where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(uqry,dbconn);
                cmd.Parameters.AddWithValue("@username",txt_username.Text) ;
                cmd.Parameters.AddWithValue("@password",txtpswd.Text);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                dbconn.Close();
                if(temp>=1)
                {
                        Session["user"]=txt_username.Text;
                        if (drp_companyname.SelectedIndex > 0)
                        {
                            dbconn.Open();
                            string companyqry = "select count(emp_id) from LoginTable where username=@username and password=@password and company_id =@company_id";
                            SqlCommand companycmd = new SqlCommand(companyqry, dbconn);
                        companycmd.Parameters.AddWithValue("@username", txt_username.Text);
                        companycmd.Parameters.AddWithValue("@password", txtpswd.Text);
                        companycmd.Parameters.AddWithValue("@company_id",drp_companyname.SelectedValue);
                        int e_id =Convert.ToInt32(companycmd.ExecuteScalar().ToString());
                        
                        dbconn.Close();
                        Session["Employeeid"] = e_id;    
                        if(e_id==0)
                        {
                            Response.Write("Record not found!");
                        }
                          else
                            Response.Redirect("EmployeeDetailForm.aspx");
                        }
                        else
                        {
                            Response.Write("Select your Company ");
                        }
                }
                else
                {
                    Response.Write("Incorrect Username or Password !");
                }
            }
            
        }
        /*
         protected void drp_companyname_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyid = Convert.ToInt32(drp_companyname.SelectedValue);
            using (SqlConnection dbconn=new SqlConnection(cs))
            {
                dbconn.Open();
               SqlCommand cmd = new SqlCommand("select * from CompanyTable where company_id="+companyid,dbconn);
            }
        }*/
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Text = "";
            txtpswd.Text = "";
            drp_companyname.SelectedIndex=-1;
       }
    }
} 