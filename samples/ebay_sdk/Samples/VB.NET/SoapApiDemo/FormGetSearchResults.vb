Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetSearchResults
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

		Friend WithEvents BtnGetSearchResults As System.Windows.Forms.Button 

		Friend WithEvents TxtQuery As System.Windows.Forms.TextBox 

		Friend WithEvents ChkSearchDescription As System.Windows.Forms.CheckBox 

		Friend WithEvents LblQuery As System.Windows.Forms.Label 

		Friend WithEvents TxtPriceFrom As System.Windows.Forms.TextBox 

		Friend WithEvents TxtPriceTo As System.Windows.Forms.TextBox 

		Friend WithEvents LblPriceRange As System.Windows.Forms.Label 

		Friend WithEvents LblPriceSep As System.Windows.Forms.Label 

		Friend WithEvents LblCategory As System.Windows.Forms.Label 

		Friend WithEvents TxtCategory As System.Windows.Forms.TextBox 

		Friend WithEvents ChkPayPal As System.Windows.Forms.CheckBox 

		Friend WithEvents CboSort  As System.Windows.Forms.ComboBox 

		Friend WithEvents LblSort As System.Windows.Forms.Label 

		Friend WithEvents LstSearchResults As System.Windows.Forms.ListView 

		Friend WithEvents LblSearchResults As System.Windows.Forms.Label 

		Friend WithEvents ClmTimeLeft As System.Windows.Forms.ColumnHeader 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblSearchResults = New System.Windows.Forms.Label()
        Me.LstSearchResults = New System.Windows.Forms.ListView()
        Me.ClmItemId = New System.Windows.Forms.ColumnHeader()
        Me.ClmTitle = New System.Windows.Forms.ColumnHeader()
        Me.ClmPrice = New System.Windows.Forms.ColumnHeader()
        Me.ClmBids = New System.Windows.Forms.ColumnHeader()
        Me.ClmTimeLeft = New System.Windows.Forms.ColumnHeader()
        Me.BtnGetSearchResults = New System.Windows.Forms.Button()
        Me.TxtQuery = New System.Windows.Forms.TextBox()
        Me.ChkSearchDescription = New System.Windows.Forms.CheckBox()
        Me.LblQuery = New System.Windows.Forms.Label()
        Me.TxtPriceFrom = New System.Windows.Forms.TextBox()
        Me.TxtPriceTo = New System.Windows.Forms.TextBox()
        Me.LblPriceRange = New System.Windows.Forms.Label()
        Me.LblPriceSep = New System.Windows.Forms.Label()
        Me.LblCategory = New System.Windows.Forms.Label()
        Me.TxtCategory = New System.Windows.Forms.TextBox()
        Me.ChkPayPal = New System.Windows.Forms.CheckBox()
        Me.CboSort = New System.Windows.Forms.ComboBox()
        Me.LblSort = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblSearchResults, Me.LstSearchResults})
        Me.GrpResult.Location = New System.Drawing.Point(8, 200)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(456, 296)
        Me.GrpResult.TabIndex = 24
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Results"
        '
        'LblSearchResults
        '
        Me.LblSearchResults.Location = New System.Drawing.Point(16, 24)
        Me.LblSearchResults.Name = "LblSearchResults"
        Me.LblSearchResults.Size = New System.Drawing.Size(112, 23)
        Me.LblSearchResults.TabIndex = 15
        Me.LblSearchResults.Text = "Items Found:"
        '
        'LstSearchResults
        '
        Me.LstSearchResults.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)
        Me.LstSearchResults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmItemId, Me.ClmTitle, Me.ClmPrice, Me.ClmBids, Me.ClmTimeLeft})
        Me.LstSearchResults.GridLines = True
        Me.LstSearchResults.Location = New System.Drawing.Point(8, 48)
        Me.LstSearchResults.Name = "LstSearchResults"
        Me.LstSearchResults.Size = New System.Drawing.Size(440, 232)
        Me.LstSearchResults.TabIndex = 4
        Me.LstSearchResults.View = System.Windows.Forms.View.Details
        '
        'ClmItemId
        '
        Me.ClmItemId.Text = "ItemId"
        Me.ClmItemId.Width = 80
        '
        'ClmTitle
        '
        Me.ClmTitle.Text = "Title"
        Me.ClmTitle.Width = 173
        '
        'ClmPrice
        '
        Me.ClmPrice.Text = "Price"
        '
        'ClmBids
        '
        Me.ClmBids.Text = "Bids"
        Me.ClmBids.Width = 39
        '
        'ClmTimeLeft
        '
        Me.ClmTimeLeft.Text = "TimeLeft"
        '
        'BtnGetSearchResults
        '
        Me.BtnGetSearchResults.Location = New System.Drawing.Point(176, 168)
        Me.BtnGetSearchResults.Name = "BtnGetSearchResults"
        Me.BtnGetSearchResults.Size = New System.Drawing.Size(128, 23)
        Me.BtnGetSearchResults.TabIndex = 23
        Me.BtnGetSearchResults.Text = "GetSearchResults"
        '
        'TxtQuery
        '
        Me.TxtQuery.Location = New System.Drawing.Point(96, 16)
        Me.TxtQuery.Name = "TxtQuery"
        Me.TxtQuery.Size = New System.Drawing.Size(240, 20)
        Me.TxtQuery.TabIndex = 70
        Me.TxtQuery.Text = ""
        '
        'ChkSearchDescription
        '
        Me.ChkSearchDescription.Location = New System.Drawing.Point(96, 40)
        Me.ChkSearchDescription.Name = "ChkSearchDescription"
        Me.ChkSearchDescription.Size = New System.Drawing.Size(152, 24)
        Me.ChkSearchDescription.TabIndex = 71
        Me.ChkSearchDescription.Text = "Search In Description"
        '
        'LblQuery
        '
        Me.LblQuery.Location = New System.Drawing.Point(16, 16)
        Me.LblQuery.Name = "LblQuery"
        Me.LblQuery.Size = New System.Drawing.Size(80, 16)
        Me.LblQuery.TabIndex = 72
        Me.LblQuery.Text = "Search Term:"
        '
        'TxtPriceFrom
        '
        Me.TxtPriceFrom.Location = New System.Drawing.Point(96, 64)
        Me.TxtPriceFrom.Name = "TxtPriceFrom"
        Me.TxtPriceFrom.TabIndex = 73
        Me.TxtPriceFrom.Text = ""
        '
        'TxtPriceTo
        '
        Me.TxtPriceTo.Location = New System.Drawing.Point(216, 64)
        Me.TxtPriceTo.Name = "TxtPriceTo"
        Me.TxtPriceTo.TabIndex = 74
        Me.TxtPriceTo.Text = ""
        '
        'LblPriceRange
        '
        Me.LblPriceRange.Location = New System.Drawing.Point(16, 64)
        Me.LblPriceRange.Name = "LblPriceRange"
        Me.LblPriceRange.Size = New System.Drawing.Size(80, 23)
        Me.LblPriceRange.TabIndex = 75
        Me.LblPriceRange.Text = "Price Range:"
        '
        'LblPriceSep
        '
        Me.LblPriceSep.Location = New System.Drawing.Point(200, 64)
        Me.LblPriceSep.Name = "LblPriceSep"
        Me.LblPriceSep.Size = New System.Drawing.Size(8, 23)
        Me.LblPriceSep.TabIndex = 76
        Me.LblPriceSep.Text = "-"
        '
        'LblCategory
        '
        Me.LblCategory.Location = New System.Drawing.Point(16, 88)
        Me.LblCategory.Name = "LblCategory"
        Me.LblCategory.Size = New System.Drawing.Size(80, 23)
        Me.LblCategory.TabIndex = 78
        Me.LblCategory.Text = "Category:"
        '
        'TxtCategory
        '
        Me.TxtCategory.Location = New System.Drawing.Point(96, 88)
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.TabIndex = 77
        Me.TxtCategory.Text = ""
        '
        'ChkPayPal
        '
        Me.ChkPayPal.Location = New System.Drawing.Point(96, 112)
        Me.ChkPayPal.Name = "ChkPayPal"
        Me.ChkPayPal.Size = New System.Drawing.Size(120, 24)
        Me.ChkPayPal.TabIndex = 79
        Me.ChkPayPal.Text = "Pay Pal Accepted"
        '
        'CboSort
        '
        Me.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSort.Location = New System.Drawing.Point(96, 136)
        Me.CboSort.Name = "CboSort"
        Me.CboSort.Size = New System.Drawing.Size(136, 21)
        Me.CboSort.TabIndex = 81
        '
        'LblSort
        '
        Me.LblSort.Location = New System.Drawing.Point(32, 136)
        Me.LblSort.Name = "LblSort"
        Me.LblSort.Size = New System.Drawing.Size(64, 18)
        Me.LblSort.TabIndex = 80
        Me.LblSort.Text = "Sort:"
        '
        'FormGetSearchResults
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(472, 501)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CboSort, Me.LblSort, Me.ChkPayPal, Me.LblCategory, Me.TxtCategory, Me.LblPriceSep, Me.LblPriceRange, Me.TxtPriceTo, Me.TxtPriceFrom, Me.LblQuery, Me.ChkSearchDescription, Me.TxtQuery, Me.GrpResult, Me.BtnGetSearchResults})
        Me.Name = "FormGetSearchResults"
        Me.Text = "GetSearchResults"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

		Private Sub  FrmGetSearchResults_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		

        Dim s() As String = [Enum].GetNames(GetType(SearchSortOrderCodeType))
			Dim item As String

			For Each item in s
				If item <> "CustomCode" Then

					CboSort.Items.Add(item)

				End If
			Next item



			CboSort.SelectedIndex = 0

		End Sub



		Private Sub  BtnGetSearchResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetSearchResults.Click

		Try
			
				LstSearchResults.Items.Clear()

				Dim apicall As GetSearchResultsCall = new GetSearchResultsCall(Context)

            If ChkSearchDescription.Checked Or ChkPayPal.Checked Then
                apicall.SearchFlagsList = New SearchFlagsCodeTypeCollection()
            End If

            If ChkSearchDescription.Checked Then
                apicall.SearchFlagsList.Add(SearchFlagsCodeType.SearchInDescription)
            End If


            If ChkPayPal.Checked Then

                apicall.SearchFlagsList.Add(SearchFlagsCodeType.PayPalBuyerPaymentOption)

            End If

            If TxtPriceFrom.Text.Length > 0 And TxtPriceTo.Text.Length > 0 Then

                apicall.PriceRangeFilter = New PriceRangeFilterType()

                apicall.PriceRangeFilter.MinPrice = New AmountType()

                apicall.PriceRangeFilter.MaxPrice = New AmountType()

                apicall.PriceRangeFilter.MinPrice.Value = Convert.ToDouble(TxtPriceFrom.Text)

                apicall.PriceRangeFilter.MaxPrice.Value = Convert.ToDouble(TxtPriceTo.Text)

            End If



            apicall.CategoryID = TxtCategory.Text

            apicall.Order = [Enum].Parse(GetType(SearchSortOrderCodeType), CboSort.SelectedItem.ToString())

            Dim fnditems As SearchResultItemTypeCollection = apicall.GetSearchResults(TxtQuery.Text)
            Dim fnditem As SearchResultItemType

            For Each fnditem In fnditems
                Dim listparams(5) As String

                listparams(0) = fnditem.Item.ItemID

                listparams(1) = fnditem.Item.Title

                listparams(2) = fnditem.Item.SellingStatus.CurrentPrice.Value.ToString()

                listparams(3) = fnditem.Item.SellingStatus.BidCount.ToString()

                listparams(4) = DateTime.Now.ToString()


                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstSearchResults.Items.Add(vi)
            Next fnditem



        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class


