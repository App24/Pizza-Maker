Imports System.Drawing.Printing

Public Class PizzaMaker
#Region "Init Variables"
#Region "Prices"
    Dim totalPrice As Decimal
    Dim pizzaPrice As Decimal
#End Region

#Region "Order"
    Dim orders As Order() = {}
    Dim starterIndex As Integer
    Dim pizzaIndex As Integer
#End Region

#Region "Printing"
    Private WithEvents printDocument1 As New PrintDocument()
    Private documentContents, stringToPrint As String
#End Region

#Region "Editing"
    Dim editing As Boolean
    Dim editingIndex As Integer
#End Region

#Region "Misc"
    Dim lbFreeDefaultLocation As Point
#End Region

#End Region

#Region "Control Subroutines"
#Region "Init Form"
    Private Sub PizzaMaker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbFreeDefaultLocation = lblFree.Location

        ppdOrder.Size = New Size(640, 480)
        ppdOrder.PrintPreviewControl.Zoom = 1.5 'Sets zoom in printPreviewOrder to 150%
        ppdOrder.Icon = MyBase.Icon

        editing = False
        totalPrice = 0
        pizzaPrice = 0
        pizzaIndex = -1
        starterIndex = -1

        initClbStarters()
        initClbPizzas()
        initLbOrders()
        initClbToppings()
        updatePizzaPrice()
        updateTotalPrice()

        clbStarters.SelectedItem = Nothing
        clbPizzas.SelectedItem = Nothing
        clbToppings.SelectedItem = Nothing
    End Sub
#End Region

#Region "Starters"
    Private Sub btnStarters_Click(sender As Object, e As EventArgs) Handles btnStarters.Click
        'Only shows clbStarters
        clbPizzas.Hide()
        clbToppings.Hide()
        clbStarters.Show()
    End Sub

    Private Sub clbStarters_allowOne(sender As Object, e As ItemCheckEventArgs) Handles clbStarters.ItemCheck
        Dim clb As CheckedListBox = sender
        onlyAllowOne(sender, e)
        If e.NewValue = CheckState.Checked Then
            Dim drv As DataRowView = clb.Items.Item(e.Index) 'Gets the data of the row inside the DataTable of clbStaters
            pizzaPrice += drv.Row.Field(Of Decimal)("Cost")
        Else
            Dim drv As DataRowView = clb.Items.Item(e.Index)
            pizzaPrice -= drv.Row.Field(Of Decimal)("Cost")
        End If
        If e.NewValue = CheckState.Checked Then
            starterIndex = e.Index
            btnPizzas.Enabled = True
            For Each drv As DataRowView In clbPizzas.CheckedItems
                pizzaPrice += drv.Row.Field(Of Decimal)("Cost")
            Next
            For Each drv As DataRowView In clbToppings.CheckedItems
                pizzaPrice += drv.Row.Field(Of Decimal)("Cost")
            Next
        Else
            btnPizzas.Enabled = False
            btnToppings.Enabled = False
            btnEdit.Enabled = False
            For Each drv As DataRowView In clbPizzas.CheckedItems
                pizzaPrice -= drv.Row.Field(Of Decimal)("Cost")
            Next
            For Each drv As DataRowView In clbToppings.CheckedItems
                pizzaPrice -= drv.Row.Field(Of Decimal)("Cost")
            Next
        End If
        updatePizzaPrice()
    End Sub
#End Region
#Region "Pizzas"
    Private Sub btnPizzas_Click(sender As Object, e As EventArgs) Handles btnPizzas.Click
        clbStarters.Hide()
        clbToppings.Hide()
        clbPizzas.Show()
    End Sub

    Private Sub btnPizzas_EnabledChanged(sender As Object, e As EventArgs) Handles btnPizzas.EnabledChanged
        'When the button becomes enabled or disabled it checks if clbPizzas has at least one item check, if so enables the btnToppings
        If clbPizzas.CheckedItems.Count >= 1 Then
            btnToppings.Enabled = True
        End If
    End Sub

    Private Sub clbPizzas_allowOne(sender As Object, e As ItemCheckEventArgs) Handles clbPizzas.ItemCheck
        Dim clb As CheckedListBox = sender
        onlyAllowOne(sender, e)
        If e.NewValue = CheckState.Checked Then
            Dim drv As DataRowView = clb.Items.Item(e.Index)
            pizzaPrice += drv.Row.Field(Of Decimal)("Cost")
        Else
            Dim drv As DataRowView = clb.Items.Item(e.Index)
            pizzaPrice -= drv.Row.Field(Of Decimal)("Cost")
        End If
        If e.NewValue = CheckState.Checked Then
            pizzaIndex = e.Index
            btnToppings.Enabled = True
            For Each drv As DataRowView In clbToppings.CheckedItems
                pizzaPrice += drv.Row.Field(Of Decimal)("Cost")
            Next
        Else
            btnToppings.Enabled = False
            btnEdit.Enabled = False
            For Each drv As DataRowView In clbToppings.CheckedItems
                pizzaPrice -= drv.Row.Field(Of Decimal)("Cost")
            Next
        End If
        updatePizzaPrice()
    End Sub
