Public Class Form1
    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, _
                                                        ByVal dwProcessId As Integer) As Integer
    Private Declare Function WriteProcessMemory1 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, _
                                                                                            ByRef lpBuffer As Integer, ByVal nSize As Integer, _
                                                                                            ByRef lpNumberOfBytesWritten As Integer) As Integer
    Const PROCESS_ALL_ACCESS = &H1F0FF

    Public Sub WriteInteger(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Integer, Optional ByVal nsize As Integer = 4)
        If ProcessName.EndsWith(".exe") Then ProcessName = ProcessName.Replace(".exe", "")
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then Exit Sub

        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then Exit Sub

        Dim hAddress, vBuffer As Integer
        hAddress = Address
        vBuffer = Value
        WriteProcessMemory1(hProcess, hAddress, CInt(vBuffer), nsize, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim MyP As Process() = Process.GetProcessesByName("pes2013")
        If MyP.Length = 0 Then MsgBox("Pes 2013 isn't open!", MsgBoxStyle.Critical)
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then MsgBox("Failed to open the game !", MsgBoxStyle.Exclamation)

        If hProcess <> IntPtr.Zero And MyP.Length <> 0 Then
            Dim P1, P2 As Integer
            P1 = NumericUpDown1.Value
            P2 = NumericUpDown2.Value
            'HOME 0
            WriteInteger("pes2013.exe", &H19F9FC8, P1)
            WriteInteger("pes2013.exe", &H19F9FD0, P1)
            WriteInteger("pes2013.exe", &H1F584330, P1)
            WriteInteger("pes2013.exe", &H1F86E000, P1)
            WriteInteger("pes2013.exe", &H1FAC66F0, P1)
            WriteInteger("pes2013.exe", &H252BDF88, P1)
            WriteInteger("pes2013.exe", &H252BE028, P1)
            'AWAY 0
            WriteInteger("pes2013.exe", &H19FA304, P2)
            WriteInteger("pes2013.exe", &H19FA30C, P2)
            WriteInteger("pes2013.exe", &H6F344F0, P2)
            WriteInteger("pes2013.exe", &H12A0FBF4, P2)
            WriteInteger("pes2013.exe", &H1F58432C, P2)
            WriteInteger("pes2013.exe", &H252BC1F4, P2)
            WriteInteger("pes2013.exe", &H252BC294, P2)
            MsgBox("^_^ Done ^_^")
        End If
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        Label1.ForeColor = Color.LimeGreen
    End Sub

    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.Aqua
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Red
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        Label1.ForeColor = Color.Aqua
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = ""
        Label5.Text = ""
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = ListBox1.SelectedItem
        If ListBox1.SelectedIndex = ListBox1.Items.Count - 1 Then
            ListBox1.SelectedIndex = 0
            Timer2.Start()
        Else
            Label5.Text = ""
            ListBox1.SelectedIndex = ListBox1.SelectedIndex + +1
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label5.Text = ListBox2.SelectedItem
        If ListBox2.SelectedIndex = ListBox2.Items.Count - 1 Then
            ListBox2.SelectedIndex = 0
            Timer2.Stop()
            Timer2.Stop()
            Timer2.Stop()
            Timer1.Start()
        Else
            Timer1.Stop()
            Timer1.Stop()
            Timer1.Stop()
            ListBox2.SelectedIndex = ListBox2.SelectedIndex + +1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next
        Dim MyP As Process() = Process.GetProcessesByName("pes2013")
        If MyP.Length = 0 Then MsgBox("Pes 2013 isn't open!", MsgBoxStyle.Critical)
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then MsgBox("Failed to open the game !", MsgBoxStyle.Exclamation)

        If hProcess <> IntPtr.Zero And MyP.Length <> 0 Then
            Dim F1, F2 As Integer
            F1 = NumericUpDown4.Value
            F2 = NumericUpDown3.Value
            'HOME 0
            WriteInteger("pes2013.exe", &H19F9FDC, F1)
            'AWAY 0
            WriteInteger("pes2013.exe", &H19FA318, F1)
            MsgBox("^_^ Done ^_^")
        End If
    End Sub
End Class