namespace SampleApp2;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ContactNamesListBox = new ListBox();
        label1 = new Label();
        ContactIdTextBox = new TextBox();
        label2 = new Label();
        FirstNameTextBox = new TextBox();
        label3 = new Label();
        LastNameTextBox = new TextBox();
        label4 = new Label();
        ContactTitleComboBox = new ComboBox();
        SuspendLayout();
        // 
        // ContactNamesListBox
        // 
        ContactNamesListBox.FormattingEnabled = true;
        ContactNamesListBox.Location = new Point(12, 12);
        ContactNamesListBox.Name = "ContactNamesListBox";
        ContactNamesListBox.Size = new Size(249, 204);
        ContactNamesListBox.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(306, 23);
        label1.Name = "label1";
        label1.Size = new Size(77, 20);
        label1.TabIndex = 2;
        label1.Text = "Contact Id";
        // 
        // ContactIdTextBox
        // 
        ContactIdTextBox.Location = new Point(306, 46);
        ContactIdTextBox.Name = "ContactIdTextBox";
        ContactIdTextBox.ReadOnly = true;
        ContactIdTextBox.Size = new Size(125, 27);
        ContactIdTextBox.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(306, 95);
        label2.Name = "label2";
        label2.Size = new Size(77, 20);
        label2.TabIndex = 4;
        label2.Text = "First name";
        // 
        // FirstNameTextBox
        // 
        FirstNameTextBox.Location = new Point(306, 118);
        FirstNameTextBox.Name = "FirstNameTextBox";
        FirstNameTextBox.Size = new Size(169, 27);
        FirstNameTextBox.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(520, 95);
        label3.Name = "label3";
        label3.Size = new Size(76, 20);
        label3.TabIndex = 6;
        label3.Text = "Last name";
        // 
        // LastNameTextBox
        // 
        LastNameTextBox.Location = new Point(520, 118);
        LastNameTextBox.Name = "LastNameTextBox";
        LastNameTextBox.Size = new Size(190, 27);
        LastNameTextBox.TabIndex = 7;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(740, 95);
        label4.Name = "label4";
        label4.Size = new Size(38, 20);
        label4.TabIndex = 8;
        label4.Text = "Title";
        // 
        // ContactTitleComboBox
        // 
        ContactTitleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ContactTitleComboBox.FormattingEnabled = true;
        ContactTitleComboBox.Location = new Point(740, 118);
        ContactTitleComboBox.Name = "ContactTitleComboBox";
        ContactTitleComboBox.Size = new Size(230, 28);
        ContactTitleComboBox.TabIndex = 10;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(986, 249);
        Controls.Add(ContactTitleComboBox);
        Controls.Add(label4);
        Controls.Add(LastNameTextBox);
        Controls.Add(label3);
        Controls.Add(FirstNameTextBox);
        Controls.Add(label2);
        Controls.Add(ContactIdTextBox);
        Controls.Add(label1);
        Controls.Add(ContactNamesListBox);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "EF Core sample";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private ListBox ContactNamesListBox;
    private Label label1;
    private TextBox ContactIdTextBox;
    private Label label2;
    private TextBox FirstNameTextBox;
    private Label label3;
    private TextBox LastNameTextBox;
    private Label label4;
    private ComboBox ContactTitleComboBox;
}
