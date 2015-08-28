<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align ="center" >
   <table align ="center" width ="100%">
       <tr>
           <td align ="center" >
               <asp:Label ID="Label_vzid" runat="server" Text="User name"></asp:Label>
           </td>
           <td align ="left">
               <asp:TextBox ID="Txtvzid" runat="server"></asp:TextBox>
           </td>
           <td>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User name cannot be empty" ControlToValidate ="Txtvzid"></asp:RequiredFieldValidator></td>
       </tr>
       <tr>
           <td colspan ="2"></td>
       </tr>
         <tr>
           <td align ="center">
               <asp:Label ID="Label_pwd" runat="server" Text="Password"></asp:Label>
           </td>
           <td align ="left">
               <asp:TextBox ID="Txtpwd" runat="server" TextMode="Password"></asp:TextBox>
           </td>
             <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password field cannot be empty" ControlToValidate ="Txtpwd"></asp:RequiredFieldValidator></td>
       </tr>
       <tr>
           <td colspan ="3"></td>
       </tr>
       <tr>
           <td></td>
           <td  colspan ="2" align ="left">
               <asp:Button ID="Btnlogin" runat="server" Text="Login" OnClick="Btnlogin_Click" />
           </td>
       </tr>
       <tr>
           <td colspan ="3">
               <asp:Label ID="Label_LoginError" runat="server" Text=""></asp:Label>
           </td>
       </tr>

   </table>
        </div>
</asp:Content>

