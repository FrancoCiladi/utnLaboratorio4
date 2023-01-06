Public Class frmConsultaSocios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub txtApellidoSocio_TextChanged(sender As Object, e As EventArgs) Handles txtApellidoSocio.TextChanged
        'a medida que el usuario escribe en el textbox automaticamente se filtran aquellos cuyo apellido coincida con lo ingresado
        Dim strApellido As String   'string utilizada como filtro de socios
        strApellido = Me.txtApellidoSocio.Text.Trim.ToString()

        If strApellido.Length >= 3 Then
            Dim objSocios As New claSocios
            Dim dtsDataSet As New DataSet
            Dim intRetorno As Integer

            Me.pnlListadoSocios.Visible = True

            intRetorno = objSocios.devSociosPorApellido(dtsDataSet, strApellido)    'busco socios por apellido

            If intRetorno > 0 Then
                Me.gvSocios.DataSource = dtsDataSet.Tables("socios")
                Me.gvSocios.DataBind()

            End If
        Else
            Me.pnlListadoSocios.Visible = False
        End If
    End Sub
End Class