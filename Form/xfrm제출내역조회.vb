Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu
Imports NeoModule


Public Class xfrm제출내역조회

    Private API종류 As enAPI종류

    Public Sub New(ByVal pAPI종류 As Integer)

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()
        API종류 = pAPI종류
        Select Case API종류
            Case enAPI종류.출생통보
                Me.Text &= " [출생통보]"
        End Select
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

    End Sub

    Private Sub sD_iniControls()

        Me.dtp기간1.EditValue = Now
        Me.dtp기간2.EditValue = Now

        Me.txt챠트번호.Text = ""
        cbo처리구분.EditValue = "전 체"

        sG_GridInit(grdList, vwList,,, True, False,,,,,,, False,,, True)
        vwList.OptionsDetail.SmartDetailHeight = True

        fG_GridAddCol(vwList, "요청일자", "요청일자",,,,,,, DevExpress.Utils.HorzAlignment.Center)
        fG_GridAddCol(vwList, "챠트번호", "챠트번호",,,,,,, DevExpress.Utils.HorzAlignment.Default)
        fG_GridAddCol(vwList, "수진자명", "수진자명",,,,,,, DevExpress.Utils.HorzAlignment.Center)
        fG_GridAddCol(vwList, "주민등록번호", "주민등록번호", False)
        fG_GridAddCol(vwList, "부모챠트", "부모챠트",,,,,,, DevExpress.Utils.HorzAlignment.Default)
        fG_GridAddCol(vwList, "부모성명", "부모성명",,,,,,, DevExpress.Utils.HorzAlignment.Center)
        fG_GridAddCol(vwList, "부모주민", "부모주민",,,,,,, DevExpress.Utils.HorzAlignment.Default)
        fG_GridAddCol(vwList, "신생아챠트", "신생아챠트",,,,,,, DevExpress.Utils.HorzAlignment.Default)
        fG_GridAddCol(vwList, "신생아성명", "신생아성명",,,,,,, DevExpress.Utils.HorzAlignment.Center)
        fG_GridAddCol(vwList, "신생아주민", "신생아주민",,,,,,, DevExpress.Utils.HorzAlignment.Default)
        fG_GridAddCol(vwList, "처리상태", "처리상태",,,,,,, DevExpress.Utils.HorzAlignment.Center)
        fG_GridAddCol(vwList, "비고", "에러내용",,,,,,, DevExpress.Utils.HorzAlignment.Center)
        fG_GridAddCol(vwList, "요청내용", "요청내용", False)
        fG_GridAddCol(vwList, "요청시간", "요청시간", False)

        sG_GridInit(grd상세, vw상세,,, True, False,,,,,,, False,,, True)
        vwList.OptionsDetail.SmartDetailHeight = True

    End Sub

    Private Sub sD_Search()

        If Me.dtp기간1.EditValue > Me.dtp기간2.EditValue Then
            fG_MsgBox("조회기간을 확인해주세요.", MessageBoxButtons.OK)
            Exit Sub
        End If

        Dim strL_SQL As String = ""
        Select Case mProgram
            Case ocsEnumProgram.ocsProgram0센스, ocsEnumProgram.ocsProgram6센스플러스, ocsEnumProgram.ocsProgram1메디챠트
                strL_SQL = " SELECT DISTINCT B.요청일자, A.챠트번호, A.수진자명, A.주민등록번호, "
                strL_SQL &= " P.챠트번호 AS 부모챠트, P.수진자명 AS 부모성명, P.주민등록번호 AS 부모주민, "
                strL_SQL &= " J.챠트번호 AS 신생아챠트, J.수진자명 AS 신생아성명, J.주민등록번호 AS 신생아주민, "
                strL_SQL &= " B.처리상태, B.에러내용, B.요청내용, B.요청시간 "
                strL_SQL &= " From TB_인적사항 A INNER Join eFormAgent..TB_REQUEST B "
                strL_SQL &= " On A.챠트번호 = B.챠트번호 "
                strL_SQL &= " Left Join TB_인적사항 P " & vbNewLine
                strL_SQL &= " On A.이전챠트번호 = P.챠트번호 " & vbNewLine
                strL_SQL &= " Left Join TB_인적사항 J " & vbNewLine
                strL_SQL &= " On A.챠트번호 = J.이전챠트번호 " & vbNewLine
            Case ocsEnumProgram.ocsProgram2이플러스
                strL_SQL = " Select DISTINCT B.요청일자, A.CHAM_ID 챠트번호, A.CHAM_WHANJA 수진자명, (A.CHAM_JUMIN1 + A.CHAM_JUMIN2) 주민등록번호,  " & vbNewLine
                strL_SQL &= " a.CHAM_ID AS 부모챠트, a.CHAM_WHANJA As 부모성명, (a.CHAM_JUMIN1 + a.CHAM_JUMIN2) As 부모주민,  " & vbNewLine
                strL_SQL &= " c.CHAM_ID AS 신생아챠트, c.CHAM_WHANJA As 신생아성명, (c.CHAM_JUMIN1 + c.CHAM_JUMIN2) As 신생아주민,  " & vbNewLine
                strL_SQL &= " b.처리상태, b.에러내용, b.요청내용, b.요청시간  " & vbNewLine
                strL_SQL &= " From NEOSOFT..CC_CHAM A INNER Join eFormAgent..TB_REQUEST B  " & vbNewLine
                strL_SQL &= " On A.CHAM_ID = B.챠트번호  " & vbNewLine
                strL_SQL &= " Left Join NEOSOFT..CC_CHAM C " & vbNewLine
                strL_SQL &= " On A.CHAM_PART = C.CHAM_PART " & vbNewLine
                strL_SQL &= " And A.CHAM_ORGM_ID = C.CHAM_ORGM_ID " & vbNewLine
                strL_SQL &= " And A.CHAM_JEUNG = C.CHAM_JEUNG " & vbNewLine
                strL_SQL &= " WHERE a.CHAM_ID <> c.CHAM_ID " & vbNewLine
                strL_SQL &= " And A.CHAM_WHANJA = REPLACE(C.CHAM_WHANJA,'아기','') " & vbNewLine
        End Select

        strL_SQL &= " WHERE "

        Select Case API종류
            Case enAPI종류.출생통보
                strL_SQL &= " B.API종류 = '1' "
        End Select

        strL_SQL &= " AND B.요청일자 BETWEEN '" & Format(Me.dtp기간1.EditValue, 년월일) & "' AND '" & Format(Me.dtp기간2.EditValue, 년월일) & "'"
        If cbo처리구분.EditValue = "제출 대기" Then
            strL_SQL &= " AND ISNULL(B.처리상태, 0) = '0' "
        ElseIf cbo처리구분.EditValue = "제출 완료" Then
            strL_SQL &= " AND ISNULL(B.처리상태, 0) = '1' "
        ElseIf cbo처리구분.EditValue = "제출 실패" Then
            strL_SQL &= " AND ISNULL(B.처리상태, 0) = '2' "
        End If

        Select Case mProgram
            Case ocsEnumProgram.ocsProgram0센스, ocsEnumProgram.ocsProgram6센스플러스, ocsEnumProgram.ocsProgram1메디챠트
                If Me.txt챠트번호.Text.Trim <> "" Then
                    strL_SQL &= " AND (A.챠트번호 LIKE '%" & Me.txt챠트번호.Text & "%' OR A.수진자명 LIKE '%" & Me.txt챠트번호.Text & "%') "
                End If
            Case ocsEnumProgram.ocsProgram2이플러스
                If Me.txt챠트번호.Text.Trim <> "" Then
                    strL_SQL &= " AND (A.CHAM_ID LIKE '%" & Me.txt챠트번호.Text & "%' OR A.CHAM_WHANJA LIKE '%" & Me.txt챠트번호.Text & "%') "
                End If
        End Select
        strL_SQL &= " ORDER by B.요청시간 desc "

        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            Call sG_GridDatasource(Me.grdList, Me.vwList, rst)
        Else
            Call fG_MsgBox("조회결과가 없습니다.", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub btn조회_Click(sender As Object, e As EventArgs) Handles btn조회.Click
        sD_Search()
    End Sub

    Private Sub vwList_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles vwList.CustomColumnDisplayText

        Select Case e.Column.FieldName
            Case "처리상태"
                If e.Value.ToString = "0" Then
                    e.DisplayText = "제출 대기"
                ElseIf e.Value.ToString = "1" Then
                    e.DisplayText = "제출 완료"
                Else
                    e.DisplayText = "제출 실패"
                End If
            Case Else
                e.DisplayText = fG_GetDisplayText(sender, e)
        End Select

    End Sub

    Private Sub xfrm제출내역조회_Load(sender As Object, e As EventArgs) Handles Me.Load
        sD_iniControls()
    End Sub

    Private Sub txt챠트번호_KeyDown(sender As Object, e As KeyEventArgs) Handles txt챠트번호.KeyDown
        If e.KeyCode = Keys.Return Then
            Call sD_Search()
        End If
    End Sub

    Private Sub vw상세_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles vw상세.CustomColumnDisplayText

        Dim strL_Value As String
        If e.Value Is Nothing Then
            strL_Value = ""
        Else
            strL_Value = e.Value.ToString
        End If

        Select Case e.Column.FieldName
            Case "신생아 성별"
                If strL_Value = "1" Then
                    e.DisplayText = "남자"
                ElseIf strL_Value = "2" Then
                    e.DisplayText = "여자"
                ElseIf strL_Value = "9" Then
                    e.DisplayText = "불명"
                End If
        End Select

    End Sub

    Private Sub vwList_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles vwList.RowCellClick
        With DirectCast(vwList.GetRow(vwList.FocusedRowHandle), System.Data.DataRowView)
            Dim strL_산모주민번호 As String = ""
            If IsDBNull(.Item("부모주민")) = True Then '부모주민이 있으면 애기챠트에 작성한거
                strL_산모주민번호 = .Item("주민등록번호")
            Else '아니라면 부모챠트에 작성
                strL_산모주민번호 = .Item("부모주민")
            End If
            Dim strL_Json As String = conG_JSON_출생정보조회
            strL_Json = strL_Json.Replace("{{요양기관기호}}", ocsHospital.m요양기관번호)
            strL_Json = strL_Json.Replace("{{조회시작일}}", "20240101")
            strL_Json = strL_Json.Replace("{{조회종료일}}", Format(Now, 년월일).Replace("-", ""))
            If mProgram = ocsEnumProgram.ocsProgram2이플러스 Then
                Dim strL_Jumin1 As String = clsG_Eplus암복호화.fG_복호화(Strings.Left(strL_산모주민번호, 64))
                Dim strL_Jumin2 As String = clsG_Eplus암복호화.fG_복호화(Strings.Right(strL_산모주민번호, 64))
                strL_Json = strL_Json.Replace("{{산모주민번호}}", strL_Jumin1 & strL_Jumin2)
            Else
                strL_Json = strL_Json.Replace("{{산모주민번호}}", fG_복호화(strL_산모주민번호).Replace("-", ""))
            End If

            dicG_Search.Clear()
            dicG_Search = sG_ParseJsonToDictionary(strL_Json)
            If fG_RequestAPI출생정보(en요청구분.조회) = True Then
                'Dim dicResult As New List(Of Dictionary(Of String, Object))()
                Dim dt As New DataTable()
                dt.Columns.Add(New DataColumn("산모성명") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("산모생년월일") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("신생아 생년월일") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("신생아 출생시분") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("신생아 출생수") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("신생아 출생순서") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("신생아 성별") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("일련번호") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("확정제출여부") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("제출일시") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("작성일시") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("삭제여부") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("삭제사유") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("줄번호") With {.DataType = System.Type.GetType("System.String")})
                dt.Columns.Add(New DataColumn("총 수") With {.DataType = System.Type.GetType("System.String")})
                For Each row As Object In Dyn_Response.ListDatas.Rows
                    dt.Rows.Add(row("PPD_NM").Value, row("PPD_BTH").Value, row("NBY_BTH").Value, row("NBY_BIRTH_HM").Value, row("NBY_CNT").Value _
                                , row("NBY_ORD").Value, row("NBY_SEX").Value, row("SNO").Value, row("SMIT_YN").Value, row("SMIT_DT").Value _
                                , row("CRE_DT").Value, row("DEL_YN").Value, row("BIRTH_DEL_RS_TXT").Value, row("ROW_NO").Value, row("TOT_CNT").Value)
                Next
                grd상세.DataSource = dt
                vw상세.Columns.Item("줄번호").Visible = False
                vw상세.Columns.Item("총 수").Visible = False
            Else
                grd상세.DataSource = Nothing
            End If
            grd상세.Refresh()

        End With
    End Sub

    Private Sub vw상세_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles vw상세.PopupMenuShowing

        If e.Menu Is Nothing Then Return
        e.Menu.Items.Clear()
        If e.MenuType <> GridMenuType.Row Then Return
        If vw상세.GetRowCellValue(e.HitInfo.RowHandle, "삭제여부") = "Y" Then Return

        e.Menu.Items.Add(New DXMenuItem("제출 취소", New EventHandler(AddressOf GridRow_MenuClick)) With {.BeginGroup = True, .Tag = e.HitInfo.RowHandle})

    End Sub

    Private Sub GridRow_MenuClick(sender As Object, e As EventArgs)

        Dim mnuItem As DXMenuItem = TryCast(sender, DXMenuItem)

        If mnuItem Is Nothing Then Return

        Dim intL_RowHandle As Integer = mnuItem.Tag

        If mnuItem.Tag Is Nothing Or intL_RowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Return

        Dim strL_삭제사유 As String = fG_InputBoxHTML("삭제사유를 입력하세요.", "제출내역 삭제")
        If strL_삭제사유 = "" Then Exit Sub
        Dim strL_신생아생년월일 As String = vw상세.GetRowCellValue(mnuItem.Tag, vw상세.Columns.ColumnByFieldName("신생아 생년월일"))
        Dim strL_신생아출생순서 As String = vw상세.GetRowCellValue(mnuItem.Tag, vw상세.Columns.ColumnByFieldName("신생아 출생순서"))

        Dim strL_Json As String = conG_JSON_출생정보삭제
        strL_Json = strL_Json.Replace("{{요양기관기호}}", ocsHospital.m요양기관번호)
        strL_Json = strL_Json.Replace("{{확정제출여부}}", "Y")
        If mProgram = ocsEnumProgram.ocsProgram2이플러스 Then

            If IsDBNull(DirectCast(vwList.GetRow(vwList.FocusedRowHandle), System.Data.DataRowView).Item("부모챠트")) = True Then
                Dim strL_산모주민번호 As String = DirectCast(vwList.GetRow(vwList.FocusedRowHandle), System.Data.DataRowView).Item("주민등록번호")
                Dim strL_Jumin1 As String = clsG_Eplus암복호화.fG_복호화(Strings.Left(strL_산모주민번호, 64))
                Dim strL_Jumin2 As String = clsG_Eplus암복호화.fG_복호화(Strings.Right(strL_산모주민번호, 64))
                strL_Json = strL_Json.Replace("{{산모주민번호}}", strL_Jumin1 & strL_Jumin2)
            Else
                Dim strL_산모주민번호 As String = DirectCast(vwList.GetRow(vwList.FocusedRowHandle), System.Data.DataRowView).Item("부모주민")
                Dim strL_Jumin1 As String = clsG_Eplus암복호화.fG_복호화(Strings.Left(strL_산모주민번호, 64))
                Dim strL_Jumin2 As String = clsG_Eplus암복호화.fG_복호화(Strings.Right(strL_산모주민번호, 64))
                strL_Json = strL_Json.Replace("{{산모주민번호}}", strL_Jumin1 & strL_Jumin2)
            End If
        Else
            If IsDBNull(DirectCast(vwList.GetRow(vwList.FocusedRowHandle), System.Data.DataRowView).Item("부모챠트")) = True Then
                strL_Json = strL_Json.Replace("{{산모주민번호}}", fG_복호화(DirectCast(vwList.GetRow(vwList.FocusedRowHandle), System.Data.DataRowView).Item("주민등록번호")).Replace("-", ""))
            Else
                strL_Json = strL_Json.Replace("{{산모주민번호}}", fG_복호화(DirectCast(vwList.GetRow(vwList.FocusedRowHandle), System.Data.DataRowView).Item("부모주민")).Replace("-", ""))
            End If
        End If
        strL_Json = strL_Json.Replace("{{신생아생년월일}}", strL_신생아생년월일)
        strL_Json = strL_Json.Replace("{{신생아출생순서}}", strL_신생아출생순서)
        strL_Json = strL_Json.Replace("{{삭제사유}}", strL_삭제사유)
        dicG_Delete.Clear()
        dicG_Delete = sG_ParseJsonToDictionary(strL_Json)
        If fG_RequestAPI출생정보(en요청구분.삭제) = True Then
            sG_ShowToast("삭제되었습니다.", "출생통보 제출내역 삭제")
            Dim strL_SQL As String
            Dim rst As ADODB.Recordset
            With DirectCast(vwList.GetRow(vwList.FocusedRowHandle), System.Data.DataRowView)
                strL_SQL = " SELECT 문서인덱스 FROM eFormAgent..TB_REQUEST "
                If IsDBNull(.Item("신생아챠트")) = True Then
                    strL_SQL &= " WHERE 챠트번호 = '" & .Item("부모챠트") & "' "
                Else
                    strL_SQL &= " WHERE 챠트번호 = '" & .Item("신생아챠트") & "' "
                End If
                strL_SQL &= " AND API종류 = 1 AND 요청구분 = 1 "
                strL_SQL &= " AND 요청내용 Like '%""NBY_BTH"": """ & strL_신생아생년월일 & """%' "
                rst = ocsDBMng.GetRecordset(strL_SQL)
                If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
                    If rst.EOF = False Then
                        strL_SQL = ""
                        Select Case mProgram
                            Case ocsEnumProgram.ocsProgram0센스, ocsEnumProgram.ocsProgram6센스플러스
                                strL_SQL = "UPDATE TB_D환자문서 SET 제출여부 = 0 WHERE 인덱스 = '" & rst.Fields("문서인덱스").Value & "' "
                            Case ocsEnumProgram.ocsProgram1메디챠트
                                strL_SQL = "UPDATE TB_DOC출생증명서 SET 제출여부 = 0 WHERE 일련번호 = '" & rst.Fields("문서인덱스").Value & "' "
                            Case ocsEnumProgram.ocsProgram2이플러스
                                strL_SQL = "UPDATE NEOSOFT..CC_DOC6 SET DOC6_출생통보 = 'N' WHERE DOC6_SEQ = '" & rst.Fields("문서인덱스").Value & "' "
                        End Select
                        If strL_SQL <> "" Then
                            Call ocsDBMng.Execute(strL_SQL)
                        End If
                    End If
                End If
            End With

        End If

    End Sub

End Class