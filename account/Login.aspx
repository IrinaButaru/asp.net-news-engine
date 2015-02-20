<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="engine_stiri_1.account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Button class="buttons" ID="Button1" runat="server"  Text="Noutati" 
            Width="74px" onclick="Button1_Click" />
        <asp:Button class="buttons" ID="Button2" runat="server"  Text="Finante" 
            Width="74px" onclick="Button2_Click" />
        <asp:Button class="buttons" ID="Button3" runat="server"  Text="Sport" 
            Width="74px" onclick="Button3_Click" />
        <asp:Button class="buttons" ID="Button4" runat="server"  Text="Lifestyle" 
            Width="74px" onclick="Button4_Click" />
        <asp:Button class="buttons" ID="Button5" runat="server"  Text="Tech" 
            Width="74px" onclick="Button5_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
&nbsp;<asp:Button ID="ButtonSearch" runat="server" onclick="ButtonSearch_Click" 
            Text="Search" Width="77px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
 <tr>
  <td>Username&nbsp;&nbsp;&nbsp; </td>
  <td>
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     </td>
  <td>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
          ControlToValidate="TextBox1" ErrorMessage="Username este obligatoriu"></asp:RequiredFieldValidator>
     </td>
 </tr>
 <tr>
  <td>Password </td>
  <td>
      <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
     </td>
  <td>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
          ControlToValidate="TextBox2" ErrorMessage="Password este obligatoriu"></asp:RequiredFieldValidator>
     </td>
 </tr>
</table>
<br />
    <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="Login" />
    <br /><br />
<asp:Label ID="error" runat ="server" 
                    Text="Invalid Username or Password" Visible="False" 
        style="font-size: medium; font-weight: 700"/>
</asp:Content>
