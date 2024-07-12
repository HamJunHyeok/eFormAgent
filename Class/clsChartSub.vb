Imports NeoModule
Public Class clsChartSub

    '연동에 필요한애들만 갖구 씀
    Public mData As OcsEnumDataState
    Public m챠트번호 As String
    Public m수진자명 As String
    Public m주민등록번호 As String
    Public m정보번호 As String

    Public Enum ocsEnumChartSearchResult
        ocsChartSearchResultNotData = 0
        ocsChartSearchResultOneData = 1
        ocsChartSearchResultTwoData = 2
        ocsChartSearchResultCancel = 3
    End Enum

    Public Sub sP_Clear()
        mData = OcsEnumDataState.ocsDataStateNo
        m챠트번호 = ""
        m수진자명 = ""
        m주민등록번호 = ""
        m정보번호 = ""
    End Sub

    Public Function fP_IsChartNumber(ByVal strChartNumber As String) As Boolean
        Dim bytL_Index As Byte
        Dim strL_Char As String

        fP_IsChartNumber = False
        strL_Char = Left(strChartNumber, 1)
        If Len(strL_Char) = LenH(strL_Char) Then
            For bytL_Index = 1 To Len(strChartNumber)
                If IsNumeric(Mid(strChartNumber, bytL_Index, 1)) = True Then
                    fP_IsChartNumber = True
                    Exit For
                End If
            Next bytL_Index
        End If

    End Function

    Public Function fP_FindChart(ByVal strFind As String) As ocsEnumChartSearchResult

        Dim strL_Sql As String
        Dim strL_Add As String
        Dim ReturnValue As ocsEnumChartSearchResult
        Dim blnL_JuminFind As Boolean = False '주민번호 검색인지 여부
        Dim blnL_ReFind As Boolean = False '주민번호 검색 후 결과가 없어 다시 챠트or이름으로 검색했는지 여부
        Dim blnL_NameFind As Boolean = False '22/05/27 준혁 수진자명검색여부 추가

