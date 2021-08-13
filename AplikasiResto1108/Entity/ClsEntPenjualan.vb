Public Class ClsEntPenjualan

    Private _idJual As String
    Private _total As Integer
    Private _tglJual As Date
    Private _idKasir As String


    Public Property idJual As String
        Get
            Return _idJual
        End Get
        Set(value As String)
            _idJual = value
        End Set
    End Property


    Public Property total As Integer
        Get
            Return _total
        End Get
        Set(value As Integer)
            _total = value
        End Set
    End Property


    Public Property tglJual As Date
        Get
            Return _tglJual
        End Get
        Set(value As Date)
            _tglJual = value
        End Set
    End Property

    Public Property idKasir As String

        Get
            Return _idKasir
        End Get
        Set(value As String)
            _idKasir = value
        End Set
    End Property
End Class