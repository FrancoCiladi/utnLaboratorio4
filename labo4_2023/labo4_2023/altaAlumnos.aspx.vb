Public Class altaAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        Else
            Me.mensajesUsuario("", 0)

        End If


    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim objAlumnos As New claAlumnos
        Dim dtsAlumnos As New dtsAlumnos
        Dim dtrAlumnosRow As dtsAlumnos.alumnosRow
        Dim intRetorno As Integer

        If Not Page.IsValid Then
            Return

        End If

        ' INERTAR LOS DATOS INGRESADOS
        dtrAlumnosRow = dtsAlumnos.alumnos.NewRow

        dtrAlumnosRow.apellido = Me.txtApellido.Text.ToString.Trim
        dtrAlumnosRow.nombre = Me.txtNombre.Text.ToString.Trim
        dtrAlumnosRow.dni = Me.txtDni.Text.ToString.Trim
        dtrAlumnosRow.nro_legajo = Me.txtLegajo.Text.ToString.Trim

        dtsAlumnos.alumnos.AddalumnosRow(dtrAlumnosRow)

        intRetorno = objAlumnos.insertaAlumno(dtsAlumnos)

        If intRetorno = 1 Then
            Me.mensajesUsuario("Grabacion Exitosa.", 1)

        Else
            Me.mensajesUsuario("Error al insertar.", -1)

        End If


    End Sub

    Private Sub cvDNI_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles cvDNI.ServerValidate
        Dim objAlumnos As New claAlumnos
        Dim dtsDataSet As New DataSet
        Dim intRetorno As Integer
        Dim strDni As String

        strDni = Me.txtDni.Text.ToString.Trim

        intRetorno = objAlumnos.devAlumnoPorDni(dtsDataSet, strDni)

        If intRetorno = 1 Then
            cvDNI.ErrorMessage = "El dni ingresado corresponde a " & dtsDataSet.Tables("alumnos").Rows(0).Item("apellido")
            args.IsValid = False
            Return

        End If

        args.IsValid = True

    End Sub

    Private Function mensajesUsuario(ByVal ARmensaje As String, ByVal ARtipoMensaje As Integer) As Integer

        Me.pnlMensajes.Visible = True
        Me.lblMensaje.Text = ARmensaje

        Select Case ARtipoMensaje
            Case -1
                ' ERROR
                Me.pnlMensajes.CssClass = "alert alert-danger"
            Case 1
                ' MOSTRAR MENSAJE
                Me.pnlMensajes.CssClass = "alert alert-success"
            Case 0
                ' BORRAR MENSAJE
                Me.pnlMensajes.Visible = False


        End Select

        Return 1

    End Function



End Class