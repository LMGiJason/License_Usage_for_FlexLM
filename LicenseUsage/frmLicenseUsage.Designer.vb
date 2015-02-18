<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicenseUsage
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLicenseUsage))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tabLog = New System.Windows.Forms.TabPage()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.tabStatus = New System.Windows.Forms.TabPage()
        Me.gpLicense = New System.Windows.Forms.GroupBox()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.cboLicenses = New System.Windows.Forms.ComboBox()
        Me.gpStatus = New System.Windows.Forms.GroupBox()
        Me.btnApplyFilter = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRefresh = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkShowAllFeatures = New System.Windows.Forms.CheckBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lnkInfo = New System.Windows.Forms.LinkLabel()
        Me.tvStatus = New System.Windows.Forms.TreeView()
        Me.RMB = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCheckInLicense = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabs = New System.Windows.Forms.TabControl()
        Me.StatusStrip1.SuspendLayout()
        Me.tabLog.SuspendLayout()
        Me.tabStatus.SuspendLayout()
        Me.gpLicense.SuspendLayout()
        Me.gpStatus.SuspendLayout()
        Me.RMB.SuspendLayout()
        Me.tabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Server.png")
        Me.ImageList1.Images.SetKeyName(1, "Product.png")
        Me.ImageList1.Images.SetKeyName(2, "User.png")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 635)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(682, 25)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(50, 20)
        Me.lblStatus.Text = "Ready"
        '
        'Timer1
        '
        '
        'tabLog
        '
        Me.tabLog.Controls.Add(Me.txtLog)
        Me.tabLog.Location = New System.Drawing.Point(4, 25)
        Me.tabLog.Name = "tabLog"
        Me.tabLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLog.Size = New System.Drawing.Size(674, 606)
        Me.tabLog.TabIndex = 2
        Me.tabLog.Text = "Log"
        Me.tabLog.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.SystemColors.Info
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Location = New System.Drawing.Point(3, 3)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(668, 600)
        Me.txtLog.TabIndex = 0
        '
        'tabStatus
        '
        Me.tabStatus.Controls.Add(Me.gpLicense)
        Me.tabStatus.Controls.Add(Me.gpStatus)
        Me.tabStatus.Controls.Add(Me.lnkInfo)
        Me.tabStatus.Controls.Add(Me.tvStatus)
        Me.tabStatus.Location = New System.Drawing.Point(4, 25)
        Me.tabStatus.Name = "tabStatus"
        Me.tabStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStatus.Size = New System.Drawing.Size(674, 606)
        Me.tabStatus.TabIndex = 0
        Me.tabStatus.Text = "Status"
        Me.tabStatus.UseVisualStyleBackColor = True
        '
        'gpLicense
        '
        Me.gpLicense.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpLicense.Controls.Add(Me.btnApply)
        Me.gpLicense.Controls.Add(Me.cboLicenses)
        Me.gpLicense.Location = New System.Drawing.Point(345, 433)
        Me.gpLicense.Name = "gpLicense"
        Me.gpLicense.Size = New System.Drawing.Size(317, 124)
        Me.gpLicense.TabIndex = 7
        Me.gpLicense.TabStop = False
        Me.gpLicense.Text = "License"
        '
        'btnApply
        '
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(107, 75)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(144, 26)
        Me.btnApply.TabIndex = 2
        Me.btnApply.Text = "Apply License"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'cboLicenses
        '
        Me.cboLicenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLicenses.FormattingEnabled = True
        Me.cboLicenses.Location = New System.Drawing.Point(20, 37)
        Me.cboLicenses.Name = "cboLicenses"
        Me.cboLicenses.Size = New System.Drawing.Size(231, 24)
        Me.cboLicenses.TabIndex = 1
        '
        'gpStatus
        '
        Me.gpStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpStatus.Controls.Add(Me.btnApplyFilter)
        Me.gpStatus.Controls.Add(Me.txtFilter)
        Me.gpStatus.Controls.Add(Me.Label1)
        Me.gpStatus.Controls.Add(Me.cboRefresh)
        Me.gpStatus.Controls.Add(Me.Label2)
        Me.gpStatus.Controls.Add(Me.chkShowAllFeatures)
        Me.gpStatus.Controls.Add(Me.btnRefresh)
        Me.gpStatus.Location = New System.Drawing.Point(7, 434)
        Me.gpStatus.Name = "gpStatus"
        Me.gpStatus.Size = New System.Drawing.Size(332, 160)
        Me.gpStatus.TabIndex = 7
        Me.gpStatus.TabStop = False
        Me.gpStatus.Text = "Status"
        '
        'btnApplyFilter
        '
        Me.btnApplyFilter.Location = New System.Drawing.Point(195, 21)
        Me.btnApplyFilter.Name = "btnApplyFilter"
        Me.btnApplyFilter.Size = New System.Drawing.Size(72, 24)
        Me.btnApplyFilter.TabIndex = 12
        Me.btnApplyFilter.Text = "Apply"
        Me.btnApplyFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LicenseUsage.My.MySettings.Default, "Filter", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtFilter.Location = New System.Drawing.Point(91, 24)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(98, 22)
        Me.txtFilter.TabIndex = 11
        Me.txtFilter.Text = Global.LicenseUsage.My.MySettings.Default.Filter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Filter list:"
        '
        'cboRefresh
        '
        Me.cboRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboRefresh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRefresh.FormattingEnabled = True
        Me.cboRefresh.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "10", "20", "30", "60", "120"})
        Me.cboRefresh.Location = New System.Drawing.Point(125, 112)
        Me.cboRefresh.Name = "cboRefresh"
        Me.cboRefresh.Size = New System.Drawing.Size(121, 24)
        Me.cboRefresh.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Refresh min:"
        '
        'chkShowAllFeatures
        '
        Me.chkShowAllFeatures.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShowAllFeatures.AutoSize = True
        Me.chkShowAllFeatures.Location = New System.Drawing.Point(125, 72)
        Me.chkShowAllFeatures.Name = "chkShowAllFeatures"
        Me.chkShowAllFeatures.Size = New System.Drawing.Size(143, 21)
        Me.chkShowAllFeatures.TabIndex = 7
        Me.chkShowAllFeatures.Text = "Show All Features"
        Me.chkShowAllFeatures.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(18, 67)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(91, 26)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lnkInfo
        '
        Me.lnkInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkInfo.AutoSize = True
        Me.lnkInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkInfo.Location = New System.Drawing.Point(602, 569)
        Me.lnkInfo.Name = "lnkInfo"
        Me.lnkInfo.Size = New System.Drawing.Size(60, 25)
        Me.lnkInfo.TabIndex = 6
        Me.lnkInfo.TabStop = True
        Me.lnkInfo.Text = "Info ?"
        '
        'tvStatus
        '
        Me.tvStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvStatus.ContextMenuStrip = Me.RMB
        Me.tvStatus.ImageIndex = 0
        Me.tvStatus.ImageList = Me.ImageList1
        Me.tvStatus.Location = New System.Drawing.Point(8, 6)
        Me.tvStatus.Name = "tvStatus"
        Me.tvStatus.SelectedImageIndex = 0
        Me.tvStatus.ShowPlusMinus = False
        Me.tvStatus.ShowRootLines = False
        Me.tvStatus.Size = New System.Drawing.Size(654, 421)
        Me.tvStatus.TabIndex = 0
        '
        'RMB
        '
        Me.RMB.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCheckInLicense})
        Me.RMB.Name = "RMB"
        Me.RMB.Size = New System.Drawing.Size(186, 28)
        '
        'mnuCheckInLicense
        '
        Me.mnuCheckInLicense.Enabled = False
        Me.mnuCheckInLicense.Name = "mnuCheckInLicense"
        Me.mnuCheckInLicense.Size = New System.Drawing.Size(185, 24)
        Me.mnuCheckInLicense.Text = "Check In License"
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.tabStatus)
        Me.tabs.Controls.Add(Me.tabLog)
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(682, 635)
        Me.tabs.TabIndex = 0
        '
        'frmLicenseUsage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 660)
        Me.Controls.Add(Me.tabs)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(700, 700)
        Me.Name = "frmLicenseUsage"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "License Usage V"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tabLog.ResumeLayout(False)
        Me.tabLog.PerformLayout()
        Me.tabStatus.ResumeLayout(False)
        Me.tabStatus.PerformLayout()
        Me.gpLicense.ResumeLayout(False)
        Me.gpStatus.ResumeLayout(False)
        Me.gpStatus.PerformLayout()
        Me.RMB.ResumeLayout(False)
        Me.tabs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tabLog As System.Windows.Forms.TabPage
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents tabStatus As System.Windows.Forms.TabPage
    Friend WithEvents tvStatus As System.Windows.Forms.TreeView
    Friend WithEvents tabs As System.Windows.Forms.TabControl
    Friend WithEvents RMB As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCheckInLicense As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lnkInfo As System.Windows.Forms.LinkLabel
    Friend WithEvents gpLicense As System.Windows.Forms.GroupBox
    Friend WithEvents gpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents cboRefresh As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkShowAllFeatures As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents cboLicenses As System.Windows.Forms.ComboBox
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnApplyFilter As System.Windows.Forms.Button

End Class
