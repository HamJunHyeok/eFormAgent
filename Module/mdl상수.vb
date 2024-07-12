Module mdl상수



    '-- 일차의료만성질환
    Public Const conG_API서식_일차의료만성질환 As String = "ASQ10001"
    Public Const conG_API_만성질환대상자조회 As String = "selectTgtpList"
    Public Const conG_API_만성포괄평가서제출 As String = "insertIcsnAsm"
    Public Const conG_API_만성포괄평가서수정 As String = "updateIcsnAsm"
    Public Const conG_API_만성포괄평가서조회 As String = "selectIcsnAsm"
    Public Const conG_API_만성평가서점검및제출 As String = "insertChcAsm"
    Public Const conG_API_만성평가서점검및수정 As String = "updateChcAsm"
    Public Const conG_API_만성평가서점검및조회 As String = "selectChcAsm"
    Public Const conG_API_만성모니터링점검제출 As String = "insertMntrChk"
    Public Const conG_API_만성모니터링점검조회 As String = "selectMntrChk"
    Public Const conG_API_만성교육상담료제출 As String = "insertEduCnsl"
    Public Const conG_API_만성교육상담료조회 As String = "selectEduCnsl"
    Public Const conG_API_만성환자관리료제출 As String = "insertPtntMgmt"
    Public Const conG_API_만성환자관리료조회 As String = "selectPtntMgmt"
    Public Const conG_API_만성서식조회 As String = "selectLink"

    '-- 출생통보
    Public Const conG_API_출생정보제출 As String = "insertBirthData"
    Public Const conG_API_출생정보수정 As String = "updateBirthDataStat"
    Public Const conG_API_출생정보삭제 As String = "deleteBirthData"
    Public Const conG_API_출생정보조회 As String = "selectBirthDataList"

    Public Const conG_API서식고정_출생통보서식ID As String = "EF000002"
    Public Const conG_API서식고정_출생통보VERSION As String = "001"
    Public Const conG_API서식_서식ID As String = "FOM_ID"
    Public Const conG_API서식_함수버전 As String = "FNCT_VER"
    Public Const conG_API서식_요양기관기호 As String = "YKIHO"
    Public Const conG_API서식_확정제출여부 As String = "SMIT_YN"

    '-- 출생통보 API 에러
    Public Const conG_API_INSERT_ERROR As String = "error.birth.insertError"
    Public Const conG_API_INSERT_ERROR01 As String = "error.birth.insertError01"
    Public Const conG_API_INSERT_ERROR02 As String = "error.birth.insertError02"
    Public Const conG_API_INSERT_ERROR03 As String = "error.birth.insertError03"
    Public Const conG_API_INSERT_ERROR04 As String = "error.birth.insertError04"
    Public Const conG_API_INSERT_ERROR05 As String = "error.birth.insertError05"
    Public Const conG_API_INSERT_ERROR06 As String = "error.birth.insertError06"

    Public Const conG_API_DELETE_ERROR As String = "error.birth.deleteError"
    Public Const conG_API_DELETE_ERROR01 As String = "error.birth.deleteError01"
    Public Const conG_API_DELETE_ERROR02 As String = "error.birth.deleteError02"
    Public Const conG_API_DELETE_ERROR03 As String = "error.birth.deleteError03"
    Public Const conG_API_DELETE_ERROR04 As String = "error.birth.deleteError04"
    Public Const conG_API_DELETE_ERROR05 As String = "error.birth.deleteError05"

    Public Const conG_API_UPDATE_ERROR As String = "error.birth.updateError"
    Public Const conG_API_UPDATE_ERROR01 As String = "error.birth.updateError01"
    Public Const conG_API_UPDATE_ERROR02 As String = "error.birth.updateError02"
    Public Const conG_API_UPDATE_ERROR03 As String = "error.birth.updateError03"
    Public Const conG_API_UPDATE_ERROR04 As String = "error.birth.updateError04"
    Public Const conG_API_UPDATE_ERROR05 As String = "error.birth.updateError05"


    '--넘겨받을 정보
    Public Const conG_JSON_제출상태변경 As String = "{""YKIHO"": ""{{요양기관기호}}"", ""PPD_JNO"": ""{{산모주민번호}}"", ""NBY_BTH"": ""{{신생아생년월일}}"", ""NBY_ORD"": ""{{신생아출생순서}}""}"
    Public Const conG_JSON_출생정보삭제 As String = "{""YKIHO"": ""{{요양기관기호}}"", ""SMIT_YN"": ""{{확정제출여부}}"", ""PPD_JNO"": ""{{산모주민번호}}"", ""NBY_BTH"": ""{{신생아생년월일}}"", ""NBY_ORD"": ""{{신생아출생순서}}"", ""BIRTH_DEL_RS_TXT"": ""{{삭제사유}}""}"
    Public Const conG_JSON_출생정보제출 As String = "{""YKIHO"": ""{{요양기관기호}}"", ""SMIT_YN"": ""{{확정제출여부}}"", ""PPD_NM"": ""{{산모성명}}"", ""PPD_JNO"": ""{{산모주민번호}}"", ""NBY_CNT"": ""{{신생아출생수}}"", ""NBY_BTH"": ""{{신생아생년월일}}"", ""NBY_ORD"": ""{{신생아출생순서}}"", ""NBY_BIRTH_HM"": ""{{신생아출생시분}}"", ""NBY_SEX"": ""{{신생아성별}}""}"
    Public Const conG_JSON_출생정보조회 As String = "{""YKIHO"": ""{{요양기관기호}}"", ""WRT_STA_DD"": ""{{조회시작일}}"", ""WRT_END_DD"": ""{{조회종료일}}"", ""PPD_JNO"": ""{{산모주민번호}}"", ""DEL_YN"": ""{{삭제조회여부}}"", ""SMIT_YN"": ""{{확정제출조회여부}}"", ""PPD_NM"": ""{{산모성명}}"", ""PPD_BTH"": ""{{산모생년월일}}"", ""NBY_BTH"": ""{{신생아생년월일}}"", ""CURRENT_PAGE"": ""{{현재페이지수}}, ""RECORD_COUNT_PER_PAGE"": ""{{목록카운트}}""}"

    Public Enum enAPI종류
        출생통보 = 1
    End Enum

    Public Enum en요청구분
        제출 = 1
        수정 = 2
        삭제 = 3
        조회 = 4
    End Enum

End Module
