<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NewOwner.aspx.cs" Inherits="Administration.NewOwner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:Panel ID="NewOwnerForm" CssClass="d-flex justify-content-center mt-3" runat="server" data-aos="flip-up">

        <div class="bg-dark text-muted p-5 rounded w-50">

            <div class="d-flex justify-content-center m-3">

                <label for="apFirstName" class="col-sm-2 col-form-label">Ime:</label>

                <div>

                    <asp:TextBox ID="apFirstName" runat="server" Text=""></asp:TextBox>

                </div>

            </div>

            <div class="d-flex justify-content-center">

                <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server" ControlToValidate="apFirstName" Display="Dynamic" ForeColor="Red">* Niste upisali ime</asp:RequiredFieldValidator>

            </div>

            <div class="d-flex justify-content-center m-3">

                <label for="apLastName" class="col-sm-2 col-form-label">Prezime:</label>

                <div>

                    <asp:TextBox ID="apLastName" runat="server" Text=""></asp:TextBox>

                </div>

            </div>

            <div class="d-flex justify-content-center">

                <asp:RequiredFieldValidator ID="LastNameValidator" runat="server" ControlToValidate="apLastName" Display="Dynamic" ForeColor="Red">* Niste upisali prezime</asp:RequiredFieldValidator>

            </div>

            <div id="apCreateButtons" class="d-flex justify-content-center">

                <asp:Button class="btn btn-secondary m-2" ID="btnCancel" CausesValidation="False" runat="server" Text="Natrag" OnClick="btnCancel_Click" />
                <asp:Button class="btn btn-success m-2" ID="btnCreate" runat="server" Text="Kreiraj" OnClick="btnCreate_Click" />

            </div>

        </div>

    </asp:Panel>


</asp:Content>
