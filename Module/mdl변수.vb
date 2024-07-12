Module mdl변수

    Public Const strP_ProgramName = "e-Form Agent"
    Public Const strP_ProgramHanName = "HIRA_AGENT"

    Public m요양기관번호 As String

    Public Dyn_Response As HIRA.DynamicEntry.ResponseModel.DynamicResponse
    Public Dyn As HIRA.DynamicEntry.Model.DynamicRequest

    Public dicG_Request As New Dictionary(Of String, String)
    Public dicG_Search As New Dictionary(Of String, String)
    Public dicG_Delete As New Dictionary(Of String, String)

End Module
