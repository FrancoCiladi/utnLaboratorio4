<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="altaAlumnos.aspx.vb" Inherits="labo4_2023.altaAlumnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="row mt-1">
                    <div class="col-12 col-md-6">

                        <div class="card">
                            <div class="card-header">
                                <h4>Alta Alumnos</h4>
                            </div>

                            <div class="card-body">
                                <%--MENSAJES--%>
                                <asp:Panel ID="pnlMensajes" class="alert alert-danger" runat="server" visible="false">
                                     <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                </asp:Panel>

                                <%--FORMULARIO ALTA ALUMNO--%>
                                <div class="form-group row">
                                    <div class="col-12 col-md-4">
                                        Apellido
                                    </div>
                                    <div class="col-12 col-md-8">
                                        <asp:TextBox ID="txtApellido" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-12 col-md-4">
                                        Nombre
                                    </div>
                                    <div class="col-12 col-md-8">
                                        <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-12 col-md-4">
                                        DNI
                                    </div>
                                    <div class="col-12 col-md-8">
                                        <asp:TextBox ID="txtDni" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-12 col-md-4">
                                        Legajo
                                    </div>
                                    <div class="col-12 col-md-8">
                                        <asp:TextBox ID="txtLegajo" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-12 col-md-4">
                                    </div>
                                    <div class="col-12 col-md-8">
                                        <asp:Button ID="btnEnviar" CssClass="btn btn-primary" runat="server" Text="Enviar" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtApellido" Display="None" runat="server" ErrorMessage="Complete el apellido."></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNombre" Display="None" runat="server" ErrorMessage="Complete el nombre."></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDni" Display="None" runat="server" ErrorMessage="Complete el dni."></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvDNI" runat="server" ErrorMessage="" Display="None"></asp:CustomValidator>
                                        <asp:ValidationSummary ID="ValidationSummary1" CssClass="text-danger" runat="server" />
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </div>

    </form>
</body>
</html>
