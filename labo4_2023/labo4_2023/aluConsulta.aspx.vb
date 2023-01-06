Public Class aluConsulta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim strUltimaConsulta As String

            If Not Request.Cookies("ultima_consulta") Is Nothing Then
                strUltimaConsulta = Request.Cookies("ultima_consulta").Value

                Me.lblUltimaConsulta.Text = strUltimaConsulta & " - Usuario: " & Session("nroAlumno")

            End If

        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim objAlumnos As New claAlumnos
        Dim dtsDataSet As New DataSet
        Dim intRetorno As Integer
        Dim strApellido As String

        strApellido = Me.txtApellido.Text.ToString.Trim

        intRetorno = objAlumnos.devAlumnoPorApellido(dtsDataSet, strApellido)
        If intRetorno > 0 Then
            Me.gvAlumnos.DataSource = dtsDataSet.Tables("alumnos")
            Me.gvAlumnos.DataBind()

        End If


    End Sub

End Class