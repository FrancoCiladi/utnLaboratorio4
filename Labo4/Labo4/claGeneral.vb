Public Class claGeneral

    Public Function devEdad(ByVal ARfechaNacimiento As Date, ByRef ARedad As Integer) As Integer

        ARedad = DateDiff(DateInterval.Year, CDate(ARfechaNacimiento), Today())

        Return 1

    End Function

End Class
