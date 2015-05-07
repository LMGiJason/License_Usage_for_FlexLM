Imports System.IO

Public Class frmLicenseUsage
    Private mServerNode As TreeNode
    Private mProductNode As TreeNode
    Private mServersText As String
    Private mCurrentFolder As String
    Private mLmstatBat As String
    Private mLmremoveBat As String
    Private mOutputFile As String
    Private mLmremoveOutputFile As String
    Private WithEvents fileMan As New FileManager
    Private mSourceLicenseFolder As String
    Private mDestLicenseFolder As String
    Private mDestLicenseFile As String
    Private mFilterWasApplied As Boolean = False
    Private mHOST_NOT_FOUND As Boolean
    Private mServersFile As String

    Private Sub frmLicenseUsage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Text &= My.Application.Info.Version.ToString
            Me.cboRefresh.SelectedIndex = My.Settings.IntervalIndex
            Me.Location = My.Settings.FormLocation
            Me.Size = My.Settings.FormSize
            Me.Show()

            mCurrentFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
            mServersFile = Path.Combine(mCurrentFolder, "servers.txt")
            mServersText = IO.File.ReadAllText(mServersFile)

            gpLicense.Visible = GetLicenseFile()

            mLmstatBat = Path.Combine(mCurrentFolder, "lmstat.bat")
            mOutputFile = Path.Combine(mCurrentFolder, "Output.txt")
            mLmremoveOutputFile = Path.Combine(mCurrentFolder, "lmremoveOutput.txt")
            mLmremoveBat = Path.Combine(mCurrentFolder, "lmremove.bat")

            Refresh()
            Begin()
            CheckForHOST_NOT_FOUND()
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)
        End Try
    End Sub

    Private Sub CheckForHOST_NOT_FOUND()
        Timer1.Enabled = Not mHOST_NOT_FOUND
        If mHOST_NOT_FOUND Then
            Dim f As New frmSetServers
            If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If f.txtServers.Text.Contains("@") Then
                    Try
                        IO.File.WriteAllText(mServersFile, f.txtServers.Text)
                        mServersText = IO.File.ReadAllText(mServersFile)
                        btnRefresh.PerformClick()
                    Catch ex As Exception
                        MsgBox("Failed to write to " & mServersText, MsgBoxStyle.Critical, "Servers.txt")
                    End Try
                End If
            End If
        End If
    End Sub


    Private Function GetLicenseFile() As Boolean
        Dim licdatfl As String = Path.Combine(mCurrentFolder, "Licenses.txt")
        Dim lines() As String
        Dim oneLine As String
        Dim oneVal As String

        Try
            mDestLicenseFile = "SELicense.dat"
            If File.Exists(licdatfl) Then
                lines = File.ReadAllLines(licdatfl)

                For Each ln In lines
                    oneLine = ln.Trim
                    If oneLine.StartsWith("#") Then
                        Continue For
                    End If
                    If oneLine.StartsWith("Sourcefolder") Then
                        Dim data() As String = oneLine.Split("=")
                        If data.Length = 2 Then
                            oneVal = data(1).Trim
                            mSourceLicenseFolder = oneVal
                            Continue For
                        End If
                    End If

                    If oneLine.StartsWith("DestinationFolder") Then
                        Dim data() As String = oneLine.Split("=")
                        If data.Length = 2 Then
                            oneVal = data(1).Trim
                            mDestLicenseFolder = oneVal
                        End If
                    End If

                    If oneLine.StartsWith("DestLicenseFile") Then
                        Dim data() As String = oneLine.Split("=")
                        If data.Length = 2 Then
                            oneVal = data(1).Trim
                            mDestLicenseFile = oneVal
                        End If
                    End If
                Next

                If Directory.Exists(mSourceLicenseFolder) AndAlso Directory.Exists(mDestLicenseFolder) Then
                    Dim licFiles() As String = Directory.GetFiles(mSourceLicenseFolder)
                    If licFiles.Length > 0 Then
                        cboLicenses.Items.Clear()
                        For Each ln In licFiles
                            cboLicenses.Items.Add(Path.GetFileName(ln))
                        Next
                        Return True
                    End If
                End If
            End If
        Catch ex As Exception
            Return False
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)

        End Try
    End Function

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Try
            If cboLicenses.SelectedItem IsNot Nothing Then
                Dim thesrcFile As String = Path.Combine(mSourceLicenseFolder, cboLicenses.SelectedItem)
                Dim thedestFile As String = Path.Combine(mDestLicenseFolder, mDestLicenseFile)
                File.Copy(thesrcFile, thedestFile, True)
            End If
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)

        End Try
    End Sub


    Private Sub frmLicenseUsage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.IntervalIndex = Me.cboRefresh.SelectedIndex
        My.Settings.FormLocation = Me.Location
        My.Settings.FormSize = Me.Size
    End Sub

    Private Enum Linetype
        Product
        User
        Version
        Reservation
        Other
    End Enum

    Private Sub Begin()
        Try
            Cursor = Cursors.WaitCursor
            tvStatus.BeginUpdate()
            lblStatus.Text = "Processing..."
            StatusStrip1.Refresh()
            ProcessServers(mServersText)
            lblStatus.Text = "Done"
        Catch
            lblStatus.Text = "Error"
            Throw
        Finally
            Cursor = Cursors.Default
            tvStatus.EndUpdate()
        End Try

    End Sub

    Private Function GenerateBatAndOutput(ByVal server As String) As Boolean
        Dim str As String = "lmutil lmstat -a -c " & server & " > " & mOutputFile
        Try
            If IO.File.Exists(mOutputFile) Then
                IO.File.Delete(mOutputFile)
            End If
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)

            MsgBox("Failed to delete " & mOutputFile, MsgBoxStyle.Critical)
        End Try


        Try
            Using writer As New StreamWriter(mLmstatBat, False)
                writer.WriteLine(str)
                writer.Close()
            End Using
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)

            MsgBox("Failed to write " & mLmstatBat, MsgBoxStyle.Critical)
        End Try

        Try

            Dim num As Integer = Interaction.Shell("lmstat.bat", AppWinStyle.Hide, True, &H2710)
            Threading.Thread.Sleep(1000)
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)

            MsgBox("Shell failed.", MsgBoxStyle.Critical)
        End Try
        Return IO.File.Exists(mOutputFile)

    End Function

    Private Sub GenerateBatAndExecuteRemove(ByVal ud As UserData)
        Dim str As String = ud.GetLmRemove

        Try
            If IO.File.Exists(mLmremoveOutputFile) Then
                IO.File.Delete(mLmremoveOutputFile)
            End If
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)

            MsgBox("Failed to delete " & mLmremoveOutputFile, MsgBoxStyle.Critical)
        End Try


        Try
            Using writer As New StreamWriter(mLmremoveBat, False)
                writer.WriteLine(str)
                writer.Close()
            End Using
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)

            MsgBox("Failed to write " & mLmremoveOutputFile, MsgBoxStyle.Critical)
        End Try

        Try
            Dim num As Integer = Interaction.Shell("lmremove.bat", AppWinStyle.Hide, True, &H2710)
            Threading.Thread.Sleep(100)
            If File.Exists(mLmremoveOutputFile) Then
                MsgBox(File.ReadAllText(mLmremoveOutputFile), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)

            MsgBox("Shell failed.", MsgBoxStyle.Critical)
        End Try

    End Sub


    Private Function ProcessServers(ByVal servers As String) As Boolean
        txtLog.Text = "Processing..." & Environment.NewLine
        txtLog.AppendText(servers & Environment.NewLine)
        txtLog.AppendText(mCurrentFolder & Environment.NewLine & Environment.NewLine)
        mHOST_NOT_FOUND = False
        tvStatus.Nodes.Clear()
        If servers.Length = 0 Then
            MsgBox("Please set your server settings", MsgBoxStyle.Information, "Server Settings")
            Return False
        End If
        Dim svrs() As String = servers.Split(vbCrLf)
        For Each svr As String In svrs
            If svr.Contains("@") Then
                mOutputFile = Path.Combine(mCurrentFolder, svr.Trim & "_Output.txt")
                If GenerateBatAndOutput(svr.Trim) Then
                    PopulateListFromOutputFile(svr)
                End If
            End If
        Next
        If mFilterWasApplied Then ApplyFilter()
    End Function

    Private Sub PopulateListFromOutputFile(svr As String)
        'tvStatus.Nodes.Clear() caused only the last server to be processed
        mServerNode = New TreeNode(svr)
        tvStatus.Nodes.Add(mServerNode)
        AddServerData()
        mServerNode.Expand()
    End Sub

    Private Sub AddServerData()
        Dim strLine As String
        Dim usernode As TreeNode
        Dim userName As String
        Dim userDate As Date
        Dim productName As String = String.Empty
        Dim foundProduct As Boolean = False

        Using strm As Stream = fileMan.GetStream(mOutputFile, FileAccess.Read)
            Using reader As New StreamReader(strm)
                Do While Not reader.EndOfStream
                    strLine = reader.ReadLine
                    If strLine.Contains("HOST_NOT_FOUND") Or strLine.Contains("Error getting status") Then
                        mHOST_NOT_FOUND = True
                    End If
                    txtLog.AppendText(strLine & Environment.NewLine)
                    Select Case GetLineType(strLine)
                        Case Linetype.Version
                        Case Linetype.Reservation
                            If mProductNode IsNot Nothing Then
                                usernode = mProductNode.Nodes.Add(strLine)
                                usernode.ForeColor = Color.Black
                                usernode.ImageIndex = 2
                                usernode.SelectedImageIndex = 2

                                mProductNode.Expand()
                                If Not chkShowAllFeatures.Checked And foundProduct Then
                                    mServerNode.Nodes.Add(mProductNode)
                                End If
                                foundProduct = False

                            End If

                        Case Linetype.User
                            If mProductNode IsNot Nothing Then
                                mProductNode.ForeColor = Color.DarkGreen
                                mProductNode.ImageIndex = 1
                                mProductNode.SelectedImageIndex = 1

                                Dim ud As UserData = GetUserData(strLine, productName)
                                userName = ud.UserName & " " & ud.Machine
                                userDate = ud.UserDate

                                usernode = mProductNode.Nodes.Add((mProductNode.Nodes.Count + 1).ToString().PadRight(5) & userName & "  ->  " & userDate)
                                usernode.ForeColor = Color.Blue
                                usernode.ImageIndex = 2
                                usernode.SelectedImageIndex = 2
                                usernode.Tag = ud
                                WriteCSV(mServerNode.Text, userName, productName, userDate)

                                mProductNode.Expand()
                                If Not chkShowAllFeatures.Checked And foundProduct Then
                                    mServerNode.Nodes.Add(mProductNode)
                                End If
                                foundProduct = False
                            End If
                        Case Linetype.Product
                            foundProduct = True
                            productName = GetProductName(strLine)
                            mProductNode = New TreeNode(productName)
                            mProductNode.ImageIndex = 1
                            mProductNode.SelectedImageIndex = 1
                            If chkShowAllFeatures.Checked Then
                                mServerNode.Nodes.Add(mProductNode)
                            End If
                        Case Linetype.Other
                    End Select
                Loop
            End Using
        End Using

    End Sub

    Private Function GetLineType(ByVal txtLine As String) As Linetype
        If txtLine.Contains("(Total of ") Then
            Return Linetype.Product
        End If
        If txtLine.Contains("start ") Then
            Return Linetype.User
        End If
        If txtLine.Contains("Vendor daemon status") Then
            Return Linetype.Version
        End If
        '1 RESERVATION for USER rick (m70-1/27001)
        '1 RESERVATION for USER bob (m70-1/27001)
        If txtLine.Contains("RESERVATION") Then
            Return Linetype.Reservation
        End If
        Return Linetype.Other
    End Function

    Private Function GetProductName(ByVal inputLine As String) As String
        Dim usersOf As String = "Users of "
        Dim start As Integer = inputLine.IndexOf(usersOf) + usersOf.Length

        Dim prodData() As String = inputLine.Substring(start).Split(":")
        Dim total As String = CInt(Val(prodData(1).Substring(prodData(1).IndexOf("of") + 2)))

        'Dim length As Integer = inputLine.IndexOf(": ") - start
        Return prodData(0) & ":  Qty " & total
    End Function

    Private Function GetUserData(ByVal inputLine As String, ByVal feature As String) As UserData
        Dim parts() As String = inputLine.Replace("(", String.Empty).Replace(")", String.Empty).Replace(",", String.Empty).Trim.Split(" ")

        Dim ret(1) As String
        Array.Copy(parts, 0, ret, 0, 2)

        Dim time(2) As String
        Array.Copy(parts, 7, time, 0, 3)

        Dim monthday() As String = time(1).Split("/")
        Dim hourmin() As String = time(2).Split(":")

        Dim dt As Date = New Date(Date.Now.Year, Integer.Parse(monthday(0)), Integer.Parse(monthday(1)), Integer.Parse(hourmin(0)), Integer.Parse(hourmin(1)), 0)
        Dim ud As New UserData(parts(0), parts(5), parts(4).Split("/")(0), parts(4).Split("/")(1), feature.Split(":")(0), dt)
        Return ud
    End Function

    Private Function GetDate(ByVal inputLine As String) As Date
        Dim parts() As String = inputLine.Trim.Split(" ")

        Dim time(2) As String
        Array.Copy(parts, 7, time, 0, 3)

        Dim monthday() As String = time(1).Split("/")
        Dim hourmin() As String = time(2).Split(":")

        Return New Date(Date.Now.Year, Integer.Parse(monthday(0)), Integer.Parse(monthday(1)), Integer.Parse(hourmin(0)), Integer.Parse(hourmin(1)), 0)
    End Function

    Private Sub WriteCSV(ByVal server As String, ByVal user As String, ByVal product As String, ByVal d As Date)
        Dim fileName As String = Date.Now.DayOfYear & ".csv"
        Dim csvFile As String = Path.Combine(mCurrentFolder, fileName)
        Dim exists As Boolean = IO.File.Exists(csvFile)
        Dim prodData() As String = product.Split(":")
        Dim total As String = CInt(Val(prodData(1).Substring(prodData(1).IndexOf("Qty") + 3)))
        Dim datestring As String = d.ToString
        Using writer As New StreamWriter(csvFile, exists)
            writer.WriteLine(Date.Now.ToString & "," & d.ToString & "," & server & "," & user & "," & prodData(0).Trim & "," & total)
            writer.Close()
        End Using

    End Sub


    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            lblStatus.Text = "Processing..."
            StatusStrip1.Refresh()
            ProcessServers(mServersText)
            lblStatus.Text = "Done"
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)
        End Try
    End Sub

    Private Sub cboRefresh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRefresh.SelectedIndexChanged
        Timer1.Interval = CInt(cboRefresh.SelectedItem) * 60000
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Begin()
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)
        End Try

    End Sub

    Private Sub chkShowAllFeatures_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowAllFeatures.CheckedChanged
        Try
            Begin()
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)
        End Try

    End Sub

    Private Sub tvStatus_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvStatus.AfterSelect
        mnuCheckInLicense.Enabled = (e.Node.SelectedImageIndex = 2 And e.Node.Tag IsNot Nothing)
    End Sub

    Private Sub mnuCheckInLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckInLicense.Click
        Try
            GenerateBatAndExecuteRemove(tvStatus.SelectedNode.Tag)
            Begin()
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)
        End Try

    End Sub

    Private Sub lnkInfo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkInfo.LinkClicked
        Try
            Dim pis As ProcessStartInfo = New ProcessStartInfo("https://licenseuasageforflexlm.codeplex.com/")
            Process.Start(pis)
        Catch ex As Exception
            Me.txtLog.AppendText("ERROR" & Environment.NewLine)
            Me.txtLog.AppendText(ex.Message & Environment.NewLine)
            Me.txtLog.AppendText(ex.StackTrace)
        End Try

    End Sub

    Private Sub fileMan_OnTryGetStream(ByVal msg As String) Handles fileMan.OnTryGetStream
        lblStatus.Text = msg
        Me.txtLog.AppendText(msg & Environment.NewLine)
    End Sub

    Private Sub cboLicenses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLicenses.SelectedIndexChanged
        btnApply.Enabled = (cboLicenses.SelectedItem IsNot Nothing)
    End Sub

    Private Sub ApplyFilter()
        If txtFilter.Text.Length = 0 Then Return
        For Each machNd As TreeNode In tvStatus.Nodes
            For r As Integer = machNd.Nodes.Count - 1 To 0 Step -1
                Dim n As TreeNode = machNd.Nodes(r)
                If Not n.Text Like txtFilter.Text Then
                    n.Remove()
                    mFilterWasApplied = True
                End If
            Next
        Next
    End Sub

    Private Sub btnApplyFilter_Click(sender As Object, e As EventArgs) Handles btnApplyFilter.Click
        ApplyFilter()
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        mFilterWasApplied = False
    End Sub
End Class
