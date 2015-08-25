Imports System.IO
Imports System.Text

Public Class Format

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Drive In My.Computer.FileSystem.Drives
            'Gets drive letter and type
            Dim DriveInfo As String = Drive.Name & " (" & Drive.DriveType.ToString & ")"

            'Checks to see if drive is a removable drive
            Dim isFlashDrive As Boolean = (DriveInfo.Contains("Removable") Or DriveInfo.Contains("Fixed")) And Not (DriveInfo.Contains(MasterFD.masterDrive) Or DriveInfo.Contains("C"))

            'Adds only removable drives to the list
            If isFlashDrive Then
                ListBox1.Items.Add(DriveInfo)
            End If
        Next
        ListBox1.SelectedIndex = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Variables initialized
        Dim i, j, k As Integer

        'Stores all selected drives in an array named "drives" and creates string with drive letter
        Dim drives(ListBox1.SelectedItems.Count - 1) As String
        For i = 0 To ListBox1.SelectedItems.Count - 1
            drives(i) = ListBox1.SelectedItems(i).ToString.Substring(0, 2)

        Next

        'Gets the current date and formats it as "mm-dd"
        Dim currentDate As Date = Date.Today()
        Dim formattedDate As String = currentDate.ToString("MM-dd")

        'Prompts the user to ensure they wish to format the drives
        Dim response = MessageBox.Show("Are you sure you want to format these drives? All data will be lost.", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If response = MsgBoxResult.Yes Then
            Me.Hide()
            Dim BeginFormat As New Process
            Dim NumDrives As Integer = drives.Length
            Dim LoadingChunk = 100 \ NumDrives
            LoadingBar.Show()

            'Iterates through all selected drive, performs quick format as NTFS, and names the drive with the current date
            'Writes blank character to the command prompt in order to begin formatting
            For j = 0 To drives.Length - 1
                LoadingBar.ProgressBar1.Increment(LoadingChunk)
                LoadingBar.Label1.Text = "Formatting drive " & (j + 1) & " of " & (drives.Length)
                Dim FormatStartInfo As New System.Diagnostics.ProcessStartInfo
                FormatStartInfo.FileName = "format.com"
                FormatStartInfo.Arguments = drives(j) & "/Q /FS:NTFS /V:" & formattedDate
                FormatStartInfo.RedirectStandardInput = True
                FormatStartInfo.RedirectStandardOutput = True
                FormatStartInfo.UseShellExecute = False
                FormatStartInfo.CreateNoWindow = True
                BeginFormat.StartInfo = FormatStartInfo
                BeginFormat.Start()
                Dim SW As System.IO.StreamWriter = BeginFormat.StandardInput
                SW.WriteLine("")
                BeginFormat.WaitForExit()
            Next
            LoadingBar.Hide()
            Dim fs As FileStream = File.Create("C:\ExcludeMacTools.txt")
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("\3. Macintosh Tools\")
            fs.Write(info, 0, info.Length)
            fs.Close()

            'Tests to see if drive is over 5 GB. If so, the "Mac Tools" folder is copied over. If not it is ignored.
            For k = 0 To drives.Length - 1
                Dim CurrentDriveInfo As System.IO.DriveInfo
                CurrentDriveInfo = My.Computer.FileSystem.GetDriveInfo(drives(k).First)
                Dim CurrentDriveSize As Long = CurrentDriveInfo.TotalSize

                If CurrentDriveSize < 5000000000 Then

                    Dim BeginCopying As New Process
                    Dim CopyStartInfo As New System.Diagnostics.ProcessStartInfo
                    CopyStartInfo.FileName = "xcopy.exe"
                    CopyStartInfo.Arguments = MasterFD.masterDrive & " " & drives(k) & "\  /E /EXCLUDE:c:\ExcludeMacTools.txt"
                    BeginCopying.StartInfo = CopyStartInfo
                    BeginCopying.Start()
                    BeginCopying.WaitForExit()

                Else

                    Dim BeginCopying As New Process
                    Dim CopyStartInfo As New System.Diagnostics.ProcessStartInfo
                    CopyStartInfo.FileName = "xcopy.exe"
                    CopyStartInfo.Arguments = MasterFD.masterDrive & " " & drives(k) & "\  /E"
                    BeginCopying.StartInfo = CopyStartInfo
                    BeginCopying.Start()
                    BeginCopying.WaitForExit()

                End If

            Next

            My.Computer.FileSystem.DeleteFile("C:\ExcludeMacTools.txt")
            MessageBox.Show("Complete!")
        End If
        Application.Exit()

    End Sub

    Private Sub Format_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        
    End Sub
End Class