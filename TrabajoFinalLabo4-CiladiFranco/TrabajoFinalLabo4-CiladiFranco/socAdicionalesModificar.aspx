<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="socAdicionalesModificar.aspx.vb" Inherits="TrabajoFinalLabo4_CiladiFranco.socAdicionalesModificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-2">
        <div class="col-12 col-md-4">
            <div class="card">
                <div class="card-header">
                    <h5>Buscar adicionales de socio</h5>
                </div>

                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-12 col-md-2">
                            Nro. Socio
                        </div>
                        <div class="col-12 col-md-8">
                            <asp:TextBox ID="txtNroSocio" AutoCompleteType="Disabled" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-2 mt-2 mt-md-0">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <asp:Panel ID="pnlError" runat="server" Visible="false">
                        <div class="form-group row">
                            <div class="col">
                                <div class="alert alert-danger">
                                    No se encontro el socio!
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>

            </div>
        </div>
    </div>

    <asp:Panel ID="pnlAdicionales" runat="server" Visible="false">
        <hr />

        <div class="row">
            <div class="col-12 col-md-6">
                <div class="card">

                    <div class="card-header">
                        <h5>
                            <asp:Label ID="lblNombreSocio" runat="server" Text=""></asp:Label>
                        </h5>
                    </div>

                    <div class="card-body">

                        <asp:Panel ID="pnlMensaje" runat="server" Visible="false">
                            <div class="form-group row">
                                <div class="col">
                                    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="alert alert-success" Width="100%"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>

                        <div class="form-group row">
                            <div class="col">
                                <asp:GridView ID="gvAdicionales" CssClass="table table-sm mt-1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="cod_adicional" HeaderText="Cod_adicional">
                                            <HeaderStyle CssClass="d-none"></HeaderStyle>
                                            <ItemStyle CssClass="d-none"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField>
                                            <HeaderStyle CssClass="d-none"></HeaderStyle>
                                            <ItemStyle CssClass="d-none"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="descripcion" HeaderText="Adicional"></asp:BoundField>
                                        <asp:BoundField DataField="costo_mensual" HeaderText="Costo ($)"></asp:BoundField>
                                        <asp:TemplateField HeaderText="INS">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkInscripto" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="45px" />
                                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                        <div class="form-group row">
                            <div class="col-12">
                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn btn-success float-right" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
