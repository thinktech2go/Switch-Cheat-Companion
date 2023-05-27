<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        TextBox1 = New TextBox()
        Button1 = New Button()
        ListBox1 = New ListBox()
        ComboBox1 = New ComboBox()
        TextBox2 = New TextBox()
        ListBox2 = New ListBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        ListBox3 = New ListBox()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        TextBox3 = New TextBox()
        CheckBox1 = New CheckBox()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = SystemColors.Menu
        TextBox1.Location = New Point(98, 445)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(172, 23)
        TextBox1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(17, 444)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 25)
        Button1.TabIndex = 1
        Button1.Text = "Search"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.BackColor = SystemColors.Menu
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(359, 416)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(320, 154)
        ListBox1.TabIndex = 2
        ' 
        ' ComboBox1
        ' 
        ComboBox1.BackColor = SystemColors.Menu
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(98, 507)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(243, 23)
        ComboBox1.TabIndex = 3
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = SystemColors.Menu
        TextBox2.Location = New Point(98, 476)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(243, 23)
        TextBox2.TabIndex = 4
        ' 
        ' ListBox2
        ' 
        ListBox2.BackColor = SystemColors.Menu
        ListBox2.FormattingEnabled = True
        ListBox2.ItemHeight = 15
        ListBox2.Location = New Point(18, 42)
        ListBox2.Name = "ListBox2"
        ListBox2.SelectionMode = SelectionMode.MultiExtended
        ListBox2.Size = New Size(320, 364)
        ListBox2.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.FlatStyle = FlatStyle.Popup
        Label2.Location = New Point(10, 435)
        Label2.Name = "Label2"
        Label2.Size = New Size(338, 110)
        Label2.TabIndex = 8
        Label2.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(51, 481)
        Label3.Name = "Label3"
        Label3.Size = New Size(40, 15)
        Label3.TabIndex = 9
        Label3.Text = "TitleID"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(47, 511)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 15)
        Label4.TabIndex = 10
        Label4.Text = "BuildID"
        ' 
        ' ListBox3
        ' 
        ListBox3.BackColor = SystemColors.Menu
        ListBox3.FormattingEnabled = True
        ListBox3.ItemHeight = 15
        ListBox3.Location = New Point(360, 39)
        ListBox3.Name = "ListBox3"
        ListBox3.SelectionMode = SelectionMode.MultiExtended
        ListBox3.Size = New Size(320, 364)
        ListBox3.TabIndex = 11
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(13, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 12
        Button2.Text = "Open"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Image = My.Resources.Resources.right_arrow
        Button3.Location = New Point(266, 5)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 13
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Image = My.Resources.Resources.close__2_
        Button4.Location = New Point(360, 6)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 23)
        Button4.TabIndex = 14
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(604, 6)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 23)
        Button5.TabIndex = 15
        Button5.Text = "Export"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(12, 558)
        Button6.Name = "Button6"
        Button6.Size = New Size(75, 23)
        Button6.TabIndex = 16
        Button6.Text = "Credits"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Image = My.Resources.Resources.up_arrow
        Button7.Location = New Point(278, 444)
        Button7.Name = "Button7"
        Button7.Size = New Size(63, 25)
        Button7.TabIndex = 17
        Button7.UseVisualStyleBackColor = True
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(91, 609)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(100, 23)
        TextBox3.TabIndex = 18
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(51, 407)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(245, 19)
        CheckBox1.TabIndex = 19
        CheckBox1.Text = "Dont clear this list when importing cheats"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.BorderStyle = BorderStyle.Fixed3D
        Label1.Location = New Point(10, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(338, 394)
        Label1.TabIndex = 20
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ScrollBar
        ClientSize = New Size(694, 589)
        Controls.Add(ListBox2)
        Controls.Add(Button7)
        Controls.Add(CheckBox1)
        Controls.Add(Button2)
        Controls.Add(Label1)
        Controls.Add(TextBox3)
        Controls.Add(ListBox3)
        Controls.Add(ListBox1)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(TextBox2)
        Controls.Add(ComboBox1)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ListBox3 As ListBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label1 As Label
End Class
