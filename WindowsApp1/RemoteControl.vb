Imports System.Globalization
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Threading
Imports WindowsApp1.My.Resources

Public Class RemoteControl
    Private Const cSeparator As Char = CChar(",")
    Private mComPort As Ports.SerialPort = Nothing
    Private ReadOnly mModules As New Dictionary(Of String, String)
    Private ReadOnly mFunctions As New Dictionary(Of String, String)
    Private ReadOnly mMenuItems As New Dictionary(Of String, String)
    Private ReadOnly mLanguages As New Dictionary(Of String, String)

    Sub New()
        ' Open the resource and block it
        Try

            mComPort = My.Computer.Ports.OpenSerialPort("COM3", 115200, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)

            ' Reset Arduino
            mComPort.DtrEnable = True
            Thread.Sleep(100)
            mComPort.DtrEnable = False
            mComPort.ReadTimeout = 10000
            ' Read startup message
            Main.ToolStripStatusLabelMessage.Text = mComPort.ReadLine()

        Catch ex As TimeoutException
            Throw New RemoteControlException(RemoteControlResource.Tiemout, ex)
        Catch ex As UnauthorizedAccessException
            Throw New RemoteControlException(RemoteControlResource.PortIsLocked, ex)
        Catch ex As IOException
            Throw New RemoteControlException(RemoteControlResource.PortIsClosed, ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Close()
    End Sub

    ''' <summary>
    ''' Closes the connection
    ''' </summary>
    Public Sub Close()
        If mComPort IsNot Nothing Then
            ' Release the resource
            mComPort.Close()
            mComPort.Dispose()
            mComPort = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Processes a command
    ''' </summary>
    ''' <remarks>Processes a complete command</remarks>
    ''' <param name="iCommand">Contains the command string</param>
    ''' <returns>
    ''' Empty string: error in command processing
    ''' Otherwise: result of the command
    ''' </returns>
    Private Function ProcessCommand(iCommand As String) As String
        Dim lResponseLetter As Char
        Dim lResponse As String = ""
        Dim lCommandFailed As Boolean = False
        Dim lFailCounter As Integer

        If iCommand Is Nothing Then
            Throw New RemoteControlException(RemoteControlResource.EmptyCommand)
        End If

        If iCommand = "" Then
            Throw New RemoteControlException(RemoteControlResource.EmptyCommand)
        End If

        Try
            CleanBuffer()

            Do

                ' Send out the command
                mComPort.WriteLine(iCommand)

                ' Retrieve the echo as confirmation that hardware works
                Dim lEcho As String = mComPort.ReadLine()
                If lEcho <> (iCommand + "#" + vbCr) Then
                    ' If the echo is different to the command, then something else went wrong
                    lCommandFailed = True
                    lFailCounter += 1

                    If lFailCounter > 5 Then
                        ' After 5 failures either the command does not exist or something alse went wrong
                        Throw New RemoteControlException(RemoteControlResource.WrongCommand, iCommand)
                    End If

                End If

            Loop While lCommandFailed

            ' Collects the result of the command
            Do
                lResponseLetter = Chr(mComPort.ReadChar())
                If lResponseLetter <> "#" Then
                    lResponse += lResponseLetter
                End If
            Loop While lResponseLetter <> "#"

        Catch ex As IOException
            Throw New RemoteControlException(RemoteControlResource.ConnectionProblem, ex)
        Catch ex As InvalidOperationException
            Throw New RemoteControlException(RemoteControlResource.PortIsClosed, ex)
        Catch ex As TimeoutException
            Throw New RemoteControlException(RemoteControlResource.Tiemout, ex)
        Catch ex As RemoteControlException
            Throw
        End Try

        Return lResponse
    End Function

    ''' <summary>
    ''' Cleans serial input buffer
    ''' </summary>
    Private Sub CleanBuffer()
        Thread.Sleep(1)        ' Wait until its processed in remote device 
        ' Clean up input buffer
        mComPort.DiscardInBuffer()
        'While mComPort.BytesToRead <> 0
        '    mComPort.ReadChar()
        'End While
    End Sub

    ''' <summary>
    ''' Get version and other information
    ''' </summary>
    ''' <remarks>Returns beside the version also all information about the hardware.</remarks>
    ''' <returns>String with all information</returns>
    Public Function GetVersion() As String
        Return ProcessCommand("S:V")
    End Function

    ''' <summary>
    ''' Get the name of the connected device
    ''' </summary>
    ''' <remarks>Returns the name of the connected hardware.</remarks>
    ''' <returns>String with all information</returns>
    Public Function GetDeviceName() As String
        Return ProcessCommand("S:N")
    End Function

    ''' <summary>
    ''' Get error log
    ''' </summary>
    ''' <remarks>Returns the complete error log.</remarks>
    ''' <returns>String with all information</returns>
    Public Function GetErrorLog() As String
        Dim lDummy As String
        Dim lLogSize As Integer
        Dim lReturn As String = ""

        lLogSize = Convert.ToInt32(ProcessCommand("E:S"))
        lDummy = ProcessCommand("E:0")
        For lIterator As Integer = 1 To lLogSize
            lReturn += ProcessCommand("E:R")
        Next

        Return lReturn
    End Function

    ''' <summary>
    ''' Get error log
    ''' </summary>
    ''' <remarks>Returns the complete error log.</remarks>
    ''' <returns>String with all information</returns>
    Public Function EraseErrorLog() As String
        Return ProcessCommand("E:F")
    End Function

    ''' <summary>
    ''' Reads the current measurement value
    ''' </summary>
    ''' <returns>String with measurement value</returns>
    Public Function GetMeasurementValue() As String
        Return ProcessCommand("D:")
    End Function

    ''' <summary>
    ''' Returns all modules
    ''' </summary>
    ''' <remarks>Gets the list of all availlable modules</remarks>
    ''' <returns>List of modules</returns>
    Public Function GetModules() As String()
        Dim lDummy As String
        Dim lNamesCommaSeparated As String
        Dim lCodes As String
        Dim lNames As String()

        ' get all data
        lDummy = ProcessCommand("S:s") ' Switch on short mode
        lCodes = ProcessCommand("M:*")
        lDummy = ProcessCommand("S:v") ' Switch on verbose mode
        lNamesCommaSeparated = ProcessCommand("M:*")

        ' put data into List
        lNames = lNamesCommaSeparated.Split(cSeparator)
        mModules.Clear()

        For lIterator As Integer = 1 To lCodes.Length
            mModules.Add(lCodes.Substring(lIterator - 1, 1), CStr(lNames.GetValue(lIterator - 1)))
        Next

        Return lNames
    End Function

    ''' <summary>
    ''' Gets the module that is currently selected
    ''' </summary>
    ''' <returns>Module name</returns>
    Public Function GetSelectedModule() As String
        Dim lDummy As String
        Dim lSelectedModule As String

        lDummy = ProcessCommand("S:v") ' Switch on verbose mode
        lSelectedModule = ProcessCommand("M:?")
        lDummy = ProcessCommand("S:s") ' Switch on short mode

        Return lSelectedModule
    End Function

    ''' <summary>
    ''' Returns all functions - depending on module
    ''' </summary>
    ''' <remarks>Gets the list of all availlable functions</remarks>
    ''' <returns>List of functions</returns>
    Public Function GetFunctions() As String()
        Dim lDummy As String
        Dim lNamesCommaSeparated As String
        Dim lCodes As String
        Dim lNames As String()

        lDummy = ProcessCommand("S:s") ' Switch on short mode
        lCodes = ProcessCommand("F:*")
        lDummy = ProcessCommand("S:v") ' Switch on verbose mode
        lNamesCommaSeparated = ProcessCommand("F:*")

        ' put data into List
        lNames = lNamesCommaSeparated.Split(cSeparator)
        mFunctions.Clear()

        For lIterator As Integer = 1 To lCodes.Length
            mFunctions.Add(lCodes.Substring(lIterator - 1, 1), CStr(lNames.GetValue(lIterator - 1)))
        Next

        Return lNames
    End Function

    ''' <summary>
    ''' Gets the function that is currently selected
    ''' </summary>
    ''' <returns>Function name</returns>
    Public Function GetSelectedFunction() As String
        Dim lDummy As String
        Dim lSelectedFunction As String

        lDummy = ProcessCommand("S:v") ' Switch on verbose mode
        lSelectedFunction = ProcessCommand("F:?")
        lDummy = ProcessCommand("S:s") ' Switch on short mode

        Return lSelectedFunction
    End Function

    ''' <summary>
    ''' Returns all menu entries - depending on module
    ''' </summary>
    ''' <remarks>Gets the list of all availlable menu entries</remarks>
    ''' <returns>List of menu entries</returns>
    Public Function GetMenuItems() As String()
        Dim lDummy As String
        Dim lNamesCommaSeparated As String
        Dim lCodes As String
        Dim lNames As String()

        lDummy = ProcessCommand("S:s") ' Switch on short mode
        lCodes = ProcessCommand("K:*")
        lDummy = ProcessCommand("S:v") ' Switch on verbose mode
        lNamesCommaSeparated = ProcessCommand("K:*")

        ' put data into List
        lNames = lNamesCommaSeparated.Split(cSeparator)
        mMenuItems.Clear()

        For lIterator As Integer = 1 To lCodes.Length
            mMenuItems.Add(lCodes.Substring(lIterator - 1, 1), CStr(lNames.GetValue(lIterator - 1)))
        Next

        Return lNames
    End Function

    ''' <summary>
    ''' Gets the menu item that is currently selected
    ''' </summary>
    ''' <returns>Function name</returns>
    Public Function GetSelectedMenuItem() As String
        Dim lDummy As String
        Dim lSelectedFunction As String

        lDummy = ProcessCommand("S:v") ' Switch on verbose mode
        lSelectedFunction = ProcessCommand("K:?")
        lDummy = ProcessCommand("S:s") ' Switch on short mode

        Return lSelectedFunction
    End Function

    ''' <summary>
    ''' Returns all Languages
    ''' </summary>
    ''' <remarks>Gets the list of all availlable menu entries</remarks>
    ''' <returns>List of menu entries</returns>
    Public Function GetLanguage() As String()
        Dim lDummy As String
        Dim lNamesCommaSeparated As String
        Dim lCodes As String
        Dim lNames As String()

        lDummy = ProcessCommand("S:s") ' Switch on short mode
        lCodes = ProcessCommand("L:*")
        lDummy = ProcessCommand("S:v") ' Switch on verbose mode
        lNamesCommaSeparated = ProcessCommand("L:*")

        ' put data into List
        lNames = lNamesCommaSeparated.Split(cSeparator)
        mLanguages.Clear()

        For lIterator As Integer = 1 To lCodes.Length
            mLanguages.Add(lCodes.Substring(lIterator - 1, 1), CStr(lNames.GetValue(lIterator - 1)))
        Next

        Return lNames
    End Function

    ''' <summary>
    ''' Gets the menu item that is currently selected
    ''' </summary>
    ''' <returns>Function name</returns>
    Public Function GetSelectedLanguage() As String
        Dim lDummy As String
        Dim lSelectedFunction As String

        lDummy = ProcessCommand("S:v") ' Switch on verbose mode
        lSelectedFunction = ProcessCommand("L:?")
        lDummy = ProcessCommand("S:s") ' Switch on short mode

        Return lSelectedFunction
    End Function

    ''' <summary>
    ''' Sends the module selection to device
    ''' </summary>
    ''' <param name="iFunction"></param>
    Public Sub SelectModule(iFunction As Integer)
        Dim lCommand As String = "M:" + mModules.Keys.ElementAt(iFunction)
        ProcessCommand(lCommand)
    End Sub

    ''' <summary>
    ''' Sends function selection to device
    ''' </summary>
    Public Sub SelectFunction(iFunction As Integer)
        Dim lCommand As String = "F:" + mFunctions.Keys.ElementAt(iFunction)
        ProcessCommand(lCommand)
    End Sub

    ''' <summary>
    ''' Sends menu selection to device
    ''' </summary>
    Public Sub SelectMenu(iFunction As Integer)
        Dim lCommand As String = "K:" + mMenuItems.Keys.ElementAt(iFunction)
        ProcessCommand(lCommand)
    End Sub

    ''' <summary>
    ''' Sends Language selection to device
    ''' </summary>
    Public Sub SelectLanguage(iFunction As Integer)
        Dim lCommand As String = "L:" + mLanguages.Keys.ElementAt(iFunction)
        ProcessCommand(lCommand)
    End Sub

End Class

Public Class RemoteControlException
    Inherits Exception

    Sub New()
        MyBase.New()
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, innerException As Exception)
        MyBase.New(message, innerException)
    End Sub

    Protected Sub New(info As SerializationInfo, context As StreamingContext)
        MyBase.New(info, context)
    End Sub

    Public Sub New(message As String, ParamArray args() As String)
        MyBase.New(String.Format(CultureInfo.CurrentCulture, message, args))
    End Sub

    Public Sub New(message As String, innerException As Exception, ParamArray args() As String)
        MyBase.New(String.Format(CultureInfo.CurrentCulture, message, args), innerException)
    End Sub

End Class
