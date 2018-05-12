Public Class Form1
    Public Const sSecretKey As String = "Password"
    Public codepoints As Integer
    Public savelines(2000) As String
    Public Sub savegame()
        savelines(1) = codepoints
        IO.File.WriteAllLines(Paths.savedata & "Drivers\HDD.dri", savelines)
        File_Crypt.EncryptFile(Paths.savedata & "Drivers\HDD.dri", Paths.savedata & "SKernal.sft", sSecretKey)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        File_Crypt.DecryptFile(Paths.savedata & "Drivers\HDD.dri", Paths.savedata & "SKernal.sft", sSecretKey)
        codepoints = codepoints + 1000
        MessageBox.Show("1000 Codepoints has been added to your save file")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        File_Crypt.DecryptFile(Paths.savedata & "Drivers\HDD.dri", Paths.savedata & "SKernal.sft", sSecretKey)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        savegame()
    End Sub

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HTCAPTION As Integer = &H2
    <Runtime.InteropServices.DllImport("User32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    <Runtime.InteropServices.DllImport("User32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        About.Show()
    End Sub
End Class