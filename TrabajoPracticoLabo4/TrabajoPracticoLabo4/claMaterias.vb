Public Class claMaterias
    Inherits claPadre


    Public Function devMesasMaterias(ByRef AROdataSet As DataSet, ByVal ARmateria As String, ByVal ARaño As String) As Integer
        'recupero de la BD las mesas de materias que correspondan con el año y materia seleccionada
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select m.descripcion, mm.anio, mm.semana, mm.fecha, mm.estado, mm.modif_usr, mm.modi_fecha from al_materias m, al_materias_mesas mm where  mm.materia = m.materia and mm.anio = '" & ARaño & "' and m.materia = '" & ARmateria & "'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "mesas")
        If AROdataSet.Tables(0).Rows.Count = 0 Then
            intResultado = -1
        End If

        Return intResultado

    End Function



    Public Function VerificarSemana(ByRef AROdataSet As DataSet, ByVal ARmateria As String, ByVal ARaño As String, ByVal ARsemana As Integer) As Integer
        'funcion encargada de verificar que en la semana del examen a cargar no haya otro de la misma materia
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select * from al_materias_mesas where anio = '" & ARaño & "' and materia = '" & ARmateria & "' and semana = " & ARsemana & ""
        Me.RecuperaDataSet(AROdataSet, strSql, "mesas")
        If AROdataSet.Tables(0).Rows.Count = 0 Then
            intResultado = 1
        End If

        Return intResultado

    End Function

    Public Function insertaMesa(ByRef ARmesa As dtsMesas) As Integer
        'funcion encargada del insert
        Dim dtrMesas As dtsMesas.al_materias_mesasRow
        Dim strSql As String

        dtrMesas = ARmesa.al_materias_mesas.Rows(0)

        Try
            strSql = "insert into al_materias_mesas values ( '" & dtrMesas.materia & "', '" & dtrMesas.anio & "', " & dtrMesas.semana & ", '" & dtrMesas.fecha.ToShortDateString() & "', "
            strSql = strSql & " 'ACT', '" & dtrMesas.modif_usr & "', '" & DateTime.Today.ToShortDateString() & "')"
            Me.Ejecutar(strSql)

        Catch ex As Exception
            Return -1

        End Try

        Return 1

    End Function
End Class

