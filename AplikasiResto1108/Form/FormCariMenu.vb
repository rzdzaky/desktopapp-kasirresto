Public Class FormCariMenu


    Sub BuatTabel()
        LVCariMenu.Columns.Add("ID Menu", 120, HorizontalAlignment.Center)
        LVCariMenu.Columns.Add("ID Kategori", 120, HorizontalAlignment.Center)
        LVCariMenu.Columns.Add("Nama Menu", 120, HorizontalAlignment.Center)
        LVCariMenu.Columns.Add("Harga Menu", 120, HorizontalAlignment.Center)
        LVCariMenu.View = View.Details
        LVCariMenu.GridLines = True
        LVCariMenu.FullRowSelect = True
    End Sub

    Private Sub FormCariMenu_load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuatTabel()
        MdiParent = FormUtama
    End Sub

    Private Sub txtCariMenu_TextChanged(sender As Object, e As EventArgs) Handles txtCariMenu.TextChanged
        DTGrid = KontrolMenu.cariData(txtCariMenu.Text).ToTable
        LVCariMenu.Items.Clear()
        Dim strItem(4) As String
        If DTGrid.Rows.Count > 0 Then
            For i = 0 To DTGrid.Rows.Count - 1
                strItem(0) = DTGrid.Rows(i).Item(0).ToString
                strItem(1) = DTGrid.Rows(i).Item(1).ToString
                strItem(2) = DTGrid.Rows(i).Item(2).ToString
                strItem(3) = DTGrid.Rows(i).Item(3).ToString

                LVCariMenu.Items.Add(New ListViewItem(strItem))
            Next


        Else
            MsgBox("Menu tidak tersedia")
        End If
    End Sub

    Private Sub LVCariMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LVCariMenu.SelectedIndexChanged

    End Sub

    Private Sub LVCariMenu_DoubleClick(sender As Object, e As EventArgs) Handles LVCariMenu.DoubleClick
        With FormPenjualan
            .txtIDMenu.Text = LVCariMenu.SelectedItems(0).SubItems(0).Text
            .txtNamaMenu.Text = LVCariMenu.SelectedItems(0).SubItems(2).Text
            .txtHarga.Text = LVCariMenu.SelectedItems(0).SubItems(3).Text
            Me.Close()
            .txtJumlah.Focus()
        End With
    End Sub
End Class