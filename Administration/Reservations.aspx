<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="Administration.Reservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:Panel ID="ReservationAlert" CssClass="m-4" runat="server" Visible="false" data-aos="zoom-in-left">

        <div class="alert alert-info d-flex justify-content-center" role="alert">
            Trenutno nema rezervacija!
        </div>

    </asp:Panel>

    <asp:Panel ID="AllRegUserReservations" runat="server" Visible="true" data-aos="zoom-in-left">

        <asp:Repeater ID="RegUserResRepeater" runat="server">

            <HeaderTemplate>

                <table class="table table-striped table-dark mt-4" id="MyTable">

                    <thead>

                        <tr>

                            <div class="alert alert-info d-flex justify-content-center" role="alert">
                                Rezervacije registriranih korisnika
                            </div>

                            <th scope="col" meta:resourcekey="rId">Id rezervacije</th>
                            <th scope="col" meta:resourcekey="rApId">Id apartmana</th>
                            <th scope="col" meta:resourcekey="rApName">Naziv apartmana</th>
                            <th scope="col" meta:resourcekey="rDetails">Detalji</th>
                            <th scope="col" meta:resourcekey="rUserId">Id korisnika</th>
                            <th scope="col" meta:resourcekey="rUserName">Ime korisnika</th>
                            <th scope="col"></th>

                        </tr>

                    </thead>

                    <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>

                    <td scope="row"><%#Eval(nameof(DatabaseLib.MODELS.Reservation.Id)) %></td>
                    <td><%#Eval(nameof(DatabaseLib.MODELS.Reservation.ApartmentId))%></td>
                    <td><%#Eval(nameof(DatabaseLib.MODELS.Reservation.ApartmentName))%></td>
                    <td><%#Eval(nameof(DatabaseLib.MODELS.Reservation.Details)) %></td>
                    <td><%#Eval(nameof(DatabaseLib.MODELS.Reservation.UserId)) %></td>
                    <td><%#Eval(nameof(DatabaseLib.MODELS.Reservation.UserName)) %></td>
                    <td>
                        <asp:LinkButton class="btn btn-secondary" OnClick="LinkButton_Click" CommandArgument="<%#Eval(nameof(DatabaseLib.MODELS.Reservation.Id)) %>" ID="LinkButton" runat="server">Detalji</asp:LinkButton></td>

                </tr>

            </ItemTemplate>

        </asp:Repeater>

    </asp:Panel>

    <asp:Panel ID="UnRegReservationAlert" CssClass="m-4" runat="server" Visible="false" data-aos="zoom-in-right">

        <div class="alert alert-info d-flex justify-content-center" role="alert">
            Trenutno nema rezervacija neregistriranih korisnika!
        </div>

    </asp:Panel>

    <asp:Panel ID="AllUnRegUserReservations" runat="server" Visible="true" data-aos="zoom-in-right">

        <asp:Repeater ID="UnRegUserRepeater" runat="server">

            <HeaderTemplate>

                <table class="table table-striped table-dark mt-4" id="MyTable1">

                    <thead>

                        <div class="alert alert-info d-flex justify-content-center" role="alert">
                            Rezervacije neregistriranih korisnika
                        </div>

                        <tr>

                            <th scope="col" meta:resourcekey="urId">Id rezervacije</th>
                            <th scope="col" meta:resourcekey="urApId">Id apartmana</th>
                            <th scope="col" meta:resourcekey="urApName">Naziv apartmana</th>
                            <th scope="col" meta:resourcekey="urDetails">Detalji</th>
                            <th scope="col"></th>

                        </tr>

                    </thead>

                    <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>

                    <td scope="row"><%#Eval(nameof(DatabaseLib.MODELS.UnRegUserReservation.Id)) %></td>
                    <td><%#Eval(nameof(DatabaseLib.MODELS.UnRegUserReservation.ApartmentId))%></td>
                    <td><%#Eval(nameof(DatabaseLib.MODELS.UnRegUserReservation.ApartmentName))%></td>
                    <td><%#Eval(nameof(DatabaseLib.MODELS.UnRegUserReservation.Details)) %></td>
                    <td>
                        <asp:LinkButton class="btn btn-secondary" OnClick="UnReg_LinkButton_Click" CommandArgument="<%#Eval(nameof(DatabaseLib.MODELS.UnRegUserReservation.Id)) %>" ID="UnRegLinkButton" runat="server">Detalji</asp:LinkButton></td>

                </tr>

            </ItemTemplate>

        </asp:Repeater>

    </asp:Panel>


    <asp:Panel ID="ChosenReservation" runat="server" Visible="false">

        <div class="alert alert-info d-flex justify-content-center" role="alert">
            Trenutno pregledavate rezervaciju sa Id-om
            <asp:Label ID="ChosenResIdTb" CssClass="px-1" runat="server"></asp:Label>
        </div>

        <div class="d-flex justify-content-center m-3">

            <asp:Button class="btn btn-secondary m-1" ID="btnCancel" runat="server" Text="Natrag" OnClick="btnCancel_Click" />
            <asp:Button class="btn btn-danger m-1" ID="btnDelete" runat="server" Text="Izbriši rezervaciju" OnClick="btnDelete_Click" OnClientClick="return confirm('Jeste li sigurni?')" />

        </div>

        <div class="d-flex justify-content-around w-100">

            <div class="col-md-6 mt-2 bg-dark text-muted border border-info rounded" id="ResAp" style="width: 40%" data-aos="fade-right">

                <div class="d-flex justify-content-center m-3">

                    <label for="apId" class="col-sm-2 col-form-label">Id apartmana:</label>

                    <asp:Label ID="apId" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apName" class="col-sm-2 col-form-label">Naziv:</label>

                    <asp:Label ID="apName" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apOwner" class="col-sm-2 col-form-label">Vlasnik:</label>

                    <asp:Label ID="apOwner" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apCity" class="col-sm-2 col-form-label">Grad:</label>

                    <asp:Label ID="apCity" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apAddress" class="col-sm-2 col-form-label">Adresa:</label>

                    <asp:Label ID="apAddress" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apPrice" class="col-sm-2 col-form-label">Cijena:</label>

                    <asp:Label ID="apPrice" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>


            </div>

            <div class="col-md-6 mt-2 bg-dark text-muted border border-info rounded" id="ResUsr" style="width: 40%" data-aos="fade-left">

                <div class="d-flex justify-content-center m-3">

                    <label for="uId" class="col-sm-2 col-form-label">Id korisnika:</label>

                    <asp:Label ID="uId" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="uName" class="col-sm-2 col-form-label">Ime:</label>

                    <asp:Label ID="uName" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="uPhone" class="col-sm-2 col-form-label">Broj mobitela:</label>

                    <asp:Label ID="uPhone" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="uAddress" class="col-sm-2 col-form-label">Adresa:</label>

                    <asp:Label ID="uAddress" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="uMail" class="col-sm-2 col-form-label">Email:</label>

                    <asp:Label ID="uMail" CssClass="col-sm-2 col-form-label" runat="server" Text=""></asp:Label>

                </div>


            </div>

        </div>



    </asp:Panel>















</asp:Content>
