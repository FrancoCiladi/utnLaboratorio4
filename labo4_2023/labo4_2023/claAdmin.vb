Public Class claAdmin
    Inherits claPadre

    Public Function devMenu(ByRef AROdataSet As DataSet) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select * from admFormularios order by orden"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "menu")

        Return intResultado

    End Function

    Public Function devUsuario(ByRef AROdataSet As DataSet, ByVal ARdni As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select *,rtrim(apellido) + ' ' + rtrim(nombre) as apynom from alumnos where dni = '" & ARdni & "'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "usuario")

        Return intResultado

    End Function

End Class
