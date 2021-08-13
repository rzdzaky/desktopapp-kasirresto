Imports System.Data.Odbc

Public Class FormMenu
    Dim modeProses As Integer
    Dim baris As Integer

    Private Sub AturButton(st As Boolean)
        btnTambah.Enabled = st
        btnUbah.Enabled = st
        btnSimpan.Enabled = Not st
        btnBatal.Enabled = Not st
        btnHapus.Enabled = st

        GroupBox1.Enabled = st
    End Sub

    Private Sub IsiBox(br As Integer)
        If br < DTGrid.Rows.Count Then
            With DGMenu.Rows(br)
                txtIDMenu.Text = .Cells(0).Value.ToString
                txtKategori.Text = .Cells(1).Value.ToString
                txtNama.Text = .Cells(2).Value.ToString
                txtHarga.Text = .Cells(3).Value.ToString

            End With
        End If
    End Sub
    Private Sub RefreshGrid()
        DTGrid = KontrolMenu.tampilData.ToTable
        DGMenu.DataSource = DTGrid
    End Sub

    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
        TampilKategori()
        txtIDMenu.Enabled = False
        MdiParent = FormUtama

    End Sub

    Private Sub DGMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGMenu.CellClick
        If modeProses = 0 Then
            baris = e.RowIndex
            DGMenu.Rows(baris).Selected = True
            IsiBox(baris)
        End If
    End Sub

    Private Sub TampilKategori()
        CMD = New OdbcCommand("Select nama_kategori from kategori", BUKAKONEKSI)
        DTR = CMD.ExecuteReader
        cmbKategori.Items.Clear()
        Do While DTR.Read
            cmbKategori.Items.Add(DTR.Item("nama_kategori"))
        Loop
        BUKAKONEKSI.Close()
    End Sub

    Private Sub cmbKategori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKategori.SelectedIndexChanged
        CMD = New OdbcCommand("Select * from kategori where nama_kategori = '" & cmbKategori.Text & "'", BUKAKONEKSI)
        DTR = CMD.ExecuteReader
        DTR.Read()
        If DTR.HasRows Then
            txtKategori.Text = DTR.Item("id_kategori")
        Else
            MsgBox("Nama kategori tidak terdaftar")
        End If
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        AturButton(False)
        modeProses = 1
        txtIDMenu.Text = "Otomatis Generate Oleh Sistem"
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        AturButton(False)
        modeProses = 2
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        With EntitasMenu
            .idMenu = txtIDMenu.Text
            .idKategori = txtKategori.Text
            .namaMenu = txtNama.Text
            .HargaMenu = txtHarga.Text
        End With
        If modeProses = 1 Then
            KontrolMenu.InsertData(EntitasMenu)
        ElseIf modeProses = 2 Then
            KontrolMenu.updateData(EntitasMenu)
        End If
        MsgBox("Data telah tersimpan", MsgBoxStyle.Information, "Info")
        RefreshGrid()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim status_referensi As Boolean
        status_referensi = KontrolMenu.CekMenuDireferensi(txtIDMenu.Text)
        If status_referensi Then
            MsgBox("Data masih digunakan, tidak boleh dihapus", MsgBoxStyle.Exclamation, "peringatan")
            Exit Sub
        End If

        If MsgBox("Apakah anda yakin akan menghapus Menu " & txtNama.Text & "?",
                    MsgBoxStyle.Question + MsgBoxStyle.YesNo, "konfirmasi") = MsgBoxResult.Yes Then
            KontrolMenu.deleteData(txtIDMenu.Text)
        End If
        RefreshGrid()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        'panggil fungsi refresh grid 
        RefreshGrid()

        'panggil fungsi aturbutton dengan nilai true
        AturButton(True)

        'set nilai modeproses menjadi 0
        modeProses = 0
    End Sub


    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If txtCari.Text = "" Then
            Call RefreshGrid()
        Else
            Call TampilCari(txtCari.Text)
            txtCari.Focus()
        End If
    End Sub

    Private Sub TampilCari(kunci As String)
        DTGrid = KontrolMenu.cariData(kunci).ToTable

        If DTGrid.Rows.Count > 0 Then
            baris = DTGrid.Rows.Count - 1
            DGMenu.DataSource = DTGrid
            DGMenu.Rows(DTGrid.Rows.Count - 1).Selected = True
            DGMenu.CurrentCell = DGMenu.Item(1, baris)
            IsiBox(baris)

        Else
            MsgBox("Data Tidak Ditemukan")
            RefreshGrid()
        End If


    End Sub

End Class