Imports System.Data.Odbc
Public Class FormPenjualan
    Private Sub LVPenjualan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LVPenjualan.SelectedIndexChanged

    End Sub

    Private Sub TPTanggal_Tick(sender As Object, e As EventArgs) Handles TPTanggal.Tick
        Dim namaHari As String()
        namaHari = New String() {" \M\i\n\g\g\u", " \S\e\n\i\n", " \S\e\l\a\s\a", " \R\a\b\u", " \K\a\m\i\s", " \J\u\m\a\t", " \S\a\b\t\u"}
        lbllTanggal.Text = Format(Now, namaHari(Now.DayOfWeek()) & ", dd MMMM yyyy")
    End Sub

    Sub Buattabel()
        LVPenjualan.Columns.Add("ID Menu", 120, HorizontalAlignment.Center)
        LVPenjualan.Columns.Add("Nama Menu", 180, HorizontalAlignment.Center)
        LVPenjualan.Columns.Add("Harga Menu", 120, HorizontalAlignment.Center)
        LVPenjualan.Columns.Add("Qty", 90, HorizontalAlignment.Center)
        LVPenjualan.Columns.Add("Sub Total", 120, HorizontalAlignment.Center)

        LVPenjualan.View = View.Details
        LVPenjualan.GridLines = True
        LVPenjualan.FullRowSelect = True
    End Sub

    Private Sub FormPenjualan_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Buattabel()
        lblIDJual.Text = KontrolPenjualan.kodebaru()
        MdiParent = FormUtama
        lblIDKasir.Text = KODELOG
        lblNamaKasir.Text = NAMALOG
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim lsdetail As New List(Of ClsEntDetailJual)()
        If LVPenjualan.Items.Count = 0 Then
            MsgBox("Masukan Menu yang akan dipesan terlebih dahulu")
            Exit Sub
        End If
        With EntitasPenjualan
            .total = lblTotal.Text
            .tglJual = Format(Now, "dd/MM/yyyy")
            .idKasir = lblIDKasir.Text

        End With
        For i = 0 To LVPenjualan.Items.Count - 1

            EntitasDetailJual = New ClsEntDetailJual
            With LVPenjualan.Items(i)
                EntitasDetailJual.idMenu = .SubItems(0).Text
                EntitasDetailJual.hargaJual = .SubItems(2).Text
                EntitasDetailJual.qty = .SubItems(3).Text
            End With

            lsdetail.Add(EntitasDetailJual)
        Next i
        For I = 0 To lsdetail.Count - 1

        Next
        KontrolPenjualan.SIMPAN_DATA(EntitasPenjualan, lsdetail)

    End Sub

    Private Sub btnCariMenu_Click(sender As Object, e As EventArgs) Handles btnCariMenu.Click
        FormCariMenu.Show()
    End Sub


    Sub jumlahLVMenu()
        Dim JumMenu As Integer = 0
        Dim JumHarga As Integer = 0
        Dim total As Double = 0
        For baris As Integer = 0 To LVPenjualan.Items.Count - 1
            JumMenu = JumMenu + LVPenjualan.Items(baris).SubItems(3).Text
            JumHarga = JumHarga + LVPenjualan.Items(baris).SubItems(4).Text
        Next
        lblTotal.Text = JumHarga
        lblJumlahMenu.Text = JumMenu
    End Sub

    Sub TambahMenu()
        txtIDMenu.Text = ""
        txtNamaMenu.Text = ""
        txtHarga.Text = ""
        txtJumlah.Text = ""
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Dim strMenu(5) As String

        strMenu(0) = txtIDMenu.Text
        strMenu(1) = txtNamaMenu.Text
        strMenu(2) = txtHarga.Text
        strMenu(3) = txtJumlah.Text
        strMenu(4) = Val(txtHarga.Text * txtJumlah.Text)
        LVPenjualan.Items.Add(New ListViewItem(strMenu))
        Call jumlahLVMenu()
        Call TambahMenu()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        LVPenjualan.SelectedItems(0).Remove()
        Call jumlahLVMenu()
    End Sub


    Private Sub txtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBayar.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            If Val(txtBayar.Text) < Val(lblTotal.Text) Then
                MsgBox("Pembayaran Kurang")
                Exit Sub
            ElseIf Val(txtBayar.Text) = Val(lblTotal.Text) Then
                txtKembali.Text = 0
                btnSimpan.Focus()
            ElseIf Val(txtBayar.Text) > Val(lblTotal.Text) Then
                txtKembali.Text = Val(txtBayar.Text) - Val(lblTotal.Text)
                btnSimpan.Focus()
            End If
        End If
    End Sub

End Class