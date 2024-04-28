namespace SampleApp1;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        contactsDataGridView = new DataGridView();
        ContactTypeComboBoxColumn = new DataGridViewComboBoxColumn();
        FirstNameColumn = new DataGridViewTextBoxColumn();
        LastNameColumn = new DataGridViewTextBoxColumn();
        PhoneColumn = new DataGridViewTextBoxColumn();
        DeviceTypeColumn = new DataGridViewTextBoxColumn();
        panel1 = new Panel();
        MockAddContactButton = new Button();
        CurrentContactButton = new Button();
        BindingNavigator1 = new Classes.CoreBindingNavigator();
        ((System.ComponentModel.ISupportInitialize)contactsDataGridView).BeginInit();
        panel1.SuspendLayout();
        BindingNavigator1.BeginInit();
        SuspendLayout();
        // 
        // contactsDataGridView
        // 
        contactsDataGridView.AllowUserToAddRows = false;
        contactsDataGridView.AllowUserToDeleteRows = false;
        contactsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        contactsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ContactTypeComboBoxColumn, FirstNameColumn, LastNameColumn, PhoneColumn, DeviceTypeColumn });
        contactsDataGridView.Dock = DockStyle.Fill;
        contactsDataGridView.Location = new Point(0, 27);
        contactsDataGridView.Name = "contactsDataGridView";
        contactsDataGridView.RowHeadersWidth = 51;
        contactsDataGridView.Size = new Size(800, 358);
        contactsDataGridView.TabIndex = 0;
        // 
        // ContactTypeComboBoxColumn
        // 
        ContactTypeComboBoxColumn.DataPropertyName = "ContactTitle";
        ContactTypeComboBoxColumn.HeaderText = "Title";
        ContactTypeComboBoxColumn.MinimumWidth = 6;
        ContactTypeComboBoxColumn.Name = "ContactTypeComboBoxColumn";
        ContactTypeComboBoxColumn.Resizable = DataGridViewTriState.True;
        ContactTypeComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
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
        // panel1
        // 
        panel1.Controls.Add(MockAddContactButton);
        panel1.Controls.Add(CurrentContactButton);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 385);
        panel1.Name = "panel1";
        panel1.Size = new Size(800, 65);
        panel1.TabIndex = 1;
        // 
        // MockAddContactButton
        // 
        MockAddContactButton.Image = (Image)resources.GetObject("MockAddContactButton.Image");
        MockAddContactButton.ImageAlign = ContentAlignment.MiddleLeft;
        MockAddContactButton.Location = new Point(214, 15);
        MockAddContactButton.Name = "MockAddContactButton";
        MockAddContactButton.Size = new Size(181, 29);
        MockAddContactButton.TabIndex = 1;
        MockAddContactButton.Text = "Mock add Contact";
        MockAddContactButton.UseVisualStyleBackColor = true;
        MockAddContactButton.Click += MockAddContactButton_Click;
        // 
        // CurrentContactButton
        // 
        CurrentContactButton.Image = Properties.Resources.DatabaseSource_16x;
        CurrentContactButton.ImageAlign = ContentAlignment.MiddleLeft;
        CurrentContactButton.Location = new Point(12, 15);
        CurrentContactButton.Name = "CurrentContactButton";
        CurrentContactButton.Size = new Size(181, 29);
        CurrentContactButton.TabIndex = 0;
        CurrentContactButton.Text = "Current contact";
        CurrentContactButton.UseVisualStyleBackColor = true;
        CurrentContactButton.Click += CurrentContactButton_Click;
        // 
        // BindingNavigator1
        // 
        BindingNavigator1.BackColor = Color.Cornsilk;
        BindingNavigator1.ImageScalingSize = new Size(20, 20);
        BindingNavigator1.Location = new Point(0, 0);
        BindingNavigator1.Name = "BindingNavigator1";
        BindingNavigator1.Size = new Size(800, 27);
        BindingNavigator1.TabIndex = 2;
        BindingNavigator1.Text = "coreBindingNavigator1";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(contactsDataGridView);
        Controls.Add(BindingNavigator1);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dapper sample";
        ((System.ComponentModel.ISupportInitialize)contactsDataGridView).EndInit();
        panel1.ResumeLayout(false);
        BindingNavigator1.EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView contactsDataGridView;
    private Panel panel1;
    private Button CurrentContactButton;
    private Button MockAddContactButton;
    private DataGridViewComboBoxColumn ContactTypeComboBoxColumn;
    private DataGridViewTextBoxColumn FirstNameColumn;
    private DataGridViewTextBoxColumn LastNameColumn;
    private DataGridViewTextBoxColumn PhoneColumn;
    private DataGridViewTextBoxColumn DeviceTypeColumn;
    private Classes.CoreBindingNavigator BindingNavigator1;
}
