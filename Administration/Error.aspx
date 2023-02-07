<%@ Page Title="Error" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Administration.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
       <fieldset id="form1" class="container text-center">
        <h1>BAD REQUEST - Status code: 400</h1>
        <p>U zahtjevu nisu poslani svi parametri.</p>
    </fieldset>
</asp:Content>
