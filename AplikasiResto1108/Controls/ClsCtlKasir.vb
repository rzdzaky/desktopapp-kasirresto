Imports System.Data.Odbc


Public Class ClsCtlKasir : Implements InfProsess

    Public Function InsertData(Ob As Object) As OdbcCommand Implements InfProsess.InsertData
        Try
            Dim data As New ClsEntKasir
            data = Ob
            CMD = New OdbcCommand("insert into kasir values('" & kodebaru() & "','" & data.NamaKasir & "','" & data.UserID & "','" & data.Pass & "','" & data.LevelKasir & "')", BUKAKONEKSI)
            CMD.CommandType = CommandType.Text
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand("", TUTUPKONEKSI)
            Return CMD
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function updateData(Ob As Object) As OdbcCommand Implements InfProsess.updateData
        Try
            Dim data As New ClsEntKasir
            data = Ob
            CMD = New OdbcCommand("update kasir set nama_kasir = '" & data.NamaKasir & "', userid= '" & data.UserID & "', pass = '" & data.Pass & "', level_kasir = '" & data.NamaKasir & "' where id_kasir = '" & data.IdKasir & "'", BUKAKONEKSI)
            CMD.CommandType = CommandType.Text
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand("", TUTUPKONEKSI)
            Return CMD
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function deleteData(kunci As String) As OdbcCommand Implements InfProsess.deleteData
        CMD = New OdbcCommand("delete from kasir " & "where id_kasir = '" & kunci & "'", BUKAKONEKSI)
        CMD.CommandType = CommandType.Text
        CMD.ExecuteNonQuery()
        CMD = New OdbcCommand("", TUTUPKONEKSI)
        Return CMD
    End Function

    Function kodebaru() As String
        Dim baru As String
        Dim kodeakhir As Integer
        Try
            DTA = New OdbcDataAdapter("select max(right(id_kasir,4))from kasir", BUKAKONEKSI)
            DTS = New DataSet()
            DTA.Fill(DTS, "max_kode")
            kodeakhir = Val(DTS.Tables("max_kode").Rows(0).Item(0))
            baru = "K" & Strings.Right("000" & kodeakhir + 1, 4)
            Return baru
        Catch ex As Exception
            Throw New NotImplementedException()
        End Try
    End Function

    Public Function tampilData() As DataView Implements InfProsess.tampilData
        Try
            DTA = New OdbcDataAdapter("select * from kasir", BUKAKONEKSI)

            DTS = New DataSet()
            DTA.Fill(DTS, "Tabel_Kasir")
            Dim grid As New DataView(DTS.Tables("Tabel_Kasir"))
            Return grid
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Throw New NotImplementedException()
    End Function

    Public Function cariData(kunci As String) As DataView Implements InfProsess.cariData
        Try
            DTA = New OdbcDataAdapter("select * from kasir where nama_kasir " & " like '%" & kunci & "&'", BUKAKONEKSI)
            DTS = New DataSet()
            DTA.Fill(DTS, "Cari_kasir")
            Dim grid As New DataView(DTS.Tables("Cari_Kasir"))
            Return grid
        Catch ex As Exception
            Throw New NotImplementedException()
        End Try
    End Function

    Public Function cekKasirDireferensi(kunci As String) As Boolean
        Dim cek As Boolean
        cek = False
        Try
            DTA = New Odbc.OdbcDataAdapter("Select count(id_kasir) from penjualan " & " where id_kasir = '" & kunci & "'", BUKAKONEKSI)
            DTS = New DataSet()
            DTA.Fill(DTS, "cek")
            If DTS.Tables("cek").Rows(0)(0).ToString > 0 Then cek = True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return cek
    End Function

    Public Function loginkasir(username As String) As DataView
        Try
            DTA = New OdbcDataAdapter("select * from kasir where userid = '" & username & "'", BUKAKONEKSI)
            DTS = New DataSet()
            DTA.Fill(DTS, "cari_kasir")
            Dim grid As New DataView(DTS.Tables("cari_kasir"))

            Return grid

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class

