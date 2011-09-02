<%@ Page Title="" Language="C#" MasterPageFile="~/Standard.master" AutoEventWireup="true"
    CodeBehind="Meters.aspx.cs" Inherits="EnergyCAP.Meters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        Meters</h2>
    <p>
        Click the <strong>Select</strong> button next to a particular meter to view the
        <strong>Bills</strong> associated with that meter.</p>
    <p>
        <asp:Label runat="server" ID="lblBuilding"></asp:Label>
    </p>
    <asp:GridView ID="grdMeters" runat="server" AutoGenerateColumns="False"
        DataKeyNames="MeterInfoID" Width="850px" EmptyDataText="<p>Please first select a building from the Buildings page.</p>"
        OnSelectedIndexChanged="grdMeters_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="MeterInfoID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="MeterInfoID" />
            <asp:BoundField DataField="MeterCode" HeaderText="Code" ReadOnly="True" SortExpression="MeterCode" />
            <asp:BoundField DataField="MeterName" HeaderText="Name" ReadOnly="True" SortExpression="MeterName" />
            <asp:BoundField DataField="MeterSerial" HeaderText="Serial" ReadOnly="True" SortExpression="MeterSerial" />
            <asp:CommandField ShowSelectButton="True" SelectText="View Bills &gt;&gt;" />
        </Columns>
    </asp:GridView>
</asp:Content>
