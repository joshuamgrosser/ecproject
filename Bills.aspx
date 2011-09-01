<%@ Page Title="" Language="C#" MasterPageFile="~/Standard.master" AutoEventWireup="true"
    CodeBehind="Bills.aspx.cs" Inherits="EnergyCAP.Bills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Bills</h2>
    <p>
        This page shows the <strong>Bills</strong> associated with the selected meter.</p>
    <p>
        You are currently viewing bills for: <asp:Label runat="server" ID="lblMeter"></asp:Label>.
    </p>
    <p>
        <asp:GridView ID="grdBills" runat="server" AllowSorting="False" AutoGenerateColumns="False"
            DataKeyNames="BillMtrID" Width="100%" EmptyDataText="<p>Please first select a building from the Buildings page, then select a meter from the Meters page.</p>">
            <Columns>
                <asp:BoundField DataField="BillMtrID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="BillMtrID" />
                <asp:BoundField DataField="MtrCost" HeaderText="Code" ReadOnly="True" SortExpression="MtrCost" />
                <asp:BoundField DataField="MtrUse" HeaderText="Use" ReadOnly="True" SortExpression="MtrUse" />
                <asp:BoundField DataField="MtrBDem" HeaderText="BDem" ReadOnly="True" SortExpression="MtrBDem" />
                <asp:BoundField DataField="MtrADem" HeaderText="ADem" ReadOnly="True" SortExpression="MtrADem" />
                <asp:BoundField DataField="MtrStartDate" HeaderText="Start Date" ReadOnly="True"
                    SortExpression="MtrStartDate" />
                <asp:BoundField DataField="MtrEndDate" HeaderText="End Date" ReadOnly="True" SortExpression="MtrEndDate" />
                <asp:BoundField DataField="ReportYear" HeaderText="Report Year" ReadOnly="True" SortExpression="ReportYear" />
                <asp:BoundField DataField="ReportMonth" HeaderText="Report Month" ReadOnly="True"
                    SortExpression="ReportMonth" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
