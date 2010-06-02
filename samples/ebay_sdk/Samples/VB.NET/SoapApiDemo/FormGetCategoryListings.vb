Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetCategoryListings
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer




		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents ClmItemId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmTitle As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmPrice As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmBids As System.Windows.Forms.ColumnHeader 

		Friend WithEvents LblCategory As System.Windows.Forms.Label 

		Friend WithEvents TxtCategory As System.Windows.Forms.TextBox 

		Friend WithEvents CboSort As System.Windows.Forms.ComboBox 

		Friend WithEvents LblSort As System.Windows.Forms.Label 

		Friend WithEvents LstSearchResults As System.Windows.Forms.ListView 

		Friend WithEvents LblSearchResults As System.Windows.Forms.Label 

		Friend WithEvents ClmTimeLeft As System.Windows.Forms.ColumnHeader 

		Friend WithEvents BtnGetCategoryListings As System.Windows.Forms.Button 

		Friend WithEvents LblRegion As System.Windows.Forms.Label 

		Friend WithEvents TxtRegion As System.Windows.Forms.TextBox 

		Friend WithEvents CboSiteFilter As System.Windows.Forms.ComboBox 

		Friend WithEvents LblSiteFilter As System.Windows.Forms.Label 

		Friend WithEvents CboItemFilter As System.Windows.Forms.ComboBox 

		Friend WithEvents LblItemFilter As System.Windows.Forms.Label 

		Friend WithEvents CboSearchType As System.Windows.Forms.ComboBox 

		Friend WithEvents LblSearchType As System.Windows.Forms.Label 

		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()


		

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblSearchResults = new System.Windows.Forms.Label()

			Me.LstSearchResults = new System.Windows.Forms.ListView()

			Me.ClmItemId = new System.Windows.Forms.ColumnHeader()

			Me.ClmTitle = new System.Windows.Forms.ColumnHeader()

			Me.ClmPrice = new System.Windows.Forms.ColumnHeader()

			Me.ClmBids = new System.Windows.Forms.ColumnHeader()

			Me.ClmTimeLeft = new System.Windows.Forms.ColumnHeader()

			Me.BtnGetCategoryListings = new System.Windows.Forms.Button()

			Me.LblCategory = new System.Windows.Forms.Label()

			Me.TxtCategory = new System.Windows.Forms.TextBox()

			Me.CboSort = new System.Windows.Forms.ComboBox()

			Me.LblSort = new System.Windows.Forms.Label()

			Me.LblRegion = new System.Windows.Forms.Label()

			Me.TxtRegion = new System.Windows.Forms.TextBox()

			Me.CboSiteFilter = new System.Windows.Forms.ComboBox()

			Me.LblSiteFilter = new System.Windows.Forms.Label()

			Me.CboItemFilter = new System.Windows.Forms.ComboBox()

			Me.LblItemFilter = new System.Windows.Forms.Label()

			Me.CboSearchType = new System.Windows.Forms.ComboBox()

			Me.LblSearchType = new System.Windows.Forms.Label()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblSearchResults)

			Me.GrpResult.Controls.Add(Me.LstSearchResults)

			Me.GrpResult.Location = new System.Drawing.Point(8, 200)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(456, 296)

			Me.GrpResult.TabIndex = 24

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Results"

			' 

			' LblSearchResults

			' 

			Me.LblSearchResults.Location = new System.Drawing.Point(16, 24)

			Me.LblSearchResults.Name = "LblSearchResults"

			Me.LblSearchResults.Size = new System.Drawing.Size(112, 23)

			Me.LblSearchResults.TabIndex = 15

			Me.LblSearchResults.Text = "Items Found:"

			' 

			' LstSearchResults

			' 

        Me.LstSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right

        Me.LstSearchResults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmItemId, Me.ClmTitle, Me.ClmPrice, Me.ClmBids, Me.ClmTimeLeft})

			Me.LstSearchResults.GridLines = true

			Me.LstSearchResults.Location = new System.Drawing.Point(8, 48)

			Me.LstSearchResults.Name = "LstSearchResults"

			Me.LstSearchResults.Size = new System.Drawing.Size(440, 232)

			Me.LstSearchResults.TabIndex = 4

			Me.LstSearchResults.View = System.Windows.Forms.View.Details

			' 

			' ClmItemId

			' 

			Me.ClmItemId.Text = "ItemId"

			Me.ClmItemId.Width = 80

			' 

			' ClmTitle

			' 

			Me.ClmTitle.Text = "Title"

			Me.ClmTitle.Width = 173

			' 

			' ClmPrice

			' 

			Me.ClmPrice.Text = "Price"

			' 

			' ClmBids

			' 

			Me.ClmBids.Text = "Bids"

			Me.ClmBids.Width = 39

			' 

			' ClmTimeLeft

			' 

			Me.ClmTimeLeft.Text = "TimeLeft"

			' 

			' BtnGetCategoryListings

			' 

			Me.BtnGetCategoryListings.Location = new System.Drawing.Point(176, 136)

			Me.BtnGetCategoryListings.Name = "BtnGetCategoryListings"

			Me.BtnGetCategoryListings.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetCategoryListings.TabIndex = 23

			Me.BtnGetCategoryListings.Text = "GetCategoryListings"

			'Me.BtnGetCategoryListings.Click += new System.EventHandler(Me.BtnGetCategoryListings_Click)

			' 

			' LblCategory

			' 

			Me.LblCategory.Location = new System.Drawing.Point(16, 8)

			Me.LblCategory.Name = "LblCategory"

			Me.LblCategory.Size = new System.Drawing.Size(80, 23)

			Me.LblCategory.TabIndex = 78

			Me.LblCategory.Text = "Category:"

			' 

			' TxtCategory

			' 

			Me.TxtCategory.Location = new System.Drawing.Point(96, 8)

			Me.TxtCategory.Name = "TxtCategory"

			Me.TxtCategory.TabIndex = 77

			Me.TxtCategory.Text = ""

			' 

			' CboSort

			' 

			Me.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboSort.Location = new System.Drawing.Point(96, 104)

			Me.CboSort.Name = "CboSort"

			Me.CboSort.Size = new System.Drawing.Size(136, 21)

			Me.CboSort.TabIndex = 81

			' 

			' LblSort

			' 

			Me.LblSort.Location = new System.Drawing.Point(16, 104)

			Me.LblSort.Name = "LblSort"

			Me.LblSort.Size = new System.Drawing.Size(80, 18)

			Me.LblSort.TabIndex = 80

			Me.LblSort.Text = "Sort:"

			' 

			' LblRegion

			' 

			Me.LblRegion.Location = new System.Drawing.Point(16, 32)

			Me.LblRegion.Name = "LblRegion"

			Me.LblRegion.Size = new System.Drawing.Size(80, 23)

			Me.LblRegion.TabIndex = 83

			Me.LblRegion.Text = "Region Id:"

			' 

			' TxtRegion

			' 

			Me.TxtRegion.Location = new System.Drawing.Point(96, 32)

			Me.TxtRegion.Name = "TxtRegion"

			Me.TxtRegion.TabIndex = 82

			Me.TxtRegion.Text = ""

			' 

			' CboSiteFilter

			' 

			Me.CboSiteFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboSiteFilter.Location = new System.Drawing.Point(272, 32)

			Me.CboSiteFilter.Name = "CboSiteFilter"

			Me.CboSiteFilter.Size = new System.Drawing.Size(136, 21)

			Me.CboSiteFilter.TabIndex = 85

			' 

			' LblSiteFilter

			' 

			Me.LblSiteFilter.Location = new System.Drawing.Point(208, 32)

			Me.LblSiteFilter.Name = "LblSiteFilter"

			Me.LblSiteFilter.Size = new System.Drawing.Size(64, 18)

			Me.LblSiteFilter.TabIndex = 84

			Me.LblSiteFilter.Text = "Site Filter:"

			' 

			' CboItemFilter

			' 

			Me.CboItemFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboItemFilter.Location = new System.Drawing.Point(96, 56)

			Me.CboItemFilter.Name = "CboItemFilter"

			Me.CboItemFilter.Size = new System.Drawing.Size(136, 21)

			Me.CboItemFilter.TabIndex = 87

			' 

			' LblItemFilter

			' 

			Me.LblItemFilter.Location = new System.Drawing.Point(16, 56)

			Me.LblItemFilter.Name = "LblItemFilter"

			Me.LblItemFilter.Size = new System.Drawing.Size(80, 18)

			Me.LblItemFilter.TabIndex = 86

			Me.LblItemFilter.Text = "Item Filter:"

			' 

			' CboSearchType

			' 

			Me.CboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboSearchType.Location = new System.Drawing.Point(96, 80)

			Me.CboSearchType.Name = "CboSearchType"

			Me.CboSearchType.Size = new System.Drawing.Size(136, 21)

			Me.CboSearchType.TabIndex = 89

			' 

			' LblSearchType

			' 

			Me.LblSearchType.Location = new System.Drawing.Point(16, 80)

			Me.LblSearchType.Name = "LblSearchType"

			Me.LblSearchType.Size = new System.Drawing.Size(80, 18)

			Me.LblSearchType.TabIndex = 88

			Me.LblSearchType.Text = "Search Type:"

			' 

			' FrmGetCategoryListings

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(472, 501)

			Me.Controls.Add(Me.CboSearchType)

			Me.Controls.Add(Me.LblSearchType)

			Me.Controls.Add(Me.CboItemFilter)

			Me.Controls.Add(Me.LblItemFilter)

			Me.Controls.Add(Me.CboSiteFilter)

			Me.Controls.Add(Me.LblSiteFilter)

			Me.Controls.Add(Me.LblRegion)

			Me.Controls.Add(Me.TxtRegion)

			Me.Controls.Add(Me.CboSort)

			Me.Controls.Add(Me.LblSort)

			Me.Controls.Add(Me.LblCategory)

			Me.Controls.Add(Me.TxtCategory)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetCategoryListings)

			Me.Name = "FrmGetCategoryListings"

			Me.Text = "GetCategoryListings"

			'Me.Load += new System.EventHandler(Me.FrmGetCategoryListings_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)

   End Sub

