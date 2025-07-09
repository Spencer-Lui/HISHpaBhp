<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.textID = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.textMsg = New System.Windows.Forms.TextBox()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'textID
        '
        Me.textID.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.textID.Location = New System.Drawing.Point(107, 18)
        Me.textID.Name = "textID"
        Me.textID.Size = New System.Drawing.Size(132, 27)
        Me.textID.TabIndex = 193
        Me.textID.TabStop = False
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(12, 27)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(89, 12)
        Me.label5.TabIndex = 192
        Me.label5.Text = "民眾身分證號："
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(261, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 191
        Me.Button1.Text = "比對"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.textMsg)
        Me.groupBox2.Location = New System.Drawing.Point(14, 64)
        Me.groupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.groupBox2.Size = New System.Drawing.Size(605, 168)
        Me.groupBox2.TabIndex = 190
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "回傳訊息"
        '
        'textMsg
        '
        Me.textMsg.BackColor = System.Drawing.Color.White
        Me.textMsg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textMsg.Location = New System.Drawing.Point(9, 23)
        Me.textMsg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.textMsg.Multiline = True
        Me.textMsg.Name = "textMsg"
        Me.textMsg.ReadOnly = True
        Me.textMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.textMsg.Size = New System.Drawing.Size(587, 137)
        Me.textMsg.TabIndex = 12
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 245)
        Me.Controls.Add(Me.textID)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.groupBox2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textID As TextBox
    Private WithEvents label5 As Label
    Friend WithEvents Button1 As Button
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents textMsg As TextBox
End Class
