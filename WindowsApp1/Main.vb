Imports System.Timers

Public Delegate Sub DelegateOnTimedEvent()

Public Class Main

    Private mRemoteControl As RemoteControl
    Private mSelectedModule As String
    Private gTimer As Timer
    Private mIsInitialized As Boolean = False

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gTimer = New Timer()
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        InitializeRemoteControl()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gTimer.Stop()
        Dispose()
    End Sub

    Private Sub OnTimedEvent(source As Object, e As System.Timers.ElapsedEventArgs)
        Dim lDelegateOnTimedEvent As DelegateOnTimedEvent = AddressOf Synchronize
        Invoke(lDelegateOnTimedEvent)
    End Sub

    Private Sub InitializeRemoteControl()

        Try

            If mRemoteControl IsNot Nothing Then
                mRemoteControl.Close()
                mRemoteControl = Nothing
            End If

            mRemoteControl = New RemoteControl()
            Text = mRemoteControl.GetDeviceName() ' Load the name of the device into window header
            RefreshModules()    ' Load installed modules
            RefreshFunctions()  ' Load functions that are currently possible
            RefreshMenus()      ' Load menu items
            RefreshLanguages()  ' Load languages

        Catch ex As RemoteControlException
            mRemoteControl = Nothing
            ToolStripStatusLabelMessage.Text = ex.Message
        End Try

        ' Create a timer And set a two second interval.
        gTimer.Interval = 500

        ' Hook up the Elapsed event for the timer.  
        AddHandler gTimer.Elapsed, AddressOf OnTimedEvent

        ' Have the timer fire repeated events (true Is the default)
        gTimer.AutoReset = True

        ' Start the timer
        gTimer.Enabled = True

        mIsInitialized = True

    End Sub

    Private Sub Synchronize()
        Dim lSelectedModule As String

        gTimer.Stop()

        If mRemoteControl Is Nothing Then
            Return
        End If

        Try

            ' Update measurement
            TextBoxMeasurementValue.Text = mRemoteControl.GetMeasurementValue()
            TextBoxMeasurementValue.Refresh()

            ' Update module
            lSelectedModule = mRemoteControl.GetSelectedModule()
            If lSelectedModule <> mSelectedModule Then
                ComboBoxModule.SelectedItem = lSelectedModule
                ' If the module is changed, then read functions and menu entries again
                RefreshModules()
                RefreshFunctions()
                RefreshMenus()
                RefreshLanguages()
                mSelectedModule = lSelectedModule
            End If

            ' Update function
            ComboBoxFunction.SelectedItem = mRemoteControl.GetSelectedFunction()

            ' Update menu
            ComboBoxMenu.SelectedItem = mRemoteControl.GetSelectedMenuItem()

        Catch ex As RemoteControlException
            ToolStripStatusLabelMessage.Text = ex.Message
        End Try

        gTimer.Start()
    End Sub

    Private Sub RefreshModules()
        ' Load installed modules
        ComboBoxModule.Items.Clear()
        For Each lModule As String In mRemoteControl.GetModules()
            ComboBoxModule.Items.Add(lModule)
        Next
        ' get selected module
        ComboBoxModule.SelectedItem = mRemoteControl.GetSelectedModule()
        mSelectedModule = ComboBoxModule.SelectedItem.ToString
    End Sub

    Private Sub ComboBoxModule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxModule.SelectedIndexChanged
        If mIsInitialized Then
            Dim lObject As ComboBox = CType(sender, ComboBox)
            mRemoteControl.SelectModule(lObject.SelectedIndex)

            If gTimer IsNot Nothing Then
                If Not gTimer.Enabled Then
                    gTimer.Start()
                End If
            End If
        End If
    End Sub

    Private Sub RefreshFunctions()
        ComboBoxFunction.Items.Clear()
        For Each lFunction As String In mRemoteControl.GetFunctions()
            ComboBoxFunction.Items.Add(lFunction)
        Next
        ' get selected function
        ComboBoxFunction.SelectedItem = mRemoteControl.GetSelectedFunction()
    End Sub

    Private Sub ComboBoxFunctions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFunction.SelectedIndexChanged
        If mIsInitialized Then
            Dim lObject As ComboBox = CType(sender, ComboBox)
            mRemoteControl.SelectFunction(lObject.SelectedIndex)

            If gTimer IsNot Nothing Then
                If Not gTimer.Enabled Then
                    gTimer.Start()
                End If
            End If
        End If
    End Sub

    Private Sub RefreshMenus()
        ComboBoxMenu.Items.Clear()
        For Each lMenu As String In mRemoteControl.GetMenuItems()
            ComboBoxMenu.Items.Add(lMenu)
        Next
        ' get selected menu item
        ComboBoxMenu.SelectedItem = mRemoteControl.GetSelectedMenuItem()
    End Sub

    Private Sub ComboBoxMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMenu.SelectedIndexChanged
        If mIsInitialized Then
            Dim lObject As ComboBox = CType(sender, ComboBox)
            mRemoteControl.SelectMenu(lObject.SelectedIndex)

            If gTimer IsNot Nothing Then
                If Not gTimer.Enabled Then
                    gTimer.Start()
                End If
            End If
        End If
    End Sub

    Private Sub RefreshLanguages()
        ComboBoxLanguage.Items.Clear()
        For Each lMenu As String In mRemoteControl.GetLanguage()
            ComboBoxLanguage.Items.Add(lMenu)
        Next
        ' get selected language
        ComboBoxLanguage.SelectedItem = mRemoteControl.GetSelectedLanguage()
    End Sub

    Private Sub ComboBoxLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLanguage.SelectedIndexChanged
        If mIsInitialized Then
            Dim lObject As ComboBox = CType(sender, ComboBox)
            mRemoteControl.SelectLanguage(lObject.SelectedIndex)

            If gTimer IsNot Nothing Then
                If Not gTimer.Enabled Then
                    gTimer.Start()
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButtonConnect_Click(sender As Object, e As EventArgs) Handles ToolStripButtonConnect.Click
        InitializeRemoteControl()
    End Sub

    Private Sub ToolStripButtonGetErrors_Click(sender As Object, e As EventArgs) Handles ToolStripButtonGetErrors.Click
        OutputErrors.Text = mRemoteControl.GetErrorLog()
    End Sub

    Private Sub ToolStripButtonErrorLogErase_Click(sender As Object, e As EventArgs) Handles ToolStripButtonErrorLogErase.Click
        ToolStripStatusLabelMessage.Text = mRemoteControl.EraseErrorLog()
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        Dim lTabControl As TabControl

        lTabControl = CType(sender, TabControl)
        Select Case lTabControl.SelectedIndex
            Case 1
                OutputText.Text = mRemoteControl.GetVersion()
            Case 2
                OutputErrors.Text = mRemoteControl.GetErrorLog()
        End Select
    End Sub
End Class
