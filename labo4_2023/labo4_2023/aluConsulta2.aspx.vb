Public Class aluConsulta2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim objAlumnos As New claAlumnos
        Dim dtsDataSet As New DataSet
        Dim intRetorno As Integer
        Dim strApellido As String

        strApellido = Me.txtApellido.Text.ToString.Trim

        intRetorno = objAlumnos.devAlumnoPorApellido(dtsDataSet, strApellido)
        If intRetorno > 0 Then
            Me.repAlumnos.DataSource = dtsDataSet.Tables("alumnos")
            Me.repAlumnos.DataBind()
        Else
            Me.repAlumnos.DataSource = Nothing
            Me.repAlumnos.DataBind()

        End If

    End Sub

    Private Sub repAlumnos_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles repAlumnos.ItemDataBound
        Dim strTelefono As String
        Dim lblMensaje As Label

        strTelefono = e.Item.DataItem("telefono").ToString.Trim()

        If strTelefono = "" Then
            lblMensaje = e.Item.FindControl("lblTelefonoMensaje")

            lblMensaje.Visible = True

        End If

    End Sub

    Private Sub btnPrueba_Click(sender As Object, e As EventArgs) Handles btnPrueba.Click
        Me.txtApellido.Text = DatePart(DateInterval.WeekOfYear, Today)

    End Sub

End Class