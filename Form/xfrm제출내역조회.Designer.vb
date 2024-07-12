<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class xfrm제출내역조회
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xfrm제출내역조회))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.grd상세 = New NeoModule.NeoCustomGrid.NeoGrid()
        Me.vw상세 = New NeoModule.NeoCustomGrid.NeoGridView()
        Me.grdList = New NeoModule.NeoCustomGrid.NeoGrid()
        Me.vwList = New NeoModule.NeoCustomGrid.NeoGridView()
        Me.dtp기간1 = New DevExpress.XtraEditors.DateEdit()
        Me.dtp기간2 = New DevExpress.XtraEditors.DateEdit()
        Me.cbo처리구분 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txt챠트번호 = New DevExpress.XtraEditors.TextEdit()
        Me.btn조회 = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.grd상세, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw상세, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp기간1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp기간1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp기간2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp기간2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo처리구분.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt챠트번호.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.grd상세)
        Me.LayoutControl1.Controls.Add(Me.grdList)
        Me.LayoutControl1.Controls.Add(Me.dtp기간1)
        Me.LayoutControl1.Controls.Add(Me.dtp기간2)
        Me.LayoutControl1.Controls.Add(Me.cbo처리구분)
        Me.LayoutControl1.Controls.Add(Me.txt챠트번호)
        Me.LayoutControl1.Controls.Add(Me.btn조회)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(855, 593)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'grd상세
        '
        Me.grd상세.Location = New System.Drawing.Point(12, 324)
        Me.grd상세.MainView = Me.vw상세
        Me.grd상세.Name = "grd상세"
        Me.grd상세.Size = New System.Drawing.Size(831, 257)
        Me.grd상세.TabIndex = 15
        Me.grd상세.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vw상세})
        '
        'vw상세
        '
        Me.vw상세.GridControl = Me.grd상세
        Me.vw상세.Name = "vw상세"
        Me.vw상세.OptionsView.FooterLocation = NeoModule.NeoCustomGrid.FooterPosition.Bottom
        '
        'grdList
        '
        Me.grdList.Location = New System.Drawing.Point(12, 90)
        Me.grdList.MainView = Me.vwList
        Me.grdList.Name = "grdList"
        Me.grdList.Size = New System.Drawing.Size(831, 204)
        Me.grdList.TabIndex = 12
        Me.grdList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwList})
        '
        'vwList
        '
        Me.vwList.GridControl = Me.grdList
        Me.vwList.Name = "vwList"
        Me.vwList.OptionsView.FooterLocation = NeoModule.NeoCustomGrid.FooterPosition.Bottom
        '
        'dtp기간1
        '
        Me.dtp기간1.EditValue = Nothing
        Me.dtp기간1.Location = New System.Drawing.Point(65, 12)
        Me.dtp기간1.Name = "dtp기간1"
        Me.dtp기간1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp기간1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp기간1.Size = New System.Drawing.Size(129, 20)
        Me.dtp기간1.StyleController = Me.LayoutControl1
        Me.dtp기간1.TabIndex = 4
        '
        'dtp기간2
        '
        Me.dtp기간2.EditValue = Nothing
        Me.dtp기간2.Location = New System.Drawing.Point(211, 12)
        Me.dtp기간2.Name = "dtp기간2"
        Me.dtp기간2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp기간2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtp기간2.Size = New System.Drawing.Size(141, 20)
        Me.dtp기간2.StyleController = Me.LayoutControl1
        Me.dtp기간2.TabIndex = 5
        '
        'cbo처리구분
        '
        Me.cbo처리구분.Location = New System.Drawing.Point(409, 12)
        Me.cbo처리구분.Name = "cbo처리구분"
        Me.cbo처리구분.Properties.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.cbo처리구분.Properties.Appearance.Options.UseFont = True
        Me.cbo처리구분.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo처리구분.Properties.Items.AddRange(New Object() {"전 체", "제출 대기", "제출 완료", "제출 실패"})
        Me.cbo처리구분.Size = New System.Drawing.Size(143, 22)
        Me.cbo처리구분.StyleController = Me.LayoutControl1
        Me.cbo처리구분.TabIndex = 6
        '
        'txt챠트번호
        '
        Me.txt챠트번호.Location = New System.Drawing.Point(118, 38)
        Me.txt챠트번호.Name = "txt챠트번호"
        Me.txt챠트번호.Properties.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.txt챠트번호.Properties.Appearance.Options.UseFont = True
        Me.txt챠트번호.Size = New System.Drawing.Size(234, 22)
        Me.txt챠트번호.StyleController = Me.LayoutControl1
        Me.txt챠트번호.TabIndex = 13
        '
        'btn조회
        '
        Me.btn조회.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn조회.Appearance.Options.UseFont = True
        Me.btn조회.ImageOptions.Image = CType(resources.GetObject("btn조회.ImageOptions.Image"), System.Drawing.Image)
        Me.btn조회.Location = New System.Drawing.Point(356, 38)
        Me.btn조회.Name = "btn조회"
        Me.btn조회.Size = New System.Drawing.Size(89, 22)
        Me.btn조회.StyleController = Me.LayoutControl1
        Me.btn조회.TabIndex = 14
        Me.btn조회.Text = "조 회"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.EmptySpaceItem1, Me.LayoutControlItem6, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.LayoutControlItem7})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(855, 593)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.LayoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem1.Control = Me.dtp기간1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(186, 24)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(186, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(186, 26)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "조회기간"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(48, 15)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.LayoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem2.Control = Me.dtp기간2
        Me.LayoutControlItem2.Location = New System.Drawing.Point(186, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(158, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(158, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(158, 26)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "~"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(8, 15)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.grdList
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(835, 208)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.LayoutControlItem3.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem3.Control = Me.cbo처리구분
        Me.LayoutControlItem3.Location = New System.Drawing.Point(344, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(200, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(200, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(200, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "처리구분"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(48, 15)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem5.Control = Me.txt챠트번호
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(344, 26)
        Me.LayoutControlItem5.Text = "챠트번호/수진자명"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(101, 15)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(544, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(291, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btn조회
        Me.LayoutControlItem6.Location = New System.Drawing.Point(344, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(93, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(437, 26)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(398, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.AppearanceItemCaption.BackColor = System.Drawing.Color.SteelBlue
        Me.EmptySpaceItem3.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EmptySpaceItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.White
        Me.EmptySpaceItem3.AppearanceItemCaption.Options.UseBackColor = True
        Me.EmptySpaceItem3.AppearanceItemCaption.Options.UseFont = True
        Me.EmptySpaceItem3.AppearanceItemCaption.Options.UseForeColor = True
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 52)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(0, 26)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(10, 26)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(835, 26)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.Text = " ● 제출환자 리스트"
        Me.EmptySpaceItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.EmptySpaceItem3.TextVisible = True
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.AppearanceItemCaption.BackColor = System.Drawing.Color.SteelBlue
        Me.EmptySpaceItem4.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EmptySpaceItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.White
        Me.EmptySpaceItem4.AppearanceItemCaption.Options.UseBackColor = True
        Me.EmptySpaceItem4.AppearanceItemCaption.Options.UseFont = True
        Me.EmptySpaceItem4.AppearanceItemCaption.Options.UseForeColor = True
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 286)
        Me.EmptySpaceItem4.MaxSize = New System.Drawing.Size(0, 26)
        Me.EmptySpaceItem4.MinSize = New System.Drawing.Size(10, 26)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(835, 26)
        Me.EmptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem4.Text = " ● 상세리스트"
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.EmptySpaceItem4.TextVisible = True
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.grd상세
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 312)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(835, 261)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'xfrm제출내역조회
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 593)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconOptions.Image = CType(resources.GetObject("xfrm제출내역조회.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "xfrm제출내역조회"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "제출내역 조회"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.grd상세, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw상세, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp기간1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp기간1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp기간2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp기간2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo처리구분.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt챠트번호.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents dtp기간1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtp기간2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbo처리구분 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grdList As NeoModule.NeoCustomGrid.NeoGrid
    Friend WithEvents vwList As NeoModule.NeoCustomGrid.NeoGridView
    Friend WithEvents txt챠트번호 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btn조회 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grd상세 As NeoModule.NeoCustomGrid.NeoGrid
    Friend WithEvents vw상세 As NeoModule.NeoCustomGrid.NeoGridView
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
End Class
