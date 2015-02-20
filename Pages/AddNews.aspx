<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="engine_stiri_1.Pages.AddNews1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<asp:Button  ID="Button1" runat="server"  Text="Noutati" 
            Width="68px" onclick="Button1_Click" />
        <asp:Button  ID="Button2" runat="server"  Text="Finante" 
            Width="71px" onclick="Button2_Click" />
        <asp:Button  ID="Button3" runat="server"  Text="Sport" 
            Width="64px" onclick="Button3_Click" />
        <asp:Button  ID="Button4" runat="server"  Text="Lifestyle" 
            Width="84px" onclick="Button4_Click" />
        <asp:Button  ID="Button5" runat="server"  Text="Tech" 
            Width="64px" onclick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
            Text="Propose News" Width="119px" />
        <asp:Button ID="Button7" runat="server"  
            Text="Add News" Width="87px" onclick="Button7_Click" />
        <asp:Button ID="ButtonSearch" runat="server" onclick="ButtonSearch_Click" 
            Text="Search" Width="72px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;

        <asp:Button Class="buttons" ID="Button8" runat="server"  Text="PendingAdminRequest" 
            Width="174px" onclick="Button8_Click" />
        <asp:Button Class="buttons" ID="Button9" runat="server"  Text="User Rights" 
            Width="100px" onclick="Button9_Click" />
         <asp:Button ID="Button10" runat="server" onclick="Button10_Click" 
        Text="Change Password" Width="142px" /> 
    <asp:Button ID="Button13" runat="server" onclick="Button13_Click" 
        Text="Register" Width="87px" />
     &nbsp;  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [proposed]"></asp:SqlDataSource>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" >
    <HeaderTemplate>
     <table>
      <tr>
      <td></td>
       <td>Titlu</td>
       <td>Headline</td>
       <td>Poza</td>
       <td>Link</td>
       <td>Categorie</td>
       <td>Data</td>
      </tr>
      
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td> <asp:CheckBox ID="CheckBox1" runat="server" AccessKey = '<%#Eval("news_id") %>'/>  </td>
     <td> <%#Eval("title") %></td>
     <td> <%#Eval("headline") %></td>
     <td> <asp:Image ID="NewsImage" runat="server" Width="90px" Height="75px" ImageUrl='<%# "../code/getImageFromProposed.ashx?news_id=" + Eval("news_id") %>'  /></td>
     <td> <%#Eval("link") %></td>
     <td> <%#Eval("category") %></td>
     <td> <%#Eval("release_date") %></td>
     </tr>
    </ItemTemplate>
    <FooterTemplate>
     
     </table>
    </FooterTemplate>
    </asp:Repeater>
    </br>
    <asp:Button ID="Button11" runat="server" onclick="Button11_Click" 
        Text="Add Selected News" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Trebuie sa fiti editor pentru a putea adauga stiri.
      Puteti, in schimb, sa propuneti stiri in sectiunea Proposed" Visible="false" ></asp:Label>
    <br />
    <br />
    </br>
    <table>
  <tr>
   <td>Title&nbsp;&nbsp;&nbsp; </td>
   <td>
       <asp:TextBox ID="TextBoxTitlu" runat="server" Width="245px"></asp:TextBox>
      </td>
   <td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
           ControlToValidate="TextBoxTitlu" ErrorMessage="Titlul este obligatoriu"></asp:RequiredFieldValidator>
      </td>
  </tr>
  <tr>
   <td>Headline&nbsp;&nbsp;&nbsp; </td>
   <td>
       <asp:TextBox ID="TextBoxHeadline" runat="server" Width="245px"></asp:TextBox>
      </td>
   <td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
           ControlToValidate="TextBoxHeadline" ErrorMessage="Headline-ul este obligatoriu"></asp:RequiredFieldValidator>
      </td>
  </tr>
  <tr>
   <td>Photo</td>
   <td>
       <asp:TextBox ID="TextBoxPoza" runat="server" Width="245px"></asp:TextBox>
      </td>
   <td></td>
  </tr>
  <tr>
   <td>Link</td>
   <td>
       <asp:TextBox ID="TextBoxLink" runat="server" Width="245px"></asp:TextBox>
      </td>
   <td></td>
  </tr>
  <tr>
   <td>Text</td>
   <td>
       <asp:TextBox ID="TextBoxText" runat="server" Height="90px" Width="245px"></asp:TextBox>
      </td>
   <td></td>
  </tr>
  <tr>
   <td>Category&nbsp; </td>
   <td>
       <asp:DropDownList ID="DropDownListCategorie" runat="server" Width="245px" 
           Height="16px">
           <asp:ListItem Value="finante">Finante</asp:ListItem>
           <asp:ListItem Value="sport">Sport</asp:ListItem>
           <asp:ListItem Value="lifestyle">Lifestyle</asp:ListItem>
           <asp:ListItem Value="tech">Tech</asp:ListItem>
       </asp:DropDownList>
      </td>
   <td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
           ErrorMessage="Categoria este obligatorie" 
           ControlToValidate="DropDownListCategorie"></asp:RequiredFieldValidator>
      </td>
  </tr>
 </table>
 <br /><br />
  <asp:Button ID="Button12" runat="server" Text="Add" onclick="Button12_Click" />
    <br />
    <br />
  <asp:Label ID="Label2" runat="server" Text="Trebuie sa fiti editor pentru a putea adauga stiri.
      Puteti, in schimb, sa propuneti stiri in sectiunea Proposed" Visible="false" ></asp:Label>
</asp:Content>
