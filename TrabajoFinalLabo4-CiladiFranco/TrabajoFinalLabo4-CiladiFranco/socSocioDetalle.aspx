<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="socSocioDetalle.aspx.vb" Inherits="TrabajoFinalLabo4_CiladiFranco.frmSocioDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-2">
        <div class="col-12 col-md-6">

            <div class="card">
                <div class="card-header">
                    <ul class="nav nav-tabs card-header-tabs">
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkDetalles" runat="server" Class="nav-link active">Detalles</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkGrupoFamiliar" runat="server" Class="nav-link">Grupo Familiar</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkAdicionales" runat="server" Class="nav-link">Adicionales</asp:LinkButton>
                        </li>
                    </ul>
                </div>

                <div class="card-body">
                    <asp:Panel ID="pnlDetalles" runat="server" Visible="true">
                       <%-- poner todos los txt y demas con los detalles--%>
                        
                        <div class="form-group row">
                            <div class="col-12 col-md-3">
                                Apellido y Nombre
                            </div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="txtApellidoNombre" runat="server" class="form-control" ReadOnly="true" BackColor="White"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-12 col-md-3">
                                Nro. Documento
                            </div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="txtNroDoc" runat="server" class="form-control" ReadOnly="true" BackColor="White" ></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-12 col-md-3">
                                Fecha Nacimiento
                            </div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="txtFechaNacimiento" runat="server" class="form-control" ReadOnly="true" BackColor="White"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-12 col-md-3">
                                Categoria
                            </div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="txtCategoria" runat="server" class="form-control" ReadOnly="true" BackColor="White"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-12 col-md-3">
                                Direccion
                            </div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="txtDireccion" runat="server" class="form-control" ReadOnly="true" BackColor="White"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-12 col-md-3">
                                Codigo Postal
                            </div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="txtCodPostal" runat="server" class="form-control" ReadOnly="true" BackColor="White"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group row">
                            <div class="col-12 col-md-3">
                                Telefono
                            </div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="txtTelefono" runat="server" class="form-control" ReadOnly="true" BackColor="White"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-12 col-md-3">
                                Mail
                            </div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="txtMail" runat="server" class="form-control" ReadOnly="true" BackColor="White"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlGrupoFamiliar" runat="server" Visible="false">
                        <asp:GridView ID="gvGrupoFamiliar" CssClass="table table-sm mt-1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="apynom" HeaderText="Socio"></asp:BoundField>
                                <asp:BoundField DataField="nro_documento" HeaderText="Nro. Documento"></asp:BoundField>
                                <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                <asp:BoundField DataField="parent" HeaderText="Parentesco"></asp:BoundField>
                                <asp:BoundField DataField="cat" HeaderText="Categoria"></asp:BoundField>
                                <asp:BoundField DataField="direccion" HeaderText="Direccion"></asp:BoundField>
                                <asp:BoundField DataField="telefono" HeaderText="Telefono"></asp:BoundField>
                                <asp:BoundField DataField="mail" HeaderText="Mail"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>

                    <asp:Panel ID="pnlAdicionales" runat="server" Visible="false">
                        <asp:GridView ID="gvAdicionales" CssClass="table table-sm mt-1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="descripcion" HeaderText="Adicional"></asp:BoundField>
                                <asp:BoundField DataField="costo_mensual" HeaderText="Costo Mensual"></asp:BoundField>
                            </Columns>
                        </asp:GridView>


                    </asp:Panel>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
