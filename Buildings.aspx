<%@ Page Title="" Language="C#" MasterPageFile="~/Standard.master" AutoEventWireup="true"
    CodeBehind="Buildings.aspx.cs" Inherits="EnergyCAP.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <%--<asp:SqlDataSource ID="sdsBuilding" runat="server" ConnectionString="<%$ ConnectionStrings:energycapConnectionString %>"
        SelectCommand="SELECT [BuildingID], [BuildingCode], [BuildingName] FROM [tblBuilding] ORDER BY [BuildingName]">
    </asp:SqlDataSource>--%>
    <h2>
        Buildings</h2>
    <p>
        Click the <strong>Select</strong> button next to a particular building to view the
        <strong>Meters</strong> associated with that building.</p>
    <p>
        You are currently viewing all available buildings.
    </p>
    <p>
        <asp:GridView ID="grdBuildings" runat="server" AllowSorting="False" AutoGenerateColumns="False"
            DataKeyNames="BuildingID" Width="100%" OnSelectedIndexChanged="grdBuildings_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="BuildingID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="BuildingID" />
                <asp:BoundField DataField="BuildingCode" HeaderText="Code" ReadOnly="True" SortExpression="BuildingCode" />
                <asp:BoundField DataField="BuildingName" HeaderText="Name" SortExpression="BuildingName" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
