<%@ Page Title="" Language="C#" MasterPageFile="~/Standard.master" AutoEventWireup="true"
    CodeBehind="EditBuilding.aspx.cs" Inherits="EnergyCAP.EditBuilding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Edit Building</h2>
    <p>
        Update the desired fields for the selected building, then click <strong>Submit 
        Changes</strong> when finished.<br />
    </p>
    <table style="width:600px;">
        <tr>
            <th style="width:200px;">
                <strong>Field</strong>
            </th>
            <th>
                <strong>Value</strong>
            </th>
        </tr>
        <tr>
            <td>
                <p>Building Code</p>
            </td>
            <td>
                <asp:TextBox ID="txtBuildingCode" Width="50%" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p>Building Name</p>
            </td>
            <td>
                <asp:TextBox ID="txtBuildingName" Width="100%" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p>Building Memo</p>
            </td>
            <td>
                <asp:TextBox ID="txtBuildingMemo" Width="100%" runat="server" Rows="10" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right;">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />
                &nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
