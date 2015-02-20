<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRights.aspx.cs" Inherits="engine_stiri_1.Pages.UserRights" %>
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
    <asp:Label ID="Label1" runat="server" Text="To revoke user's rights click select"></asp:Label>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [users] WHERE ([status] = 'active')">
        
    </asp:SqlDataSource>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="last_name" HeaderText="Last Name" ReadOnly="True" 
                SortExpression="last_name" />
            <asp:BoundField DataField="first_name" HeaderText="First Name" ReadOnly="True" 
                SortExpression="first_name" />
            <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="True" 
                SortExpression="username" />
            <asp:BoundField DataField="email" HeaderText="Email" ReadOnly="True" 
                SortExpression="email"  />
            <asp:BoundField DataField="phone_number" HeaderText="Phone Number" 
                ReadOnly="True" SortExpression="phone_number" />
            <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="true" 
            SortExpression="status" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Trebuie sa fiti administrator pentru a revoca drepturi." 
    Visible = "false"></asp:Label>
    <br />
    <br />
    To grant users rights click select<br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [users]WHERE ([status] = 'revoked')"></asp:SqlDataSource>
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource2" 
        onselectedindexchanged="GridView2_SelectedIndexChanged" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="last_name" HeaderText="Last Name" ReadOnly="True" 
                SortExpression="last_name" />
            <asp:BoundField DataField="first_name" HeaderText="First Name" ReadOnly="True" 
                SortExpression="first_name" />
            <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="True" 
                SortExpression="username" />
            <asp:BoundField DataField="email" HeaderText="Email" ReadOnly="True" 
                SortExpression="email"  />
            <asp:BoundField DataField="phone_number" HeaderText="Phone Number" 
                ReadOnly="True" SortExpression="phone_number" />
            <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="true" 
            SortExpression="status" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Trebuie sa fiti administrator pentru a acorda drepturi."
    Visible = "false"></asp:Label>
</asp:Content>
