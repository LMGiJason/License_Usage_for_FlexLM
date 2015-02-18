Imports System.IO
Imports System.Threading
Imports System.Runtime.InteropServices

Public Class FileManager
    Private _numberOfTries As Integer = 60
    Private _timeIntervalBetweenTries As Integer = 1000
    Public Event OnTryGetStream(ByVal msg As String)

    Public Function GetStream(ByVal fileName As String, ByVal fileAccess As FileAccess) As FileStream
        Dim tries = 0
        While True
            Try
                RaiseEvent OnTryGetStream("File read attempt " & tries & "...")
                Return File.Open(fileName, FileMode.Open, fileAccess, FileShare.None)
            Catch e As IOException
                If Not IsFileLocked(e) Then
                    Throw
                End If
                If System.Threading.Interlocked.Increment(tries) > _numberOfTries Then
                    Throw New Exception("The file has been locked too long: " + e.Message, e)
                End If
                Thread.Sleep(_timeIntervalBetweenTries)
            End Try
        End While
        Return Nothing
    End Function

    Private Function IsFileLocked(ByVal exception As IOException) As Boolean
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function

End Class
