<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PizzaMaker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PizzaMaker))
        Me.clbStarters = New System.Windows.Forms.CheckedListBox()
        Me.clbPizzas = New System.Windows.Forms.CheckedListBox()
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.clbToppings = New System.Windows.Forms.CheckedListBox()
        Me.chkTakeAway = New System.Windows.Forms.CheckBox()
        Me.lblOrderPrice = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lbOrders = New System.Windows.Forms.ListBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblFree = New System.Windows.Forms.Label()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.lblOrders = New System.Windows.Forms.Label()
        Me.ppdOrder = New System.Windows.Forms.PrintPreviewDialog()
        Me.btnOrder = New System.Windows.Forms.Button()
        Me.picFree = New System.Windows.Forms.PictureBox()
        Me.btnToppings = New System.Windows.Forms.Button()
        Me.btnStarters = New System.Windows.Forms.Button()
        Me.btnPizzas = New System.Windows.Forms.Button()
        Me.ttHelp = New System.Windows.Forms.ToolTip(Me.components)
        Me.menuStrip.SuspendLayout()
        CType(Me.picFree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'clbStarters
        '
        Me.clbStarters.BackColor = System.Drawing.Color.Red
        Me.clbStarters.CheckOnClick = True
        Me.clbStarters.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbStarters.FormattingEnabled = True
        Me.clbStarters.Items.AddRange(New Object() {"Starter 1", "Starter 2", "Starter 3"})
        Me.clbStarters.Location = New System.Drawing.Point(236, 27)
        Me.clbStarters.Name = "clbStarters"
        Me.clbStarters.Size = New System.Drawing.Size(363, 361)
        Me.clbStarters.TabIndex = 1
        '
        'clbPizzas
        '
        Me.clbPizzas.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.clbPizzas.CheckOnClick = True
        Me.clbPizzas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbPizzas.FormattingEnabled = True
        Me.clbPizzas.Items.AddRange(New Object() {"Pizza 1", "Pizza 2", "Pizza 3", "Pizza 4", "Pizza 5"})
        Me.clbPizzas.Location = New System.Drawing.Point(236, 27)
        Me.clbPizzas.Name = "clbPizzas"
        Me.clbPizzas.Size = New System.Drawing.Size(363, 361)
        Me.clbPizzas.TabIndex = 3
        Me.clbPizzas.Visible = False
        '
        'menuStrip
        '
        Me.menuStrip.BackColor = System.Drawing.SystemColors.Control
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(1088, 24)
        Me.menuStrip.TabIndex = 16
        Me.menuStrip.Text = "MenuStrip1"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'clbToppings
        '
        Me.clbToppings.CheckOnClick = True
        Me.clbToppings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbToppings.FormattingEnabled = True
        Me.clbToppings.Items.AddRange(New Object() {"Toppings 1", "Toppings 2", "Toppings 3", "Toppings 4"})
        Me.clbToppings.Location = New System.Drawing.Point(236, 27)
        Me.clbToppings.Name = "clbToppings"
        Me.clbToppings.Size = New System.Drawing.Size(363, 361)
        Me.clbToppings.TabIndex = 5
        Me.clbToppings.Visible = False
        '
        'chkTakeAway
        '
        Me.chkTakeAway.AutoSize = True
        Me.chkTakeAway.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTakeAway.Location = New System.Drawing.Point(12, 421)
        Me.chkTakeAway.Name = "chkTakeAway"
        Me.chkTakeAway.Size = New System.Drawing.Size(108, 24)
        Me.chkTakeAway.TabIndex = 7
        Me.chkTakeAway.Text = "Takeaway?"
        Me.chkTakeAway.UseVisualStyleBackColor = True
        '
        'lblOrderPrice
        '
        Me.lblOrderPrice.AutoSize = True
        Me.lblOrderPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderPrice.Location = New System.Drawing.Point(232, 391)
        Me.lblOrderPrice.Name = "lblOrderPrice"
        Me.lblOrderPrice.Size = New System.Drawing.Size(84, 20)
        Me.lblOrderPrice.TabIndex = 6
        Me.lblOrderPrice.Text = "order price"
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(179, 471)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(125, 48)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add To Order"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lbOrders
        '
        Me.lbOrders.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lbOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOrders.FormattingEnabled = True
        Me.lbOrders.ItemHeight = 20
        Me.lbOrders.Location = New System.Drawing.Point(605, 27)
        Me.lbOrders.Name = "lbOrders"
        Me.lbOrders.Size = New System.Drawing.Size(257, 324)
        Me.lbOrders.TabIndex = 13
        '
        'lblPrice
        '
        Me.lblPrice.BackColor = System.Drawing.SystemColors.Window
        Me.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(605, 350)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(257, 37)
        Me.lblPrice.TabIndex = 14
        Me.lblPrice.Text = "total price"
        Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFree
        '
        Me.lblFree.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFree.Location = New System.Drawing.Point(868, 128)
        Me.lblFree.Name = "lblFree"
        Me.lblFree.Size = New System.Drawing.Size(208, 308)
        Me.lblFree.TabIndex = 15
        Me.lblFree.Text = "free food"
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(310, 471)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(118, 48)
        Me.btnRemove.TabIndex = 9
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(438, 471)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(118, 48)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'lblOrders
        '
        Me.lblOrders.AutoSize = True
        Me.lblOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrders.Location = New System.Drawing.Point(601, 3)
        Me.lblOrders.Name = "lblOrders"
        Me.lblOrders.Size = New System.Drawing.Size(57, 20)
        Me.lblOrders.TabIndex = 12
        Me.lblOrders.Text = "Orders"
        '
        'ppdOrder
        '
        Me.ppdOrder.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdOrder.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdOrder.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdOrder.Enabled = True
        Me.ppdOrder.Icon = CType(resources.GetObject("ppdOrder.Icon"), System.Drawing.Icon)
        Me.ppdOrder.Name = "PrintPreviewDialog1"
        Me.ppdOrder.UseAntiAlias = True
        Me.ppdOrder.Visible = False
        '
        'btnOrder
        '
        Me.btnOrder.Enabled = False
        Me.btnOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrder.Location = New System.Drawing.Point(563, 471)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(107, 48)
        Me.btnOrder.TabIndex = 11
        Me.btnOrder.Text = "Order"
        Me.btnOrder.UseVisualStyleBackColor = True
        '
        'picFree
        '
        Me.picFree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFree.Location = New System.Drawing.Point(868, 151)
        Me.picFree.Name = "picFree"
        Me.picFree.Size = New System.Drawing.Size(208, 237)
        Me.picFree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picFree.TabIndex = 12
        Me.picFree.TabStop = False
        '
        'btnToppings
        '
        Me.btnToppings.Enabled = False
        Me.btnToppings.Image = Global.Pizza_Maker.My.Resources.Resources.toppings
        Me.btnToppings.Location = New System.Drawing.Point(12, 275)
        Me.btnToppings.Name = "btnToppings"
        Me.btnToppings.Size = New System.Drawing.Size(192, 118)
        Me.btnToppings.TabIndex = 4
        Me.btnToppings.UseVisualStyleBackColor = True
        '
        'btnStarters
        '
        Me.btnStarters.Image = Global.Pizza_Maker.My.Resources.Resources.starters
        Me.btnStarters.Location = New System.Drawing.Point(12, 27)
        Me.btnStarters.Name = "btnStarters"
        Me.btnStarters.Size = New System.Drawing.Size(192, 118)
        Me.btnStarters.TabIndex = 0
        Me.btnStarters.UseVisualStyleBackColor = True
        '
        'btnPizzas
        '
        Me.btnPizzas.Enabled = False
        Me.btnPizzas.Image = Global.Pizza_Maker.My.Resources.Resources.pizza
        Me.btnPizzas.Location = New System.Drawing.Point(12, 151)
        Me.btnPizzas.Name = "btnPizzas"
        Me.btnPizzas.Size = New System.Drawing.Size(192, 118)
        Me.btnPizzas.TabIndex = 2
        Me.btnPizzas.UseVisualStyleBackColor = True
        '
        'PizzaMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 536)
        Me.Controls.Add(Me.btnOrder)
        Me.Controls.Add(Me.lblOrders)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.picFree)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.lbOrders)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblOrderPrice)
        Me.Controls.Add(Me.chkTakeAway)
        Me.Controls.Add(Me.clbToppings)
        Me.Controls.Add(Me.btnToppings)
        Me.Controls.Add(Me.clbPizzas)
        Me.Controls.Add(Me.btnStarters)
        Me.Controls.Add(Me.btnPizzas)
        Me.Controls.Add(Me.clbStarters)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.lblFree)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "PizzaMaker"
        Me.Text = "Pizza Maker"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        CType(Me.picFree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents clbStarters As CheckedListBox
    Friend WithEvents btnPizzas As Button
    Friend WithEvents btnStarters As Button
    Friend WithEvents clbPizzas As CheckedListBox
    Friend WithEvents menuStrip As MenuStrip
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnToppings As Button
    Friend WithEvents clbToppings As CheckedListBox
    Friend WithEvents chkTakeAway As CheckBox
    Friend WithEvents lblOrderPrice As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents lbOrders As ListBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents picFree As PictureBox
    Friend WithEvents lblFree As Label
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents lblOrders As Label
    Friend WithEvents ppdOrder As PrintPreviewDialog
    Friend WithEvents btnOrder As Button
    Friend WithEvents ttHelp As ToolTip
End Class
