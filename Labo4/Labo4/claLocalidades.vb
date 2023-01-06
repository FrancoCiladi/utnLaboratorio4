Public Class claLocalidades
    Inherits claPadre ' hereda de claPadre para poder utilizar sus metodos, en este caso Recuperar
    Public Function RecuperarLocalidadesPorCodPostal(ByRef ARdataSet As DataSet, ByVal ARcodPostal As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select * from zf_localidades where cod_postal = '" & ARcodPostal & "'"

        intResultado = Me.RecuperaDataSet(ARdataSet, strSql, "localidades")

        Return intResultado

    End Function

    Public Function RecuperarLocalidadesPorDescripcion(ByRef ARdataSet As DataSet, ByVal ARdescripcion As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select l.*,p.descripcion as desc_provincia from zf_localidades l,zf_provincias p where l.provincia = p.provincia and l.descripcion like '" & ARdescripcion & "%' order by l.descripcion "

        intResultado = Me.RecuperaDataSet(ARdataSet, strSql, "localidades")

        Return intResultado

    End Function

    Public Function RecuperarLocalidades(ByRef ARdataSet As DataSet) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select * from zf_localidades order by descripcion"

        intResultado = Me.RecuperaDataSet(ARdataSet, strSql, "localidades")

        Return intResultado

    End Function

    Public Function RecuperarProvincias(ByRef ARdataSet As DataSet) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select * from zf_provincias order by descripcion"

        intResultado = Me.RecuperaDataSet(ARdataSet, strSql, "provincias")

        Return intResultado

    End Function

    Public Function RecuperarLocalidadesPorProvincia(ByRef ARdataSet As DataSet, ByVal ARprovincia As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select * from sv_localidades where provincia = '" & ARprovincia & "'"

        intResultado = Me.RecuperaDataSet(ARdataSet, strSql, "localidades")

        Return intResultado

    End Function
End Class