Public Class cuwMenu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            For intN = 1 To 2
                Dim op1 As New MenuItem()

                op1.Text = "Alta Alumno"
                op1.NavigateUrl = "altaAlumnos.aspx"
                Me.Menu1.Items.Add(op1)

            Next



            'Dim op1 As New MenuItem()

            'op1.Text = "Consulta Alumno"
            'op1.NavigateUrl = "consultaAlumnos.aspx"
            'Me.Menu1.Items.Add(op1)

        End If

    End Sub

End Class