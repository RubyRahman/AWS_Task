<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetailForm.aspx.cs" Inherits="AWS_Task.EmployeeDetailForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <table>
                
                <tr>
                    <td>
                        <asp:Label ID="lbl_welcome" runat="server" Text="Welcome Back  "></asp:Label>
                    </td>
                </tr>
            </table>
            </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_empid" runat="server" Text="Employee Id"></asp:Label>
                      </td>
                    <td>
                        <asp:TextBox ID="txt_empid" runat="server"></asp:TextBox>
                    </td>
                 </tr>

                <tr>
                    <td>
                        <asp:Label ID="lbl_fname" runat="server" Text="First Name"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox ID="txt_fname" runat="server"></asp:TextBox>
                    </td>
                    </tr>

                <tr>
                    <td>
                        <asp:Label ID="lbl_lname" runat="server" Text="Last Name"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox ID="txt_lname" runat="server"></asp:TextBox>
                    </td>
                    </tr>

                <tr>
                    <td>
                        <asp:Label ID="lbl_nationality" runat="server" Text="Nationality"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox ID="txt_nationality" runat="server"></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_doj" runat="server" Text="Date Of Joining"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox ID="txt_doj" runat="server"></asp:TextBox>
                    </td>
                    </tr>
                </table>

            </div>

        <div>
            <as          
            </div>
       
              <div>
             <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_print" runat="server" Text=" Print " OnClick="btn_print_Click" />
                        </td>
                     <td>
                   <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" />
                   </td>
                </tr>

                </table>

                  <CR:CrystalReportViewer ID="crv_emp" runat="server" AutoDataBind="true" />
            </div>
    </form>
</body>
</html>