Imports DevExpress.XtraBars

Public Class xfrmMain

    Private clsD_Chart As clsChartSub
    Private Sub sD_iniControls()

        Dyn.Elements.Add("YKIHO", ocsHospital.m요양기관번호)
        Dyn.Elements.Add("BIZ_TXT", "")

        Dim strL_Menu As String = ""
        Dim MainSub As DevExpress.XtraBars.BarSubItem = bar포털바로가기

        Dim SubMenu As DevExpress.XtraBars.BarSubItem = Nothing
        Dim subMenuItem As DevExpress.XtraBars.BarButtonItem

        Dim MenuExists As Boolean

        Dyn_Response = Dyn.requestData(ocsHospital.m요양기관번호, "selectLinkList")
        If Dyn_Response.Result = True Then
            If Dyn_Response.ListDatas.Rows.Count > 0 Then
                For i As Integer = 0 To Dyn_Response.ListDatas.Rows.Count - 1
                    MenuExists = False
                    If Dyn_Response.ListDatas.Rows(i)("bizTxt").Value = "요양기관 업무포털" Or Dyn_Response.ListDatas.Rows(i)("bizTxt").Value = "심사평가정보 제출포털" Then
                        For Each itemLink As DevExpress.XtraBars.BarItemLink In bar포털바로가기.ItemLinks
                            If TypeOf itemLink.Item Is DevExpress.XtraBars.BarSubItem AndAlso DirectCast(itemLink.Item, DevExpress.XtraBars.BarSubItem).Caption = Dyn_Response.ListDatas.Rows(i)("bizTxt").Value Then
                                MenuExists = True
                                Exit For
                            End If
                        Next
                        If MenuExists = False Then
                            SubMenu = New DevExpress.XtraBars.BarSubItem
                            SubMenu.Caption = Dyn_Response.ListDatas.Rows(i)("bizTxt").Value
                            MainSub.AddItem(SubMenu)
                        End If
                        subMenuItem = New DevExpress.XtraBars.BarButtonItem
                        subMenuItem.Caption = Dyn_Response.ListDatas.Rows(i)("menuNm").Value
                        subMenuItem.Tag = Dyn_Response.ListDatas.Rows(i)("menuId").Value '태그에 메뉴ID 담아두고 그걸로실행
                        subMenuItem.Name = "mnu" & Dyn_Response.ListDatas.Rows(i)("menuNm").Value
                        AddHandler subMenuItem.ItemClick, AddressOf BarMenu_ItemClick
                        SubMenu.AddItem(subMenuItem)
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub sP_AddTab(ByVal TabName As String)

        For intL_i = 0 To tabMain.TabPages.Count - 1
            If tabMain.TabPages.Item(intL_i).Text = TabName Then
                tabMain.SelectedTabPageIndex = intL_i
                Exit Sub
            End If
        Next

        Dim frmL_Form As Form = Nothing
        Select Case TabName
            Case "출생통보"
                frmL_Form = New xfrm출생통보
        End Select

        If frmL_Form Is Nothing Then Exit Sub

        frmL_Form.TopLevel = False
        frmL_Form.FormBorderStyle = FormBorderStyle.None
        frmL_Form.Dock = DockStyle.Fill

        Dim AddTabPages As New DevExpress.XtraTab.XtraTabPage
        AddTabPages.Text = TabName
        AddTabPages.Controls.Add(frmL_Form)
        tabMain.TabPages.Add(AddTabPages)
        frmL_Form.Show()

        tabMain.SelectedTabPageIndex = tabMain.TabPages.Count - 1

    End Sub

    Private Sub xfrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        clsD_Chart = New clsChartSub
        sD_iniControls()
    End Sub

    Private Sub xfrmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        clsD_Chart = Nothing
    End Sub

    Private Sub BarTabAddMenu_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnu출생통보.ItemClick

        If e.Item.Caption = "" Then Exit Sub

        Call sP_AddTab(e.Item.Caption.Replace("mnu", ""))

    End Sub


    Private Sub BarMenu_ItemClick(sender As Object, e As ItemClickEventArgs)

        If e.Item.Tag = "" Then Exit Sub

    End Sub

End Class