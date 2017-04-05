<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailData.aspx.cs" Inherits="CMSEmergencySystem.Email.EmailData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="IncidentID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="IncidentID" HeaderText="IncidentID" InsertVisible="False" ReadOnly="True" SortExpression="IncidentID" />
                <asp:BoundField DataField="reporterName" HeaderText="reporterName" SortExpression="reporterName" />
                <asp:BoundField DataField="reportContact" HeaderText="reportContact" SortExpression="reportContact" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                <asp:BoundField DataField="dateTime" HeaderText="dateTime" SortExpression="dateTime" />
                <asp:BoundField DataField="incidentType" HeaderText="incidentType" SortExpression="incidentType" />
                <asp:BoundField DataField="incidentDesc" HeaderText="incidentDesc" SortExpression="incidentDesc" />
                <asp:BoundField DataField="updateDesc" HeaderText="updateDesc" SortExpression="updateDesc" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [IncidentManager]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
