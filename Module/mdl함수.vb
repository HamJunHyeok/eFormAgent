Imports NeoModule

Module mdl함수

    Public Function fG_RequestAPI출생정보(ByVal enP_구분 As en요청구분) As enFunctionResult

        Dyn.Clear()

        Select Case enP_구분
            Case en요청구분.조회
                Return fP_출생정보조회()
            Case en요청구분.제출
                Return fP_출생정보제출()
            Case en요청구분.삭제
                Return fP_출생정보삭제()
            Case en요청구분.수정
                Return fP_출생정보제출()
        End Select

        Return False

    End Function

    '임시저장 -> 확정제출 용도로 보임
    Private Function fP_출생정보제출상태변경() As enFunctionResult

        With Dyn.Elements
            .Add(conG_API서식_서식ID, conG_API서식고정_출생통보서식ID)
            .Add(conG_API서식_함수버전, conG_API서식고정_출생통보VERSION)
            .Add(conG_API서식_요양기관기호, ocsHospital.m요양기관번호)
            .Add("PPD_JNO", "8802272267724") '산모 주민번호
            .Add("NBY_BTH", "20240505") '신생아 생년월일
            .Add("NBY_ORD", "1") '신생아 출생순서 (아마 다태아인 경우 몇번째냐 구분하는거인듯함)
        End With

        Dyn_Response = Dyn.requestData(ocsHospital.m요양기관번호, conG_API_출생정보수정)
        If Dyn_Response.Result = True Then
            Return True
        Else
            Debug.Print(Dyn_Response.ErrorCode & vbNewLine & Dyn_Response.ErrorMessage)
            Return False
        End If

    End Function


    Private Function fP_출생정보삭제() As Boolean

        With Dyn.Elements
            .Add(conG_API서식_서식ID, conG_API서식고정_출생통보서식ID)
            .Add(conG_API서식_함수버전, conG_API서식고정_출생통보VERSION)
            .Add(conG_API서식_요양기관기호, ocsHospital.m요양기관번호)
            .Add(conG_API서식_확정제출여부, dicG_Delete.Item("SMIT_YN")) '확정제출여부 Y:확정제출 / N:임시저장
            .Add("PPD_JNO", dicG_Delete.Item("PPD_JNO")) '산모 주민번호
            .Add("NBY_BTH", dicG_Delete.Item("NBY_BTH")) '신생아 생년월일
            .Add("NBY_ORD", dicG_Delete.Item("NBY_ORD")) '신생아 출생순서 (아마 다태아인 경우 몇번째냐 구분하는거인듯함)
            .Add("BIRTH_DEL_RS_TXT", dicG_Delete.Item("BIRTH_DEL_RS_TXT")) '삭제사유
        End With

        Dyn_Response = Dyn.requestData(ocsHospital.m요양기관번호, conG_API_출생정보삭제)
        If Dyn_Response.Result = True Then
            Return True
        Else
            Debug.Print(Dyn_Response.ErrorCode & vbNewLine & Dyn_Response.ErrorMessage)
            Return False
        End If

    End Function

    Private Function fP_출생정보제출() As Boolean

        '"{""YKIHO"": ""{{요양기관기호}}"", ""SMIT_YN"": ""{{확정제출여부}}"", ""PPD_NM"": ""{{산모성명}}"", ""PPD_JNO"": ""{{산모주민번호}}"", ""NBY_CNT"": ""{{신생아출생수}}"", ""NBY_BTH"": ""{{신생아생년월일}}"", ""NBY_ORD"": ""{{신생아출생순서}}"", ""NBY_BIRTH_HM"": ""{{신생아출생시분}}"", ""NBY_SEX"": ""{{신생아성별}}}"
        With Dyn.Elements
            .Add(conG_API서식_서식ID, conG_API서식고정_출생통보서식ID)
            .Add(conG_API서식_함수버전, conG_API서식고정_출생통보VERSION)
            .Add(conG_API서식_요양기관기호, dicG_Request.Item(conG_API서식_요양기관기호))
            .Add(conG_API서식_확정제출여부, dicG_Request.Item(conG_API서식_확정제출여부)) '확정제출여부 Y:확정제출 / N:임시저장
            .Add("PPD_NM", dicG_Request.Item("PPD_NM")) '산모 성명
            .Add("PPD_JNO", dicG_Request.Item("PPD_JNO").Replace("-", "")) '산모 주민번호
            .Add("NBY_CNT", dicG_Request.Item("NBY_CNT")) '신생아 출생 수
            .Add("NBY_BTH", dicG_Request.Item("NBY_BTH")) '신생아 생년월일
            .Add("NBY_ORD", dicG_Request.Item("NBY_ORD")) '신생아 출생순서 (아마 다태아인 경우 몇번째냐 구분하는거인듯함)
            .Add("NBY_BIRTH_HM", dicG_Request.Item("NBY_BIRTH_HM")) '신생아 출생시분 HHMM
            .Add("NBY_SEX", dicG_Request.Item("NBY_SEX")) '신생아 성별 1:남자 / 2:여자 / 9:불명
        End With

        Dyn_Response = Dyn.requestData(dicG_Request.Item(conG_API서식_요양기관기호), conG_API_출생정보제출)
        If Dyn_Response.Result = True Then
            Return True
        Else
            Debug.Print(Dyn_Response.ErrorCode & vbNewLine & Dyn_Response.ErrorMessage)
            Return False
        End If

    End Function

    Private Function fP_출생정보조회() As Boolean

        With Dyn.Elements
            '필수값들
            .Add(conG_API서식_서식ID, conG_API서식고정_출생통보서식ID)
            .Add(conG_API서식_함수버전, conG_API서식고정_출생통보VERSION)
            .Add(conG_API서식_요양기관기호, ocsHospital.m요양기관번호)
            .Add("WRT_STA_DD", dicG_Search.Item("WRT_STA_DD")) '조회시작일
            .Add("WRT_END_DD", dicG_Search.Item("WRT_END_DD")) '조회종료일
            .Add("PPD_JNO", dicG_Search.Item("PPD_JNO")) '산모 주민번호
            ' ""NBY_BTH"": ""{{신생아생년월일}}"", ""CURRENT_PAGE"": ""{{현재페이지수}}, ""RECORD_COUNT_PER_PAGE"": ""{{목록카운트}}""}"

            '선택값들
            If dicG_Search.ContainsKey("DEL_YN") = True Then
                If dicG_Search.Item("DEL_YN") <> "{{삭제조회여부}}" Then
                    .Add("DEL_YN", dicG_Search.Item("DEL_YN")) 'Y 삭제 / N 미삭제 건 조회
                End If
            End If

            If dicG_Search.ContainsKey("SMIT_YN") = True Then
                If dicG_Search.Item("SMIT_YN") <> "{{확정제출조회여부}}" Then
                    .Add("SMIT_YN", dicG_Search.Item("SMIT_YN")) 'Y 확정제출 / N 임시저장 건 조회
                End If
            End If

            If dicG_Search.ContainsKey("PPD_NM") = True Then
                If dicG_Search.Item("PPD_NM") <> "{{산모성명}}" Then
                    .Add("PPD_NM", dicG_Search.Item("PPD_NM")) '산모 성명
                End If
            End If

            If dicG_Search.ContainsKey("PPD_BTH") = True Then
                If dicG_Search.Item("PPD_BTH") <> "{{산모생년월일}}" Then
                    .Add("PPD_BTH", dicG_Search.Item("PPD_BTH")) '산모 생년월일
                End If
            End If

            If dicG_Search.ContainsKey("NBY_BTH") = True Then
                If dicG_Search.Item("NBY_BTH") <> "{{신생아생년월일}}" Then
                    .Add("NBY_BTH", dicG_Search.Item("NBY_BTH")) '신생아 생년월일
                End If
            End If

            .Add("CURRENT_PAGE", "1") '현재페이지 > 페이징 수
            .Add("RECORD_COUNT_PER_PAGE", "30") '페이지에 몇건까지 볼건지 카운트
        End With

        Dyn_Response = Dyn.requestData(ocsHospital.m요양기관번호, conG_API_출생정보조회)
        If Dyn_Response.Result = True Then
            Return True
        Else
            Return False
        End If

    End Function



    Function sG_ParseJsonToDictionary(json As String) As Dictionary(Of String, String)
        Dim dict As New Dictionary(Of String, String)()

        ' JSON 문자열에서 중괄호 제거
        json = json.Trim({"{"c, "}"c})

        ' 콤마로 분리하여 각 키-값 쌍을 추출
        Dim pairs As String() = json.Split({","c}, StringSplitOptions.RemoveEmptyEntries)

        For Each pair As String In pairs
            ' 콜론으로 키와 값을 분리
            Dim keyValue As String() = pair.Split({":"c}, 2, StringSplitOptions.None)

            If keyValue.Length = 2 Then
                ' 키와 값에서 따옴표 제거
                Dim key As String = keyValue(0).Trim().Trim(""""c)
                Dim value As String = keyValue(1).Trim().Trim(""""c)

                ' Dictionary에 추가
                dict.Add(key, value)
            End If
        Next

        Return dict
    End Function


    Public Function ConvertToDataTable(ByVal listOfDicts As List(Of Dictionary(Of String, Object))) As DataTable
        Dim dt As New DataTable()

        If listOfDicts.Count > 0 Then
            ' Add columns to the DataTable
            For Each key As String In listOfDicts(0).Keys
                dt.Columns.Add(key, GetType(Object))
            Next

            ' Add rows to the DataTable
            For Each dict As Dictionary(Of String, Object) In listOfDicts
                Dim row As DataRow = dt.NewRow()
                For Each key As String In dict.Keys
                    row(key) = dict(key)
                Next
                dt.Rows.Add(row)
            Next
        End If

        Return dt
    End Function


End Module
