Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu
Imports NeoModule

Public Class xfrm출생통보

    Private WithEvents clsD_Calendar As clsCalendar
    Private clsD_Chart As clsChartSub

    Private blnD_LoadChart As Boolean

    Private Sub sP_iniControls()

        Me.dtp조회시작.EditValue = Now
        Me.dtp조회끝.EditValue = Now
        Me.dtp달력년월.EditValue = Format(Now, 년월)

        dtp기간1.EditValue = DateAdd("m", -1, Now)
        dtp기간2.EditValue = Now

        Me.cbo삭제여부.EditValue = "전 체"

        '그리드
        sG_GridInit(grd대상자, vw대상자,, "", False, False,,,,,, True, False,,,,,,,,, True, 1)
        vw대상자.OptionsCustomization.AllowColumnMoving = True
        vw대상자.OptionsCustomization.AllowQuickHideColumns = True
        vw대상자.OptionsMenu.EnableColumnMenu = True
        fG_GridAddCol(vw대상자, "챠트번호", "챠트번호")
        fG_GridAddCol(vw대상자, "수진자명", "수진자명")
        fG_GridAddCol(vw대상자, "입원일자", "입원일자")
        fG_GridAddCol(vw대상자, "퇴원일자", "퇴원일자")
        fG_GridAddCol(vw대상자, "신생아차트", "신생아차트")
        fG_GridAddCol(vw대상자, "신생아이름", "신생아이름")
        fG_GridAddCol(vw대상자, "주민등록번호", "주민등록번호", False)
        fG_GridAddCol(vw대상자, "신생아주민", "신생아주민", False)

        sG_GridInit(grd상병내역, vw상병내역,,,, False,,,,,,, False,,,,,,,, True)
        fG_GridAddCol(vw상병내역, "상병코드", "상병코드")
        fG_GridAddCol(vw상병내역, "상병명칭", "상병명칭").Width = 180
        fG_GridAddCol(vw상병내역, "주상병", "주상병")

        sG_GridInit(grd진료내역, vw진료내역,,,, False,,,,,,, False,,,,,,,, True)
        fG_GridAddCol(vw진료내역, "처방코드", "처방코드")
        fG_GridAddCol(vw진료내역, "청구코드", "청구코드")
        fG_GridAddCol(vw진료내역, "명칭", "명칭").Width = 200
        fG_GridAddCol(vw진료내역, "투여량", "투여량")
        fG_GridAddCol(vw진료내역, "횟수", "투여횟수")
        fG_GridAddCol(vw진료내역, "일수", "일수")

        sG_GridInit(grd목록, vw목록,,,, False,,,,,,, False,,, True,,,,, True)

    End Sub

    '대상자 목록조회
    Private Sub sP_GetList()

        Dim strL_SQL As String
        Dim strL_Date As String = Strings.Left(Format(dtp조회시작.EditValue, 년월일).Replace("-", ""), 6)
        Dim strL_Date2 As String = Strings.Left(Format(dtp조회끝.EditValue, 년월일).Replace("-", ""), 6)

        If mProgram = ocsEnumProgram.ocsProgram2이플러스 Then
            If strL_Date <> strL_Date2 Then

            Else
                strL_SQL = " Select DISTINCT B.CHAM_ID As 챠트번호 , B.CHAM_WHANJA As 수진자명 "
                strL_SQL &= " , C.IINF_IN_DATE AS 입원일자, C.IINF_OUT_DATE AS 퇴원일자 " & vbNewLine
                strL_SQL &= " , D.CHAM_ID AS 신생아챠트번호, D.CHAM_WHANJA AS 신생아수진자명, D.CHAM_JUMIN1 AS 신생아주민번호 " & vbNewLine
                strL_SQL &= " , D.CHAM_JUMIN1 AS 신생아주민번호 " & vbNewLine
                strL_SQL &= " From MONTH..IDIS202212 AS A " & vbNewLine
                strL_SQL &= " Left Join NEOSOFT..CC_CHAM AS B " & vbNewLine
                strL_SQL &= " On A.IDIS_CHAM_ID = B.CHAM_ID " & vbNewLine
                strL_SQL &= " Left Join NEOSOFT..WW_IINF AS C " & vbNewLine
                strL_SQL &= " On B.CHAM_ID = C.IINF_CHAM_ID " & vbNewLine
                strL_SQL &= " Left Join(SELECT CHAM_ID, CHAM_WHANJA, CHAM_PART, CHAM_ORGM_ID, CHAM_JEUNG, CHAM_JUMIN1, CHAM_JUMIN2 " & vbNewLine
                strL_SQL &= " From NEOSOFT..CC_CHAM) AS D " & vbNewLine
                strL_SQL &= " On B.CHAM_PART = D.CHAM_PART " & vbNewLine
                strL_SQL &= " And B.CHAM_ORGM_ID = D.CHAM_ORGM_ID " & vbNewLine
                strL_SQL &= " And B.CHAM_JEUNG = D.CHAM_JEUNG " & vbNewLine
                strL_SQL &= " And D.CHAM_WHANJA = (B.CHAM_WHANJA + '아기') " & vbNewLine
                strL_SQL &= " And B.CHAM_ID <> D.CHAM_ID " & vbNewLine
                strL_SQL &= " WHERE Left(a.IDIS_DISM_ID, 3) IN ('O80','O81','O82','O83','O84') " & vbNewLine
                strL_SQL &= " And ('202212' + A.IDIS_DATE) BETWEEN '20221201' AND '20221231' " & vbNewLine
                strL_SQL &= " And C.IINF_OUT_DATE >= '20221201' " & vbNewLine
            End If
        Else
            strL_SQL = " Select DISTINCT A.챠트번호, A.수진자명, D.입원일자, D.퇴원일자, P.챠트번호 AS 신생아차트, P.수진자명 AS 신생아이름, "
            strL_SQL &= " A.주민등록번호, P.주민등록번호 AS 신생아주민 " & vbNewLine
            strL_SQL &= " From TB_인적사항 A INNER Join TB_진료기본 B " & vbNewLine
            strL_SQL &= " On A.챠트번호 = B.챠트번호  " & vbNewLine
            strL_SQL &= " INNER Join TB_진료상병 C " & vbNewLine
            strL_SQL &= " On B.챠트번호 = C.챠트번호  " & vbNewLine
            strL_SQL &= " And B.진료번호 = C.진료번호  " & vbNewLine
            strL_SQL &= " And B.진료년 = C.진료년 " & vbNewLine
            strL_SQL &= " And B.진료월 = C.진료월  " & vbNewLine
            strL_SQL &= " And B.진료일 = C.진료일 " & vbNewLine
            strL_SQL &= " And LEFT(C.상병코드, 3) IN ('O80', 'O81', 'O82', 'O83', 'O84') " & vbNewLine
            strL_SQL &= " INNER Join TB_입원정보 D " & vbNewLine
            strL_SQL &= " On B.입원ID = D.입원ID  " & vbNewLine
            strL_SQL &= " And B.챠트번호 = D.챠트번호  " & vbNewLine
            strL_SQL &= " Left Join TB_인적사항 P " & vbNewLine
            strL_SQL &= " On A.챠트번호 = P.이전챠트번호  " & vbNewLine
            strL_SQL &= " WHERE b.진료일자 BETWEEN '" & Format(dtp조회시작.EditValue, 년월일) & "' AND '" & Format(dtp조회끝.EditValue, 년월일) & "' " & vbNewLine
            strL_SQL &= " ORDER BY A.수진자명 "
        End If

        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            Call sG_GridDatasource(grd대상자, vw대상자, rst)
        End If

    End Sub

    '대상자 상병/처방 조회
    Private Sub sP_Get상병내역(ByVal str진료일자 As String)

        Dim strL_SQL As String
        strL_SQL = " SELECT DISTINCT 상병코드, 상병명칭, Case When 주상병 = 1 then 'V' else '' end AS 주상병 FROM TB_진료상병 "
        strL_SQL &= " WHERE 챠트번호 = '" & clsD_Chart.m챠트번호 & "' "
        strL_SQL &= " AND 진료년 = '" & Strings.Left(str진료일자, 4) & "' "
        strL_SQL &= " AND 진료월 = '" & Strings.Mid(str진료일자, 6, 2) & "' "
        strL_SQL &= " AND 진료일 = '" & Strings.Right(str진료일자, 2) & "' "
        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            Call sG_GridDatasource(grd상병내역, vw상병내역, rst)
        End If

    End Sub

    Private Sub sP_Get처방내역(ByVal str진료일자 As String)

        Dim strL_SQL As String = ""
        Dim CurrentDate As String = Strings.Left(str진료일자.Replace("-", ""), 6)

        Select Case mProgram
            Case ocsEnumProgram.ocsProgram2이플러스
                strL_SQL = " SELECT * FROM CC_MOMR "
            Case ocsEnumProgram.ocsProgram3이챠트

            Case Else
                strL_SQL = " SELECT 처방코드, 청구코드, 명칭, 투여량, 투여횟수, 일수 FROM TB_진료내역 "
                strL_SQL &= " WHERE 챠트번호 = '" & clsD_Chart.m챠트번호 & "' "
                strL_SQL &= " AND 진료년 = '" & Strings.Left(str진료일자, 4) & "' "
                strL_SQL &= " AND 진료월 = '" & Strings.Mid(str진료일자, 6, 2) & "' "
                strL_SQL &= " AND 진료일 = '" & Strings.Right(str진료일자, 2) & "' "
                strL_SQL &= " AND 수정구분 = 0 AND 진료지원상태 <> '6' "
        End Select

        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            Call sG_GridDatasource(grd진료내역, vw진료내역, rst)
        End If

    End Sub

    '달력표기
    Private Sub sD_SetCalederColor(ByVal strP_SDate As String)

        If clsD_Chart.mData = OcsEnumDataState.ocsDataStateNo Then Exit Sub

        Dim strL_SQL As String = ""
        Dim rst As ADODB.Recordset = Nothing

        Dim BeforeDate As String = ""

        spr달력.SuspendLayout()

        Dim CellInfo As FarPoint.Win.Spread.Cell = Nothing
        Dim sDate As String = ""

        CellInfo = Nothing

        strL_SQL = " SELECT 진료일자, 초재진구분, 입원ID FROM TB_진료기본 " & vbNewLine
        strL_SQL &= " where 챠트번호 = '" & clsD_Chart.m챠트번호 & "' " & vbNewLine
        strL_SQL &= " And 진료상태 <> '4' " & vbNewLine
        strL_SQL &= " And 진료일자 between '" & strP_SDate & "-01' and '" & strP_SDate & "-" & fG_GetLastMonthDay(strP_SDate & "-01") & "'" & vbNewLine
        strL_SQL &= " ORDER BY 진료일자 "

        rst = ocsDBMng.GetRecordset(strL_SQL)

        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then

            If rst.EOF = False Then

                Dim enL_초재진구분 As ocsEnumChoJaeKind

                Do Until rst.EOF

                    CellInfo = clsD_Calendar.fP_GetDayCell(rst.Fields("진료일자").Value)
                    If CellInfo IsNot Nothing Then
                        enL_초재진구분 = GetValue(rst.Fields("초재진구분").Value)
                        Select Case enL_초재진구분
                            Case ocsEnumChoJaeKind.ocsChoJaeKind4입원, ocsEnumChoJaeKind.ocsChoJaeKind5외박
                                CellInfo.BackColor = COLOR_입원_CURR
                            Case ocsEnumChoJaeKind.ocsChoJaeKind0초진, ocsEnumChoJaeKind.ocsChoJaeKind10건강검진초진
                                If GetValue(rst.Fields("입원ID").Value) = 0 Then
                                    CellInfo.BackColor = COLOR_BACK_CHOJIN
                                Else
                                    CellInfo.BackColor = COLOR_입원_CURR
                                End If
                            Case ocsEnumChoJaeKind.ocsChoJaeKind1재진, ocsEnumChoJaeKind.ocsChoJaeKind11건강검진재진
                                If GetValue(rst.Fields("입원ID").Value) = 0 Then
                                    CellInfo.BackColor = COLOR_외래_CURR
                                Else
                                    CellInfo.BackColor = COLOR_입원_CURR
                                End If
                            Case ocsEnumChoJaeKind.ocsChoJaeKind3물리치료
                                CellInfo.BackColor = COLOR_BACK_물치
                            Case ocsEnumChoJaeKind.ocsChoJaeKind9진찰료없음
                                CellInfo.BackColor = COLOR_BACK_진X
                        End Select
                    Else
                        CellInfo.BackColor = System.Drawing.Color.White
                    End If

                    CellInfo = Nothing

                    rst.MoveNext()

                Loop

            End If

        End If

        spr달력.ResumeLayout()

        Call sG_ClearADOObj(rst)

    End Sub

    Private Sub sD_DrawCalendar(Optional blnP_DrawBackColor As Boolean = False)

        If dtp달력년월.EditValue Is Nothing Then Exit Sub

        Dim strL_SDate As String = dtp달력년월.EditValue

        clsD_Calendar.sP_DrawCalendar(strL_SDate, True)

        If clsD_Chart.mData = OcsEnumDataState.ocsDataStateYes Then
            sD_SetCalederColor(strL_SDate)
        End If

    End Sub

    Private Sub xfrm출생통보_Load(sender As Object, e As EventArgs) Handles Me.Load
        clsD_Calendar = New clsCalendar(Me.spr달력, True, System.Drawing.Color.Red, 2, clsCalendar.enDayChangeEvent.Click, True)
        clsD_Chart = New clsChartSub
        sP_iniControls()
    End Sub

    Private Sub xfrm출생통보_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        clsD_Calendar = Nothing
        clsD_Chart = Nothing
    End Sub

    Private Sub btn달력_Click(sender As Object, e As EventArgs) Handles btnNext.Click, btnPrev.Click
        If sender.name = "btnNext" Then
            dtp달력년월.EditValue = Format(DateAdd(DateInterval.Month, 1, dtp달력년월.EditValue), 년월)
        Else
            dtp달력년월.EditValue = Format(DateAdd(DateInterval.Month, -1, dtp달력년월.EditValue), 년월)
        End If
        sD_DrawCalendar()
    End Sub

    Private Sub dtp달력년월_EditValueChanged(sender As Object, e As EventArgs) Handles dtp달력년월.EditValueChanged
        sD_DrawCalendar()
    End Sub

    Private Sub btn조회_Click(sender As Object, e As EventArgs) Handles btn조회.Click
        If dtp조회시작.EditValue > dtp조회끝.EditValue Then
            Call fG_MsgBox("조회일자를 다시 확인해주세요.", MessageBoxButtons.OK)
            Exit Sub
        End If

        Call sP_GetList()
    End Sub

    Private Sub vw대상자_DoubleClick(sender As Object, e As EventArgs) Handles vw대상자.DoubleClick
        If blnD_LoadChart = True Then Exit Sub

        If vw대상자.GetRow(vw대상자.FocusedRowHandle) Is Nothing Then
            blnD_LoadChart = False
            Exit Sub
        End If

        blnD_LoadChart = True

        With DirectCast(vw대상자.GetRow(vw대상자.FocusedRowHandle), System.Data.DataRowView)
            Dim strL_챠트번호 As String = .Item("챠트번호")
            Dim strL_수진자명 As String = .Item("수진자명")
            lbl환자기록.Text = " ● 환자기록 - " & strL_수진자명 & "[" & strL_챠트번호 & "]"
            Dim strL_입원일자 As String = .Item("입원일자")
            If GetValue(strL_챠트번호) = "0" Then
                blnD_LoadChart = False
                Exit Sub
            End If

            clsD_Chart.sP_SearchChart(strL_챠트번호)
            If Strings.Left(dtp달력년월.EditValue.ToString, 7) <> Strings.Left(strL_입원일자, 7) Then
                dtp달력년월.EditValue = Strings.Left(strL_입원일자, 7)
            Else
                sD_DrawCalendar()
            End If
            sD_Search제출내역()
            blnD_LoadChart = False
        End With

    End Sub

    Private Sub sD_Search제출내역()

        With DirectCast(vw대상자.GetRow(vw대상자.FocusedRowHandle), System.Data.DataRowView)

            If IsDBNull(.Item("신생아차트")) = True Then Exit Sub

            Dim strL_신생아생년월일 As String = fG_Get생년월일(fG_복호화(.Item("신생아주민")).Replace("-", "")).Replace("-", "")
            Dim strL_산모주민번호 As String = fG_복호화(.Item("주민등록번호")).Replace("-", "")
            Dim strL_산모생년월일 As String = fG_Get생년월일(strL_산모주민번호).Replace("-", "")
            Dim strL_산모성명 As String = .Item("수진자명")

            Dim strL_Json As String = conG_JSON_출생정보조회
            strL_Json = "{""YKIHO"": ""{{요양기관기호}}"", ""WRT_STA_DD"": ""{{조회시작일}}"", ""WRT_END_DD"": ""{{조회종료일}}"", ""PPD_JNO"": ""{{산모주민번호}}"", ""PPD_NM"": ""{{산모성명}}"", ""PPD_BTH"": ""{{산모생년월일}}"", ""NBY_BTH"": ""{{신생아생년월일}}"", ""CURRENT_PAGE"": ""{{현재페이지수}}, ""RECORD_COUNT_PER_PAGE"": ""{{목록카운트}}}"
            strL_Json = strL_Json.Replace("{{요양기관기호}}", ocsHospital.m요양기관번호)
            strL_Json = strL_Json.Replace("{{조회시작일}}", Format(dtp기간1.EditValue, 년월일).ToString.Replace("-", ""))
            strL_Json = strL_Json.Replace("{{조회종료일}}", Format(dtp기간2.EditValue, 년월일).ToString.Replace("-", ""))
            strL_Json = strL_Json.Replace("{{산모주민번호}}", strL_산모주민번호)
            Select Case cbo삭제여부.EditValue
                Case "전 체"
                    strL_Json = strL_Json.Replace("{{삭제조회여부}}", "")
                Case "삭 제"
                    strL_Json = strL_Json.Replace("{{삭제조회여부}}", "Y")
                Case "미삭제"
                    strL_Json = strL_Json.Replace("{{삭제조회여부}}", "N")
            End Select
            strL_Json = strL_Json.Replace("{{확정제출조회여부}}", "")
            strL_Json = strL_Json.Replace("{{산모성명}}", strL_산모성명)
            strL_Json = strL_Json.Replace("{{산모생년월일}}", strL_산모생년월일)
            strL_Json = strL_Json.Replace("{{신생아생년월일}}", strL_신생아생년월일)
            strL_Json = strL_Json.Replace("{{현재페이지수}}", "1")
            strL_Json = strL_Json.Replace("{{목록카운트}}", "20")

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
                grd목록.DataSource = dt
                vw목록.Columns.Item("줄번호").Visible = False
                vw목록.Columns.Item("총 수").Visible = False
            Else
                grd목록.DataSource = Nothing
            End If
            grd목록.Refresh()

        End With

    End Sub

    Private Sub clsD_Calendar_DayChanged(strDate As String, Row As Integer, Column As Integer) Handles clsD_Calendar.DayChanged
        If clsD_Chart.mData = OcsEnumDataState.ocsDataStateNo Then Exit Sub

        sP_Get상병내역(strDate)
        sP_Get처방내역(strDate)
    End Sub

    Private Sub vw목록_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles vw목록.CustomColumnDisplayText

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
    Private Sub GridRow_MenuClick(sender As Object, e As EventArgs)

        Dim mnuItem As DXMenuItem = TryCast(sender, DXMenuItem)

        If mnuItem Is Nothing Then Return

        Dim intL_RowHandle As Integer = mnuItem.Tag

        If mnuItem.Tag Is Nothing Or intL_RowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Return

        Dim strL_삭제사유 As String = fG_InputBoxHTML("삭제사유를 입력하세요.", "제출내역 삭제")
        If strL_삭제사유 = "" Then Exit Sub
        Dim strL_신생아생년월일 As String = vw목록.GetRowCellValue(mnuItem.Tag, vw목록.Columns.ColumnByFieldName("신생아 생년월일"))
        Dim strL_신생아출생순서 As String = vw목록.GetRowCellValue(mnuItem.Tag, vw목록.Columns.ColumnByFieldName("신생아 출생순서"))

        Dim strL_Json As String = conG_JSON_출생정보삭제
        strL_Json = strL_Json.Replace("{{요양기관기호}}", ocsHospital.m요양기관번호)
        strL_Json = strL_Json.Replace("{{확정제출여부}}", "Y")
        strL_Json = strL_Json.Replace("{{산모주민번호}}", fG_복호화(DirectCast(vw대상자.GetRow(vw대상자.FocusedRowHandle), System.Data.DataRowView).Item("주민등록번호")).Replace("-", ""))
        strL_Json = strL_Json.Replace("{{신생아생년월일}}", strL_신생아생년월일)
        strL_Json = strL_Json.Replace("{{신생아출생순서}}", strL_신생아출생순서)
        strL_Json = strL_Json.Replace("{{삭제사유}}", strL_삭제사유)
        dicG_Delete.Clear()
        dicG_Delete = sG_ParseJsonToDictionary(strL_Json)
        If fG_RequestAPI출생정보(en요청구분.삭제) = True Then
            sG_ShowToast("삭제되었습니다.", "출생통보 제출내역 삭제")
            Dim strL_SQL As String
            Dim rst As ADODB.Recordset
            With DirectCast(vw대상자.GetRow(vw대상자.FocusedRowHandle), System.Data.DataRowView)
                strL_SQL = " SELECT 문서인덱스 FROM eFormAgent..TB_REQUEST "
                If IsDBNull(.Item("신생아차트")) = True Then
                    strL_SQL &= " WHERE 챠트번호 = '" & .Item("부모챠트") & "' "
                Else
                    strL_SQL &= " WHERE 챠트번호 = '" & .Item("신생아차트") & "' "
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
            sD_Search제출내역()
        End If

    End Sub

    Private Sub vw목록_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles vw목록.PopupMenuShowing

        If e.Menu Is Nothing Then Return
        e.Menu.Items.Clear()
        If e.MenuType <> GridMenuType.Row Then Return
        If vw목록.GetRowCellValue(e.HitInfo.RowHandle, "삭제여부") = "Y" Then Return

        e.Menu.Items.Add(New DXMenuItem("제출 취소", New EventHandler(AddressOf GridRow_MenuClick)) With {.BeginGroup = True, .Tag = e.HitInfo.RowHandle})

    End Sub
End Class