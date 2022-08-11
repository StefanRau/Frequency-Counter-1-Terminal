<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ToolStripContainer = New System.Windows.Forms.ToolStripContainer()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPageSettings = New System.Windows.Forms.TabPage()
        Me.ComboBoxModule = New System.Windows.Forms.ComboBox()
        Me.ComboBoxMenu = New System.Windows.Forms.ComboBox()
        Me.LabelMeasurementValue = New System.Windows.Forms.Label()
        Me.LabelMenu = New System.Windows.Forms.Label()
        Me.TextBoxMeasurementValue = New System.Windows.Forms.TextBox()
        Me.LabelModules = New System.Windows.Forms.Label()
        Me.ComboBoxLanguage = New System.Windows.Forms.ComboBox()
        Me.ComboBoxFunction = New System.Windows.Forms.ComboBox()
        Me.LabelLanguage = New System.Windows.Forms.Label()
        Me.LabelFunction = New System.Windows.Forms.Label()
        Me.TabPageLog = New System.Windows.Forms.TabPage()
        Me.OutputText = New System.Windows.Forms.RichTextBox()
        Me.TabPageErrors = New System.Windows.Forms.TabPage()
        Me.OutputErrors = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonConnect = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonGetErrors = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonErrorLogErase = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripTextBoxComPort = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripContainer.ContentPanel.SuspendLayout()
        Me.ToolStripContainer.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPageSettings.SuspendLayout()
        Me.TabPageLog.SuspendLayout()
        Me.TabPageErrors.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer
        '
        resources.ApplyResources(Me.ToolStripContainer, "ToolStripContainer")
        '
        'ToolStripContainer.BottomToolStripPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.BottomToolStripPanel, "ToolStripContainer.BottomToolStripPanel")
        '
        'ToolStripContainer.ContentPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.ContentPanel, "ToolStripContainer.ContentPanel")
        Me.ToolStripContainer.ContentPanel.Controls.Add(Me.TabControl)
        '
        'ToolStripContainer.LeftToolStripPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.LeftToolStripPanel, "ToolStripContainer.LeftToolStripPanel")
        Me.ToolStripContainer.Name = "ToolStripContainer"
        '
        'ToolStripContainer.RightToolStripPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.RightToolStripPanel, "ToolStripContainer.RightToolStripPanel")
        '
        'ToolStripContainer.TopToolStripPanel
        '
        resources.ApplyResources(Me.ToolStripContainer.TopToolStripPanel, "ToolStripContainer.TopToolStripPanel")
        Me.ToolStripContainer.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'TabControl
        '
        resources.ApplyResources(Me.TabControl, "TabControl")
        Me.TabControl.Controls.Add(Me.TabPageSettings)
        Me.TabControl.Controls.Add(Me.TabPageLog)
        Me.TabControl.Controls.Add(Me.TabPageErrors)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        '
        'TabPageSettings
        '
        resources.ApplyResources(Me.TabPageSettings, "TabPageSettings")
        Me.TabPageSettings.Controls.Add(Me.ComboBoxModule)
        Me.TabPageSettings.Controls.Add(Me.ComboBoxMenu)
        Me.TabPageSettings.Controls.Add(Me.LabelMeasurementValue)
        Me.TabPageSettings.Controls.Add(Me.LabelMenu)
        Me.TabPageSettings.Controls.Add(Me.TextBoxMeasurementValue)
        Me.TabPageSettings.Controls.Add(Me.LabelModules)
        Me.TabPageSettings.Controls.Add(Me.ComboBoxLanguage)
        Me.TabPageSettings.Controls.Add(Me.ComboBoxFunction)
        Me.TabPageSettings.Controls.Add(Me.LabelLanguage)
        Me.TabPageSettings.Controls.Add(Me.LabelFunction)
        Me.TabPageSettings.Name = "TabPageSettings"
        Me.TabPageSettings.UseVisualStyleBackColor = True
        '
        'ComboBoxModule
        '
        resources.ApplyResources(Me.ComboBoxModule, "ComboBoxModule")
        Me.ComboBoxModule.CausesValidation = False
        Me.ComboBoxModule.Name = "ComboBoxModule"
        '
        'ComboBoxMenu
        '
        resources.ApplyResources(Me.ComboBoxMenu, "ComboBoxMenu")
        Me.ComboBoxMenu.FormattingEnabled = True
        Me.ComboBoxMenu.Name = "ComboBoxMenu"
        '
        'LabelMeasurementValue
        '
        resources.ApplyResources(Me.LabelMeasurementValue, "LabelMeasurementValue")
        Me.LabelMeasurementValue.Name = "LabelMeasurementValue"
        '
        'LabelMenu
        '
        resources.ApplyResources(Me.LabelMenu, "LabelMenu")
        Me.LabelMenu.Name = "LabelMenu"
        '
        'TextBoxMeasurementValue
        '
        resources.ApplyResources(Me.TextBoxMeasurementValue, "TextBoxMeasurementValue")
        Me.TextBoxMeasurementValue.Name = "TextBoxMeasurementValue"
        Me.TextBoxMeasurementValue.ReadOnly = True
        '
        'LabelModules
        '
        resources.ApplyResources(Me.LabelModules, "LabelModules")
        Me.LabelModules.Name = "LabelModules"
        '
        'ComboBoxLanguage
        '
        resources.ApplyResources(Me.ComboBoxLanguage, "ComboBoxLanguage")
        Me.ComboBoxLanguage.FormattingEnabled = True
        Me.ComboBoxLanguage.Name = "ComboBoxLanguage"
        '
        'ComboBoxFunction
        '
        resources.ApplyResources(Me.ComboBoxFunction, "ComboBoxFunction")
        Me.ComboBoxFunction.FormattingEnabled = True
        Me.ComboBoxFunction.Name = "ComboBoxFunction"
        '
        'LabelLanguage
        '
        resources.ApplyResources(Me.LabelLanguage, "LabelLanguage")
        Me.LabelLanguage.Name = "LabelLanguage"
        '
        'LabelFunction
        '
        resources.ApplyResources(Me.LabelFunction, "LabelFunction")
        Me.LabelFunction.Name = "LabelFunction"
        '
        'TabPageLog
        '
        resources.ApplyResources(Me.TabPageLog, "TabPageLog")
        Me.TabPageLog.Controls.Add(Me.OutputText)
        Me.TabPageLog.Name = "TabPageLog"
        Me.TabPageLog.UseVisualStyleBackColor = True
        '
        'OutputText
        '
        resources.ApplyResources(Me.OutputText, "OutputText")
        Me.OutputText.Name = "OutputText"
        '
        'TabPageErrors
        '
        resources.ApplyResources(Me.TabPageErrors, "TabPageErrors")
        Me.TabPageErrors.Controls.Add(Me.OutputErrors)
        Me.TabPageErrors.Name = "TabPageErrors"
        Me.TabPageErrors.UseVisualStyleBackColor = True
        '
        'OutputErrors
        '
        resources.ApplyResources(Me.OutputErrors, "OutputErrors")
        Me.OutputErrors.Name = "OutputErrors"
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonConnect, Me.ToolStripButtonGetErrors, Me.ToolStripButtonErrorLogErase, Me.ToolStripTextBoxComPort})
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'ToolStripButtonConnect
        '
        resources.ApplyResources(Me.ToolStripButtonConnect, "ToolStripButtonConnect")
        Me.ToolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonConnect.Name = "ToolStripButtonConnect"
        '
        'ToolStripButtonGetErrors
        '
        resources.ApplyResources(Me.ToolStripButtonGetErrors, "ToolStripButtonGetErrors")
        Me.ToolStripButtonGetErrors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonGetErrors.Name = "ToolStripButtonGetErrors"
        '
        'ToolStripButtonErrorLogErase
        '
        resources.ApplyResources(Me.ToolStripButtonErrorLogErase, "ToolStripButtonErrorLogErase")
        Me.ToolStripButtonErrorLogErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonErrorLogErase.Name = "ToolStripButtonErrorLogErase"
        '
        'StatusStrip1
        '
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelMessage})
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'ToolStripStatusLabelMessage
        '
        resources.ApplyResources(Me.ToolStripStatusLabelMessage, "ToolStripStatusLabelMessage")
        Me.ToolStripStatusLabelMessage.Name = "ToolStripStatusLabelMessage"
        '
        'ToolStripTextBoxComPort
        '
        resources.ApplyResources(Me.ToolStripTextBoxComPort, "ToolStripTextBoxComPort")
        Me.ToolStripTextBoxComPort.Name = "ToolStripTextBoxComPort"
        '
        'Main
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Main"
        Me.ToolStripContainer.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ResumeLayout(False)
        Me.ToolStripContainer.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPageSettings.ResumeLayout(False)
        Me.TabPageSettings.PerformLayout()
        Me.TabPageLog.ResumeLayout(False)
        Me.TabPageErrors.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OutputText As RichTextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabelMessage As ToolStripStatusLabel
    Friend WithEvents ToolStripContainer As ToolStripContainer
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPageSettings As TabPage
    Friend WithEvents ComboBoxModule As ComboBox
    Friend WithEvents ComboBoxMenu As ComboBox
    Friend WithEvents LabelMeasurementValue As Label
    Friend WithEvents LabelMenu As Label
    Friend WithEvents TextBoxMeasurementValue As TextBox
    Friend WithEvents LabelModules As Label
    Friend WithEvents ComboBoxLanguage As ComboBox
    Friend WithEvents ComboBoxFunction As ComboBox
    Friend WithEvents LabelLanguage As Label
    Friend WithEvents LabelFunction As Label
    Friend WithEvents TabPageLog As TabPage
    Friend WithEvents TabPageErrors As TabPage
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButtonConnect As ToolStripButton
    Friend WithEvents OutputErrors As RichTextBox
    Friend WithEvents ToolStripButtonGetErrors As ToolStripButton
    Friend WithEvents ToolStripButtonErrorLogErase As ToolStripButton
    Friend WithEvents ToolStripTextBoxComPort As ToolStripTextBox
End Class
