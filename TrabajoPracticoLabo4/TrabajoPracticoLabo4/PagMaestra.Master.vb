Public Class PagMaestra
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lnkCerrarSesion_Click(sender As Object, e As EventArgs) Handles lnkCerrarSesion.Click
        FormsAuthentication.SignOut()

        Session.Clear()
        Session.Abandon()

        Response.Redirect(FormsAuthentication.LoginUrl)


    End Sub
End Class