#End Region
#Region "Toppings"
    Private Sub btnToppings_Click(sender As Object, e As EventArgs) Handles btnToppings.Click
        clbPizzas.Hide()
        clbStarters.Hide()
        clbToppings.Show()
    End Sub

    Private Sub btnToppings_EnabledChanged(sender As Object, e As EventArgs) Handles btnToppings.EnabledChanged
        'When the button is enabled or disabled it checks if it can enable the editing button when "editing" is true
        If clbToppings.CheckedItems.Count >= 1 Then
            If editing Then
                btnEdit.Enabled = True
            End If
        End If
    End Sub

    Private Sub clbToppings_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbToppings.ItemCheck
        Dim clb As CheckedListBox = sender

        'Since multiple toppings can be picked, it does not require to call allowOne() subroutine

        If e.NewValue = CheckState.Checked Then
            Dim drv As DataRowView = clb.Items.Item(e.Index)
            pizzaPrice += drv.Row.Field(Of Decimal)("Cost")
        Else
            Dim drv As DataRowView = clb.Items.Item(e.Index)
            pizzaPrice -= drv.Row.Field(Of Decimal)("Cost")
        End If

        If e.NewValue = CheckState.Checked Then
            If Not editing Then
                btnAdd.Enabled = True
            End If
            If editing Then
                btnEdit.Enabled = True
            End If
        Else
            If clb.CheckedItems.Count < 2 Then
                btnAdd.Enabled = False
                If editing Then
                    btnEdit.Enabled = False
                End If
            End If
        End If
        updatePizzaPrice()
    End Sub
#End Region

#Region "Add"
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim toppingsIndex As Integer() = getToppingsSelected()
        Dim order As Order = New Order(starterIndex, pizzaIndex, toppingsIndex, pizzaPrice)
        orders.Add(order)
        reset()
        updateListBoxOrders()
        updatePizzaPrice()
    End Sub
#End Region
#Region "Remove"
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        'When list box is empty its selected index is -1
        If lbOrders.SelectedIndex > -1 Then
            Dim drv As DataRowView = lbOrders.SelectedItem
            For Each ddrv As DataRowView In lbOrders.Items
                If ddrv.Row.Field(Of Int32)("Identifier") = drv.Row.Field(Of Int32)("Identifier") Then
                    orders.RemoveAt(drv.Row.Field(Of Int32)("Identifier")) 'Removes the order at index
                    Exit For 'Prevents the removal of the same order, since multiple items in the lbOrders have the same index
                End If
            Next
            updateListBoxOrders()
        End If
    End Sub
#End Region
#Region "Edit"
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim btn As Button = sender 'Converts sender to Button class
        If Not editing Then
            Dim edittingDrv As DataRowView
            edittingDrv = lbOrders.SelectedItem
            editingIndex = edittingDrv.Row.Field(Of Int32)("Identifier")
            Dim order As Order = orders(editingIndex)
            resetSelections()

            clbStarters.SetItemChecked(order.getStarterIndex(), True)
            clbPizzas.SetItemChecked(order.getPizzaIndex(), True)
            For Each i As Integer In order.getToppingsIndexes()
                clbToppings.SetItemChecked(i, True)
            Next

            btnRemove.Enabled = False
            btnAdd.Enabled = False
            btnOrder.Enabled = False
            btn.Enabled = False
            editing = True
            btn.Text = "Finish Editing"
        Else
            Dim toppingsIndex As Integer() = getToppingsSelected()
            orders(editingIndex) = New Order(starterIndex, pizzaIndex, toppingsIndex, pizzaPrice)
            editing = False
            btn.Text = "Edit"
            reset()
        End If
        updateListBoxOrders()
        updatePizzaPrice()
    End Sub
