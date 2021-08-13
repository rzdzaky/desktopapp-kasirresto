<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.KategoriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OlahDataKategoriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OlahDataBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiBaruToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LihatTransaksiPerBulanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KasirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OlahDataKasirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CetakToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CetakDataMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CetakDataKasirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.KategoriToolStripMenuItem, Me.MenuToolStripMenuItem, Me.PenjualanToolStripMenuItem, Me.KasirToolStripMenuItem, Me.CetakToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'KategoriToolStripMenuItem
        '
        Me.KategoriToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OlahDataKategoriToolStripMenuItem})
        Me.KategoriToolStripMenuItem.Name = "KategoriToolStripMenuItem"
        Me.KategoriToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.KategoriToolStripMenuItem.Text = "Kategori"
        '
        'OlahDataKategoriToolStripMenuItem
        '
        Me.OlahDataKategoriToolStripMenuItem.Name = "OlahDataKategoriToolStripMenuItem"
        Me.OlahDataKategoriToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.OlahDataKategoriToolStripMenuItem.Text = "Olah Data Kategori"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OlahDataBarangToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'OlahDataBarangToolStripMenuItem
        '
        Me.OlahDataBarangToolStripMenuItem.Name = "OlahDataBarangToolStripMenuItem"
        Me.OlahDataBarangToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OlahDataBarangToolStripMenuItem.Text = "Olah Data Menu"
        '
        'PenjualanToolStripMenuItem
        '
        Me.PenjualanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransaksiBaruToolStripMenuItem, Me.LihatTransaksiPerBulanToolStripMenuItem})
        Me.PenjualanToolStripMenuItem.Name = "PenjualanToolStripMenuItem"
        Me.PenjualanToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.PenjualanToolStripMenuItem.Text = "Penjualan"
        '
        'TransaksiBaruToolStripMenuItem
        '
        Me.TransaksiBaruToolStripMenuItem.Name = "TransaksiBaruToolStripMenuItem"
        Me.TransaksiBaruToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.TransaksiBaruToolStripMenuItem.Text = "Transaksi Baru"
        '
        'LihatTransaksiPerBulanToolStripMenuItem
        '
        Me.LihatTransaksiPerBulanToolStripMenuItem.Name = "LihatTransaksiPerBulanToolStripMenuItem"
        Me.LihatTransaksiPerBulanToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.LihatTransaksiPerBulanToolStripMenuItem.Text = "Lihat Transaksi Per Bulan"
        '
        'KasirToolStripMenuItem
        '
        Me.KasirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OlahDataKasirToolStripMenuItem})
        Me.KasirToolStripMenuItem.Name = "KasirToolStripMenuItem"
        Me.KasirToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.KasirToolStripMenuItem.Text = "Kasir"
        '
        'OlahDataKasirToolStripMenuItem
        '
        Me.OlahDataKasirToolStripMenuItem.Name = "OlahDataKasirToolStripMenuItem"
        Me.OlahDataKasirToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.OlahDataKasirToolStripMenuItem.Text = "Olah Data Kasir"
        '
        'CetakToolStripMenuItem
        '
        Me.CetakToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CetakDataMenuToolStripMenuItem, Me.CetakDataKasirToolStripMenuItem})
        Me.CetakToolStripMenuItem.Name = "CetakToolStripMenuItem"
        Me.CetakToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.CetakToolStripMenuItem.Text = "Cetak"
        '
        'CetakDataMenuToolStripMenuItem
        '
        Me.CetakDataMenuToolStripMenuItem.Name = "CetakDataMenuToolStripMenuItem"
        Me.CetakDataMenuToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CetakDataMenuToolStripMenuItem.Text = "Cetak Data Menu"
        '
        'CetakDataKasirToolStripMenuItem
        '
        Me.CetakDataKasirToolStripMenuItem.Name = "CetakDataKasirToolStripMenuItem"
        Me.CetakDataKasirToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.CetakDataKasirToolStripMenuItem.Text = "Cetak Data Kasir"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormUtama"
        Me.Text = "FormUtama"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents KategoriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OlahDataKategoriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KasirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CetakToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaksiBaruToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LihatTransaksiPerBulanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OlahDataKasirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CetakDataMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CetakDataKasirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OlahDataBarangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
End Class
