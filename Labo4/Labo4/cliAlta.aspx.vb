Public Class cliAlta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'CARGA INICIAL
            Me.ddlLocalidades.DataBind() 'SI O SI AGREGAR ESO
            Me.ddlLocalidades.Items.Insert(0, "Seleccione...") 'esto se ejecuta cada vez que hay un postback == en la carga inicial y en los postback

        End If


    End Sub


    Private Sub ddlTipoPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoPersona.SelectedIndexChanged
        Dim strTipoPersona As String

        strTipoPersona = Me.ddlTipoPersona.SelectedValue

        Select Case strTipoPersona
            Case "FIS"
                Me.lblTipoPersona.Text = "Apellido"
                Me.pnlNombre.Visible = True
            Case "JUR"
                Me.lblTipoPersona.Text = "Razon Social"
                Me.pnlNombre.Visible = False
        End Select


    End Sub


    Protected Sub chkNotificaciones_CheckedChanged(sender As Object, e As EventArgs) Handles chkNotificaciones.CheckedChanged
        If Me.chkNotificaciones.Checked Then
            txtMail.Enabled = True
        Else
            txtMail.Enabled = False
        End If
    End Sub

    Private Sub txtFechaNacimiento_TextChanged(sender As Object, e As EventArgs) Handles txtFechaNacimiento.TextChanged
        Dim detFechaNacimiento As Date
        Dim intEdad As Integer
        Dim objGeneral As New claGeneral
        Dim intRetorno As Integer

        detFechaNacimiento = CDate(Me.txtFechaNacimiento.Text.ToString.Trim) 'el cdate convierte a edad

        intRetorno = objGeneral.devEdad(detFechaNacimiento, intEdad)

        If intRetorno = 1 Then
            Me.lblEdad.Text = intEdad.ToString() & " años"
        Else
            'error
        End If


    End Sub

    Private Sub txtLocalidad_TextChanged(sender As Object, e As EventArgs) Handles txtLocalidad.TextChanged
        Dim objLocalidades As New claLocalidades
        Dim dtsDataSet As New DataSet
        Dim strCP As String
        Dim intRetorno As Integer

        strCP = Me.txtLocalidad.Text.ToString.Trim

        intRetorno = objLocalidades.RecuperarLocalidadesPorCodPostal(dtsDataSet, strCP)

        If intRetorno > 0 Then
            Me.lblLocalidad.Text = dtsDataSet.Tables("localidades").Rows(0).Item("descripcion")
        Else
            Me.lblLocalidad.Text = "Cod. Postal no registrado."
        End If

    End Sub
End Class