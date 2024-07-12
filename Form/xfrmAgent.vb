Imports NeoModule

Public Class xfrmAgent

    Private WithEvents trayIcon As NotifyIcon
    Private WithEvents trayMenu As ContextMenu
    Private WithEvents ExecuteTimer As New Timer With {.Interval = 3000, .Enabled = False}
    Private WithEvents RequestTimer As New Timer With {.Interval = 3000, .Enabled = True}

    Private WithEvents Alarm As New Timer With {.Interval = 30000, .Enabled = True}

    Private blnD_Alarm As Boolean

    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()
        trayIcon = New NotifyIcon()
        trayIcon.Icon = Me.Icon
        trayIcon.Text = "e-Form Agent"
        trayIcon.Visible = True
        AddHandler trayIcon.BalloonTipClicked, AddressOf sD_Show미제출내역

        '조회 - 제출내역 - 출생통보
        '　　 - 대상자조회 - 출생통보
        '-
        '사용법
        '설정
        '종료
        Dim subMenu_Search As New MenuItem("조 회")
        Dim subMenu_제출내역 As New MenuItem("제출내역")
        Dim subMenu_대상자조회 As New MenuItem("대상자조회")
        subMenu_제출내역.MenuItems.Add("출생통보", AddressOf sD_출생통보제출내역)
        subMenu_대상자조회.MenuItems.Add("출생통보", AddressOf sD_출생통보대상자조회)

        subMenu_Search.MenuItems.Add(subMenu_제출내역)
        If mProgram <> ocsEnumProgram.ocsProgram2이플러스 Then
            subMenu_Search.MenuItems.Add(subMenu_대상자조회)
        End If


        trayMenu = New ContextMenu()
        trayMenu.MenuItems.Add(subMenu_Search)
        trayMenu.MenuItems.Add("-")
        trayMenu.MenuItems.Add("도움말", AddressOf sD_ShowHelp)
        trayMenu.MenuItems.Add("설 정", AddressOf sD_ShowSetting)
        trayMenu.MenuItems.Add("종 료", AddressOf sD_ExitApp)
        trayIcon.ContextMenu = trayMenu

        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False
        Me.Hide()

        AddHandler Me.Resize, AddressOf xfrmAgent_Resize

    End Sub

    Private Sub sD_Show미제출내역()

        If blnD_Alarm = False Then Exit Sub

        Dim frmL_미전송내역 As New xfrm미전송내역
        frmL_미전송내역.Show()

    End Sub

    Private Sub sD_CheckAlarm()

        Dim strL_SQL As String = ""

        If mProgram = ocsEnumProgram.ocsProgram0센스 Or mProgram = ocsEnumProgram.ocsProgram6센스플러스 Then
            strL_SQL = " Select a.인덱스, A.문서번호, A.챠트번호, SUBSTRING(A.생성정보, 6, 10) As 생성일자, ISNULL(A.제출여부, 0) As 제출여부 "
            strL_SQL &= " From TB_D환자문서 A INNER Join TB_D문서정보 B " & vbNewLine
            strL_SQL &= " On A.문서 = B.인덱스 " & vbNewLine
            strL_SQL &= " WHERE b.문서코드 = '0067' " & vbNewLine
            strL_SQL &= " And ISNULL(a.제출여부, 0) = 0 " & vbNewLine
            strL_SQL &= " And SUBSTRING(A.생성정보, 6, 10) >= '2024-07-19' " & vbNewLine
            strL_SQL &= " And SUBSTRING(A.생성정보, 6, 10) BETWEEN '" & Format(DateAdd("d", -7, Now), 년월일) & "' AND '" & Format(Now, 년월일) & "' " & vbNewLine
        ElseIf mProgram = ocsEnumProgram.ocsProgram1메디챠트 Then
            strL_SQL = " SELECT 일련번호 AS 인덱스 FROM TB_DOC출생증명서 " & vbNewLine
            strL_SQL &= " WHERE ISNULL(제출여부, 0) = 0 " & vbNewLine
            strL_SQL &= " And 발행일자 BETWEEN '" & Format(DateAdd("d", -7, Now), 년월일) & "' AND '" & Format(Now, 년월일) & "' " & vbNewLine
            strL_SQL &= " And 발행일자 BETWEEN >= '2024-07-19' "
        ElseIf mProgram = ocsEnumProgram.ocsProgram2이플러스 Then
            strL_SQL = " Select * From NEOSOFT..CC_DOC6 " & vbNewLine
            strL_SQL &= " Where ISNULL(DOC6_출생통보,'') <> 'Y' " & vbNewLine
            strL_SQL &= " And DOC6_ISSUE_DATE BETWEEN '" & Format(DateAdd("d", -7, Now), 년월일).Replace("-", "") & "' AND '" & Format(Now, 년월일).Replace("-", "") & "' "
            strL_SQL &= " And DOC6_ISSUE_DATE >= '20240719' "
        End If

        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                blnD_Alarm = True
                trayIcon.ShowBalloonTip(5, "※ 출생정보 미제출건 알림 (" & rst.RecordCount & " 건)", "클릭하여 확인해주세요.", ToolTipIcon.Info)
            End If
        End If

        Call sG_ClearADOObj(rst)

    End Sub

    Private Sub Alarm_Tick(sender As Object, e As EventArgs) Handles Alarm.Tick
        Call sD_CheckAlarm
    End Sub

    Private Sub RequestTimer_Tick(sender As Object, e As EventArgs) Handles RequestTimer.Tick
        Call sD_CheckRequest()
    End Sub

    Private Sub ExecuteTimer_Tick(sender As Object, e As EventArgs) Handles ExecuteTimer.Tick
        Call sD_CheckExecute()
    End Sub

    Private Sub sD_CheckExecute()

        Dim strL_SQL As String
        strL_SQL = " SELECT * FROM TB_REQUEST WHERE 요청일자 = '" & Format(Now, 년월일) & "' AND ISNULL(처리상태, 0) = 0 "
        strL_SQL &= " And 요청구분 IN (" & en요청구분.조회 & "," & en요청구분.수정 & ") "
        Dim rst As ADODB.Recordset
        Dim strL_처리내역 As String = ""

        rst = ocsAgentMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                Dim 요청구분 As en요청구분
                Dim API종류 As enAPI종류
                dicG_Request.Clear()
                Dim strL_요청내용 As String = ""
                Do Until rst.EOF
                    요청구분 = GetValue(rst.Fields("요청구분").Value)
                    API종류 = GetValue(rst.Fields("API종류").Value)
                    Select Case API종류
                        Case enAPI종류.출생통보
                            Select Case 요청구분
                                Case en요청구분.제출
                                    strL_요청내용 = rst.Fields("요청내용").Value.ToString

                                Case en요청구분.삭제
                            End Select
                    End Select
                Loop
            End If
        End If

    End Sub

    Private Sub sD_CheckRequest()

        Dim strL_SQL As String
        strL_SQL = " SELECT * FROM TB_REQUEST WHERE 요청일자 = '" & Format(Now, 년월일) & "' AND ISNULL(처리상태, 0) = 0 "
        strL_SQL &= " And 요청구분 IN (" & en요청구분.제출 & "," & en요청구분.삭제 & ") "
        Dim rst As ADODB.Recordset
        Dim strL_처리내역 As String = ""

        rst = ocsAgentMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                RequestTimer.Enabled = False
                Dim 요청구분 As en요청구분
                Dim API종류 As enAPI종류
                Dim strL_요청내용 As String = ""
                Do Until rst.EOF
                    dicG_Request.Clear()
                    요청구분 = GetValue(rst.Fields("요청구분").Value)
                    API종류 = GetValue(rst.Fields("API종류").Value)
                    Select Case API종류
                        Case enAPI종류.출생통보
                            Select Case 요청구분
                                Case en요청구분.제출
                                    strL_요청내용 = rst.Fields("요청내용").Value
                                    dicG_Request = sG_ParseJsonToDictionary(strL_요청내용)
                                    If fG_RequestAPI출생정보(en요청구분.제출) = True Then
                                        strL_SQL = "UPDATE TB_REQUEST SET 처리상태 = 1 WHERE ID = '" & rst.Fields("ID").Value & "' "
                                        Call ocsAgentMng.Execute(strL_SQL)
                                        trayIcon.ShowBalloonTip(5, "출생정보 제출 완료", "챠트번호 : " & rst.Fields("챠트번호").Value, ToolTipIcon.Info)
                                    Else
                                        If Dyn_Response.ErrorCode <> "" Then
                                            strL_SQL = " UPDATE TB_REQUEST SET 처리상태 = 2, 에러코드 = '" & Dyn_Response.ErrorCode.Replace(conG_API_INSERT_ERROR, "") & "', "
                                            strL_SQL &= " 에러내용 = '" & Dyn_Response.ErrorMessage & "' "
                                            strL_SQL &= " WHERE ID = '" & rst.Fields("ID").Value & "' "
                                            Call ocsAgentMng.Execute(strL_SQL)
                                            trayIcon.ShowBalloonTip(5, "출생정보 제출 실패", "챠트번호 : " & rst.Fields("챠트번호").Value & vbNewLine &
                                                                    Dyn_Response.ErrorMessage, ToolTipIcon.Info)
                                        End If
                                    End If
                                Case en요청구분.삭제

                            End Select
                    End Select
                    rst.MoveNext()
                Loop
                RequestTimer.Enabled = True
            End If
        End If

    End Sub

    Private Sub sD_출생통보제출내역()
        Call sD_Show제출내역조회(enAPI종류.출생통보)
    End Sub

    Private Sub sD_출생통보대상자조회()
        Call sD_Show대상자조회(enAPI종류.출생통보)
    End Sub

    Private Sub sD_Show제출내역조회(ByVal en종류 As enAPI종류)

        Select Case en종류
            Case enAPI종류.출생통보
                Dim frmL_조회 As New xfrm제출내역조회(en종류)
                frmL_조회.Show()
        End Select

    End Sub

    Private Sub sD_Show대상자조회(ByVal en종류 As enAPI종류)

        Select Case en종류
            Case enAPI종류.출생통보
                Dim frmL_출생통보 As New xfrm출생통보
                frmL_출생통보.Show()
        End Select

    End Sub

    Private Sub sD_ShowHelp(sender As Object, e As EventArgs)
        fG_GoToWeb("http://self.neochart.co.kr/board/run.asp?board=senseP_Cm_birthNotice&id=1&page=1&page_size=10&group_size=10&menu=136")
    End Sub

    Private Sub sD_ShowSetting(sender As Object, e As EventArgs)
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        trayIcon.Visible = False
    End Sub

    Private Sub sD_ExitApp(sender As Object, e As EventArgs)
        trayIcon.Visible = False
        Application.Exit()
        End
    End Sub

    Private Sub xfrmAgent_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            trayIcon.Visible = True
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        e.Cancel = True
        Me.Hide()
        trayIcon.Visible = False
        Me.ShowInTaskbar = False
    End Sub

    Protected Overrides Sub OnClosed(e As EventArgs)
        trayIcon.Visible = False
        trayIcon.Dispose()
        MyBase.OnClosed(e)
    End Sub

    Private Sub xfrmAgent_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Hide()
    End Sub

    Private Sub trayIcon_BalloonTipClosed(sender As Object, e As EventArgs) Handles trayIcon.BalloonTipClosed
        blnD_Alarm = False
    End Sub
End Class