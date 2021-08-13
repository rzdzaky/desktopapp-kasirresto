Imports System.Data.Odbc

Public Class ClsCtlMenu : Implements InfProsess

    Public Function InsertData(Ob As Object) As OdbcCommand Implements InfProsess.InsertData
        Try
            Dim data As New ClsEntMenu
            data = Ob
            CMD = New OdbcCommand("insert into menu values('" & kodebaru() & "','" & data.idKategori & "','" & data.namaMenu & "','" & data.HargaMenu & "')", BUKAKONEKSI)
            CMD.CommandType = CommandType.Text
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand("", TUTUPKONEKSI)
            Return CMD
        Catch ex As Exception
            Throw New NotImplementedException()
        End Try

    End Function

    Public Function updateData(Ob As Object) As OdbcCommand Implements InfProsess.updateData
        Try
            Dim data As New ClsEntMenu
            data = Ob
            CMD = New OdbcCommand("update menu set nama_menu = '" & data.namaMenu & "', id_kategori = '" & data.idKategori & "', harga_menu = '" & data.HargaMenu & "' where id_menu = '" & data.idMenu & "'", BUKAKONEKSI)
            CMD.CommandType = CommandType.Text
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand("", TUTUPKONEKSI)
            Return CMD
        Catch ex As Exception
            Throw New NotImplementedException()
        End Try

    End Function

    Public Function deleteData(kunci As String) As OdbcCommand Implements InfProsess.deleteData
        Try
            CMD = New OdbcCommand("delete from menu where id_menu = '" & kunci & "'", BUKAKONEKSI)
            CMD.CommandType = CommandType.Text
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand("", TUTUPKONEKSI)
            Return CMD
        Catch ex As Exception
            Throw New NotImplementedException()
        End Try
    End Function

    Function kodebaru() As String
        Dim baru As String
        Dim kodeakhir As Integer

        Try
            DTA = New OdbcDataAdapter("select max(right(id_menu, 4)) from menu", BUKAKONEKSI)
            DTS = New DataSet()
            DTA.Fill(DTS, "max_kode")
            kodeakhir = Val(DTS.Tables("max_kode").Rows(0).Item(0))
            baru = "M" & Strings.Right("000" & kodeakhir + 1, 4)

            Return baru
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function tampilData() As DataView Implements InfProsess.tampilData
        Try
            DTA = New OdbcDataAdapter("select menu.ID_MENU , kategori.NAMA_KATEGORI , menu.NAMA_MENU , menu.HARGA_MENU from menu menu INNER JOIN kategori ON menu.ID_KATEGORI=kategori.ID_KATEGORI", BUKAKONEKSI)

            DTS = New DataSet()
            DTA.Fill(DTS, "Tabel_Menu")
            Dim grid As New DataView(DTS.Tables("Tabel_Menu"))
            Return grid

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function cariData(kunci As String) As DataView Implements InfProsess.cariData
        Try
            DTA = New OdbcDataAdapter("select * from menu where NAMA_MENU " & " like '%" & kunci & "%'", BUKAKONEKSI)
            DTS = New DataSet()
            DTA.Fill(DTS, "Cari_menu")
            Dim grid As New DataView(DTS.Tables("Cari_menu"))
            Return grid
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function CekMenuDireferensi(kunci As String) As Boolean
        Dim cek As Boolean
        cek = False
        Try
            DTA = New Odbc.OdbcDataAdapter("select count(ID_MENU) from detail_jual " & " where ID_MENU = '" & kunci & "'", BUKAKONEKSI)
            DTS = New DataSet()
            DTA.Fill(DTS, "cek")
            If DTS.Tables("cek").Rows(0)(0).ToString > 0 Then cek = True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return cek
    End Function


End Class



