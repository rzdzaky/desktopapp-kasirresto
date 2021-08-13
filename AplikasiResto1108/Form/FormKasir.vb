Imports System.Data.Odbc

Public Class FormKasir
    Dim modeProses As Integer
    Dim baris As Integer

    Private Sub AturButton(st As Boolean)
        btnTambah.Enabled = st
        btnUbah.Enabled = st
        btnHapus.Enabled = st
        btnSimpan.Enabled = Not st
        btnBatal.Enabled = Not st

        GroupBox1.Enabled = st
    End Sub

    Private Sub IsiBox(br As Integer)
        If br < DTGrid.Rows.Count Then
            With DGKasir.Rows(br)
                txtIDKasir.Text = .Cells(0).Value.ToString
                txtNama.Text = .Cells(1).Value.ToString
                txtUserID.Text = .Cells(2).Value.ToString
                txtPassword.Text = .Cells(3).Value.ToString
                cmbLevelKasir.SelectedIndex = cmbLevelKasir.FindStringExact(.Cells(4).Value.ToString)

            End With
        End If
    End Sub

    Sub TampilLevelKasir()
        cmbLevelKasir.Items.Add("SK")
        cmbLevelKasir.Items.Add("AK")
    End Sub
    Private Sub RefreshGrid()
        DTGrid = KontrolKasir.tampilData.ToTable
        DGKasir.DataSource = DTGrid

        If DTGrid.Rows.Count > 0 Then
            baris = DTGrid.Rows.Count - 1
            DGKasir.Rows(DTGrid.Rows.Count - 1).Selected = True
            DGKasir.CurrentCell = DGKasir.Item(1, baris)
            AturButton(True)
            IsiBox(baris)
        End If
    End Sub

    Private Sub TampilCari(kunci As String)
        DTGrid = KontrolKasir.cariData(kunci).ToTable

        If DTGrid.Rows.Count > 0 Then
            baris = DTGrid.Rows.Count - 1
            DGKasir.DataSource = DTGrid
            DGKasir.Rows(DTGrid.Rows.Count - 1).Selected = True
            DGKasir.CurrentCell = DGKasir.Item(1, baris)
            IsiBox(baris)
        Else
            MsgBox("Data Tidak Ditemukan")
            RefreshGrid()
        End If
    End Sub

    Private Sub FormKasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
        TampilLevelKasir()
        'atur texbox menjadi disable
        txtIDKasir.Enabled = False
        MdiParent = FormUtama
    End Sub

    Private Sub DGKasir_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGKasir.CellClick
        If modeProses = 0 Then
            baris = e.RowIndex
            DGKasir.Rows(baris).Selected = True
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
        With EntitasKasir
            .IdKasir = txtIDKasir.Text
            .NamaKasir = txtNama.Text
            .UserID = txtUserID.Text
            .Pass = txtPassword.Text
            .LevelKasir = cmbLevelKasir.Text
        End With

        If modeProses = 1 Then
            KontrolKasir.InsertData(EntitasKasir)
        ElseIf modeProses = 2 Then
            KontrolKasir.updateData(EntitasKasir)
        End If
        MsgBox("Data telah tersimpan", MsgBoxStyle.Information, "Info")
        RefreshGrid()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim status_referensi As Boolean
        status_referensi = KontrolKasir.cekKasirDireferensi(txtIDKasir.Text)
        If status_referensi Then
            MsgBox("Data masih digunakan, tidak boleh dihapus", MsgBoxStyle.Exclamation, "peringatan")
            Exit Sub
        End If

        If MsgBox("Apakah anda yakin akan menghapus kasir " & txtNama.Text & "?",
                    MsgBoxStyle.Question + MsgBoxStyle.YesNo, "konfirmasi") = MsgBoxResult.Yes Then
            KontrolKasir.deleteData(txtIDKasir.Text)
        End If
        RefreshGrid()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        AturButton(False)
        modeProses = 1
        txtIDKasir.Text = "Otomatis Generate oleh sistem"
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        'atur button false 
        AturButton(False)
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
End Class