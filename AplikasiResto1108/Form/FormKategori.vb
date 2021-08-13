Public Class FormKategori
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
            With DGKategori.Rows(br)
                txtIDKategori.Text = .Cells(0).Value.ToString
                txtNama.Text = .Cells(1).Value.ToString
            End With
        End If
    End Sub
    Private Sub FormKategori_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()

        'atur textbox menjadi disable
        txtIDKategori.Enabled = False

        MdiParent = FormUtama

    End Sub

    Private Sub RefreshGrid()
        DTGrid = KontrolKategori.tampilData.ToTable
        DGKategori.DataSource = DTGrid

        If DTGrid.Rows.Count > 0 Then
            baris = DTGrid.Rows.Count - 1
            DGKategori.Rows(DTGrid.Rows.Count - 1).Selected = True
            DGKategori.CurrentCell = DGKategori.Item(1, baris)
            AturButton(True)
            IsiBox(baris)
        End If
    End Sub

    Private Sub TampilCari(kunci As String)
        DTGrid = KontrolKategori.cariData(kunci).ToTable

        If DTGrid.Rows.Count > 0 Then
            baris = DTGrid.Rows.Count - 1
            DGKategori.DataSource = DTGrid
            DGKategori.Rows(DTGrid.Rows.Count - 1).Selected = True
            DGKategori.CurrentCell = DGKategori.Item(1, baris)
            IsiBox(baris)
        Else
            MsgBox("Data tidak ditemukan")
            RefreshGrid()
        End If
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        AturButton(False)
        modeProses = 1
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        AturButton(False)
        txtNama.Focus()
        modeProses = 2
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        'panggil fungsi refresh grid 
        RefreshGrid()

        'panggil fungsi aturbutton dengan nilai true
        AturButton(True)

        'set nilai modeproses menjadi 0
        modeProses = 0
    End Sub

    Private Sub DGKategori_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGKategori.CellClick
        If modeProses = 0 Then
            baris = e.RowIndex
            DGKategori.Rows(baris).Selected = True
            IsiBox(baris)
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If txtCari.Text = "" Then
            Call RefreshGrid()
        Else
            Call TampilCari(txtCari.Text)
            txtCari.Focus()
        End If
    End Sub



    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        With EntitasKategori
            .idKategori = txtIDKategori.Text
            .NamaKategori = txtNama.Text
        End With

        If modeProses = 1 Then
            KontrolKategori.InsertData(EntitasKategori)
        ElseIf modeProses = 2 Then
            KontrolKategori.updateData(EntitasKategori)
        End If
        MsgBox("Data telah tersimpan", MsgBoxStyle.Information, "Info")
        RefreshGrid()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim status_referensi As Boolean
        status_referensi = KontrolKategori.cekKategoriDireferensi(txtIDKategori.Text)
        If status_referensi Then
            MsgBox("Data masih digunakan, tidak boleh dihapus", MsgBoxStyle.Exclamation, "peringatan")
            Exit Sub
        End If

        If MsgBox("Apakah anda yakin akan menghapus " & txtIDKategori.Text & "-" & txtNama.Text & "?",
                    MsgBoxStyle.Question + MsgBoxStyle.YesNo, "konfirmasi") = MsgBoxResult.Yes Then
            KontrolKategori.deleteData(txtIDKategori.Text)
        End If
        RefreshGrid()
    End Sub
End Class