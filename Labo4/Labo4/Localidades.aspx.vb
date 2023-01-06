Imports System.Data.SqlClient
Public Class Localidades
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'CARGA INICIAL, PRIMERA CARGA 
            Dim objLocalidades As New claLocalidades
            Dim dtsDataSet As New DataSet
            Dim intRetorno As Integer

            Me.ddlProvincias.DataTextField = "descripcion"
            Me.ddlProvincias.DataValueField = "provincia"

            intRetorno = objLocalidades.RecuperarProvincias(dtsDataSet)

            ddlProvincias.DataSource = dtsDataSet.Tables("provincias")
            ddlProvincias.DataBind()
            ddlProvincias.Items.Insert(0, "Seleccione...")
        End If


    End Sub

    Private Sub btnRecuperar_Click(sender As Object, e As EventArgs) Handles btnRecuperar.Click
        Dim objConexion As New SqlConnection
        Dim strConexion As String
        'Dim objCommand As New SqlCommand
        Dim strSqltext As String
        Dim intRetorno As Integer
        Dim strCP As String

        strConexion = "Data Source=DESKTOP-2T5VNFR\SQLEXPRESS;Initial Catalog=Labo4;User ID= sa;Password=TurnItUp_41134538"

        objConexion.ConnectionString = strConexion

        objConexion.Open()

        strCP = Me.txtCP.Text.ToString.Trim

        strSqltext = "Select * from sv_localidades where cod_postal = '" & strCP & "'"

        Dim objCommand As New SqlCommand(strSqltext, objConexion) 'sentencia que mandamos con la conexion creada
        Dim objAdapter As New SqlDataAdapter  'EJECUTA EL FILL
        Dim dtsDataSet As New DataSet 'RECIPIENTE DEL FILL

        objAdapter.SelectCommand = objCommand
        intRetorno = objAdapter.Fill(dtsDataSet, "localidades")


        objConexion.Close()
        objConexion = Nothing

        Me.gvLocalidades.DataSource = dtsDataSet.Tables("localidades")
        Me.gvLocalidades.DataBind()



    End Sub

    Private Sub btnRecuperar2_Click(sender As Object, e As EventArgs) Handles btnRecuperar2.Click
        Dim objLocalidades As New claLocalidades
        Dim dtsDataSet As New DataSet
        Dim strCP As String
        Dim intRetorno As Integer

        strCP = Me.txtCP.Text.ToString.Trim

        intRetorno = objLocalidades.RecuperarLocalidades(dtsDataSet)

        If intRetorno > 0 Then
            Me.gvLocalidades.DataSource = dtsDataSet.Tables("localidades")
            Me.gvLocalidades.DataBind()

        Else
            'mensaje error
        End If


    End Sub

    Private Sub ddlProvincias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvincias.SelectedIndexChanged
        Dim objLocalidades As New claLocalidades
        Dim dtsDataSet As New DataSet
        Dim strProvincia As String
        Dim intRetorno As Integer

        If ddlProvincias.SelectedIndex = 0 Then
            Return
        End If

        strProvincia = ddlProvincias.SelectedValue

        intRetorno = objLocalidades.RecuperarLocalidadesPorProvincia(dtsDataSet, strProvincia)

        If intRetorno > 0 Then
            Me.gvLocalidades.DataSource = dtsDataSet.Tables("localidades")
            Me.gvLocalidades.DataBind()
        Else
            'mensaje
            Me.gvLocalidades.DataSource = Nothing
            Me.gvLocalidades.DataBind()

        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim objLocalidades As New claLocalidades
        Dim dtsDataSet As New DataSet
        Dim strDescripcion As String
        Dim intRetorno As Integer

        strDescripcion = Me.txtDescripcion.Text.ToString.Trim

        intRetorno = objLocalidades.RecuperarLocalidadesPorDescripcion(dtsDataSet, strDescripcion)

        If intRetorno > 0 Then
            Me.gvLocalidadesDescripcion.DataSource = dtsDataSet.Tables("localidades")
            Me.gvLocalidadesDescripcion.DataBind()
        Else
            Me.gvLocalidadesDescripcion.DataSource = Nothing
            Me.gvLocalidadesDescripcion.DataBind()
        End If
    End Sub
End Class