#End Region


    Public Context As ApiContext


		Private Sub  FrmGetCategoryListings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		

			CboSiteFilter.Items.Add("NoFilter")

			CboItemFilter.Items.Add("NoFilter")

			CboSearchType.Items.Add("NoFilter")

			CboSort.Items.Add("DefaultSort")

        Dim enums() As String = [Enum].GetNames(GetType(SiteIDFilterCodeType))
        Dim item As String

        For Each item In enums

            If item <> "CustomCode" Then
                CboSiteFilter.Items.Add(item)
            End If
        Next item

        enums = [Enum].GetNames(GetType(ItemTypeFilterCodeType))

        For Each item In enums
            If item <> "CustomCode" Then
                CboItemFilter.Items.Add(item)
            End If
        Next item


        enums = [Enum].GetNames(GetType(CategoryListingsOrderCodeType))

        For Each item In enums
            If item <> "CustomCode" Then
                CboSort.Items.Add(item)
            End If
        Next item


        enums = [Enum].GetNames(GetType(CategoryListingsSearchCodeType))

        For Each item In enums
            If item <> "CustomCode" Then
                CboSearchType.Items.Add(item)
            End If
        Next item



        CboItemFilter.SelectedIndex = 0

        CboSearchType.SelectedIndex = 0

        CboSiteFilter.SelectedIndex = 0

        CboSort.SelectedIndex = 0
		End Sub


		Private Sub  BtnGetCategoryListings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetCategoryListings.Click

			Try

				LstSearchResults.Items.Clear()

				Dim apicall As GetCategoryListingsCall = new GetCategoryListingsCall(Context)

				If TxtRegion.Text.Length > 0 Or CboSiteFilter.SelectedIndex > 0 Then

					apicall.SearchLocation = new SearchLocationType()

					apicall.SearchLocation.RegionID = TxtRegion.Text

					If CboSiteFilter.SelectedIndex > 0 Then

						apicall.SearchLocation.SiteLocation = new SiteLocationType()

						apicall.SearchLocation.SiteLocation.SiteID =[Enum].Parse(GetType(SiteIDFilterCodeType), CboSiteFilter.SelectedItem.ToString())

					End If

				End If


            If CboItemFilter.SelectedIndex > 0 Then
                apicall.ItemTypeFilter = [Enum].Parse(GetType(ItemTypeFilterCodeType), CboItemFilter.SelectedItem.ToString())
            End If

            If CboSearchType.SelectedIndex > 0 Then
                apicall.SearchType = [Enum].Parse(GetType(CategoryListingsSearchCodeType), CboSearchType.SelectedItem.ToString())
            End If

            If CboSort.SelectedIndex > 0 Then
                apicall.OrderBy = [Enum].Parse(GetType(CategoryListingsOrderCodeType), CboSort.SelectedItem.ToString())
            End If


            Dim fnditems As ItemTypeCollection = apicall.GetCategoryListings(TxtCategory.Text)
            Dim fnditem As ItemType

            For Each fnditem In fnditems
                Dim listparams(6) As String

                listparams(0) = fnditem.ItemID

                listparams(1) = fnditem.Title

                listparams(2) = fnditem.SellingStatus.CurrentPrice.Value.ToString()

                listparams(3) = fnditem.SellingStatus.BidCount.ToString()

                listparams(4) = DateTime.Now.ToString()

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstSearchResults.Items.Add(vi)
            Next fnditem


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class
