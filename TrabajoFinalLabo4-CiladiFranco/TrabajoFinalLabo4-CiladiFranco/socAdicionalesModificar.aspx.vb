Public Class socAdicionalesModificar
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim objSocios As New claSocios
        Dim objAdicionales As New claAdicionales
        Dim dtsDataSet As New DataSet
        Dim intRetorno As Integer
        Dim strNroSocio As String
        Dim intLargo As Integer     'variable necesaria para saber las cant de filas del GV
        Dim dt As DataTable     'creo un datatable para poder extraer valores de el como asi tambien realizar verificaciones
        Dim gvrFila As GridViewRow  'necesario para evaluar cada fila individual del GV
        Dim chkInscripto As CheckBox    'checkbox utilizados para inscripcion
        Dim strCodAdicional As String
        Dim strNombreSocio As String
        Dim strCategoria As String
        Dim strDescripcionAdicional As String

        Me.pnlMensaje.Visible = False   'escondo el panel de mensajes de operaciones en caso de busqueda de otro socio

        strNroSocio = Me.txtNroSocio.Text.Trim  'asigno el valor del textbox a la variable

        intRetorno = objSocios.devSociosPorNroSocio(dtsDataSet, strNroSocio)    'verifico que el socio buscado existe

        If intRetorno > 0 Then
            Me.pnlError.Visible = False     'escondo el panel de errores en caso de un error anterior
            Me.pnlAdicionales.Visible = True    'habilito el panel de adicionales en caso de que exista el socio

            dt = dtsDataSet.Tables("socios")

            strCategoria = dt.Rows(0).Item("categoria").ToString.Trim       'asigno la categoria extraida desde el datatable creado
            strNombreSocio = dt.Rows(0).Item("apynom").ToString.Trim        'asigno el nombre extraido desde el datatable creado
            Me.lblNombreSocio.Text = "Adicionales - " & strNombreSocio      'asigno el nombre al header del card para saber cual es el socio actual

            intRetorno = objAdicionales.devAdicionales(dtsDataSet)  'recupero los adicionales

            If intRetorno > 0 Then
                Me.gvAdicionales.DataSource = dtsDataSet.Tables("adicionales")
                Me.gvAdicionales.DataBind()

                intRetorno = objAdicionales.devAdicionalesSocios(dtsDataSet)    'recupero los adicionales del socio

                intLargo = Me.gvAdicionales.Rows.Count  'cantidad de adicionales totales

                For intN = 0 To intLargo - 1
                    gvrFila = Me.gvAdicionales.Rows(intN)       'empiezo a separar las filas de forma individual

                    strCodAdicional = gvrFila.Cells(0).Text     'asigno el cod adicional de la fila
                    strDescripcionAdicional = gvrFila.Cells(2).Text.Trim 'asigno la descripcion del adicional de la fila

                    dt = dtsDataSet.Tables("adicionales_socio")     'verifico si tanto el nro de socio como el cod_adicional se encuentran presentes en la tabla adicionales_mensuales_socio
                    dt.DefaultView.RowFilter = "nro_socio = '" & strNroSocio & "' and cod_adicional = '" & strCodAdicional & "'"
                    dt = dt.DefaultView.ToTable

                    If dt.Rows.Count = 1 Then
                        'si existe la combinacion
                        If dt.Rows(0).Item("estado") = "ACT" Then
                            'marco el checkbox por estar activo el adicional
                            chkInscripto = gvrFila.FindControl("chkInscripto")

                            chkInscripto.Checked = True

                            gvrFila.Cells(1).Text = "ACT"
                        Else
                            'no es necesario activar nada
                            gvrFila.Cells(1).Text = "BAJ"
                        End If
                    Else
                        'si no existe la combinacion no se marca checkbox ya que nunca fue activado o dado de baja el adicional
                        gvrFila.Cells(1).Text = "NUEVO"
                    End If

                    'necesario para no permitir que un mayor de edad se inscriba en deportes de menores
                    If strCategoria = "MAY" Then
                        Select Case strDescripcionAdicional
                            Case "Futbol Menores"
                                chkInscripto = gvrFila.FindControl("chkInscripto")
                                chkInscripto.Enabled = False
                            Case "Basquet Menores"
                                chkInscripto = gvrFila.FindControl("chkInscripto")
                                chkInscripto.Enabled = False
                            Case "Voley Menores"
                                chkInscripto = gvrFila.FindControl("chkInscripto")
                                chkInscripto.Enabled = False
                        End Select
                    End If
                Next
            End If
        Else
            'mensaje de error en caso de usuario no existente
            Me.pnlError.Visible = True
            Me.pnlAdicionales.Visible = False
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim objAdicional As New claAdicionales
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim gvrFila As GridViewRow
        Dim chkInscripto As CheckBox
        Dim strNroSocio As String
        Dim strEstadoOriginal As String
        Dim strCodAdicional As String
        Dim intN As Integer
        Dim intLargo As Integer
        Dim intRetorno As Integer

        'creo un datatable y agrego columnas que van a almacenar los datos a insertarse o modificarse de la BD
        dt.Columns.Add(New DataColumn("cod_adicional", GetType(String)))
        dt.Columns.Add(New DataColumn("nro_socio", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_ult_modif", GetType(DateTime)))

        strNroSocio = Me.txtNroSocio.Text.Trim

        intLargo = Me.gvAdicionales.Rows.Count

        For intN = 0 To intLargo - 1
            gvrFila = Me.gvAdicionales.Rows(intN)

            strCodAdicional = gvrFila.Cells(0).Text.ToString.Trim
            strEstadoOriginal = gvrFila.Cells(1).Text.ToString.Trim

            chkInscripto = gvrFila.FindControl("chkInscripto")

            Select Case strEstadoOriginal
                Case "ACT"
                    If Not chkInscripto.Checked Then
                        dr = dt.NewRow()
                        dr("cod_adicional") = strCodAdicional
                        dr("nro_socio") = strNroSocio
                        dr("estado") = "BAJ"
                        dr("fecha_ult_modif") = DateTime.Now
                        dt.Rows.Add(dr)
                    End If
                Case "BAJ"
                    If chkInscripto.Checked Then
                        dr = dt.NewRow()
                        dr("cod_adicional") = strCodAdicional
                        dr("nro_socio") = strNroSocio
                        dr("estado") = "ACT"
                        dr("fecha_ult_modif") = DateTime.Now
                        dt.Rows.Add(dr)
                    End If
                Case "NUEVO"
                    If chkInscripto.Checked Then
                        dr = dt.NewRow()
                        dr("cod_adicional") = strCodAdicional
                        dr("nro_socio") = strNroSocio
                        dr("estado") = "NUEVO"
                        dr("fecha_ult_modif") = DateTime.Now
                        dt.Rows.Add(dr)
                    End If
            End Select
        Next

        If dt.Rows.Count > 0 Then
            intRetorno = objAdicional.actualizaAdicionalesSocio(dt)

            If intRetorno > 0 Then
                'mensaje en caso de modificacion realizada con exito
                Me.pnlMensaje.Visible = True
                Me.lblMensaje.Text = "Modificacion Realizada!"
                Me.lblMensaje.CssClass = "alert alert-success"
            Else
                'mensaje de error al realizar modificacion
                Me.pnlMensaje.Visible = True
                Me.lblMensaje.Text = "Error al realizar operacion."
                Me.lblMensaje.CssClass = "alert alert-danger"
            End If

        End If


    End Sub
End Class