<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" style="display: none;" Text="0"></asp:Label>
    <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblThanks" Visible="false" Text="Thanks for your input" runat="server"></asp:Label>
            <div id="divContent" runat="server" visible="true">
                <p style="text-align:center">
                    
                    <iframe id="urlIframe" width="500" height="409" style="border:none;overflow:hidden" frameborder="0" scrolling="yes" allowTransparency="true" allow="encrypted-media" runat="server"></iframe>
                    <br />
                    <br />
                    <b>Prior Knowledge</b>
                    <input  type="range" id="priorKnowledgeslider" value="0" min="0" max="1" step="0.1" onchange="showvalue(this.value)" runat ="server"/>
                    <br />
                    <b>Believability Index</b>
                    <input  type="range" id="believabilitySlider"  style=" border-radius: 5px;" value="0" min="0" max="1" step="0.1" onchange="showvalue(this.value)" runat ="server"/>
                    <br />
                    <br />
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
