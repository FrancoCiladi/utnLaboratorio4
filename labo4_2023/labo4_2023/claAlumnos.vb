Public Class claAlumnos
    Inherits claPadre

    Public Function devAlumnoPorDni(ByRef AROdataSet As DataSet, ByVal ARdni As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select * from alumnos where dni = '" & ARdni & "'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "alumnos")

        Return intResultado

    End Function

    Public Function devAlumnoPorApellido(ByRef AROdataSet As DataSet, ByVal ARapellido As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select *, rtrim(apellido) + ' ' + rtrim(nombre) as apynom from alumnos where apellido like '" & ARapellido & "%'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "alumnos")

        Return intResultado

    End Function

    Public Function devAlumnoPorNroAlumno(ByRef AROdataSet As DataSet, ByVal ARnroAlumno As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        strSql = "select *, rtrim(apellido) + ' ' + rtrim(nombre) as apynom from alumnos where nro_alumno = " & ARnroAlumno & ""

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "alumnos")

        Return intResultado

    End Function

    Public Function insertaAlumno(ByRef ARalumnos As dtsAlumnos) As Integer
        Dim dtrAlumnos As dtsAlumnos.alumnosRow
        Dim strSql As String

        dtrAlumnos = ARalumnos.alumnos.Rows(0)

        Try
            strSql = "insert into alumnos values ('" & dtrAlumnos.apellido & "'," &
    "'" & dtrAlumnos.nombre & "','" & dtrAlumnos.dni & "',''," &
    "'" & dtrAlumnos.nro_legajo & "')"

            Me.Ejecutar(strSql)

        Catch ex As Exception
            Return -1

        End Try

        Return 1

    End Function



    Public Function actualizaAlumno(ByRef ARalumnos As dtsAlumnos) As Integer
        Dim dtrAlumnos As dtsAlumnos.alumnosRow
        Dim strSql As String

        dtrAlumnos = ARalumnos.alumnos.Rows(0)

        Try
            strSql = "update alumnos set apellido = '" & dtrAlumnos.apellido & "'," &
            "nombre = '" & dtrAlumnos.nombre & "',dni = '" & dtrAlumnos.dni & "'," &
            "nro_legajo = '" & dtrAlumnos.nro_legajo & "'," &
            "telefono = '" & dtrAlumnos.telefono & "' " &
            "where nro_alumno = " & dtrAlumnos.nro_alumno

            Me.Ejecutar(strSql)

        Catch ex As Exception
            Return -1

        End Try

        Return 1

    End Function

End Class
