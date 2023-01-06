﻿Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Login_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login.Authenticate
        Dim objAdmin As New claAdmin
        Dim dtsDataSet As New DataSet
        Dim strUsuario As String
        Dim strPWD As String
        Dim strPWDbaseDatos As String
        Dim intRetorno As Integer

        strUsuario = Me.Login.UserName
        strPWD = Me.Login.Password

        intRetorno = objAdmin.devUsuario(dtsDataSet, strUsuario)

        Select Case intRetorno
            Case 0
                ' USAURIO NO REGISTRADO
                Me.Login.FailureText = "Usuario invalido."

            Case 1
                ' USUARIO REGISTRADO, DEBO VERIFICAR PWD
                strPWDbaseDatos = dtsDataSet.Tables("usuario").Rows(0).Item("clave").ToString.Trim
                If strPWD = strPWDbaseDatos Then
                    ' login valido
                    Session("nroAlumno") = dtsDataSet.Tables("usuario").Rows(0).Item("nro_alumno").ToString.Trim
                    Session("apynom") = dtsDataSet.Tables("usuario").Rows(0).Item("apynom").ToString.Trim

                    FormsAuthentication.RedirectFromLoginPage(strUsuario, True)

                Else
                    ' login invalido
                    Me.Login.FailureText = "Clave invalida."

                End If


            Case Else

        End Select


    End Sub

End Class