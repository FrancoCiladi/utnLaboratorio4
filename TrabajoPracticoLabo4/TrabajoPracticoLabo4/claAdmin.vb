Public Class claAdmin
    Inherits claPadre

    Public Function devUsuario(ByRef AROdataSet As DataSet, ByVal ARdni As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer
        'esto sirve para verificar el usuario en el login

        strSql = "select *,rtrim(apellido) + ' ' + rtrim(nombre) as apynom from alumnos where dni = '" & ARdni & "'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "usuario")

        Return intResultado

    End Function

End Class
