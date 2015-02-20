<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="engine_stiri_1.account.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button Class="buttons" ID="Button1" runat="server"  Text="Noutati" 
            Width="74px" onclick="Button1_Click" />
        <asp:Button Class="buttons" ID="Button2" runat="server"  Text="Finante" 
            Width="74px" onclick="Button2_Click" />
        <asp:Button Class="buttons" ID="Button3" runat="server"  Text="Sport" 
            Width="74px" onclick="Button3_Click" />
        <asp:Button Class="buttons" ID="Button4" runat="server"  Text="Lifestyle" 
            Width="74px" onclick="Button4_Click" />
        <asp:Button Class="buttons" ID="Button5" runat="server"  Text="Tech" 
            Width="74px" onclick="Button5_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
&nbsp;<asp:Button ID="ButtonSearch" runat="server" onclick="ButtonSearch_Click" 
            Text="Search" Width="77px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
  <tr>
   <td>Nume :&nbsp;&nbsp; </td>
   <td>
       <asp:TextBox ID="TextBoxNume" runat="server" Width="138px" ></asp:TextBox>
      </td>
   <td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
           ErrorMessage="Completati numele!" ControlToValidate="TextBoxNume">*</asp:RequiredFieldValidator>
      </td>
  </tr>
  <tr>
   <td>Prenume :&nbsp;&nbsp;&nbsp; </td>
   <td>
       <asp:TextBox ID="TextBoxPrenume" runat="server" Width="138px"></asp:TextBox>
      </td>
   <td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
           ControlToValidate="TextBoxPrenume" ErrorMessage="Completati prenumele!">*</asp:RequiredFieldValidator>
      </td>
  </tr>
  <tr>
   <td>Email :&nbsp; </td>
   <td>
       <asp:TextBox ID="TextBoxEmail" runat="server" Width="138px"></asp:TextBox>
      </td>
   <td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
           ControlToValidate="TextBoxEmail" ErrorMessage="Completati email-ul!">*</asp:RequiredFieldValidator>
      </td>
  </tr>
  <tr>
   <td>Telefon : </td>
   <td>
       <asp:TextBox ID="TextBoxTelefon" runat="server" Width="138px"></asp:TextBox>
      </td>
   <td></td>
  </tr>
  <tr>
   <td>Username :&nbsp;&nbsp;&nbsp; </td>
   <td>
       <asp:TextBox ID="TextBoxUsername" runat="server" Width="138px"></asp:TextBox>
      </td>
   <td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
           ControlToValidate="TextBoxUsername" ErrorMessage="Alegeti un username!">*</asp:RequiredFieldValidator>
      </td>
  </tr>
  <tr>
   <td>Parola : </td>
   <td>
       <asp:TextBox ID="TextBoxParola" runat="server" Width="138px" TextMode="Password"></asp:TextBox>
      </td>
   <td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
           ControlToValidate="TextBoxParola" ErrorMessage="Alegeti o parola!">*</asp:RequiredFieldValidator>
      </td>
  </tr>
  <tr>
   <td>Confirmare Parola :&nbsp;&nbsp;&nbsp; </td>
   <td>
       <asp:TextBox ID="TextBoxConfirmareParola" runat="server" Width="138px" TextMode="Password"></asp:TextBox>
      </td>
   <td>
       <asp:CompareValidator ID="CompareValidator1" runat="server" 
           ControlToCompare="TextBoxParola" 
           ErrorMessage="Introduceti aceeasi parola!" 
           ControlToValidate="TextBoxConfirmareParola">*</asp:CompareValidator>
      </td>
  </tr>
  <tr>
   <td>Tip cont : </td>
   <td>
       <asp:DropDownList ID="DropDownListUtilizator" runat="server" Width="138px">
           <asp:ListItem Value="administrator">Administrator</asp:ListItem>
           <asp:ListItem Value="editor">Editor</asp:ListItem>
           <asp:ListItem Value="utilizator">Utilizator</asp:ListItem>

       </asp:DropDownList>
      </td>
   <td></td>
  </tr>
 </table>
 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ButtonCreareCont" runat="server" Height="28px" 
        Text="Creare Cont" Width="90px" onclick="ButtonCreareCont_Click" />
   <br /><br />
   <asp:Label ID="error" runat ="server" 
                    Text="Invalid Username or Password" Visible="False" 
        style="font-size: medium; font-weight: 700"/>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
    <br />
&nbsp;&nbsp;&nbsp; 
</asp:Content>
