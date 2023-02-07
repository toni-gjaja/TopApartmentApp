<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DashboardUsers.aspx.cs" Inherits="Administration.DashboardUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="col-md-6 mt-2" style="width: 100%" id="parent" data-aos="fade-down"
        data-aos-easing="linear"
        data-aos-duration="500">

        <asp:Panel ID="AllUsers" runat="server" Visible="true">

            <asp:Repeater ID="UsersRepeater" runat="server">

                <HeaderTemplate>

                    <table class="table table-striped table-dark" id="MyTable">

                        <thead>

                            <tr>

                                <th scope="col" meta:resourcekey="aName">Ime</th>
                                <th scope="col" meta:resourcekey="aAddress">Adresa</th>
                                <th scope="col" meta:resourcekey="aPhone">Broj mobitela</th>
                                <th scope="col" meta:resourcekey="aPhoneConf">Broj potvrđen</th>
                                <th scope="col" meta:resourcekey="aMail">Mail</th>
                                <th scope="col" meta:resourcekey="aMailConf">Mailpotvrđen</th>

                            </tr>

                        </thead>

                        <tbody>
                </HeaderTemplate>

                <ItemTemplate>

                    <tr>

                        <td scope="row"><%#Eval(nameof(DatabaseLib.MODELS.User.Name)) %></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.User.Address))%></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.User.PhoneNumber))%></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.User.PhoneNumberConfirmed))%></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.User.Mail)) %></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.User.MailConfirmed)) %></td>

                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </asp:Panel>

    </div>



</asp:Content>
