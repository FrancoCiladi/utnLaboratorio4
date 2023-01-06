<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/labo4.Master" CodeBehind="aluConsulta2.aspx.vb" Inherits="labo4_2023.aluConsulta2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-2">
        <div class="col-12 col-md-6">
            <%--DENTRO DEL MARCO--%>
            <div class="row">
                <div class="col">
                    <h4>Consulta Alumnos 2</h4>
                </div>
            </div>
            <hr />

            <div class="row">
                <div class="col-6">
                    <asp:TextBox ID="txtApellido" AutoCompleteType="Disabled" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-6">
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" />
                
                    <asp:Button ID="btnPrueba" runat="server" Text="Button" />
                
                </div>
            </div>

            <div class="row mt-1">
                <div class="col">
                    <asp:Repeater ID="repAlumnos" runat="server">
                        <ItemTemplate>
                            <div class="card mt-1 shadow-sm">
                                <div class="card-header p-1">
                                    <div class="row">
                                        <div class="col">
                                            <h5><%#Eval("apynom") %></h5>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-body p-1">
                                    <div class="row">
                                        <div class="col-3">
                                            DNI
                                        </div>
                                        <div class="col-9">
                                            <%#Eval("dni") %>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-3">
                                            Telefono
                                        </div>
                                        <div class="col-9">
                                            <a href='https://wa.me/+54{0}<%#Eval("telefono") %>'><%#Eval("telefono") %></a>
                                            <asp:Label ID="lblTelefonoMensaje" runat="server" CssClass="alert-danger" Text="Sin Telefono" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-3">
                                            Legajo
                                        </div>
                                        <div class="col-9">
                                            <%#Eval("nro_legajo") %>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>

        </div>
    </div>

</asp:Content>
