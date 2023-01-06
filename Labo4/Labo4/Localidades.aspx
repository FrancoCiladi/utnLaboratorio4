<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Localidades.aspx.vb" Inherits="Labo4.Localidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">

            <div class="row mt-2">
                <div class="col-12 col-md-2">
                    <asp:TextBox ID="txtCP" runat="server" AutoCompleteType="disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-12 col-md-10">
                    <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar" />
                    <asp:Button ID="btnRecuperar2" runat="server" Text="Recuperar2" />
                </div>
            </div>

            <hr />

            <div class="row mt-2">
                <div class="col-12 col-md-2">
                    Provincias
                </div>
                <div class="col-12 col-md-10">
                    <asp:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>

            <hr />

            <div class="row mt-2">
                <div class="col-12 col-md-2">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-12 col-md-10">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info"/>
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-12 col-md-6">

                    <asp:GridView ID="gvLocalidades" runat="server" CssClass="table table-small table-striped" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="cod_postal" HeaderText="CP">
                                <HeaderStyle Width="20%"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="descripcion" HeaderText="Localidad">
                                 <HeaderStyle Width="80%"></HeaderStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
           
            <div class="row mt-2">
                <div class="col-12 col-md-6">
                    <asp:GridView ID="gvLocalidadesDescripcion" runat="server" CssClass="table table-small table-striped" AutoGenerateColumns="False">

                        <Columns>
                            <asp:BoundField DataField="codpostal" HeaderText="CP"></asp:BoundField>
                            <asp:BoundField DataField="descripcion" HeaderText="Localidad"></asp:BoundField>
                            <asp:BoundField DataField="habitantes" HeaderText="Cant.Hab."></asp:BoundField>
                            <asp:BoundField DataField="desc_provincia" HeaderText="Provincia"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>







        </div>
    </form>
</body>
</html>
