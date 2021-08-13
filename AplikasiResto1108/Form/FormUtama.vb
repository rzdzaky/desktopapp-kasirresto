Public Class FormUtama
    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click

    End Sub

    Private Sub OlahDataKategoriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OlahDataKategoriToolStripMenuItem.Click
        FormKategori.Show()
    End Sub

    Private Sub OlahDataMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OlahDataBarangToolStripMenuItem.Click
        FormMenu.Show()

    End Sub

    Private Sub OlahDataKasirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OlahDataKasirToolStripMenuItem.Click
        FormKasir.Show()

    End Sub

    Private Sub TransaksiBaruToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiBaruToolStripMenuItem.Click
        FormPenjualan.Show()

    End Sub

    Private Sub LihatTransaksiPerBulanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LihatTransaksiPerBulanToolStripMenuItem.Click
        FormPenjualan.Show()


    End Sub

    Private Sub CetakDataMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CetakDataMenuToolStripMenuItem.Click

    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
End Class