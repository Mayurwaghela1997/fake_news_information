<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div>
    <table style="align-content:center; padding-top:15px">
        <tr>
            <td style="background-color:grey"> Please enter a username</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td> 
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
        </center>
    </asp:Content>