#End Region
#Region "Order"
    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        Dim dialogResult As DialogResult = MessageBox.Show("Do you want to print receipt?", "Printing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If dialogResult = DialogResult.OK Then
            createReceipt()
            ppdOrder.Document = printDocument1
            ppdOrder.ShowDialog() 'Shows printPreviewDocument
        End If
        MessageBox.Show("Successfully Ordered", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region

#Region "Orders"
    Private Sub lbOrders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbOrders.SelectedIndexChanged
        If CType(lbOrders.SelectedItem, DataRowView).Row.Field(Of String)("Name").Contains("----") Then 'Checks if the user has selected the separator
            btnRemove.Enabled = False
            If Not editing Then
                btnEdit.Enabled = False
            End If
        Else
            If Not editing Then
                btnRemove.Enabled = True
            End If
            btnEdit.Enabled = True
        End If
    End Sub

    Private Sub lbOrders_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lbOrders.DrawItem
        If e.Index > -1 Then 'Prevents negative indexes from crashing the program
            e.DrawBackground()

            Dim rectangleBrush As Brush = Brushes.Black
            Dim stringBrush As Brush = Brushes.Black

            'Sets the color of the item's background depending on the index and the reminder when dividing by 3
            If e.Index Mod 3 = 0 Then
                rectangleBrush = Brushes.Red
            ElseIf e.Index Mod 3 = 1 Then
                rectangleBrush = Brushes.LightGreen
            ElseIf e.Index Mod 3 = 2 Then
                rectangleBrush = Brushes.White
            End If

            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                'if item is selected make it appear selected
                rectangleBrush = New SolidBrush(Color.FromArgb(255, 51, 153, 255))
                stringBrush = Brushes.White
            End If

            e.Graphics.FillRectangle(rectangleBrush, e.Bounds)
            e.Graphics.DrawString(CType(lbOrders.Items.Item(e.Index), DataRowView).Row.Field(Of String)("Name"), e.Font, stringBrush, e.Bounds, StringFormat.GenericDefault)

            e.DrawFocusRectangle()
        End If
    End Sub
#End Region

#Region "Menu Strip"
    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Dim helpForm As HelpForm = New HelpForm() 'Creates help form
        helpForm.Show() 'Shows help Form
    End Sub
#End Region

#Region "Printing"
    Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles printDocument1.PrintPage

        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters 
        ' of stringToPrint that will fit within the bounds of the page.
        Dim stringPosition As SizeF = e.Graphics.MeasureString(stringToPrint, Me.Font, e.MarginBounds.Size,
        StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page.
        e.Graphics.DrawString(stringToPrint, Me.Font, Brushes.Black,
        e.MarginBounds, StringFormat.GenericTypographic)

        Dim image As Bitmap = My.Resources.icon
        Dim ratio As Decimal = (image.Width / image.Height)
        Dim width As Decimal = 64 * ratio
        Dim height As Decimal = width / ratio
        e.Graphics.DrawImage(image, e.MarginBounds.Left, e.MarginBounds.Top + stringPosition.Height + 30, width, height)

        ' Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0

        ' If there are no more pages, reset the string to be printed.
        If Not e.HasMorePages Then
            stringToPrint = documentContents
        End If

    End Sub
#End Region

#Region "Misc"
    Private Sub PizzaMaker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Environment.Exit(0) 'Ensures that the application closes when the main form is closed
    End Sub

    Private Sub createTooltip(sender As Object, e As EventArgs) Handles btnStarters.MouseHover, btnPizzas.MouseHover, btnToppings.MouseHover, chkTakeAway.MouseHover, clbStarters.MouseHover, clbPizzas.MouseHover, clbToppings.MouseHover, btnAdd.MouseHover, btnRemove.MouseHover, btnEdit.MouseHover, btnOrder.MouseHover, lbOrders.MouseHover, lblOrderPrice.MouseHover, lblPrice.MouseHover, lblFree.MouseHover, picFree.MouseHover
        Dim tooltip As String = ""
        Select Case CType(sender, Control).Name
            Case btnStarters.Name
                tooltip = "Shows All The Starters Available"
            Case btnPizzas.Name
                tooltip = "Shows All The Pizzas Available"
            Case btnToppings.Name
                tooltip = "Shows All The Toppings Availabe"
            Case chkTakeAway.Name
                tooltip = "Tick If TakeAway, Leave Untick If Eat In"
            Case clbStarters.Name
                tooltip = "Select One Starter"
            Case clbPizzas.Name
                tooltip = "Select One Pizza"
            Case clbToppings.Name
                tooltip = "Select One or More Toppings"
            Case btnAdd.Name
                tooltip = "Click to Add Order to Order List"
            Case btnRemove.Name
                tooltip = "Click to Remove Selected Order From Order List"
            Case btnEdit.Name
                tooltip = "Click to Edit Selected Order"
            Case btnOrder.Name
                tooltip = "Click When Finished Ordering and Ready to Order The Food"
            Case lblOrderPrice.Name
                tooltip = "Shows The Price of The Current Order"
            Case lblPrice.Name
                tooltip = "Shows The Total Price of Your Order"
            Case lbOrders.Name
                tooltip = "Your Orders Will Appear Here"
            Case lblFree.Name
                tooltip = "You Can Get Free Food And Drink Depending On How Much You Spend"
            Case picFree.Name
                tooltip = "You Can Get Free Food And Drink Depending On How Much You Spend"
            Case Else
                tooltip = "NEED TO ADD TOOLTIP"
        End Select
        ttHelp.SetToolTip(CType(sender, Control), tooltip)
    End Sub
#End Region
#End Region

#Region "My Subroutines"
#Region "Init Controls"
    Private Sub initClbStarters()
        Dim dt As New DataTable 'Creates a DataTable
        'And adds DataColumn for easy data handling
        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier",
                                                    .DataType = GetType(Int32),
                                                    .AutoIncrement = True,
                                                    .AutoIncrementStep = 100,
                                                    .AutoIncrementSeed = 100})

        dt.Columns.Add(New DataColumn With {.ColumnName = "ItemName",
                                            .DataType = GetType(String)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "Cost",
                                            .DataType = GetType(Decimal)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "StringCost",
                                            .DataType = GetType(String)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "FullName",
                                            .DataType = GetType(String),
                                            .Expression = "ItemName+' - £'+ISNULL(StringCost, Cost)"})

        'Creates items in the DataTable
        dt.Rows.Add(New Object() {Nothing, "Garlic Bread", 1.5D, "1.50"})
        dt.Rows.Add(New Object() {Nothing, "Fries", 2D})
        dt.Rows.Add(New Object() {Nothing, "Onion Rings", 3D})

        clbStarters.DataSource = dt 'Sets the DataSource to the DataTable just created
        clbStarters.DisplayMember = "FullName" 'Sets the Display Member to be the Column "FullName"
    End Sub

    Private Sub initClbPizzas()
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier",
                                                    .DataType = GetType(Int32),
                                                    .AutoIncrement = True,
                                                    .AutoIncrementStep = 100,
                                                    .AutoIncrementSeed = 100})

        dt.Columns.Add(New DataColumn With {.ColumnName = "ItemName",
                                            .DataType = GetType(String)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "Cost",
                                            .DataType = GetType(Decimal)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "StringCost",
                                            .DataType = GetType(String)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "FullName",
                                            .DataType = GetType(String),
                                            .Expression = "ItemName+' - £'+ISNULL(StringCost, Cost)"})

        dt.Rows.Add(New Object() {Nothing, "Margherita Pizza", 0.99D})
        dt.Rows.Add(New Object() {Nothing, "Mozzarella Pizza", 3.45D})
        dt.Rows.Add(New Object() {Nothing, "Pepperoni Pizza", 5.95D})
        dt.Rows.Add(New Object() {Nothing, "Ham Pizza", 10.99D})
        dt.Rows.Add(New Object() {Nothing, "Hawaiian Pizza", 15.5D, "15.50"})

        clbPizzas.DataSource = dt
        clbPizzas.DisplayMember = "FullName"
    End Sub

    Private Sub initClbToppings()
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier",
                                                    .DataType = GetType(Int32),
                                                    .AutoIncrement = True,
                                                    .AutoIncrementStep = 100,
                                                    .AutoIncrementSeed = 100})

        dt.Columns.Add(New DataColumn With {.ColumnName = "ItemName",
                                            .DataType = GetType(String)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "Cost",
                                            .DataType = GetType(Decimal)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "StringCost",
                                            .DataType = GetType(String)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "FullName",
                                            .DataType = GetType(String),
                                            .Expression = "ItemName+' - £'+ISNULL(StringCost, Cost)"})

        dt.Rows.Add(New Object() {Nothing, "Pepperoni", 1.5D, "1.50"})
        dt.Rows.Add(New Object() {Nothing, "Pineapple", 2D})
        dt.Rows.Add(New Object() {Nothing, "Tuna", 3D})
        dt.Rows.Add(New Object() {Nothing, "Ham", 4D})
        dt.Rows.Add(New Object() {Nothing, "Sausage", 5D})
        dt.Rows.Add(New Object() {Nothing, "Onions", 5.99D})
        dt.Rows.Add(New Object() {Nothing, "Broccoli", 10.5D, "10.50"})
        dt.Rows.Add(New Object() {Nothing, "Jalapeño", 9D})

        clbToppings.DataSource = dt
        clbToppings.DisplayMember = "FullName"
    End Sub

    Private Sub initLbOrders()
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier",
                                                    .DataType = GetType(Int32)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "Starter",
                                                    .DataType = GetType(Int32)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "Pizza",
                                                    .DataType = GetType(Int32)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "Toppings",
                                                    .DataType = GetType(Int32())})

        dt.Columns.Add(New DataColumn With {.ColumnName = "Name",
            .DataType = GetType(String)})

        lbOrders.DataSource = dt
        lbOrders.DisplayMember = "Name"
    End Sub

