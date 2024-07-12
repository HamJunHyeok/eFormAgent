Public Class clsEplus암복호화

    Dim clsD_Eplue암복호화 As NeoESnet.clsNeoES
    Dim clsD_EplueSha256 As NeoESnet.clsNeoSha256

    Public Sub New()
        clsD_Eplue암복호화 = New NeoESnet.clsNeoES
        clsD_EplueSha256 = New NeoESnet.clsNeoSha256
    End Sub

    Protected Overrides Sub Finalize()
        clsD_Eplue암복호화 = Nothing
        clsD_EplueSha256 = Nothing
    End Sub

    Public Function fG_복호화(ByRef strValue As String) As String
        On Error Resume Next

        Return clsD_Eplue암복호화.fG_ES1(strValue, "A")

    End Function

    Public Function fG_암호화(ByRef strValue As String) As String

        Return clsD_Eplue암복호화.fG_ES2(strValue)

    End Function

End Class
