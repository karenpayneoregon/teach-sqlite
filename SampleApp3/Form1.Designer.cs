namespace SampleApp3;

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
        contactsDataGridView = new DataGridView();
        panel1 = new Panel();
        firstNameTextBox = new TextBox();
        CurrentContactButton = new Button();
        ContactTypeComboBoxColumn = new DataGridViewComboBoxColumn();
        FirstNameColumn = new DataGridViewTextBoxColumn();
        LastNameColumn = new DataGridViewTextBoxColumn();
        PhoneColumn = new DataGridViewTextBoxColumn();
        DeviceTypeColumn = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)contactsDataGridView).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // contactsDataGridView
        // 
        contactsDataGridView.AllowUserToAddRows = false;
        contactsDataGridView.AllowUserToDeleteRows = false;
        contactsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        contactsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ContactTypeComboBoxColumn, FirstNameColumn, LastNameColumn, PhoneColumn, DeviceTypeColumn });
        contactsDataGridView.Dock = DockStyle.Fill;
        contactsDataGridView.Location = new Point(0, 0);
        contactsDataGridView.Name = "contactsDataGridView";
        contactsDataGridView.RowHeadersWidth = 51;
        contactsDataGridView.Size = new Size(800, 509);
        contactsDataGridView.TabIndex = 1;
        // 
        // panel1
        // 
        panel1.Controls.Add(firstNameTextBox);
        panel1.Controls.Add(CurrentContactButton);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 509);
        panel1.Name = "panel1";
        panel1.Size = new Size(800, 78);
        panel1.TabIndex = 2;
        // 
        // firstNameTextBox
        // 
        firstNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        firstNameTextBox.Location = new Point(548, 17);
        firstNameTextBox.Name = "firstNameTextBox";
        firstNameTextBox.PlaceholderText = "Incremental filter";
        firstNameTextBox.Size = new Size(225, 27);
        firstNameTextBox.TabIndex = 2;
        // 
        // CurrentContactButton
        // 
        CurrentContactButton.ImageAlign = ContentAlignment.MiddleLeft;
        CurrentContactButton.Location = new Point(12, 15);
        CurrentContactButton.Name = "CurrentContactButton";
        CurrentContactButton.Size = new Size(181, 29);
        CurrentContactButton.TabIndex = 0;
        CurrentContactButton.Text = "Current contact";
        CurrentContactButton.UseVisualStyleBackColor = true;
        CurrentContactButton.Click += CurrentContactButton_Click;
        // 
        // ContactTypeComboBoxColumn
        // 
        ContactTypeComboBoxColumn.DataPropertyName = "ContactTitle";
        ContactTypeComboBoxColumn.HeaderText = "Title";
        ContactTypeComboBoxColumn.MinimumWidth = 6;
        ContactTypeComboBoxColumn.Name = "ContactTypeComboBoxColumn";
        ContactTypeComboBoxColumn.Resizable = DataGridViewTriState.True;
        ContactTypeComboBoxColumn.Width = 125;
        // 
        // FirstNameColumn
        // 
        FirstNameColumn.DataPropertyName = "FirstName";
        FirstNameColumn.HeaderText = "First name";
        FirstNameColumn.MinimumWidth = 6;
        FirstNameColumn.Name = "FirstNameColumn";
        FirstNameColumn.Width = 125;
        // 
        // LastNameColumn
        // 
        LastNameColumn.DataPropertyName = "LastName";
        LastNameColumn.HeaderText = "Last name";
        LastNameColumn.MinimumWidth = 6;
        LastNameColumn.Name = "LastNameColumn";
        LastNameColumn.Width = 125;
        // 
        // PhoneColumn
        // 
        PhoneColumn.DataPropertyName = "PhoneNumber";
        PhoneColumn.HeaderText = "Phone";
        PhoneColumn.MinimumWidth = 6;
        PhoneColumn.Name = "PhoneColumn";
        PhoneColumn.Width = 125;
        // 
        // DeviceTypeColumn
        // 
        DeviceTypeColumn.DataPropertyName = "PhoneTypeDescription";
        DeviceTypeColumn.HeaderText = "Type";
        DeviceTypeColumn.MinimumWidth = 6;
        DeviceTypeColumn.Name = "DeviceTypeColumn";
        DeviceTypeColumn.ReadOnly = true;
        DeviceTypeColumn.Visible = false;
        DeviceTypeColumn.Width = 125;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 587);
        Controls.Add(contactsDataGridView);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Code sample: Filter on first name";
        ((System.ComponentModel.ISupportInitialize)contactsDataGridView).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView contactsDataGridView;
    private Panel panel1;
    private TextBox firstNameTextBox;
    private Button CurrentContactButton;
    private DataGridViewComboBoxColumn ContactTypeComboBoxColumn;
    private DataGridViewTextBoxColumn FirstNameColumn;
    private DataGridViewTextBoxColumn LastNameColumn;
    private DataGridViewTextBoxColumn PhoneColumn;
    private DataGridViewTextBoxColumn DeviceTypeColumn;
}
