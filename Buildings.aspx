<%@ Page Title="" Language="C#" MasterPageFile="~/Standard.master" AutoEventWireup="true"
    CodeBehind="Buildings.aspx.cs" Inherits="EnergyCAP.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Buildings</h2>
    <p>
        Click the <strong>View Meters</strong> button next to a particular building to view the
        <strong>Meters</strong> associated with that building.</p>
    <p>
        You are currently viewing all available buildings.
    </p>
    <asp:GridView ID="grdBuildings" runat="server" 
        AutoGenerateColumns="False" DataKeyNames="BuildingID"
        Width="850px" OnSelectedIndexChanged="grdBuildings_SelectedIndexChanged" 
        OnRowCommand="grdBuildings_RowCommand">
        <Columns>
            <asp:BoundField DataField="BuildingID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="BuildingID" />
            <asp:BoundField DataField="BuildingCode" HeaderText="Code" ReadOnly="True" SortExpression="BuildingCode" />
            <asp:BoundField DataField="BuildingName" HeaderText="Name" SortExpression="BuildingName" />
            <asp:ButtonField CommandName="EditBuilding" Text="Edit &gt;&gt;" />
            <asp:CommandField ShowSelectButton="True" SelectText="View Meters &gt;&gt;" />
        </Columns>
    </asp:GridView>
</asp:Content>
