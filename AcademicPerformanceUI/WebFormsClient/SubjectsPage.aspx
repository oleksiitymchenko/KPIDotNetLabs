<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubjectsPage.aspx.cs" Inherits="WebFormsClient.SubjectsPage" MasterPageFile="~/Site.Master"%>
<%@ Import Namespace="WcfRestService.DTOModels" %>

<asp:Content ID="SubjectsPage" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Subjects list </h1>
        <asp:Button runat="server" class='btn btn-warning' OnClick="OnClick" Text="Create" role='button'></asp:Button>
        <hr>
        <asp:Repeater ID="Repeater" runat="server" onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div>
                    <span>Id: <%#Eval("Id") %></span>
                    <h5>Name: <%#Eval("Name") %></h5>
                    <h6>FinalTestType:  <%#Eval("FinalTestType") %></h6>
                    <h6>Hours:  <%#Eval("Hours") %></h6>
                </div>
                <asp:Button ID="test" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Update"></asp:Button>
                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Delete"></asp:Button>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>