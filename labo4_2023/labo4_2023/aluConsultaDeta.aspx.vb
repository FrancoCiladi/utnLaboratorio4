Public Class aluConsultaDeta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim objAlumnos As New claAlumnos
            Dim dtsDataSet As New DataSet
            Dim intRetorno As Integer
            Dim strNroAlumno As String

            strNroAlumno = Request.QueryString("a")

            intRetorno = objAlumnos.devAlumnoPorNroAlumno(dtsDataSet, strNroAlumno)
            If intRetorno > 0 Then
                Me.txtApellido.Text = dtsDataSet.Tables("alumnos").Rows(0).Item("apellido").ToString.Trim
                Me.txtNombre.Text = dtsDataSet.Tables("alumnos").Rows(0).Item("nombre").ToString.Trim
                Me.txtDni.Text = dtsDataSet.Tables("alumnos").Rows(0).Item("dni").ToString.Trim
                Me.txtLegajo.Text = dtsDataSet.Tables("alumnos").Rows(0).Item("nro_legajo").ToString.Trim
                Me.txtTelefono.Text = dtsDataSet.Tables("alumnos").Rows(0).Item("telefono").ToString.Trim

                ViewState("nro_alumno") = dtsDataSet.Tables("alumnos").Rows(0).Item("nro_alumno")

                ' guardamos cookie ultima consulta.
                Dim cokieUltimaConsulta As New HttpCookie("ultima_consulta")

                cokieUltimaConsulta.Value = dtsDataSet.Tables("alumnos").Rows(0).Item("apynom").ToString.Trim
                cokieUltimaConsulta.Expires = Date.Now.AddYears(1)

                Response.Cookies.Add(cokieUltimaConsulta)

                ViewState("prueba") = dtsDataSet.Tables("alumnos").Rows(0).Item("apynom").ToString.Trim

            End If

        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        mensajesUsuario(ViewState("prueba"), 1)

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

        dtrAlumnosRow.nro_alumno = ViewState("nro_alumno")

        dtrAlumnosRow.apellido = Me.txtApellido.Text.ToString.Trim
        dtrAlumnosRow.nombre = Me.txtNombre.Text.ToString.Trim
        dtrAlumnosRow.dni = Me.txtDni.Text.ToString.Trim
        dtrAlumnosRow.nro_legajo = Me.txtLegajo.Text.ToString.Trim
        dtrAlumnosRow.telefono = Me.txtTelefono.Text.ToString.Trim

        dtsAlumnos.alumnos.AddalumnosRow(dtrAlumnosRow)

        intRetorno = objAlumnos.actualizaAlumno(dtsAlumnos)

        If intRetorno = 1 Then
            Me.mensajesUsuario("Grabacion Exitosa.", 1)

        Else
            Me.mensajesUsuario("Error al insertar.", -1)

        End If


    End Sub


End Class