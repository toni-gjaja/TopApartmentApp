<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="NewApartment.aspx.cs" Inherits="Administration.NewApartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:Panel ID="NewApartmentForm" CssClass="d-flex justify-content-center mt-3" runat="server" Visible="true" data-aos="flip-up">

        <div class="bg-dark text-muted p-5 rounded w-50">

            <div class="d-flex justify-content-center m-3">

                <label for="apOwner" class="col-sm-2 col-form-label">Vlasnik:</label>

                <div>

                    <asp:DropDownList ID="apOwner" runat="server">

                    </asp:DropDownList>
                </div>
            </div>

            <div class="d-flex justify-content-center">

                <asp:CustomValidator ID="OwnerValidator" runat="server" ControlToValidate="apOwner" OnServerValidate="DropdownValidation" Display="Dynamic" ForeColor="Red" ErrorMessage="* Niste odabrali vlasnika"></asp:CustomValidator>

            </div>

            <div class="d-flex justify-content-center m-3">

                <label for="apStatus" class="col-sm-2 col-form-label">Status:</label>

                <div>

                    <asp:DropDownList ID="apStatus" runat="server">

                        <asp:ListItem Text="Slobodno" Value="3" />
                        <asp:ListItem Text="Zauzeto" Value="1"/>
                        <asp:ListItem Text="Rezervirano" Value="2" />
                        
                    </asp:DropDownList>
                </div>
            </div>

            <div class="d-flex justify-content-center">

                <asp:CustomValidator ID="StatusValidator" runat="server" ControlToValidate="apStatus" OnServerValidate="DropdownValidation" Enabled="true" Display="Dynamic" ForeColor="Red" ErrorMessage="* Niste odabrali status"></asp:CustomValidator>

            </div>

            <div class="d-flex justify-content-center m-3">

                <label for="apCity" class="col-sm-2 col-form-label">Grad:</label>

                <div>

                    <asp:DropDownList ID="apCity" runat="server">


                   </asp:DropDownList>

                </div>
            </div>

            <div class="d-flex justify-content-center">

                <asp:CustomValidator ID="CityValidator" runat="server" ControlToValidate="apCity" OnServerValidate="DropdownValidation" Display="Dynamic" ForeColor="Red" ErrorMessage="* Niste odabrali grad"></asp:CustomValidator>

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

            <div id="apCreateButtons" class="d-flex justify-content-center">

                <asp:Button class="btn btn-secondary m-2" ID="btnCancel" CausesValidation="False" runat="server" Text="Natrag" OnClick="btnCancel_Click" />
                <asp:Button class="btn btn-success m-2" ID="btnCreate" runat="server" Text="Kreiraj" OnClick="btnCreate_Click" />

            </div>

        </div>

    </asp:Panel>
</asp:Content>
