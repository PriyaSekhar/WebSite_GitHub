<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align ="center" >
   <table align ="center" width ="100%">
       <tr>
           <td align ="center" >
               <asp:Label ID="Label_AppName" runat="server" Text="Application Name"></asp:Label>
           </td>
           <td align ="left">
               <asp:DropDownList ID="DDL_AppName" runat="server" Width ="150px" AutoPostBack="True" OnSelectedIndexChanged="DDL_AppName_SelectedIndexChanged"></asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td colspan ="2"></td>

           <asp:TextBox ID="Test" runat="server" ></asp:TextBox>
       </tr>
         <tr>
           <td align ="center">
               <asp:Label ID="Label_ServerName" runat="server" Text="ServerName/IP"></asp:Label>
           </td>
           <td align ="left">
               <asp:DropDownList ID="DDL_ServerName" runat="server" Width ="150px" AutoPostBack="True"></asp:DropDownList>
           </td>
       </tr>

   </table>
        </div>
    <div>
    <table align ="center" width ="100%">
        <tr>
            <td colspan ="3"></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button_Databases" runat="server" Text="Databases" OnClick="Button_Databases_Click" />

            </td>
            <td>
                <asp:Button ID="Button_SQLJobs" runat="server" Text="SQL Jobs" OnClick="Button_SQLJobs_Click" />

            </td>
            <td>
                <asp:Button ID="Button_Statistics" runat="server" Text="Statistics" OnClick="Button_Statistics_Click" />

            </td>
        </tr>
    </table>
        </div>
    <br />
    <br />
    <br />

        <asp:Panel ID="Panel_Databases" runat="server" Visible ="false">
            <asp:GridView ID="GridView_Databases" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns ="false" OnSelectedIndexChanged="GridView_Databases_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns >
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--<input name ="MyRadioButton" type ="radio"/>--%>
                            <asp:RadioButton ID="dbRadioButton" runat="server" AutoPostBack ="true" GroupName ="dbRadio" /><%--OnCheckedChanged="dbRadioButton_CheckedChanged"--%> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField ="database_name" HeaderText ="Databases"  />                    
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Panel_SQLJobs" runat="server" Visible ="false">
            
            <asp:GridView ID="GridView_JobDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" align ="center" >
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Panel_Statistics" runat="server" Visible ="false">
            <asp:GridView ID="GridView_ServerStats" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" align="center" >
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </asp:Panel>
    <br />
    <br />
    <asp:Panel ID ="PanelErrorMessages" runat ="server" Visible ="false">
        <asp:Label ID="Label_ErrorMessage" runat="server" Text="" Visible ="false"></asp:Label>
    </asp:Panel>

</asp:Content>

