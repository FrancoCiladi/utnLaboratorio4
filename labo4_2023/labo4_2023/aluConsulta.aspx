<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/labo4.Master" CodeBehind="aluConsulta.aspx.vb" Inherits="labo4_2023.aluConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-2">
        <div class="col-12 col-md-6">
            <%--DENTRO DEL MARCO--%>
            <div class="row">
                <div class="col">
                    <h4>Consulta Alumnos</h4>
                </div>
            </div>
            <hr />

            <div class="row">
                <div class="col-3">
                    Ultima Consulta
                </div>
                <div class="col-9">
                    <asp:Label ID="lblUltimaConsulta" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-6">
                    <asp:TextBox ID="txtApellido" AutoCompleteType="Disabled" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-6">
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" />
                </div>
            </div>
            <div class="row mt-1">
                <div class="col">
                    <asp:GridView ID="gvAlumnos" CssClass="table table-sm" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="nro_alumno" HeaderText="#" HtmlEncode="False"></asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="nro_alumno" DataNavigateUrlFormatString="aluConsultaDeta.aspx?a={0}" DataTextField="apynom" HeaderText="Alumno"></asp:HyperLinkField>
                            <asp:BoundField DataField="dni" HeaderText="DNI">
                                <HeaderStyle CssClass="d-none d-md-block" />
                                <ItemStyle CssClass="d-none d-md-block" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="telefono" DataNavigateUrlFormatString="https://wa.me/+54{0}" DataTextField="telefono" HeaderText="TEL">
                                <HeaderStyle Width="15%"></HeaderStyle>
                            </asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <%--FIN MARCO--%>
        </div>
    </div>
</asp:Content>
