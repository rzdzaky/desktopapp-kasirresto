Imports System.Data.Odbc
Module ModKoneksiDB
    Public DTR As OdbcDataReader
    Public CMD As New OdbcCommand
    Public DTA As New OdbcDataAdapter
    Public DTS As New DataSet
    Public DTT As New DataTable
    Public DTGrid As New DataTable
    Public MyDB = "Driver={MySQL ODBC 5.1 Driver};Database=dbresto_1108;server:localhost;uid=root"
    Public koneksi As New OdbcConnection(MyDB)

    Public Function BUKAKONEKSI() As OdbcConnection
        Try
            If koneksi.State = ConnectionState.Closed Then koneksi.Open()
        Catch ex As Exception

        End Try
        Return koneksi
    End Function
    Public Function TUTUPKONEKSI() As OdbcConnection
        koneksi.Close()
        Return koneksi
    End Function
End Module
