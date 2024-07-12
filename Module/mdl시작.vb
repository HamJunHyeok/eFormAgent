Imports NeoModule
Imports DevExpress.XtraEditors
Imports System.Reflection
Module mdl시작

    Public ocsDBMng As clsDBMng
    Public ocsAgentMng As clsDBMng
    Public ocsCodeLib As ClsCodeBase
    Public ocsHospital As clsHospital
    Public ocsJinStation As ClsJinStation
    Public ocsWorkUser As ClsWorkUser
    Public ocs권한 As Cls권한
    Public ocs의무기록로그 As clsMedicalRecord
    Public ocsServer As clsOCSServer
    Public ocsFormManager As clsFormManager
    Public ocsProgress As xfrmProgress

    Public mProgram As ocsEnumProgram
    Public m실행모드 As Integer

    Public clsG_Eplus암복호화 As Object '센스메디는 dll 넣기싫어서 object로 선언함..

    Public Structure mEPLUS_Structure
        Dim m병원종별 As ocsEnumHospitalKind
        Dim m기관기호 As String
        Dim m병원이름 As String
        Dim m사용자ID As String
        Dim m사용자이름 As String
        Dim m병원구분 As String
    End Structure

    Public mEplus As mEPLUS_Structure
    Public mEchart As mEPLUS_Structure

    Public Sub Main()

        sG_WriteLog("mdlClass/Main", "프로그램 실행")
        Call sP_Initialize()

    End Sub

    Public Sub sP_Initialize()
        Dim strL_args() As String
        Dim strL_Command() As String

        sG_WriteLog("mdlClass/sP_Initialize", "디자인 적용")
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.Skins.SkinManager.EnableMdiFormSkins()
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged()

        WindowsFormsSettings.DefaultFont = New Font("맑은 고딕", 9, FontStyle.Regular)
        WindowsFormsSettings.ThickBorderWidth = 1
        sG_WriteLog("mdlClass/sP_Initialize", "디자인 적용 완료")

        strL_args = Environment.GetCommandLineArgs()

        If Debugger.IsAttached Then
            Dim result As String = InputBox("테스트 프로그램 입력" & vbNewLine & vbNewLine & "센스 : 0" & vbNewLine & "메디 : 1" & vbNewLine & "이플러스 : 2" & vbNewLine & "이챠트 : 3" & vbNewLine & "한의맥 : 4" & vbNewLine & "센스플러스 : 6")
            If result = "2" Then
                strL_Command = Split(WinAPI_INI파일읽기("Database Server", "database_name", conG_SenseINI, "SenseChart") & "/admin/TMZPDLFDJQ/2/D01", "/")
            ElseIf result = "0" Then
                strL_Command = Split(WinAPI_INI파일읽기("Database Server", "database_name", conG_SenseINI, "SenseChart") & "/admin/TMZPDLFDJQ/0", "/")
            ElseIf result = "6" Then
                strL_Command = Split(WinAPI_INI파일읽기("Database Server", "database_name", conG_SenseINI, "SenseChart") & "/admin/TMZPDLFDJQ/6", "/")
            ElseIf result = "3" Then
                strL_Command = Split(WinAPI_INI파일읽기("Database Server", "database_name", conG_SenseINI, "SenseChart") & "/admin/TMZPDLFDJQ/3/D01", "/")
            Else
                strL_Command = Split(WinAPI_INI파일읽기("Database Server", "database_name", conG_MedichartINI, "Medichart") & "/admin/TMZPDLFDJQ/" & result & "/", "/")
            End If
        Else
            '디비이름/유저ID/유저PWD/프로그램구분/실행모드
            strL_Command = Split(strL_args(1), "/")
        End If

        Dim strL_DBName As String = ""
        Dim strL_UserId As String = ""
        Dim strL_UserPwd As String = ""

        If UBound(strL_Command) >= 0 Then strL_DBName = strL_Command(0)
        If UBound(strL_Command) >= 1 Then strL_UserId = strL_Command(1)
        If UBound(strL_Command) >= 2 Then strL_UserPwd = strL_Command(2)
        If UBound(strL_Command) >= 3 Then '프로그램구분 0 : 센스 / 1 : 메디 / 2 : 이플러스 / 4 : 한의맥 / 6 : 센플
            mProgram = GetValue(strL_Command(3))
        End If

        ocsDBMng = New clsDBMng
        If ocsDBMng.fP_ConnectByDB(strL_DBName, mProgram) = True Then

            If fP_CreateDataBase() = False Then
                fG_MsgBox("데이터베이스 접속 실패" & vbNewLine & "네오소프트뱅크에 문의해주세요.", MessageBoxButtons.OK)
                End
            End If

            ocsAgentMng = New clsDBMng
            If ocsAgentMng.fP_ConnectByDB("eFormAgent") = False Then
                fG_MsgBox("데이터베이스 접속 실패(e-Form Agent)" & vbNewLine & "네오소프트뱅크에 문의해주세요.", MessageBoxButtons.OK)
                End
            End If
            If fP_CreateTable() = False Then
                fG_MsgBox("테이블 생성 실패" & vbNewLine & "네오소프트뱅크에 문의해주세요.", MessageBoxButtons.OK)
                End
            End If

            sP_ClassInitialize()
            If mProgram <> ocsEnumProgram.ocsProgram2이플러스 And mProgram <> ocsEnumProgram.ocsProgram3이챠트 Then
                Select Case ocsWorkUser.fP_UserLogin(strL_UserId, strL_UserPwd)
                    Case ocsEnumResultLogin.ocsResultLogin0True
                    Case ocsEnumResultLogin.ocsResultLogin1FalseID
                        fG_MsgBox("존재하지 않는 아이디입니다.", MessageBoxButtons.OK, MessageBoxIcon.Warning, "사용자 변경")
                        sP_ClassFinalize()
                        End
                    Case ocsEnumResultLogin.ocsResultLogin2FalsePWD
                        fG_MsgBox("비밀번호가 잘못되었습니다.", MessageBoxButtons.OK, MessageBoxIcon.Warning, "사용자 변경")
                        sP_ClassFinalize()
                        End
                    Case ocsEnumResultLogin.ocsResultLogin3FalseOUT
                        fG_MsgBox("퇴사한 사용자입니다.", MessageBoxButtons.OK, MessageBoxIcon.Warning, "사용자 변경")
                        sP_ClassFinalize()
                        End
                End Select

                If mProgram = ocsEnumProgram.ocsProgram1메디챠트 Then
                    sP_GetMediChartInfo()
                ElseIf mProgram = ocsEnumProgram.ocsProgram4한의맥프로 Then '한방여부 가져오기
                    ocsHospital.m한방여부 = 1
                End If
            Else
                sG_WriteLog("mdlClass/Main", "이플러스 정보세팅")
                If mProgram = ocsEnumProgram.ocsProgram2이플러스 Then
                    sP_GetEplusInfo()
                    clsG_Eplus암복호화 = New clsEplus암복호화
                Else
                    sP_GetEchartInfo()
                End If
                sG_WriteLog("mdlClass/Main", "이플러스 정보세팅 완료")
            End If

            Dyn = New HIRA.DynamicEntry.Model.DynamicRequest
            Dyn_Response = New HIRA.DynamicEntry.ResponseModel.DynamicResponse

            sG_WriteLog("mdlClass/Main", "e-Form 메인화면 실행")
            ocsFormManager.ADDForm(xfrmAgent, "xfrmAgent",,, False, True,,,, "xfrmAgent", True)
        Else
            fG_MsgBox("서버 연결에 실패하였습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sP_ClassFinalize()
            End
        End If


    End Sub

    Private Sub sP_GetEchartInfo()

        Dim strL_SQL As String
        strL_SQL = " SELECT TOP 1 MEDM_ID, MEDM_GUBUN, MEDM_NAME " & vbNewLine
        strL_SQL &= " FROM HP_MEDM " & vbNewLine
        strL_SQL &= " ORDER BY MEDM_SDATE DESC "
        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                With mEchart
                    .m기관기호 = rst.Fields("MEDM_ID").Value
                    .m병원종별 = ocsEnumHospitalKind.ocsHospitalKind1병원
                    .m병원이름 = rst.Fields("MEDM_NAME").Value
                End With
            End If
        End If

    End Sub

    Private Sub sP_GetEplusInfo()

        Dim strL_SQL As String
        strL_SQL = "  select  TOP 1 A.MEDM_HK_NAME, B.MEDS_HK_CODE, B.MEDS_HOSP_GUBUN, A.MEDM_GUBUN " & vbNewLine
        strL_SQL &= " From CC_MEDM a inner Join CC_MEDS b " & vbNewLine
        strL_SQL &= " On a.MEDM_HK_CODE = b.MEDS_HK_CODE  " & vbNewLine
        strL_SQL &= " inner Join CC_USRM c " & vbNewLine
        strL_SQL &= " On a.MEDM_HK_CODE = C.USRM_MEDM_ID " & vbNewLine
        strL_SQL &= " where Left(a.MEDM_HK_CODE, 4) <> '1128' " & vbNewLine
        strL_SQL &= " And c.USRM_ID = '" & mEplus.m사용자ID & "' " & vbNewLine
        strL_SQL &= " ORDER by MEDM_DATE DESC " & vbNewLine
        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                With mEplus
                    .m기관기호 = rst.Fields("MEDS_HK_CODE").Value
                    .m병원종별 = GetValue(rst.Fields("MEDS_HOSP_GUBUN").Value)
                    .m병원이름 = rst.Fields("MEDM_HK_NAME").Value
                    .m병원구분 = rst.Fields("MEDM_GUBUN").Value     '2024/06/11 Ahn 이플러스 병원구분추가
                End With
            End If
        End If

    End Sub

    Private Sub sP_GetMediChartInfo()

        Dim strL_SQL As String
        strL_SQL = " SELECT 진료과목 FROM TB_진료지원 WHERE 진료과목 >= '80' "
        Dim rst As ADODB.Recordset = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                ocsHospital.m한방구분 = "1"
            End If
        End If

    End Sub

    Private Function fP_CreateDataBase() As Boolean

        Dim strL_Path As String = ""
        Dim strL_SQL As String = ""
        Dim rst As ADODB.Recordset = Nothing
        Dim strL_Temp() As String

        strL_SQL = "SELECT filename FROM master..sysdatabases WHERE name = '" & ocsDBMng.DataBaseName & "' "
        rst = ocsDBMng.GetRecordset(strL_SQL)
        If rst.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rst.EOF = False Then
                strL_Temp = Split(rst.Fields("filename").Value & "", "\")
                For intL_i As Integer = 0 To UBound(strL_Temp)
                    If intL_i = UBound(strL_Temp) Then Exit For
                    strL_Path = strL_Path & strL_Temp(intL_i) & "\"
                Next
            End If
        End If

        If strL_Path = "" Then strL_Path = "C:\Sense\bin\"

        Dim rstCheck As ADODB.Recordset = ocsDBMng.GetRecordset("Select Name From SYS.databases Where Name = N'eFormAgent'")
        If rstCheck.State = ADODB.ObjectStateEnum.adStateOpen Then
            If rstCheck.EOF = True Then
                strL_SQL = " IF NOT EXISTS(Select Name From SYS.databases Where Name = N'eFormAgent')" & vbNewLine
                strL_SQL &= " Begin " & vbNewLine
                strL_SQL &= "   CREATE DATABASE [eFormAgent] ON  PRIMARY " & vbNewLine
                strL_SQL &= "   ( NAME = N'eFormAgent', FILENAME = N'" & strL_Path & "eFormAgent.mdf' , SIZE = 64704KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ) " & vbNewLine
                strL_SQL &= "   LOG ON " & vbNewLine
                strL_SQL &= "   ( NAME = N'eFormAgent_log', FILENAME = N'" & strL_Path & "eFormAgent.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%) " & vbNewLine
                strL_SQL &= "   ALTER DATABASE [eFormAgent] SET COMPATIBILITY_LEVEL = 100 " & vbNewLine
                strL_SQL &= "   IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled')) " & vbNewLine
                strL_SQL &= "   Begin " & vbNewLine
                strL_SQL &= "   EXEC [eFormAgent].[dbo].[sp_fulltext_database] @action = 'enable' " & vbNewLine
                strL_SQL &= "   End " & vbNewLine
                strL_SQL &= " END "

                If ocsDBMng.Execute(strL_SQL) = False Then
                    sG_WriteLog("mdlClass/Main", "eFormAgent 디비 생성 실패")
                    Return False
                End If
            End If
        End If

        Return True

    End Function

    Private Function fP_CreateTable() As Boolean

        Dim strL_SQL As String

        strL_SQL = " IF NOT EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='TB_REQUEST') BEGIN" & vbNewLine
        strL_SQL &= " CREATE TABLE [dbo].[TB_REQUEST]( " & vbNewLine
        strL_SQL &= " [id] [bigint] IDENTITY(1, 1) Not NULL, " & vbNewLine
        strL_SQL &= " [챠트번호] [nvarchar](20) NULL, " & vbNewLine
        strL_SQL &= " [API종류] [Int] NULL, " & vbNewLine
        strL_SQL &= " [요청구분] [Int] NULL, " & vbNewLine
        strL_SQL &= " [요청일자] [varchar](10) NULL, " & vbNewLine
        strL_SQL &= " [요청시간] [smalldatetime] NULL CONSTRAINT [DF_TB_REQUEST_요청시간]  DEFAULT (getdate()), " & vbNewLine
        strL_SQL &= " [요청내용] [nvarchar](4000) NULL, " & vbNewLine
        strL_SQL &= " [요청자] [varchar](20) NULL, " & vbNewLine
        strL_SQL &= " [처리상태] [varchar](6) NULL, " & vbNewLine
        strL_SQL &= " [처리시간] [smalldatetime] NULL CONSTRAINT [DF_TB_REQUEST_처리시간]  DEFAULT (getdate()), " & vbNewLine
        strL_SQL &= " [에러코드] [varchar](3) NULL, " & vbNewLine
        strL_SQL &= " [에러내용] [nvarchar](500) NULL, " & vbNewLine
        strL_SQL &= " [문서인덱스] [Int] NULL, " & vbNewLine
        strL_SQL &= " Constraint [PK_TB_REQUEST] PRIMARY KEY CLUSTERED  " & vbNewLine
        strL_SQL &= " ( " & vbNewLine
        strL_SQL &= " [id] Asc " & vbNewLine
        strL_SQL &= " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " & vbNewLine
        strL_SQL &= " ) ON [PRIMARY] " & vbNewLine
        strL_SQL &= "END"
        If ocsAgentMng.Execute(strL_SQL) = False Then
            sG_WriteLog("mdlClass/Main", "eFormAgent TB_REQUEST 테이블 생성 실패")
            Return False
        End If

        strL_SQL = " IF NOT EXISTS(SELECT name FROM SYS.indexes WHERE NAME='IDX_TB_REQUEST') BEGIN" & vbNewLine
        strL_SQL &= " CREATE NONCLUSTERED INDEX [IDX_TB_REQUEST] ON [dbo].[TB_REQUEST] " & vbNewLine
        strL_SQL &= " ( " & vbNewLine
        strL_SQL &= " [API종류] Asc, " & vbNewLine
        strL_SQL &= " [요청구분] ASC, " & vbNewLine
        strL_SQL &= " [요청일자] Asc " & vbNewLine
        strL_SQL &= " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) " & vbNewLine
        strL_SQL &= " End " & vbNewLine
        If ocsAgentMng.Execute(strL_SQL) = False Then
            sG_WriteLog("mdlClass/Main", "eFormAgent IDX_TB_REQUEST 인덱스 생성 실패")
        End If

        strL_SQL = " IF NOT EXISTS(SELECT name FROM SYS.indexes WHERE NAME='IDX_TB_REQUEST2') BEGIN" & vbNewLine
        strL_SQL &= " CREATE NONCLUSTERED INDEX [IDX_TB_REQUEST2] ON [dbo].[TB_REQUEST] " & vbNewLine
        strL_SQL &= " ( " & vbNewLine
        strL_SQL &= " [요청일자] Asc, " & vbNewLine
        strL_SQL &= " [처리상태] Asc " & vbNewLine
        strL_SQL &= " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) " & vbNewLine
        strL_SQL &= " End " & vbNewLine
        If ocsAgentMng.Execute(strL_SQL) = False Then
            sG_WriteLog("mdlClass/Main", "eFormAgent IDX_TB_REQUEST2 인덱스 생성 실패")
        End If

        strL_SQL = " IF NOT EXISTS(SELECT name FROM SYS.indexes WHERE NAME='IDX_TB_REQUEST3') BEGIN" & vbNewLine
        strL_SQL &= " CREATE NONCLUSTERED INDEX [IDX_TB_REQUEST3] ON [dbo].[TB_REQUEST] " & vbNewLine
        strL_SQL &= " ( " & vbNewLine
        strL_SQL &= " [챠트번호] Asc " & vbNewLine
        strL_SQL &= " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) " & vbNewLine
        strL_SQL &= " End " & vbNewLine
        If ocsAgentMng.Execute(strL_SQL) = False Then
            sG_WriteLog("mdlClass/Main", "eFormAgent IDX_TB_REQUEST3 인덱스 생성 실패")
        End If

        Return True

    End Function

    Public Sub sP_ClassInitialize()

        sG_WriteLog("mdlClass/sP_ClassInitialize", "클래스 초기화")

        ocsFormManager = New clsFormManager()

        If mProgram = ocsEnumProgram.ocsProgram2이플러스 Or mProgram = ocsEnumProgram.ocsProgram3이챠트 Then
            sG_SetDLLInitalizeEplus(ocsDBMng, strP_ProgramName, ocsFormManager, ocsServer)
        ElseIf mProgram = ocsEnumProgram.ocsProgram1메디챠트 Then
            sG_SetDLLInitalizeMedi(ocsDBMng, ocsCodeLib, ocsWorkUser, ocsHospital, strP_ProgramName, ocsJinStation, ocsFormManager, ocsServer)
        ElseIf mProgram = ocsEnumProgram.ocsProgram4한의맥프로 Then
            sG_SetDLLInitalizeHanimac(ocsDBMng, ocsCodeLib, ocsWorkUser, ocsHospital, strP_ProgramName, ocsJinStation, ocsFormManager, ocsServer)
        Else
            sG_SetDLLInitalize(ocsDBMng, ocsCodeLib, ocsWorkUser, ocsHospital, strP_ProgramName, ocsJinStation, , ocsFormManager, ocs의무기록로그, ocsServer, True, mProgram)
        End If

        sG_WriteLog("mdlClass/sP_ClassInitialize", "클래스 초기화 완료")

    End Sub

    Public Sub sP_ClassFinalize()
        ocsWorkUser = Nothing
        ocsDBMng = Nothing
        ocsCodeLib = Nothing
        ocsHospital = Nothing
        ocsJinStation = Nothing
        ocs의무기록로그 = Nothing
        ocsFormManager = Nothing
        ocsJinStation = Nothing
        ocsFormManager = Nothing
        ocsServer = Nothing
        If ocsProgress IsNot Nothing Then
            ocsProgress.Close()
            ocsProgress = Nothing
        End If
        sG_TerminateDLL()
    End Sub

End Module
