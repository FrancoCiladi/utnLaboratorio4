<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cliAlta.aspx.vb" Inherits="Labo4.cliAlta" %>

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


             <div class="row mt-4">
                <div class="col-2">
                    Localidades
                </div>
                <div class="col-4">
                    <asp:DropDownList ID="ddlLocalidades" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="cod_postal"></asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Labo4ConnectionString %>' SelectCommand="SELECT * FROM [sv_localidades] order by descripcion asc"></asp:SqlDataSource>
                </div>
            </div>



            <div class="row mt-4">
                <div class="col-2">
                    Tipo Persona
                </div>
                <div class="col-4">
                    <asp:DropDownList ID="ddlTipoPersona" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="FIS" Selected="True">FISICA</asp:ListItem>
                        <asp:ListItem Value="JUR">JURIDICA</asp:ListItem>
                    </asp:DropDownList> 
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    <asp:Label ID="lblTipoPersona" runat="server" Text="Apellido"></asp:Label>
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtApellido" runat="server" AutoPostBack="True" MaxLength="40"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApellido" ErrorMessage="Complete el Apellido"></asp:RequiredFieldValidator>
                </div>
            </div>

            <asp:Panel ID="pnlNombre" runat="server">
                <div class="row mt-4">
                    <div class="col-2">
                        Nombre
                    </div>

                    <div class="col-4">
                    <asp:TextBox ID="txtNombre" runat="server"  AutoPostBack="true" AutoCompleteType="Disabled" MaxLength="40"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="Complete el Nombre"></asp:RequiredFieldValidator>
                    </div>

                </div>
            </asp:Panel>
            
            <div class="row mt-4">
                <div class="col-2">
                    Documento
                </div>
               
                <div class="col-4">
                        <asp:DropDownList ID="ddlDocumento" runat="server">
                            <asp:ListItem Selected="True">DNI</asp:ListItem>
                            <asp:ListItem>PAS</asp:ListItem>
                        </asp:DropDownList>

                    <asp:TextBox ID="txtDocumento" runat="server" CssClass="ml-2" MaxLength="9"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDocumento" ErrorMessage="Complete el Nro de Documento"></asp:RequiredFieldValidator>
                </div>
            </div>
          
            <div class="row mt-4">
                <div class="col-2">
                    CUIT
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtCUIT" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Fecha Nacimiento
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="lblEdad" runat="server" CssClass="ml-2" Text=""></asp:Label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Fecha Invalida" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Sexo
                </div>
                <div class="col-6">
                    <asp:RadioButtonList ID="rbSexo" runat="server" RepeatDirection="Horizontal" CellPadding="5">
                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2 mr-3">
                    Recibir Notificaciones
                </div>
                
                    <asp:CheckBox ID="chkNotificaciones" runat="server" AutoPostBack="True"/>

                <div class="col-4">
                    <asp:TextBox ID="txtMail" runat="server" MaxLength="45" Enabled="False"></asp:TextBox>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Rango Etario
                </div>
                <div class="col-2">

                    <asp:TextBox ID="txtRango1" runat="server" MaxLength="2" Width="30"></asp:TextBox>
                    a
                    <asp:TextBox ID="txtRango2" runat="server" MaxLength="2" Width="30" CssClass="mr-3"></asp:TextBox>

                </div>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ambos valores son identicos" ControlToCompare="txtRango1" ControlToValidate="txtRango2" Operator="NotEqual"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Primer valor no puede ser mayor que el segundo" ControlToCompare="txtRango1" ControlToValidate="txtRango2" Operator="GreaterThan"></asp:CompareValidator>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtRango1" ErrorMessage="Primer valor no permitido" MinimumValue="18" MaximumValue="73"></asp:RangeValidator>
                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtRango2" ErrorMessage="Segundo valor no permitido" MinimumValue="19" MaximumValue="74"></asp:RangeValidator>

                
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Horas Semanales
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtHorasSemanales" runat="server" Width="30" AutoPostBack="True" MaxLength="2"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtHorasSemanales" ErrorMessage="Cantidad de horas invalidas" MinimumValue="15" MaximumValue="80"></asp:RangeValidator>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Direccion
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtDireccion" runat="server" MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Complete la Direccion"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Localidad
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtLocalidad" runat="server" MaxLength="4" Width="60" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="lblLocalidad" runat="server" Text="" ></asp:Label>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Modo Pago
                </div>
                <div class="col-4">
                    <asp:DropDownList ID="ddlModoPago" runat="server" Width="150px">
                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                        <asp:ListItem>TAR</asp:ListItem>
                        <asp:ListItem>PAF</asp:ListItem>
                        <asp:ListItem>CBU</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Foto Usuario
                </div>
                <div class="col-4">
                    <asp:FileUpload ID="fuFotoUsuario" runat="server" />
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-2">
                    Observaciones
                </div>
                <div class="col-6">
                    <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="255" TextMode="MultiLine" Height="100" Width="300"></asp:TextBox>
                </div>
            </div>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert-danger" />
        </div>
    </form>
</body>
</html>
