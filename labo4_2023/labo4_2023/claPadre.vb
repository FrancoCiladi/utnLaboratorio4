Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class claPadre
    Dim objConexion As SqlConnection

    Private Function Conectar(ByRef objConexion As SqlConnection) As Integer
        Dim strConexion As String
        Dim intResultado As Integer

        intResultado = 1

        Try
            strConexion = "Data Source=190.106.131.5;Initial Catalog=gt_labo4; User ID=labo4;Password=labo4"

            objConexion.ConnectionString = strConexion
            objConexion.Open()
        Catch ex As Exception
            intResultado = -1

        End Try

        Return intResultado

    End Function

    Public Function RecuperaDataSet(ByRef dtsDatos As DataSet, ByVal strSqltext As String, ByVal strTabla As String) As Integer
        Dim intRetorno As Integer
        Dim objConexion As SqlConnection

        Try

            objConexion = New SqlConnection
            Me.Conectar(objConexion)

            Dim objCommand As New SqlCommand(strSqltext, objConexion)
            Dim objAdapter As New SqlDataAdapter
            objAdapter.SelectCommand = objCommand
            intRetorno = objAdapter.Fill(dtsDatos, strTabla)
            objConexion.Close()
            objConexion = Nothing

        Catch ex As Exception

            intRetorno = -1

        End Try

        Return intRetorno

    End Function

    Public Function Ejecutar(ByVal strSqlText As String) As Integer
        Dim intRetorno As Integer

        objConexion = New SqlConnection
        Me.Conectar(objConexion)

        Dim objCommand As New SqlCommand(strSqlText, objConexion)
        intRetorno = objCommand.ExecuteNonQuery()

        Return intRetorno

    End Function

End Class
