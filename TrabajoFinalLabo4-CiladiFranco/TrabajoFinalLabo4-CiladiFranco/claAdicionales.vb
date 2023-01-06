Public Class claAdicionales
    Inherits claPadre

    Public Function devAdicionalesPorNroSocio(ByRef AROdataSet As DataSet, ByVal AROnroSocio As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select am.descripcion, cast(am.costo_mensual as decimal) as costo_mensual from adicionales_mensuales am, adicionales_mensuales_socio ams where am.cod_adicional = ams.cod_adicional and ams.estado = 'ACT' and ams.nro_socio = '" & AROnroSocio & "'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "adicionales")

        Return intResultado

    End Function

    Public Function devAdicionales(ByRef AROdataSet As DataSet) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select cod_adicional, descripcion, cast(costo_mensual as decimal) as costo_mensual from adicionales_mensuales"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "adicionales")

        Return intResultado

    End Function

    Public Function devAdicionalesSocios(ByRef AROdataSet As DataSet) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select * from adicionales_mensuales_socio"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "adicionales_socio")

        Return intResultado

    End Function

    Public Function actualizaAdicionalesSocio(ByRef AROdataTable As DataTable) As Integer
        Dim strSql As String
        Dim intResultado As Integer
        Dim dr As DataRow
        Dim intN As Integer

        Try
            For intN = 0 To AROdataTable.Rows.Count - 1
                dr = AROdataTable.Rows(intN)

                Select Case dr("estado")
                    Case "ACT"
                        strSql = "update adicionales_mensuales_socio set estado = 'ACT', fecha_ult_modif = getdate() where cod_adicional = '" & dr("cod_adicional") & "' and nro_socio = '" & dr("nro_socio") & "'"
                    Case "BAJ"
                        strSql = "update adicionales_mensuales_socio set estado = 'BAJ', fecha_ult_modif = getdate() where cod_adicional = '" & dr("cod_adicional") & "' and nro_socio = '" & dr("nro_socio") & "'"
                    Case "NUEVO"
                        strSql = "insert into adicionales_mensuales_socio(cod_adicional,nro_socio,estado,fecha_ult_modif) values ('" & dr("cod_adicional") & "', '" & dr("nro_socio") & "', "
                        strSql = strSql & "'ACT',getdate())"

                End Select

                Me.Ejecutar(strSql)

            Next

        Catch ex As Exception
            intResultado = -1

        End Try

        Return 1

    End Function
End Class