#End Region

#Region "Updates"
    Private Sub updateTotalPrice()
        lblPrice.Text = "Total Price: £" + totalPrice.ToString("F2")
        lblFree.Location = lbFreeDefaultLocation
        Dim location As Point = lblFree.Location 'Allows for setting position of lblFree
        If totalPrice >= 9 Then
            picFree.Image = My.Resources.drink_bread
            location.Y -= (lblFree.Font.Size * 2) - 5
            lblFree.Text = "You get a free drink and a free portion of garlic bread"
        ElseIf totalPrice >= 7 Then
            picFree.Image = My.Resources.drink
            location.Y -= (lblFree.Font.Size * 1) - 10
            lblFree.Text = "You get a free drink"
        Else
            picFree.Image = Nothing
            location.Y -= (lblFree.Font.Size * 2) - 5
            lblFree.Text = "£7=free drink" & vbCrLf & "£9=free garlic bread"
        End If
        lblFree.Location = location
    End Sub

    Private Sub updateListBoxOrders()
        Dim data As DataTable = CType(lbOrders.DataSource, DataTable).Clone() 'Copies the structure of the DataTable stored in lbOrders, but does not copy the data
        'Done to prevent a crash occuring

        Dim selectedIndex = lbOrders.SelectedIndex
        Dim index As Integer = 0
        totalPrice = 0

        'Sets up the data in DataTable using the orders Array
        For Each order As Order In orders
            Dim starterDrv As DataRowView = clbStarters.Items.Item(order.getStarterIndex())
            Dim pizzaDrv As DataRowView = clbPizzas.Items.Item(order.getPizzaIndex())
            data.Rows.Add(New Object() {index, order.getStarterIndex(), order.getPizzaIndex(), order.getToppingsIndexes(), starterDrv.Row.Field(Of String)("FullName")})
            data.Rows.Add(New Object() {index, order.getStarterIndex(), order.getPizzaIndex(), order.getToppingsIndexes(), pizzaDrv.Row.Field(Of String)("FullName")})
            For Each toppingsIndex As Integer In order.getToppingsIndexes()
                Dim toppingsDrv As DataRowView = clbToppings.Items.Item(toppingsIndex)
                data.Rows.Add(New Object() {index, order.getStarterIndex(), order.getPizzaIndex(), order.getToppingsIndexes(), toppingsDrv.Row.Field(Of String)("FullName")})
            Next
            data.Rows.Add(New Object() {index, order.getStarterIndex(), order.getPizzaIndex(), order.getToppingsIndexes(), "------------------------------------------------------------"})
            index += 1
            totalPrice += order.getPrice()
        Next
        lbOrders.DataSource = data

        'Prevents selectedIndex being below 0 and above the item count of lbOrders
        If selectedIndex < 0 Then
            selectedIndex = 0
        End If
        If selectedIndex > lbOrders.Items.Count - 1 Then
            selectedIndex = lbOrders.Items.Count - 1
        End If
        lbOrders.SelectedIndex = selectedIndex

        If lbOrders.Items.Count > 0 Then
            If Not CType(lbOrders.SelectedItem, DataRowView).Row.Field(Of String)("Name").Contains("-----------") Then
                If Not editing Then
                    btnRemove.Enabled = True
                    btnOrder.Enabled = True
                End If
                btnEdit.Enabled = True
            End If
        Else
            btnRemove.Enabled = False
            btnEdit.Enabled = False
            btnOrder.Enabled = False
        End If
        updateTotalPrice()
    End Sub

    Private Sub updatePizzaPrice()
        lblOrderPrice.Text = "Order Price: £" + pizzaPrice.ToString("F2")
    End Sub
