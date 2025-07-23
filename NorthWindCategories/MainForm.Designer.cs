namespace NorthWindCategories;

partial class MainForm
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        dataGridView1 = new DataGridView();
        InsertImageButton = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Window;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
        dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.RowTemplate.Height = 110;
        dataGridView1.Size = new Size(926, 514);
        dataGridView1.TabIndex = 0;
        // 
        // InsertImageButton
        // 
        InsertImageButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        InsertImageButton.Location = new Point(12, 537);
        InsertImageButton.Name = "InsertImageButton";
        InsertImageButton.Size = new Size(140, 29);
        InsertImageButton.TabIndex = 1;
        InsertImageButton.Text = "Insert image";
        InsertImageButton.TextAlign = ContentAlignment.BottomCenter;
        InsertImageButton.UseVisualStyleBackColor = true;
        InsertImageButton.Click += InsertImageButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(938, 578);
        Controls.Add(InsertImageButton);
        Controls.Add(dataGridView1);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Insert image example";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView1;
    private Button InsertImageButton;
}
