<%@ Page Title="" Language="C#" MasterPageFile="~/Standard.master" AutoEventWireup="true"
    CodeBehind="EditBuilding.aspx.cs" Inherits="EnergyCAP.EditBuilding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Edit Building</h2>
    <p>
        Update the desired fields for the selected building, then click <strong>Submit 
        Changes</strong> when finished.<br />
    </p>
    <table class="ecapTable">
        <tr>
            <td class="ecapHeader">
                <strong>Item</strong>
            </td>
            <td class="ecapHeader">
                <strong>Value</strong>
            </td>
        </tr>
        <tr>
            <td class="ecapRowName">
                <p>Building Code</p>
            </td>
            <td class="ecapRow">
                <asp:TextBox ID="txtBuildingCode" Width="50%" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="ecapRowName">
                <p>Building Name</p>
            </td>
            <td class="ecapRow">
                <asp:TextBox ID="txtBuildingName" Width="100%" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="ecapRowName">
                <p>Building Memo</p>
            </td>
            <td class="ecapRow">
                <asp:TextBox ID="txtBuildingMemo" Width="100%" runat="server" Rows="10" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ecapRow" style="text-align:right;">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />
                &nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
