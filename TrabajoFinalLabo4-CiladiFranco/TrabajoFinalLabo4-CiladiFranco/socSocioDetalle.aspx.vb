Public Class frmSocioDetalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim objSocio As New claSocios   'obj para utilizar la clase socios
            Dim objAdicionales As New claAdicionales    'obj para utilizar la clase adicionales
            Dim dtsDataSet As New DataSet   ' dataset para volcar los datos
            Dim intRetorno As Integer   'variable de resultado
            Dim strNroSocio As String
            Dim strNroSocioTitular As String
            Dim strCategoria As String
            Dim datFechaNac As Date

            strNroSocio = Request.QueryString("a")  '"pido" el nro de socio que recibo en la url al abrir el formulario presente

            intRetorno = objSocio.devSociosPorNroSocio(dtsDataSet, strNroSocio) 'recupero el socio que coincida con el nro seleccionado
            If intRetorno > 0 Then
                strCategoria = dtsDataSet.Tables("socios").Rows(0).Item("categoria").ToString.Trim  'guardo el valor de la categoria en una variable
                strNroSocioTitular = dtsDataSet.Tables("socios").Rows(0).Item("nro_socio_titular").ToString.Trim    'guardo el valor del nro de socio titular en una variable

                Me.txtApellidoNombre.Text = dtsDataSet.Tables("socios").Rows(0).Item("apynom").ToString.Trim        'asignacion de valores del dataset a los controles del card
                Me.txtNroDoc.Text = dtsDataSet.Tables("socios").Rows(0).Item("nro_documento").ToString.Trim
                datFechaNac = dtsDataSet.Tables("socios").Rows(0).Item("fecha_nacimiento").ToString.Trim    'necesario para convertir la fecha
                Me.txtFechaNacimiento.Text = datFechaNac.ToShortDateString()    'convierto la fecha a un shortdatestring
                Select Case strCategoria    'uso de case para una mejor lectura de categoria
                    Case "MAY"
                        Me.txtCategoria.Text = "Mayor"
                    Case "CAD"
                        Me.txtCategoria.Text = "Cadete"
                    Case "BEC"
                        Me.txtCategoria.Text = "Becado"
                    Case "VIT"
                        Me.txtCategoria.Text = "Vitalicio"
                End Select
                Me.txtDireccion.Text = dtsDataSet.Tables("socios").Rows(0).Item("direccion").ToString.Trim  'asignacion de valores del dataset a los controles del card...
                Me.txtCodPostal.Text = dtsDataSet.Tables("socios").Rows(0).Item("cp").ToString.Trim
                Me.txtTelefono.Text = dtsDataSet.Tables("socios").Rows(0).Item("telefono").ToString.Trim
                Me.txtMail.Text = dtsDataSet.Tables("socios").Rows(0).Item("mail").ToString.Trim
            End If

            dtsDataSet.Clear()  'vacio el dataset para evitar la duplicacion en el grupo familiar

            intRetorno = objSocio.devGrupoFamiliarPorNroSocioTitular(dtsDataSet, strNroSocioTitular)    'recupero el grupo familiar en base al nro de socio titular
            If intRetorno > 0 Then
                Me.gvGrupoFamiliar.DataSource = dtsDataSet.Tables("socios")
                Me.gvGrupoFamiliar.DataBind()
            End If

            intRetorno = objAdicionales.devAdicionalesPorNroSocio(dtsDataSet, strNroSocio)  'recupero los adicionales del socio seleccionado
            If intRetorno > 0 Then
                Me.gvAdicionales.DataSource = dtsDataSet.Tables("adicionales")
                Me.gvAdicionales.DataBind()
            End If
        End If
    End Sub

    Private Sub lnkDetalles_Click(sender As Object, e As EventArgs) Handles lnkDetalles.Click
        'dependiendo del tab seleccionado muestro o oculto opciones como asi tambien selecciono las solapas tabs
        Me.pnlDetalles.Visible = True
        Me.pnlAdicionales.Visible = False
        Me.pnlGrupoFamiliar.Visible = False

        Me.lnkDetalles.CssClass = "nav-link active"
        Me.lnkAdicionales.CssClass = "nav-link"
        Me.lnkGrupoFamiliar.CssClass = "nav-link"
    End Sub

    Private Sub lnkGrupoFamiliar_Click(sender As Object, e As EventArgs) Handles lnkGrupoFamiliar.Click
        'dependiendo del tab seleccionado muestro o oculto opciones como asi tambien selecciono las solapas tabs
        Me.pnlDetalles.Visible = False
        Me.pnlAdicionales.Visible = False
        Me.pnlGrupoFamiliar.Visible = True

        Me.lnkDetalles.CssClass = "nav-link"
        Me.lnkAdicionales.CssClass = "nav-link"
        Me.lnkGrupoFamiliar.CssClass = "nav-link active"
    End Sub

    Private Sub lnkAdicionales_Click(sender As Object, e As EventArgs) Handles lnkAdicionales.Click
        'dependiendo del tab seleccionado muestro o oculto opciones como asi tambien selecciono las solapas tabs
        Me.pnlDetalles.Visible = False
        Me.pnlAdicionales.Visible = True
        Me.pnlGrupoFamiliar.Visible = False

        Me.lnkDetalles.CssClass = "nav-link"
        Me.lnkAdicionales.CssClass = "nav-link active"
        Me.lnkGrupoFamiliar.CssClass = "nav-link"
    End Sub
End Class