Public Class ClsEntMenu
    Private _IDMENU As String
    Private _IDKATEGORI As String
    Private _NAMAMENU As String
    Private _HARGAMENU As Integer


    Public Property idMenu As String
        Get
            Return _IDMENU
        End Get
        Set(value As String)
            _IDMENU = value
        End Set
    End Property


    Public Property idKategori As String
        Get
            Return _IDKATEGORI
        End Get
        Set(value As String)
            _IDKATEGORI = value
        End Set
    End Property


    Public Property namaMenu As String
        Get
            Return _NAMAMENU
        End Get
        Set(value As String)
            _NAMAMENU = value
        End Set
    End Property

    Public Property HargaMenu As Integer

        Get
            Return _HARGAMENU
        End Get
        Set(value As Integer)
            _HARGAMENU = value
        End Set
    End Property

End Class
