<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterFD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterFD))
        Me.MFD_Next = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MasterFlashDrive = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'MFD_Next
        '
        Me.MFD_Next.Location = New System.Drawing.Point(100, 227)
        Me.MFD_Next.Name = "MFD_Next"
        Me.MFD_Next.Size = New System.Drawing.Size(75, 23)
        Me.MFD_Next.TabIndex = 1
        Me.MFD_Next.Text = "Next"
        Me.MFD_Next.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select the master flash drive from the list, then click next."
        '
        'MasterFlashDrive
        '
        Me.MasterFlashDrive.FormattingEnabled = True
        Me.MasterFlashDrive.Location = New System.Drawing.Point(12, 51)
        Me.MasterFlashDrive.Name = "MasterFlashDrive"
        Me.MasterFlashDrive.Size = New System.Drawing.Size(260, 160)
        Me.MasterFlashDrive.TabIndex = 0
        '
        'MasterFD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MFD_Next)
        Me.Controls.Add(Me.MasterFlashDrive)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MasterFD"
        Me.Text = "Flash Format"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MFD_Next As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MasterFlashDrive As System.Windows.Forms.ListBox
End Class
