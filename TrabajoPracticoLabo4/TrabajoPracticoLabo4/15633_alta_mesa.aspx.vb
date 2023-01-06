Imports System.Globalization
Public Class _15633_alta_mesa
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim datFechaMinima As DateTime = DateTime.Today.Date
            Dim strFechaMinima As String = datFechaMinima.ToString("yyyy-MM-dd")
            txtFechaExamen.Attributes("min") = strFechaMinima
            txtAño.Text = DatePart(DateInterval.Year, DateTime.Today)

            'ingreso la opcion seleccione a la dropdownlist
            Me.ddlMaterias.DataBind()
            Me.ddlMaterias.Items.Insert(0, "Selecione...")


        Else
            Me.mensajesUsuario("", 0)

        End If

    End Sub

    Private Sub btnRecuperar_Click(sender As Object, e As EventArgs) Handles btnRecuperar.Click
        If Not Page.IsValid Then
            Return
        Else
            Dim objMaterias As New claMaterias
            Dim dtsDataSet As New DataSet
            Dim intRetorno As Integer
            Dim strMateria As String
            Dim strAño As String

            'habilito el panel si se cumple la validacion
            pnlGV.Visible = True

            strMateria = Me.ddlMaterias.SelectedValue.ToString
            strAño = Me.txtAño.Text.ToString

            intRetorno = objMaterias.devMesasMaterias(dtsDataSet, strMateria, strAño)
            If intRetorno > 0 Then
                'cargo el GV
                Me.gvMateriasMesas.DataSource = dtsDataSet.Tables("mesas")
                Me.gvMateriasMesas.DataBind()
            Else
                'cierro el panel y muestro mensaje de error en caso de que no haya resultado 
                pnlGV.Visible = False
                pnlMensajeAlta.Visible = False
                Me.mensajesUsuario("No se encontro ninguna mesa para el año y materia elegidos", -1)
            End If
        End If

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not Page.IsValid Then
            Return
        Else
            'habilito el panel de alta en caso de que se cumpla la validacion
            pnlAlta.Visible = True
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If Not Page.IsValid Then
            Return

        End If


        Dim objMateria As New claMaterias
        Dim dtsMesas As New dtsMesas
        Dim dtrMesasRow As dtsMesas.al_materias_mesasRow
        Dim dtsDataSet As New DataSet
        Dim intRetorno As Integer
        Dim strMateria As String
        Dim strAño As String
        'NECESARIO PARA CALCULAR SEMANA
        Dim cc As CultureInfo = CultureInfo.CurrentCulture
        Dim semana As Integer
        Dim fecha As Date
        fecha = Date.Parse(txtFechaExamen.Text)
        semana = cc.Calendar.GetWeekOfYear(fecha, cc.DateTimeFormat.CalendarWeekRule, cc.DateTimeFormat.FirstDayOfWeek)
        'NECESARIO PARA CALCULAR SEMANA

        strMateria = ddlMaterias.SelectedValue.ToString
        strAño = txtAño.Text.Trim.ToString
        'llamo a una funcion para verificar la seman y si se cumple procedo con la carga/insert
        intRetorno = objMateria.VerificarSemana(dtsDataSet, strMateria, strAño, semana)
        If intRetorno > 0 Then
            'CREO FILA
            dtrMesasRow = dtsMesas.al_materias_mesas.NewRow
            'INGRESO LOS DATOS A LA FILA CREADA
            dtrMesasRow.anio = Me.txtAño.Text.Trim.ToString
            dtrMesasRow.materia = Me.ddlMaterias.SelectedValue
            dtrMesasRow.fecha = Me.txtFechaExamen.Text.Trim.ToString
            dtrMesasRow.estado = "ACT"
            dtrMesasRow.modif_usr = Session("nroAlumno")
            dtrMesasRow.modi_fecha = DateTime.Today.ToShortDateString()
            dtrMesasRow.semana = semana
            'AGREGO LA FILA YA CREADA AL DATASET
            dtsMesas.al_materias_mesas.Addal_materias_mesasRow(dtrMesasRow)
            'INSERTO LA FILA NUEVA A LA BD
            intRetorno = objMateria.insertaMesa(dtsMesas)

            If intRetorno = 1 Then
                Me.mensajesUsuario("Grabacion Exitosa.", 1)
                pnlMensajeRecuperar.Visible = False
            Else
                pnlMensajeRecuperar.Visible = False
                Me.mensajesUsuario("Error al insertar.", -1)
            End If
        Else
            Me.mensajesUsuario("Ya se encuentra habilitada una mesa para la semana", -1)
            pnlMensajeRecuperar.Visible = False
        End If


    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        'limpio pagina entera en caso de que lo necesite el usuario para una nueva operacion
        pnlGV.Visible = False
        pnlAlta.Visible = False
        txtFechaExamen.Text = Date.Today
        txtAño.Text = String.Empty
        ddlMaterias.SelectedIndex = 0
    End Sub

    Private Function mensajesUsuario(ByVal ARmensaje As String, ByVal ARtipoMensaje As Integer) As Integer
        'al usar dos paneles diferentes los tengo que tratar por separado
        Me.pnlMensajeAlta.Visible = True
        Me.lblMensajeAlta.Text = ARmensaje
        Me.pnlMensajeRecuperar.Visible = True
        Me.lblMensajeRecuperar.Text = ARmensaje

        Select Case ARtipoMensaje
            Case -1
                ' ERROR
                Me.pnlMensajeAlta.CssClass = "alert alert-danger"
                Me.pnlMensajeRecuperar.CssClass = "alert alert-danger"
            Case 1
                ' MOSTRAR MENSAJE
                Me.pnlMensajeAlta.CssClass = "alert alert-success"
            Case 0
                ' BORRAR MENSAJE
                Me.pnlMensajeAlta.Visible = False
                Me.pnlMensajeRecuperar.Visible = False


        End Select

        Return 1

    End Function
End Class