Public Class UserData
    Public UserName As String
    Public Machine As String
    Public Port As String
    Public Handle As String
    Public Feature As String
    Public UserDate As Date

    Public Sub New(ByVal u As String, ByVal h As String, ByVal m As String, ByVal p As String, ByVal f As String, ByVal d As Date)
        UserName = u
        Machine = m
        Port = p
        Feature = f
        Handle = h
        UserDate = d
    End Sub

    Public Function GetLmRemove() As String
        Return "lmutil lmremove -c " & Port & "@" & Machine & " -h " & Feature & " " & Machine & " " & Port & " " & Handle & " >lmremoveOutput.txt"
    End Function
End Class
