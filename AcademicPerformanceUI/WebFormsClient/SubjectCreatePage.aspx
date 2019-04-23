<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SubjectCreatePage.aspx.cs" Inherits="WebFormsClient.SubjectCreatePage" %>

<asp:Content ID="SubjectCreatePage" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Label ID="Label" runat="server" Text=""></asp:Label>
        </div>
                <label>Input name</label>
                <asp:TextBox ID="subjectName" runat="server" Text=""></asp:TextBox><br />
                <label>Input finaltesttype</label>
                <asp:TextBox ID="subjectTestType" runat="server" Text=""></asp:TextBox><br />
                <label>Input hours</label>
                <asp:TextBox ID="subjectHours" runat="server" Text=""></asp:TextBox><br />
                <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
                <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>