Public Class FormLogin
    Private Sub btnMasuk_Click(sender As Object, e As EventArgs) Handles btnMasuk.Click
        DTGrid = KontrolKasir.loginkasir(txtUsername.Text).ToTable
        If txtUsername.Text = "" And txtPassword.Text = "" Then
            MsgBox("Silahkan isikan username dan password anda")
        ElseIf txtPassword.Text = "" Then
            MsgBox("Silahkan isikan password anda")
        ElseIf txtUsername.Text = "" Then
            MsgBox("Silahkan isikan username anda")
        Else
            If DTGrid.Rows.Count > 0 Then
                EntitasKasir.IdKasir = DTGrid.Rows(0).Item(0)
                EntitasKasir.NamaKasir = DTGrid.Rows(0).Item(1)
                EntitasKasir.UserID = DTGrid.Rows(0).Item(2)
                EntitasKasir.Pass = DTGrid.Rows(0).Item(3)
                EntitasKasir.LevelKasir = DTGrid.Rows(0).Item(4)

                KODELOG = EntitasKasir.IdKasir
                NAMALOG = EntitasKasir.NamaKasir

                If txtPassword.Text = EntitasKasir.Pass Then
                    FormUtama.Show()
                    txtPassword.Text = ""
                    txtUsername.Text = ""
                    Me.Hide()
                Else
                    MessageBox.Show("PASSWORD SALAH!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtPassword.Text = ""
                    txtUsername.Focus()
                End If
            Else
                MessageBox.Show("ID tidak dikenal!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Text = ""
                txtUsername.Text = ""
                txtUsername.Focus()
            End If
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        If MsgBox("apakah anda yakin ingin keluar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            Environment.Exit(1)
        End If
    End Sub
End Class