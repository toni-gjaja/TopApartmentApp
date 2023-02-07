<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="Administration.Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="d-flex justify-content-center m-3">

        <asp:Button class="btn btn-primary m-1" ID="btnUnused" runat="server" Text="Nekorištene oznake" OnClick="btnUnused_Click" />
        <asp:Button class="btn btn-primary m-1" ID="btnAssigned" runat="server" Text="Označeni apartmani" OnClick="btnAssigned_Click"/>
        <asp:Button class="btn btn-primary m-1" ID="btnTagApartment" runat="server" Text="Označi apartman" OnClick="btnTagApartment_Click"/>
        <asp:Button class="btn btn-primary m-1" ID="btnAddNewTag" runat="server" Text="Dodaj novi tag" OnClick="btnAddNewTag_Click"/>

    </div>

    <div class="d-flex justify-content-around w-100">

        <asp:Panel class="col-md-6 mt-2 bg-dark text-muted rounded" id="UnusedTags" style="width: 40%" runat="server" Visible="true" data-aos="fade-right">

            <asp:Repeater ID="UnusedTagsRepeater" runat="server" >

                <HeaderTemplate>

                    <table class="table table-striped table-dark mt-4" id="MyTable">

                        <thead>

                            <div class="alert alert-info d-flex justify-content-center" role="alert">
                                Nekorištene oznake
                            </div>

                            <tr>

                                <th scope="col" meta:resourcekey="uId">Id</th>
                                <th scope="col" meta:resourcekey="uId">Naziv</th>
                                <th scope="col" meta:resourcekey="uType">Tip</th>
                                <th scope="col"></th>

                            </tr>

                        </thead>

                        <tbody>
                </HeaderTemplate>

                <ItemTemplate>

                    <tr>

                        <td scope="row"><%#Eval(nameof(DatabaseLib.MODELS.UnusedTag.Id)) %></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.UnusedTag.Name))%></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.UnusedTag.Type))%></td>
                        <td>
                            <asp:LinkButton class="btn btn-danger" CommandArgument="<%#Eval(nameof(DatabaseLib.MODELS.UnusedTag.Id)) %>" ID="UnusedTagLinkButton" OnClick="btnUnusedDelete_Click" OnClientClick="return confirm('Jeste li sigurni?')" runat="server">Izbriši</asp:LinkButton></td>

                    </tr>

                </ItemTemplate>

            </asp:Repeater>
        </asp:Panel>

        <asp:Panel class="col-md-6 mt-2 bg-dark text-muted rounded" id="AssignedTags" style="width: 40%" runat="server" Visible="false" data-aos="fade-left">

            <asp:Repeater ID="AssignedTagsRepeater" runat="server" >

                <HeaderTemplate>

                    <table class="table table-striped table-dark mt-4" id="MyTable">

                        <thead>

                            <div class="alert alert-info d-flex justify-content-center" role="alert">
                                Označeni apartmani
                            </div>

                            <tr>

                                <th scope="col" meta:resourcekey="aId">Id</th>
                                <th scope="col" meta:resourcekey="aName">Naziv</th>
                                <th scope="col" meta:resourcekey="aType">Tip</th>
                                <th scope="col" meta:resourcekey="aApart">Apartman</th>

                            </tr>

                        </thead>

                        <tbody>
                </HeaderTemplate>

                <ItemTemplate>

                    <tr>

                        <td scope="row"><%#Eval(nameof(DatabaseLib.MODELS.AssignedTag.Id)) %></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.AssignedTag.Name))%></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.AssignedTag.Type))%></td>
                        <td><%#Eval(nameof(DatabaseLib.MODELS.AssignedTag.ApartmentName))%></td>

                    </tr>

                </ItemTemplate>

            </asp:Repeater>


        </asp:Panel>

        <asp:Panel ID="AddNewTag" style="width: 40%" Visible="false" data-aos="fade-left" runat="server">

            <div class="bg-dark text-muted p-5 rounded">

                <div class="d-flex justify-content-center m-3">

                    <label for="tagType" class="col-sm-2 col-form-label">Tip:</label>

                    <div>

                        <asp:DropDownList ID="tagType" runat="server">
                        </asp:DropDownList>

                    </div>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="tagNameCro" class="col-sm-2 col-form-label">Naziv:</label>

                    <div>

                        <asp:TextBox ID="tagNameCro" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="tagNameEng" class="col-sm-2 col-form-label">Naziv Eng:</label>

                    <div>

                        <asp:TextBox ID="tagNameEng" runat="server" Text=""></asp:TextBox>

                    </div>

                </div>

                <div class="d-flex justify-content-center m-3 w-100 ">

                    <asp:Label CssClass="w-100 col-sm-2 col-form-label text-danger text-center" ID="fieldWarning" runat="server" Text=""></asp:Label>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <asp:Button CssClass="btn btn-success" ID="btnAddTag" runat="server" Text="Dodaj" OnClick="addNewTagClick" />

                </div>

            </div>




        </asp:Panel>

        <asp:Panel ID="AddTagToApartment" runat="server" Visible="false" style="width: 40%" data-aos="fade-left">

            <div class="bg-dark text-muted p-5 rounded">

                <div class="d-flex justify-content-center m-3">

                    <label for="Apartments" class="col-sm-2 col-form-label">Apartman:</label>

                    <div>

                        <asp:DropDownList ID="Apartments" runat="server">
                        </asp:DropDownList>

                    </div>

                </div>

                <div class="d-flex justify-content-center m-3">

                    <label for="TagsForAp" class="col-sm-2 col-form-label">Tag:</label>

                    <div>

                        <asp:DropDownList ID="TagsForAp" runat="server">
                        </asp:DropDownList>

                    </div>

                </div>


                <div class="d-flex justify-content-center m-3">

                    <asp:Button ID="btnTagAp" CssClass="btn btn-success" runat="server" Text="Dodaj" OnClick="addTagToApartmentClick"/>

                </div>



            </div>

        </asp:Panel>



    </div>

</asp:Content>