#End Region

#Region "Resets"
    Private Sub resetSelections()
        'Used to reset every checkedListBox
        For i As Integer = 0 To clbStarters.Items.Count - 1
            If clbStarters.GetItemChecked(i) Then
                clbStarters.SetItemChecked(i, False)
            End If
        Next
        For i As Integer = 0 To clbPizzas.Items.Count - 1
            If clbPizzas.GetItemChecked(i) Then
                clbPizzas.SetItemChecked(i, False)
            End If
        Next
        For i As Integer = 0 To clbToppings.Items.Count - 1
            If clbToppings.GetItemChecked(i) Then
                clbToppings.SetItemChecked(i, False)
            End If
        Next
        clbStarters.SelectedItem = Nothing
        clbPizzas.SelectedItem = Nothing
        clbToppings.SelectedItem = Nothing
    End Sub

    Private Sub reset()
        'Resets the program to allow for more orders to be entered
        resetSelections()
        clbPizzas.Hide()
        clbToppings.Hide()
        clbStarters.Show()
        pizzaPrice = 0
    End Sub
#End Region

#Region "Printing"
    Private Sub createReceipt()
        'Sets up the receipt
        printDocument1.DocumentName = "Order"
        Dim rand As Random = New Random()
        Dim id As Integer = rand.Next(999999)
        documentContents = "Receipt Number: " + id.ToString() & vbCrLf
        documentContents += vbCrLf & If(chkTakeAway.Checked = True, "Take Away", "Eat In") & vbCrLf & vbCrLf
        documentContents += "Order:" & vbCrLf
        'Puts all the data in the orders array into a string
        For Each order As Order In orders
            Dim starterDrv As DataRowView = clbStarters.Items.Item(order.getStarterIndex())
            Dim pizzaDrv As DataRowView = clbPizzas.Items.Item(order.getPizzaIndex())

            Dim starter As String = starterDrv.Row.Field(Of String)("FullName")
            Dim pizza As String = pizzaDrv.Row.Field(Of String)("FullName")
            Dim toppings As String = ""

            For Each i As Integer In order.getToppingsIndexes()
                Dim toppingDrv As DataRowView = clbToppings.Items.Item(i)
                toppings += toppingDrv.Row.Field(Of String)("FullName") & vbCrLf
            Next
            documentContents += starter & vbCrLf & pizza & vbCrLf & toppings & "-----------------------------------------------" & vbCrLf
        Next

        If totalPrice >= 7 Then
            documentContents += "Free Drink" & vbCrLf
        End If
        If totalPrice >= 9 Then
            documentContents += "Free Portion Of Garlic Bread" & vbCrLf
        End If

        documentContents += vbCrLf & "Total Price: £" + totalPrice.ToString("F2") & vbCrLf & vbCrLf
        documentContents += "Thank you for choosing us"
        stringToPrint = documentContents
    End Sub
#End Region

#Region "Misc"
    Private Function getToppingsSelected()
        'Returns all the checked boxes that are checked in the checkedListBox
        Dim toppingsIndex As Integer() = {}
        For i As Integer = 0 To clbToppings.Items.Count - 1
            If clbToppings.GetItemChecked(i) Then
                toppingsIndex.Add(i)
            End If
        Next
        Return toppingsIndex
    End Function

    Private Sub onlyAllowOne(sender As Object, e As ItemCheckEventArgs)
        Dim clb As CheckedListBox = sender
        'Prevents more than one check box being ticked in a checkedListBox
        If clb.CheckedItems.Count >= 1 And e.CurrentValue <> CheckState.Checked Then
            For i As Integer = 0 To clb.Items.Count - 1
                If i <> e.Index Then
                    clb.SetItemChecked(i, False)
                End If
            Next
        End If
    End Sub
#End Region
#End Region
End Class
