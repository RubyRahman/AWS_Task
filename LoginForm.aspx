<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="AWS_Task.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body> 
    <form id="form1" runat="server">
        <div><table>
            <tr>
                <td>Welcome </td>
            </tr>
             </table>
            <table>
                <tr>
                     <td> <asp:Label runat="server" Text="User Name" ID="lbl_username"></asp:Label></td>
                    <td> <asp:TextBox ID="txt_username" runat="server"></asp:TextBox></td>
                    <td>
                        
                        </td>
                </tr>
                <tr>
                
                      <td> <asp:Label runat="server" Text="Password" ID="lbl_pswd"></asp:Label></td>
                      <td>  <asp:TextBox ID="txtpswd" runat="server"></asp:TextBox></td>
                          <td>
                              
                        </td>         
                    </tr>  
              
                <tr>
                     
                       <td><asp:Label ID="lbl_drp_companyname" runat="server" Text="Company Name"></asp:Label></td>
                       <td> <asp:DropDownList ID="drp_companyname" runat="server" DataTextField="companyname"></asp:DropDownList></td>
                   <td>
                       
                        </td>
               </tr>         
                <tr>                 
                        <td> <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="btn_clear_Click" />
                        </td>
                    <td>
                        <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" />

                    </td>
                   </tr>
        </table>
       </div>
        
    </form>
</body>
</html>
