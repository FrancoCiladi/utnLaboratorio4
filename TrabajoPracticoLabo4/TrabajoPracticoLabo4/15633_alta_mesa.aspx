<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PagMaestra.Master" CodeBehind="15633_alta_mesa.aspx.vb" Inherits="TrabajoPracticoLabo4._15633_alta_mesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-1">
        <div class="col-12 col-md-6">
            <%--creo la card--%>
            <div class="card">
  
                <div class="card-header">
                    <h4>
                        <asp:Label ID="lblCardHeader" runat="server" Text="Mesas de Examen"></asp:Label>
                    </h4>

                </div>

                <%--creo el cuerpo de la card--%>
                <div class="card-body">

                    <%--panel de mensajes de carga de GV para el usuario en caso de error--%>
                    <asp:Panel ID="pnlMensajeRecuperar" class="alert alert-danger" runat="server" Visible="false">
                        <asp:Label ID="lblMensajeRecuperar" runat="server" Text=""></asp:Label>
                    </asp:Panel>

                    <%--creo una fila y dentro le cargo el nombre del control junto con el control--%>
                    <div class="form-group row">
                        <div class="col-12 col-md-4">
                            Año
                        </div>
                        <div class="col-12 col-md-8">
                            <asp:TextBox ID="txtAño" runat="server" Class="form-control" MaxLength="4" Width="80"></asp:TextBox>
                        </div>
                    </div>

                    <%--creo una fila y dentro le cargo el nombre del control junto con el control--%>
                    <div class="form-group row">
                        <div class="col-12 col-md-4">
                            Materia
                        </div>
                        <div class="col-12 col-md-8">
                            <asp:DropDownList ID="ddlMaterias" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="materia"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=localhost\sqlexpress;Initial Catalog=TrabajoPracticoLabo4;Persist Security Info=True;User ID=sa;Password=TurnItUp_41134538" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [al_materias]"></asp:SqlDataSource>
                        </div>
                    </div>

                    <%--creo una fila y dentro le cargo el nombre del control junto con el control--%>
                    <div class="form-group row">
                        <div class="col-4 col-md-2">
                            <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar" class="btn btn-primary" ValidationGroup="1" />
                        </div>

                        <div class="col-4 col-md-2">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-primary" ValidationGroup="1" />
                        </div>
                        <div class="col-4 col-md-8">
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-primary" ValidationGroup="1"  />
                        </div>
                    </div>

                    <%--validadores--%>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ValidationGroup="1" ControlToValidate="txtAño" ErrorMessage="Complete el año"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" ValidationGroup="1" ErrorMessage="Seleccione una materia" ValueToCompare='Selecione...' ControlToValidate="ddlMaterias" Operator="NotEqual"></asp:CompareValidator>
                            <asp:ValidationSummary ID="ValidationSummary1" CssClass="alert alert-danger" runat="server" ValidationGroup="1" />
                        </div>
                    </div>
                </div>
            </div>



            <%--panel para poder ocultar o mostrar--%>
            <asp:Panel ID="pnlGV" runat="server" Visible="false">
                <hr />
                <div class="row mt-1">
                    <div class="col">
                        <asp:GridView ID="gvMateriasMesas" CssClass="table table-sm" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="descripcion" HeaderText="Materia"></asp:BoundField>
                                <asp:BoundField DataField="anio" HeaderText="A&#241;o"></asp:BoundField>
                                <asp:BoundField DataField="semana" HeaderText="Semana"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha Examen" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                <asp:BoundField DataField="estado" HeaderText="Estado">
                                    <%--para que no muestre dependiendo del dispositivo--%>
                                    <HeaderStyle CssClass="d-none d-md-table-cell" />
                                    <ItemStyle CssClass="d-none d-md-table-cell" />
                                </asp:BoundField>
                                <asp:BoundField DataField="modif_usr" HeaderText="Mod. Usuario">
                                    <%--para que no muestre dependiendo del dispositivo--%>
                                    <HeaderStyle CssClass="d-none d-md-table-cell" />
                                    <ItemStyle CssClass="d-none d-md-table-cell" />
                                </asp:BoundField>
                                <asp:BoundField DataField="modi_fecha" HeaderText="Mod. Fecha" DataFormatString="{0:dd/MM/yyyy}">
                                    <%--para que no muestre dependiendo del dispositivo--%>
                                    <HeaderStyle CssClass="d-none d-md-table-cell" />
                                    <ItemStyle CssClass="d-none d-md-table-cell" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
            <%--panel para poder ocultar o mostrar--%>




            <%--panel para poder ocultar o mostrar--%>
            <asp:Panel ID="pnlAlta" runat="server" Visible="false">
                <hr />
                <div class="card">

                    <div class="card-header">
                        <h4>Alta Mesa Examen
                        </h4>
                    </div>

                    <div class="card-body">

                        <%--panel de mensajes para alta de datos para el usuario en caso de error--%>
                        <asp:Panel ID="pnlMensajeAlta" class="alert alert-danger" runat="server" Visible="false">
                            <asp:Label ID="lblMensajeAlta" runat="server" Text=""></asp:Label>
                        </asp:Panel>


                        <div class="form-group row">
                            <div class="col-12 col-md-4">
                                Fecha Examen
                            </div>
                            <div class="col-12 col-md-8">
                                <asp:TextBox ID="txtFechaExamen" runat="server" TextMode="Date" onchange="SetDate()"></asp:TextBox>
                            </div>
                        </div>



                        <div class="form-group row">
                            <div class="col-12">
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="btn btn-primary" ValidationGroup="2" />
                            </div>

                        </div>


                        <div class="row mt-2">
                            <div class="col">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaExamen" ErrorMessage="Seleccione una fecha" ValidationGroup="2"></asp:RequiredFieldValidator>
                                <asp:ValidationSummary ID="ValidationSummary2" CssClass="alert alert-danger" runat="server" ValidationGroup="2" />
                            </div>
                        </div>

                    </div>
                </div>
            </asp:Panel>
            <%--panel para poder ocultar o mostrar--%>


        </div>

    </div>


</asp:Content>
