<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Finante.aspx.cs" Inherits="engine_stiri_1.NewsCategories.Finante" %>
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
    <asp:Button ID="Button11" runat="server" onclick="Button11_Click" 
        Text="Register" Width="87px" />
     &nbsp;  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<br />
<asp:DropDownList   ID="DropDownList1" AutoPostBack="true" runat="server" Height="25px"  
        Width="305px" onselectedindexchanged="Sort" >
        <asp:ListItem>Date(descending)</asp:ListItem>
        <asp:ListItem>Date(ascending)</asp:ListItem>
        <asp:ListItem>Title(ascending)</asp:ListItem>
        <asp:ListItem>Title(descending)</asp:ListItem>
    </asp:DropDownList>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
    <HeaderTemplate>
    <table>
     <tr>
    </HeaderTemplate>
    <ItemTemplate>
     <table>
      <tr>
        <td rowspan = "2" > <asp:Image ID="NewsImage" runat="server" Width="90px" Height="75px" ImageUrl='<%# "../code/getImageFromDB.ashx?news_id=" + Eval("news_id") %>'  /></td>
        <td> <%#Eval("title") %></td>
      </tr>
      <tr>
       <td><%#Eval("headline") %> <a href = '<%#Eval("link") %>'> read more </a></td>
      </tr>
     </table>
    </ItemTemplate>
    <FooterTemplate>
     </tr>
    </table>
    </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [news] WHERE ([category] = 'finante')">
    </asp:SqlDataSource>
</asp:Content>
