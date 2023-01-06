Public Class claSocios
    Inherits claPadre
    Public Function devSocios(ByRef AROdataSet As DataSet) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        'agrego campo apynom para usarlo como hyperlink
        strSql = "select *, rtrim(apellido) + ' ' + rtrim(nombre) as apynom from socios order by apynom asc"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "socios")

        Return intResultado

    End Function


    Public Function devSociosPorApellido(ByRef AROdataSet As DataSet, ByVal AROapellido As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        'agrego campo apynom para usarlo como hyperlink
        strSql = "select *, rtrim(apellido) + ' ' + rtrim(nombre) as apynom from socios where apellido like '" & AROapellido & "%'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "socios")

        Return intResultado

    End Function

    Public Function devSociosPorNroSocio(ByRef AROdataSet As DataSet, ByVal AROnroSocio As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        'agrego campo apynom para usarlo como hyperlink
        strSql = "select *, rtrim(apellido) + ' ' + rtrim(nombre) as apynom from socios where nro_socio = '" & AROnroSocio & "'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "socios")

        Return intResultado

    End Function

    Public Function devGrupoFamiliarPorNroSocioTitular(ByRef AROdataSet As DataSet, ByVal AROnroSocioTitular As String) As Integer
        Dim strSql As String
        Dim intResultado As Integer

        'agrego campo apynom para usarlo como hyperlink
        strSql = "select *, rtrim(apellido) + ' ' + rtrim(nombre) as apynom, case when parentesco = 'HIJ' then  'Hijo/a' 
	                when parentesco = 'CON' then 'Conyuge'
	                when parentesco = 'PAD' then 'Padre'
	                when parentesco = 'TIT' then 'Titular'
                    end as parent,
                    case when categoria = 'MAY' then 'Mayor' 
	                when categoria = 'CAD' then 'Cadete'
	                when categoria = 'BEC' then 'Becado'
	                when categoria = 'VIT' then 'Vitalicio'
                    end as cat
                    from socios where nro_socio_titular = '" & AROnroSocioTitular & "'"

        intResultado = Me.RecuperaDataSet(AROdataSet, strSql, "socios")

        Return intResultado

    End Function


End Class
