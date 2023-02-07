<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Administration.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="col-md-6 mt-2" style="width: 100%" id="parent" data-aos="zoom-in-up">

        <asp:Panel ID="AllApartments" runat="server" Visible="true">

            <asp:Repeater ID="ApartmentsRepeater" runat="server">

                <HeaderTemplate>

                    <table class="table table-striped table-dark" id="MyTable">

                        <thead>

                            <tr>

                                <th scope="col" meta:resourcekey="aName">Naziv</th>
                                <th scope="col" meta:resourcekey="aOwner">Vlasnik</th>
                                <th scope="col" meta:resourcekey="aCity">Grad</th>
                                <th scope="col" meta:resourcekey="aAdults">Odrasli</th>
                                <th scope="col" meta:resourcekey="aChildren">Djeca</th>
                                <th scope="col" meta:resourcekey="aRooms">Sobe</th>
                                <th scope="col" meta:resourcekey="aPrice">Cijena</th>
                                <th scope="col"></th>

                            </tr>

                        </thead>

                        <tbody>
                </HeaderTemplate>

                <ItemTemplate>

                    <tr>

                        <td scope="row"><%#Eval(nameof(DatabaseLib.MODELS.Apartment.Name)) %></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.Apartment.Owner))%></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.Apartment.City))%></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.Apartment.MaxAdults)) %></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.Apartment.MaxChildren)) %></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.Apartment.TotalRooms)) %></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.Apartment.Price)) %>HRK</td>
                        <td>
                            <asp:LinkButton class="btn btn-secondary" OnClick="LinkButton_Click" CommandArgument="<%#Eval(nameof(DatabaseLib.MODELS.Apartment.Id)) %>" ID="LinkButton" runat="server">Detalji</asp:LinkButton></td>

                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </asp:Panel>

        <div class="d-flex justify-content-center m-3">

            <asp:Button class="btn btn-primary m-1" ID="btnAddNewApartment" runat="server" Text="Dodaj novi apartman" OnClick="btnAddNewApartment_Click" Visible="true" />
            <asp:Button class="btn btn-primary m-1" ID="btnAddNewOwner"  runat="server" Text="Dodaj novog vlasnika" Visible="true" OnClick="btnAddNewOwner_Click" />

        </div>

        <asp:Panel ID="SelectedApartment" CssClass="d-flex justify-content-center" runat="server" Visible="false" data-aos="zoom-in-up">

            <div class="bg-dark text-muted p-5 rounded w-50">

                <div class="d-flex justify-content-center m-3">

                    <label for="apStatus" class="col-sm-2 col-form-label">Status:</label>

                    <div>

                        <asp:DropDownList ID="apStatus" runat="server">

                            <asp:ListItem ID="apCurrentStatus" Text="" Selected="true" />
                            <asp:ListItem Text="Zauzeto" />
                            <asp:ListItem Text="Rezervirano" />
                            <asp:ListItem Text="Slobodno" />

                        </asp:DropDownList>

                    </div>
                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apAddress" class="col-sm-2 col-form-label">Adresa:</label>

                    <div>

                        <asp:TextBox ID="apAddress" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center">

                    <asp:RequiredFieldValidator ID="AddressValidator" runat="server" ControlToValidate="apAddress" Display="Dynamic" ForeColor="Red">* Niste upisali adresu</asp:RequiredFieldValidator>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apName" class="col-sm-2 col-form-label">Naziv:</label>

                    <div>

                        <asp:TextBox ID="apName" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center">

                    <asp:RequiredFieldValidator ID="NameValidator" runat="server" ControlToValidate="apName" Display="Dynamic" ForeColor="Red">* Niste upisali naziv</asp:RequiredFieldValidator>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apNameEng" class="col-sm-2 col-form-label">Naziv Eng:</label>

                    <div>

                        <asp:TextBox ID="apNameEng" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center">

                    <asp:RequiredFieldValidator ID="NameEngValidator" runat="server" ControlToValidate="apNameEng" Display="Dynamic" ForeColor="Red">* Niste upisali Naziv eng</asp:RequiredFieldValidator>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apPrice" class="col-sm-2 col-form-label">Cijena:</label>

                    <div>

                        <asp:TextBox type="number" ID="apPrice" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center">

                    <asp:RequiredFieldValidator ID="PriceValidator" runat="server" ControlToValidate="apPrice" Display="Dynamic" ForeColor="Red">* Niste upisali cijenu</asp:RequiredFieldValidator>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apMaxAdults" class="col-sm-2 col-form-label">Odrasli:</label>

                    

                    <div>

                        <asp:TextBox type="number" ID="apMaxAdults" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center">

                    <asp:RequiredFieldValidator ID="MaxAdultValidator" runat="server" ControlToValidate="apMaxAdults" Display="Dynamic" ForeColor="Red">* Niste upisali broj odraslih</asp:RequiredFieldValidator>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apMaxChildren" class="col-sm-2 col-form-label">Djeca:</label>

                    <div>

                        <asp:TextBox type="number" ID="apMaxChildren" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center">

                    <asp:RequiredFieldValidator ID="MaxChildrenValidator" runat="server" ControlToValidate="apMaxChildren" Display="Dynamic" ForeColor="Red">* Niste upisali broj djece</asp:RequiredFieldValidator>

                </div>

                <div class="d-flex justify-content-center">

                    <label for="apRooms" class="col-sm-2 col-form-label">Sobe:</label>

                    <div>

                        <asp:TextBox type="number" ID="apRooms" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center">

                    <asp:RequiredFieldValidator ID="RoomsValidator" runat="server" ControlToValidate="apRooms" Display="Dynamic" ForeColor="Red">* Niste upisali broj soba</asp:RequiredFieldValidator>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="apBeachDistance" class="col-sm-2 col-form-label">Udaljenost od plaže:</label>

                    <div>

                        <asp:TextBox type="number" ID="apBeachDistance" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center">

                    <asp:RequiredFieldValidator ID="BeachDistanceValidator" runat="server" ControlToValidate="apBeachDistance" Display="Dynamic" ForeColor="Red">* Niste upisali udaljenost od plaže</asp:RequiredFieldValidator>

                </div>

                <div id="apActionButtons" class="d-flex justify-content-center">

                    <asp:Button class="btn btn-secondary m-2" ID="btnCancel" CausesValidation="False" runat="server" Text="Natrag" OnClick="btnCancel_Click" />
                    <asp:Button class="btn btn-success m-2" ID="btnUpdate" runat="server" Text="Ažuriraj" OnClick="btnUpdate_Click" OnClientClick="return confirm('Jeste li sigurni?')" />
                    <asp:Button class="btn btn-warning m-2" ID="btnDelete" CausesValidation="False" runat="server" Text="Izbriši" OnClick="btnDelete_Click" OnClientClick="return confirm('Jeste li sigurni?')" />

                </div>

            </div>

        </asp:Panel>

    </div>
















</asp:Content>
