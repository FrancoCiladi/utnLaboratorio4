<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="socConsultaSocios.aspx.vb" Inherits="TrabajoFinalLabo4_CiladiFranco.frmConsultaSocios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row mt-2">
        <div class="col-12 col-md-4">
            <div class="card">
                <div class="card-header">
                    <h5>Buscar Socios</h5>
                </div>

                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-12 col-md-2">
                            Apellido
                        </div>
                        <div class="col-12 col-md-10">
                            <asp:TextBox ID="txtApellidoSocio" AutoCompleteType="Disabled" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>


    <asp:Panel ID="pnlListadoSocios" runat="server" Visible="false">
        <hr />

        <div class="row">
            <div class="col-12 col-md-6">
                <div class="card">
                    <div class="card-body">
                        <asp:GridView ID="gvSocios" CssClass="table table-sm mt-1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="nro_socio">
                                    <HeaderStyle CssClass="d-none" />
                                    <ItemStyle CssClass="d-none" />
                                </asp:BoundField>
                                <%--campo hyperlynk para el apellido y nombre del socio que envia al formulario socSocioDetalle el nro de socio del apellido y nombre seleccionado--%>
                                <asp:HyperLinkField DataNavigateUrlFields="nro_socio" DataNavigateUrlFormatString="socSocioDetalle.aspx?a={0}" DataTextField="apynom" HeaderText="Socio"></asp:HyperLinkField>
                                <asp:BoundField DataField="direccion" HeaderText="Direccion">
                                    <HeaderStyle CssClass="d-none d-md-table-cell" />
                                    <ItemStyle CssClass="d-none d-md-table-cell" />
                                </asp:BoundField>
                                <asp:BoundField DataField="mail" HeaderText="Mail">
                                    <HeaderStyle CssClass="d-none d-md-table-cell" />
                                    <ItemStyle CssClass="d-none d-md-table-cell" />
                                </asp:BoundField>
                                <asp:BoundField DataField="telefono" HeaderText="Telefono"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>



</asp:Content>
