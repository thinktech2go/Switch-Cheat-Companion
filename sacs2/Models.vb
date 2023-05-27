Namespace sacs2.Models
    Public Class Game
        Public Property Name As String
        Public Property TitleId As String
        Public Property BuildId As String

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Public Class TokenRequest
        Public Property Email As String
        Public Property Password As String
    End Class

    Public Class TokenResponse
        Public Property Token As String
    End Class
End Namespace
