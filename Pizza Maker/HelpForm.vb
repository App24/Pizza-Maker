Public Class HelpForm
    Dim page As Integer = 0
    Dim maxPage As Integer = 1

    Private Sub HelpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setPage()
        lblHelp.Text = "1. Starters Button" & vbCrLf & "2. Pizzas Button
" + "3. Toppings Button" & vbCrLf & "4. This will display the starters, pizzas or toppings depending on what button you pressed
" + "5. This will display the total pizza price" & vbCrLf & "6. Check this if its takeaway else dont tick it
" + "7. When satisfied with your pizza, press this to add it to the order" & vbCrLf & "8. Remove the selected item in the order list
" + "9. Edit the order you have selected on the order list" & vbCrLf & "10. Order your order when you finished
" + "11. This is the order list" & vbCrLf & "12. Displays the total price of your order
" + "13. This will tell you if you got any free drink or food" & vbCrLf & "14. Display the image of your free food or drink
" + "15. This will lead you to this window"
    End Sub

    Private Sub setPage()
        lblPage.Text = "Page: " + (page + 1).ToString() + "/" + (maxPage + 1).ToString()

        Select Case page
            Case 0
                picHelp.Visible = True
                lblHelp.Visible = False
            Case 1
                picHelp.Visible = False
                lblHelp.Visible = True
        End Select
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        page -= 1
        If page < 0 Then
            page = maxPage
        End If
        setPage()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        page += 1
        If page > maxPage Then
            page = 0
        End If
        setPage()
    End Sub

    Private Sub Help_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        page = 0
    End Sub

    Private Sub createTooltip(sender As Object, e As EventArgs) Handles picHelp.MouseHover, btnNext.MouseHover, btnPrevious.MouseHover, lblHelp.MouseHover, lblPage.MouseHover
        Dim tooltip As String = ""
        Select Case CType(sender, Control).Name
            Case picHelp.Name
                tooltip = "Image With Numbers"
            Case lblPage.Name
                tooltip = "Shows What Page You Are In"
            Case lblHelp.Name
                tooltip = "Tells Which Number Correlates With What"
            Case btnPrevious.Name
                tooltip = "Go To Previous Page"
            Case btnNext.Name
                tooltip = "Go To Next Page"
            Case Else
                tooltip = "NEED TO ADD TOOLTIP"
        End Select
        ttpHelp.SetToolTip(CType(sender, Control), tooltip)
    End Sub
End Class