Public Class ClsEntKasir
    Private _IDKASIR As String
    Private _NAMAKASIR As String
    Private _USERID As String
    Private _PASS As String
    Private _LEVELKASIR As String

    Public Property IdKasir As String
        Get
            Return _IDKASIR
        End Get
        Set(value As String)
            _IDKASIR = value

        End Set
    End Property

    Public Property NamaKasir As String
        Get
            Return _NAMAKASIR
        End Get
        Set(value As String)
            _NAMAKASIR = value

        End Set
    End Property

    Public Property UserID As String
        Get
            Return _USERID
        End Get
        Set(value As String)
            _USERID = value
        End Set
    End Property

    Public Property Pass As String
        Get
            Return _PASS
        End Get
        Set(value As String)
            _PASS = value
        End Set
    End Property

    Public Property LevelKasir As String
        Get
            Return _LEVELKASIR
        End Get
        Set(value As String)
            _LEVELKASIR = value
        End Set
    End Property

End Class