<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubjectInGroupCreatePage.aspx.cs" Inherits="WebFormsClient.SubjectInGroupCreatePage"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="SubjectInroupCreatePage" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label" runat="server" Text=""></asp:Label>
    </div>
    <label>Select subject</label>
    <asp:DropDownList ID="dropdownSubject" runat="server" ></asp:DropDownList><br />
    <label>Select group</label>    
    <asp:DropDownList ID="dropdownGroup" runat="server" ></asp:DropDownList><br />


    <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
    <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>