ReFind:

        strL_Sql = fP_GetQuery()
        If Len(strFind) = 7 And IsNumeric(Left(strFind, 6)) = True And Right(strFind, 1) = "-" And blnL_ReFind = False Then
            If mProgram = ocsEnumProgram.ocsProgram2이플러스 Or mProgram = ocsEnumProgram.ocsProgram3이챠트 Then
                strL_Add = " And Left(CHAM_PASSWORD, 6) = '" & Left(strFind, 6) & "' "
            Else
                strL_Add = " And Left(정보번호, 6) = '" & Left(strFind, 6) & "' ORDER BY 마지막내원일자 DESC "
            End If
            blnL_JuminFind = True
        ElseIf Len(strFind) = 13 And IsNumeric(Replace(strFind, "-", "")) = True And Split(strFind, "-").Length - 1 = 2 And blnL_ReFind = False Then
            If mProgram = ocsEnumProgram.ocsProgram2이플러스 Or mProgram = ocsEnumProgram.ocsProgram3이챠트 Then
                strL_Add = " And REPLACE(CHAM_HP,'-','') = '" & Replace(strFind, "-", "") & "' ORDER BY 마지막내원일자 DESC "
            Else
                strL_Add = " And (REPLACE(이동전화,'-','') = '" & Replace(strFind, "-", "") & "' OR REPLACE(전화번호,'-','') = '" & Replace(strFind, "-", "") & "') ORDER BY 마지막내원일자 DESC "
            End If
            blnL_JuminFind = True
        ElseIf fP_IsChartNumber(strFind) = False Then
            If mProgram = ocsEnumProgram.ocsProgram2이플러스 Then
                strL_Add = " And CHAM_WHANJA Like '%" & strFind & "%' "
            ElseIf mProgram = ocsEnumProgram.ocsProgram3이챠트 Then
                strL_Add = " And CHAM_NAME Like '%" & strFind & "%' "
            Else
                strL_Add = " And 수진자명 Like '%" & strFind & "%' ORDER BY 마지막내원일자 DESC "
            End If
            blnL_NameFind = True
        Else
            If mProgram = ocsEnumProgram.ocsProgram2이플러스 Then
                strL_Add = " And CHAM_ID Like '%" & strFind & "%' "
            ElseIf mProgram = ocsEnumProgram.ocsProgram3이챠트 Then
                strL_Add = " And CHAM_INDEX Like '%" & strFind & "%' "
            Else
                strL_Add = " And 챠트번호 = '" & strFind & "' "
            End If
        End If

        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_Sql & strL_Add)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                Select Case GetValue(rst.RecordCount)
                    Case 0
                        If blnL_JuminFind = True And blnL_ReFind = False Then '주민번호 검색했을 경우 결과가 없으면 한 번 더 검색해본다.(한 번만 실행하기 위해 blnL_ReFind로 구분)
                            rst.Close()
                            rst = Nothing
                            blnL_ReFind = True
                            GoTo ReFind
                        Else
                            sP_Clear()
                            ReturnValue = ocsEnumChartSearchResult.ocsChartSearchResultNotData
                        End If

                    Case 1
                        sP_Clear()
                        sP_LoadDataRst(rst)
                        sG_ClearADOObj(rst)
                        ReturnValue = ocsEnumChartSearchResult.ocsChartSearchResultOneData
                    Case Else
                        Dim frmL_챠트선택 As xfrm챠트선택 = New xfrm챠트선택()
                        Dim strL_ChartNumber As String
                        If blnL_NameFind = True Then '22/05/27 준혁 수진자명검색 시 예약정보 가져오도록 파라미터 추가
                            strL_ChartNumber = frmL_챠트선택.fP_ShowMe(rst, strFind)
                        Else
                            strL_ChartNumber = frmL_챠트선택.fP_ShowMe(rst)
                        End If

                        If strL_ChartNumber <> conG_취소 And strL_ChartNumber <> "|신규|" Then
                            rst.Filter = " 챠트번호 = '" & strL_ChartNumber & "' "
                            sP_Clear()
                            sP_LoadDataRst(rst)
                            ReturnValue = ocsEnumChartSearchResult.ocsChartSearchResultOneData
                        Else
                            '취소
                            If strL_ChartNumber = conG_취소 Then
                                ReturnValue = ocsEnumChartSearchResult.ocsChartSearchResultCancel
                            Else
                                ReturnValue = ocsEnumChartSearchResult.ocsChartSearchResultNotData
                            End If
                        End If
                End Select
            End If
        End If
        sG_ClearADOObj(rst)
        Return ReturnValue
    End Function

    Public Function fP_GetQuery()

        Dim strL_SQL As String

        Select Case mProgram
            Case ocsEnumProgram.ocsProgram2이플러스
                strL_SQL = " SELECT CHAM_ID AS 챠트번호, CHAM_JUMIN1 AS 주민1, CHAM_JUMIN2 AS 주민2, CHAM_WHANJA AS 수진자명, CHAM_PASSWORD AS 정보번호 FROM CC_CHAM "
            Case ocsEnumProgram.ocsProgram3이챠트
                strL_SQL = " SELECT CHAM_INDEX AS 챠트번호, CHAM_JUMIN1 AS 주민1, CHAM_JUMIN2 AS 주민2, CHAM_NAME AS 수진자명, CHAM_PASSWORD AS 정보번호 FROM HP_CHAM "
            Case Else
                strL_SQL = " SELECT 챠트번호, 주민등록번호, 수진자명, 정보번호 FROM TB_인적사항 "
        End Select

        Return strL_SQL

    End Function

    Public Sub sP_SearchChart(ByVal str챠트번호 As String)

        Dim strL_SQL As String = fP_GetQuery()
        Dim rst As ADODB.Recordset

        Select Case mProgram
            Case ocsEnumProgram.ocsProgram2이플러스
                strL_SQL &= "WHERE CHAM_ID = '" & str챠트번호 & "' "
            Case ocsEnumProgram.ocsProgram3이챠트
                strL_SQL &= "WHERE CHAM_INDEX = '" & str챠트번호 & "' "
            Case Else
                strL_SQL &= "WHERE 챠트번호 = '" & str챠트번호 & "' "
        End Select

        rst = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                Call sP_LoadDataRst(rst)
            End If
        End If

    End Sub

    Private Sub sP_LoadDataRst(ByVal rst As ADODB.Recordset)

        With rst
            mData = OcsEnumDataState.ocsDataStateYes
            Me.m챠트번호 = .Fields("챠트번호").Value & ""
            Me.m수진자명 = .Fields("수진자명").Value & ""
            If mProgram = ocsEnumProgram.ocsProgram2이플러스 Or mProgram = ocsEnumProgram.ocsProgram3이챠트 Then

            Else
                Me.m주민등록번호 = .Fields("주민등록번호").Value & ""
                Me.m주민등록번호 = fG_복호화(m주민등록번호)
            End If
            Me.m정보번호 = .Fields("정보번호").Value & ""
            If Me.m정보번호 = "" Then
                Me.m정보번호 = Mid(Me.m주민등록번호, 1, 7)
            End If
        End With

    End Sub

    Public ReadOnly Property Get생년월일() As String
        Get
            Return fG_Get생년월일(m주민등록번호)
        End Get
    End Property

    Public ReadOnly Property Get생년월일YYYYMMDD() As String
        Get
            Return fG_Get생년월일(m주민등록번호).Replace("-", "")
        End Get
    End Property


    Public ReadOnly Property Is신생아주민번호() As Boolean
        Get
            If Right(Me.m주민등록번호, 6) Like "00000*" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

End Class
