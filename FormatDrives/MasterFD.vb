Public Class MasterFD
    Public masterDrive As String

    Private Sub MasterFlashDrive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Drive In My.Computer.FileSystem.Drives
            'Gets drive letter and type
            Dim DriveInfo As String = Drive.Name & " (" & Drive.DriveType.ToString & ")"

            'Checks to see if drive is a removable drive
            Dim removable As String = "Removable"
            Dim C As String = "C:\"
            Dim network As String = "Network"
            Dim CD As String = "CD"

            'Adds only removable drives to the list
            If Not DriveInfo.Contains(network) And Not DriveInfo.Contains(C) And Not DriveInfo.Contains(CD) Then
                MasterFlashDrive.Items.Add(DriveInfo)
            End If
        Next
        MasterFlashDrive.SelectedIndex = 0
    End Sub

    Private Sub MFD_Next_Click(sender As Object, e As EventArgs) Handles MFD_Next.Click
        'Gets drive letter of master flash drive
        masterDrive = MasterFlashDrive.SelectedItem.ToString().Substring(0, 3)
        Hide()
        Format.Show()
    End Sub

    Private Sub MasterFD_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case Windows.Forms.DialogResult.Yes
                'nothing to do here the form is already closing
            Case Windows.Forms.DialogResult.No
                e.Cancel = True 'cancel the form closing event
                'minimize to tray/hide etc here 
        End Select
    End Sub
End Class