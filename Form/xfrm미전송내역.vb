Imports NeoModule

Public Class xfrm미전송내역

    Private Sub sD_iniControls()

        sG_GridInit(grd목록, vw목록,, "", False, False,,,,,, True, False,,,,,,,,, True, 1)
        vw목록.OptionsCustomization.AllowColumnMoving = True
        vw목록.OptionsCustomization.AllowQuickHideColumns = True
        vw목록.OptionsMenu.EnableColumnMenu = True
        fG_GridAddCol(vw목록, "문서번호", "문서번호")
        fG_GridAddCol(vw목록, "챠트번호", "챠트번호")
        fG_GridAddCol(vw목록, "수진자명", "수진자명")
        fG_GridAddCol(vw목록, "문서작성일", "문서작성일")
        fG_GridAddCol(vw목록, "제출여부", "제출여부")

    End Sub

    Private Sub sD_Get미전송내역()

        Dim strL_SQL As String = ""

        If mProgram = ocsEnumProgram.ocsProgram2이플러스 Then
            strL_SQL = " Select B.DOC6_SEQ AS 인덱스, A.CHAM_ID AS 챠트번호, A.CHAM_WHANJA AS 수진자명, B.DOC6_ISSUE_DATE AS 문서작성일, B.DOC6_출생통보 AS 제출여부 " & vbNewLine
            strL_SQL &= " From CC_CHAM A INNER JOIN CC_DOC6 B " & vbNewLine
            strL_SQL &= " ON A.CHAM_ID = B.DOC6_CHAM_ID " & vbNewLine
            strL_SQL &= " Where ISNULL(B.DOC6_출생통보,'') <> 'Y' " & vbNewLine
            strL_SQL &= " And B.DOC6_ISSUE_DATE BETWEEN '" & Format(DateAdd("d", -7, Now), 년월일).Replace("-", "") & "' AND '" & Format(Now, 년월일).Replace("-", "") & "' "
        ElseIf mProgram = ocsEnumProgram.ocsProgram1메디챠트 Then
            strL_SQL = " SELECT B.일련번호 AS 인덱스, B.연번호 AS 문서번호, A.챠트번호, A.수진자명, B.발행일자 AS 문서작성일, CASE WHEN ISNULL(B.제출여부, 0) = '1' THEN 'Y' ELSE 'N' END As 제출여부 "
            strL_SQL &= " From TB_인적사항 A INNER JOIN TB_DOC출생증명서 B "
            strL_SQL &= " ON A.챠트번호 = B.챠트번호 "
            strL_SQL &= " WHERE ISNULL(B.제출여부, 0) = 0 "
            strL_SQL &= " And B.발행일자 BETWEEN '" & Format(DateAdd("d", -7, Now), 년월일) & "' AND '" & Format(Now, 년월일) & "' " & vbNewLine
        ElseIf mProgram = ocsEnumProgram.ocsProgram0센스 Or mProgram = ocsEnumProgram.ocsProgram6센스플러스 Then
            strL_SQL = " Select a.인덱스, A.문서번호, A.챠트번호, C.수진자명, SUBSTRING(A.생성정보, 6, 10) As 문서작성일, CASE WHEN ISNULL(A.제출여부, 0) = '1' THEN 'Y' ELSE 'N' END As 제출여부 "
            strL_SQL &= " From TB_D환자문서 A INNER Join TB_D문서정보 B " & vbNewLine
            strL_SQL &= " On A.문서 = B.인덱스 " & vbNewLine
            strL_SQL &= " INNER Join TB_인적사항 C " & vbNewLine
            strL_SQL &= " On A.챠트번호 = C.챠트번호 " & vbNewLine
            strL_SQL &= " WHERE b.문서코드 = '0067' " & vbNewLine
            strL_SQL &= " And ISNULL(a.제출여부, 0) = 0 " & vbNewLine
            strL_SQL &= " And SUBSTRING(A.생성정보, 6, 10) BETWEEN '" & Format(DateAdd("d", -7, Now), 년월일) & "' AND '" & Format(Now, 년월일) & "' " & vbNewLine
        End If

        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            Call sG_GridDatasource(Me.grd목록, Me.vw목록, rst)
        End If

    End Sub

    Private Sub xfrm미전송내역_Load(sender As Object, e As EventArgs) Handles Me.Load
        sD_iniControls()
        sD_Get미전송내역()
    End Sub
End Class