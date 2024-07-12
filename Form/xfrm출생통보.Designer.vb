<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xfrm출생통보
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xfrm출생통보))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.grd목록 = New DevExpress.XtraGrid.GridControl()
        Me.vw목록 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grd대상자 = New DevExpress.XtraGrid.GridControl()
        Me.vw대상자 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.spr달력 = New FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, CType(resources.GetObject("LayoutControl1.Controls"), Object))
        Me.spr달력_Sheet1 = Me.spr달력.GetSheet(0)
        Me.grd진료내역 = New DevExpress.XtraGrid.GridControl()
        Me.vw진료내역 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grd상병내역 = New DevExpress.XtraGrid.GridControl()
        Me.vw상병내역 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnPrev = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNext = New DevExpress.XtraEditors.SimpleButton()
        Me.dtp달력년월 = New DevExpress.XtraEditors.DateEdit()
        Me.dtp조회시작 = New DevExpress.XtraEditors.DateEdit()
        Me.dtp조회끝 = New DevExpress.XtraEditors.DateEdit()
        Me.btn조회 = New DevExpress.XtraEditors.SimpleButton()
        Me.btn엑셀 = New DevExpress.XtraEditors.SimpleButton()
        Me.dtp기간1 = New DevExpress.XtraEditors.DateEdit()
        Me.dtp기간2 = New DevExpress.XtraEditors.DateEdit()
        Me.cbo삭제여부 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lbl환자기록 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.grd목록, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw목록, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd대상자, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw대상자, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spr달력, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd진료내역, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw진료내역, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd상병내역, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw상병내역, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp달력년월.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp달력년월.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp조회시작.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp조회시작.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp조회끝.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp조회끝.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp기간1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp기간1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp기간2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp기간2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo삭제여부.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl환자기록, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.grd목록)
        Me.LayoutControl1.Controls.Add(Me.grd대상자)
        Me.LayoutControl1.Controls.Add(Me.spr달력)
        Me.LayoutControl1.Controls.Add(Me.grd진료내역)
        Me.LayoutControl1.Controls.Add(Me.grd상병내역)
        Me.LayoutControl1.Controls.Add(Me.btnPrev)
        Me.LayoutControl1.Controls.Add(Me.btnNext)
        Me.LayoutControl1.Controls.Add(Me.dtp달력년월)
        Me.LayoutControl1.Controls.Add(Me.dtp조회시작)
        Me.LayoutControl1.Controls.Add(Me.dtp조회끝)
        Me.LayoutControl1.Controls.Add(Me.btn조회)
        Me.LayoutControl1.Controls.Add(Me.btn엑셀)
        Me.LayoutControl1.Controls.Add(Me.dtp기간1)
        Me.LayoutControl1.Controls.Add(Me.dtp기간2)
        Me.LayoutControl1.Controls.Add(Me.cbo삭제여부)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1302, 796)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'grd목록
        '
        Me.grd목록.Location = New System.Drawing.Point(12, 510)
        Me.grd목록.MainView = Me.vw목록
        Me.grd목록.Name = "grd목록"
        Me.grd목록.Size = New System.Drawing.Size(1278, 274)
        Me.grd목록.TabIndex = 32
        Me.grd목록.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vw목록})
        '
        'vw목록
        '
        Me.vw목록.DetailHeight = 408
        Me.vw목록.GridControl = Me.grd목록
        Me.vw목록.Name = "vw목록"
        '
        'grd대상자
        '
        Me.grd대상자.Location = New System.Drawing.Point(12, 38)
        Me.grd대상자.MainView = Me.vw대상자
        Me.grd대상자.Name = "grd대상자"
        Me.grd대상자.Size = New System.Drawing.Size(639, 418)
        Me.grd대상자.TabIndex = 27
        Me.grd대상자.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vw대상자})
        '
        'vw대상자
        '
        Me.vw대상자.DetailHeight = 408
        Me.vw대상자.GridControl = Me.grd대상자
        Me.vw대상자.Name = "vw대상자"
        '
        'spr달력
        '
        Me.spr달력.AccessibleDescription = "spr달력, Sheet1, Row 0, Column 0"
        Me.spr달력.Font = New System.Drawing.Font("맑은 고딕", 11.0!)
        Me.spr달력.Location = New System.Drawing.Point(1019, 64)
        Me.spr달력.Name = "spr달력"
        Me.spr달력.Size = New System.Drawing.Size(271, 220)
        Me.spr달력.TabIndex = 23
        '
        'grd진료내역
        '
        Me.grd진료내역.Location = New System.Drawing.Point(655, 288)
        Me.grd진료내역.MainView = Me.vw진료내역
        Me.grd진료내역.Name = "grd진료내역"
        Me.grd진료내역.Size = New System.Drawing.Size(635, 168)
        Me.grd진료내역.TabIndex = 22
        Me.grd진료내역.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vw진료내역})
        '
        'vw진료내역
        '
        Me.vw진료내역.DetailHeight = 408
        Me.vw진료내역.GridControl = Me.grd진료내역
        Me.vw진료내역.Name = "vw진료내역"
        '
        'grd상병내역
        '
        Me.grd상병내역.Location = New System.Drawing.Point(655, 38)
        Me.grd상병내역.MainView = Me.vw상병내역
        Me.grd상병내역.Name = "grd상병내역"
        Me.grd상병내역.Size = New System.Drawing.Size(360, 246)
        Me.grd상병내역.TabIndex = 21
        Me.grd상병내역.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vw상병내역})
        '
        'vw상병내역
        '
        Me.vw상병내역.DetailHeight = 408
        Me.vw상병내역.GridControl = Me.grd상병내역
        Me.vw상병내역.Name = "vw상병내역"
        '
        'btnPrev
        '
        Me.btnPrev.ImageOptions.Image = CType(resources.GetObject("btnPrev.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrev.Location = New System.Drawing.Point(1119, 38)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(22, 22)
        Me.btnPrev.StyleController = Me.LayoutControl1
        Me.btnPrev.TabIndex = 25
        '
        'btnNext
        '
        Me.btnNext.ImageOptions.Image = CType(resources.GetObject("btnNext.ImageOptions.Image"), System.Drawing.Image)
        Me.btnNext.Location = New System.Drawing.Point(1145, 38)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(22, 22)
        Me.btnNext.StyleController = Me.LayoutControl1
        Me.btnNext.TabIndex = 26
        '
        'dtp달력년월
        '
        Me.dtp달력년월.EditValue = Nothing
        Me.dtp달력년월.Location = New System.Drawing.Point(1019, 38)
        Me.dtp달력년월.Name = "dtp달력년월"
        Me.dtp달력년월.Properties.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp달력년월.Properties.Appearance.Options.UseFont = True
        Me.dtp달력년월.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp달력년월.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp달력년월.Properties.DisplayFormat.FormatString = ""
        Me.dtp달력년월.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtp달력년월.Properties.EditFormat.FormatString = ""
        Me.dtp달력년월.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtp달력년월.Properties.Mask.EditMask = "yyyy-MM"
        Me.dtp달력년월.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.dtp달력년월.Size = New System.Drawing.Size(96, 22)
        Me.dtp달력년월.StyleController = Me.LayoutControl1
        Me.dtp달력년월.TabIndex = 24
        '
        'dtp조회시작
        '
        Me.dtp조회시작.EditValue = Nothing
        Me.dtp조회시작.Location = New System.Drawing.Point(57, 12)
        Me.dtp조회시작.Name = "dtp조회시작"
        Me.dtp조회시작.Properties.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp조회시작.Properties.Appearance.Options.UseFont = True
        Me.dtp조회시작.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp조회시작.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp조회시작.Size = New System.Drawing.Size(102, 22)
        Me.dtp조회시작.StyleController = Me.LayoutControl1
        Me.dtp조회시작.TabIndex = 28
        '
        'dtp조회끝
        '
        Me.dtp조회끝.EditValue = Nothing
        Me.dtp조회끝.Location = New System.Drawing.Point(177, 12)
        Me.dtp조회끝.Name = "dtp조회끝"
        Me.dtp조회끝.Properties.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp조회끝.Properties.Appearance.Options.UseFont = True
        Me.dtp조회끝.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp조회끝.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp조회끝.Size = New System.Drawing.Size(107, 22)
        Me.dtp조회끝.StyleController = Me.LayoutControl1
        Me.dtp조회끝.TabIndex = 29
        '
        'btn조회
        '
        Me.btn조회.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn조회.Appearance.Options.UseFont = True
        Me.btn조회.ImageOptions.Image = CType(resources.GetObject("btn조회.ImageOptions.Image"), System.Drawing.Image)
        Me.btn조회.Location = New System.Drawing.Point(288, 12)
        Me.btn조회.Name = "btn조회"
        Me.btn조회.Size = New System.Drawing.Size(94, 22)
        Me.btn조회.StyleController = Me.LayoutControl1
        Me.btn조회.TabIndex = 30
        Me.btn조회.Text = "대상자 조회"
        '
        'btn엑셀
        '
        Me.btn엑셀.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn엑셀.Appearance.Options.UseFont = True
        Me.btn엑셀.ImageOptions.Image = CType(resources.GetObject("btn엑셀.ImageOptions.Image"), System.Drawing.Image)
        Me.btn엑셀.Location = New System.Drawing.Point(386, 12)
        Me.btn엑셀.Name = "btn엑셀"
        Me.btn엑셀.Size = New System.Drawing.Size(91, 22)
        Me.btn엑셀.StyleController = Me.LayoutControl1
        Me.btn엑셀.TabIndex = 31
        Me.btn엑셀.Text = "엑 셀"
        '
        'dtp기간1
        '
        Me.dtp기간1.EditValue = Nothing
        Me.dtp기간1.Location = New System.Drawing.Point(65, 484)
        Me.dtp기간1.Name = "dtp기간1"
        Me.dtp기간1.Properties.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.dtp기간1.Properties.Appearance.Options.UseFont = True
        Me.dtp기간1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp기간1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp기간1.Size = New System.Drawing.Size(103, 22)
        Me.dtp기간1.StyleController = Me.LayoutControl1
        Me.dtp기간1.TabIndex = 33
        '
        'dtp기간2
        '
        Me.dtp기간2.EditValue = Nothing
        Me.dtp기간2.Location = New System.Drawing.Point(185, 484)
        Me.dtp기간2.Name = "dtp기간2"
        Me.dtp기간2.Properties.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.dtp기간2.Properties.Appearance.Options.UseFont = True
        Me.dtp기간2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp기간2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp기간2.Size = New System.Drawing.Size(110, 22)
        Me.dtp기간2.StyleController = Me.LayoutControl1
        Me.dtp기간2.TabIndex = 34
        '
        'cbo삭제여부
        '
        Me.cbo삭제여부.Location = New System.Drawing.Point(350, 484)
        Me.cbo삭제여부.Name = "cbo삭제여부"
        Me.cbo삭제여부.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo삭제여부.Properties.Items.AddRange(New Object() {"전 체", "삭 제", "미삭제"})
        Me.cbo삭제여부.Size = New System.Drawing.Size(118, 20)
        Me.cbo삭제여부.StyleController = Me.LayoutControl1
        Me.cbo삭제여부.TabIndex = 35
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.EmptySpaceItem1, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.EmptySpaceItem2, Me.LayoutControlItem12, Me.EmptySpaceItem3, Me.lbl환자기록, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.EmptySpaceItem5, Me.LayoutControlItem15})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1302, 796)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.grd상병내역
        Me.LayoutControlItem1.Location = New System.Drawing.Point(643, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(364, 250)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.grd진료내역
        Me.LayoutControlItem2.Location = New System.Drawing.Point(643, 276)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(639, 172)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.spr달력
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1007, 52)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(275, 224)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.dtp달력년월
        Me.LayoutControlItem4.Location = New System.Drawing.Point(1007, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(100, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(1159, 26)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(123, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnPrev
        Me.LayoutControlItem5.Location = New System.Drawing.Point(1107, 26)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(26, 26)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(26, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(26, 26)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnNext
        Me.LayoutControlItem6.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1133, 26)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(26, 26)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(26, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(26, 26)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.dtp조회시작
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(151, 26)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(151, 26)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(151, 26)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "조회일자"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(40, 14)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.grd대상자
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(643, 422)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.dtp조회끝
        Me.LayoutControlItem9.Location = New System.Drawing.Point(151, 0)
        Me.LayoutControlItem9.MaxSize = New System.Drawing.Size(125, 26)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(125, 26)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(125, 26)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.Text = "~"
        Me.LayoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(9, 14)
        Me.LayoutControlItem9.TextToControlDistance = 5
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.btn조회
        Me.LayoutControlItem10.Location = New System.Drawing.Point(276, 0)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(98, 26)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(98, 26)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(98, 26)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.btn엑셀
        Me.LayoutControlItem11.Location = New System.Drawing.Point(374, 0)
        Me.LayoutControlItem11.MaxSize = New System.Drawing.Size(95, 26)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(95, 26)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(95, 26)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(469, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(174, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.grd목록
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 498)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(1282, 278)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.AppearanceItemCaption.BackColor = System.Drawing.Color.SteelBlue
        Me.EmptySpaceItem3.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmptySpaceItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.White
        Me.EmptySpaceItem3.AppearanceItemCaption.Options.UseBackColor = True
        Me.EmptySpaceItem3.AppearanceItemCaption.Options.UseFont = True
        Me.EmptySpaceItem3.AppearanceItemCaption.Options.UseForeColor = True
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 448)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(0, 24)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(10, 24)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1282, 24)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.Text = " ● 출생통보 제출목록"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(48, 0)
        Me.EmptySpaceItem3.TextVisible = True
        '
        'lbl환자기록
        '
        Me.lbl환자기록.AllowHotTrack = False
        Me.lbl환자기록.AppearanceItemCaption.BackColor = System.Drawing.Color.SteelBlue
        Me.lbl환자기록.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl환자기록.AppearanceItemCaption.ForeColor = System.Drawing.Color.White
        Me.lbl환자기록.AppearanceItemCaption.Options.UseBackColor = True
        Me.lbl환자기록.AppearanceItemCaption.Options.UseFont = True
        Me.lbl환자기록.AppearanceItemCaption.Options.UseForeColor = True
        Me.lbl환자기록.Location = New System.Drawing.Point(643, 0)
        Me.lbl환자기록.Name = "lbl환자기록"
        Me.lbl환자기록.Size = New System.Drawing.Size(639, 26)
        Me.lbl환자기록.Text = " ● 환자기록"
        Me.lbl환자기록.TextSize = New System.Drawing.Size(48, 0)
        Me.lbl환자기록.TextVisible = True
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.LayoutControlItem13.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem13.Control = Me.dtp기간1
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 472)
        Me.LayoutControlItem13.MaxSize = New System.Drawing.Size(160, 26)
        Me.LayoutControlItem13.MinSize = New System.Drawing.Size(160, 26)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(160, 26)
        Me.LayoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem13.Text = "조회기간"
        Me.LayoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(48, 15)
        Me.LayoutControlItem13.TextToControlDistance = 5
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.LayoutControlItem14.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem14.Control = Me.dtp기간2
        Me.LayoutControlItem14.Location = New System.Drawing.Point(160, 472)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.Text = "~"
        Me.LayoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(8, 15)
        Me.LayoutControlItem14.TextToControlDistance = 5
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(460, 472)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(822, 26)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.LayoutControlItem15.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem15.Control = Me.cbo삭제여부
        Me.LayoutControlItem15.Location = New System.Drawing.Point(287, 472)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem15.Text = "삭제여부"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(48, 15)
        '
        'xfrm출생통보
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1302, 796)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconOptions.Image = CType(resources.GetObject("xfrm출생통보.IconOptions.Image"), System.Drawing.Image)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "xfrm출생통보"
        Me.Text = "출생통보 조회"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.grd목록, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw목록, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd대상자, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw대상자, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spr달력, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd진료내역, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw진료내역, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd상병내역, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw상병내역, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp달력년월.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp달력년월.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp조회시작.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp조회시작.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp조회끝.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp조회끝.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp기간1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp기간1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp기간2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp기간2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo삭제여부.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl환자기록, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents grd진료내역 As DevExpress.XtraGrid.GridControl
    Friend WithEvents vw진료내역 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grd상병내역 As DevExpress.XtraGrid.GridControl
    Friend WithEvents vw상병내역 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents spr달력 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents spr달력_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents btnPrev As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNext As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtp달력년월 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grd대상자 As DevExpress.XtraGrid.GridControl
    Friend WithEvents vw대상자 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dtp조회시작 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtp조회끝 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btn조회 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btn엑셀 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents grd목록 As DevExpress.XtraGrid.GridControl
    Friend WithEvents vw목록 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lbl환자기록 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents dtp기간1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtp기간2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cbo삭제여부 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
End Class
