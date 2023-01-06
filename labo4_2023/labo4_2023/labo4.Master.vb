Public Class labo4
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim objAdmin As New claAdmin
            Dim dtsDataSet As New DataSet
            Dim intRetorno As Integer
            Dim intN As Integer

            intRetorno = objAdmin.devMenu(dtsDataSet)

            ' form char(4)
            ' descripcion vchar(50)
            ' formulario vchar(70)
            ' orden int

            For intN = 0 To intRetorno - 1
                Dim op1 As New MenuItem()

                op1.Text = dtsDataSet.Tables("menu").Rows(intN).Item("descripcion")
                op1.NavigateUrl = dtsDataSet.Tables("menu").Rows(intN).Item("formulario")
                Me.Menu1.Items.Add(op1)

            Next

            Me.lblUsuario.Text = Session("apynom")

        End If

    End Sub

    Private Sub lnkCerrarSesion_Click(sender As Object, e As EventArgs) Handles lnkCerrarSesion.Click
        FormsAuthentication.SignOut()

        Session.Clear()
        Session.Abandon()

        Response.Redirect(FormsAuthentication.LoginUrl)


    End Sub

End Class