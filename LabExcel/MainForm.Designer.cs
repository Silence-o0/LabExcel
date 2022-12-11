using System.Data.Common;
using System.Windows.Forms;

namespace LabExcel
{
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.A_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewTableButton = new System.Windows.Forms.ToolStripMenuItem();
            this.generalSaveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.infoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addRowButton = new System.Windows.Forms.Button();
            this.addColumnButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 35;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A_Column});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView.Location = new System.Drawing.Point(32, 106);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(40);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowHeadersWidth = 40;
            this.dataGridView.RowTemplate.Height = 33;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowCellToolTips = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(883, 446);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick);
            this.dataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseDown);
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_ColumnHeaderMouseClick);
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView_RowPostPaint);
            // 
            // A_Column
            // 
            this.A_Column.HeaderText = "A";
            this.A_Column.MinimumWidth = 8;
            this.A_Column.Name = "A_Column";
            this.A_Column.ReadOnly = true;
            this.A_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.A_Column.Width = 120;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripButton,
            this.infoButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(948, 33);
            this.menuStrip1.TabIndex = 2;
            // 
            // fileToolStripButton
            // 
            this.fileToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewTableButton,
            this.generalSaveButton,
            this.openAsButton});
            this.fileToolStripButton.Name = "fileToolStripButton";
            this.fileToolStripButton.Size = new System.Drawing.Size(69, 29);
            this.fileToolStripButton.Text = "Файл";
            // 
            // createNewTableButton
            // 
            this.createNewTableButton.Name = "createNewTableButton";
            this.createNewTableButton.Size = new System.Drawing.Size(227, 34);
            this.createNewTableButton.Text = "Нова таблиця";
            this.createNewTableButton.Click += new System.EventHandler(this.CreateNewTableButton_Click);
            // 
            // generalSaveButton
            // 
            this.generalSaveButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.saveAsButton});
            this.generalSaveButton.Name = "generalSaveButton";
            this.generalSaveButton.Size = new System.Drawing.Size(227, 34);
            this.generalSaveButton.Text = "Зберегти";
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(210, 34);
            this.saveButton.Text = "Зберегти";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(210, 34);
            this.saveAsButton.Text = "Зберегти як";
            this.saveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // openAsButton
            // 
            this.openAsButton.Name = "openAsButton";
            this.openAsButton.Size = new System.Drawing.Size(227, 34);
            this.openAsButton.Text = "Відкрити як";
            this.openAsButton.Click += new System.EventHandler(this.OpenAsButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(93, 29);
            this.infoButton.Text = "Довідка";
            this.infoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // formulaTextBox
            // 
            this.formulaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formulaTextBox.Location = new System.Drawing.Point(98, 54);
            this.formulaTextBox.Name = "formulaTextBox";
            this.formulaTextBox.Size = new System.Drawing.Size(374, 31);
            this.formulaTextBox.TabIndex = 6;
            this.formulaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormulaTextBox_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LabExcel.Properties.Resources.Новый_проект;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::LabExcel.Properties.Resources.Новый_проект;
            this.pictureBox1.Location = new System.Drawing.Point(51, 46);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(41, 46);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(41, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 46);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // addRowButton
            // 
            this.addRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addRowButton.BackgroundImage = global::LabExcel.Properties.Resources._;
            this.addRowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addRowButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.addRowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRowButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.addRowButton.Location = new System.Drawing.Point(2, 525);
            this.addRowButton.Margin = new System.Windows.Forms.Padding(0);
            this.addRowButton.MaximumSize = new System.Drawing.Size(27, 27);
            this.addRowButton.MinimumSize = new System.Drawing.Size(27, 27);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addRowButton.Size = new System.Drawing.Size(27, 27);
            this.addRowButton.TabIndex = 8;
            this.addRowButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // addColumnButton
            // 
            this.addColumnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addColumnButton.BackgroundImage = global::LabExcel.Properties.Resources._;
            this.addColumnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addColumnButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.addColumnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addColumnButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.addColumnButton.Location = new System.Drawing.Point(918, 106);
            this.addColumnButton.Margin = new System.Windows.Forms.Padding(0);
            this.addColumnButton.MaximumSize = new System.Drawing.Size(27, 27);
            this.addColumnButton.MinimumSize = new System.Drawing.Size(27, 27);
            this.addColumnButton.Name = "addColumnButton";
            this.addColumnButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addColumnButton.Size = new System.Drawing.Size(27, 27);
            this.addColumnButton.TabIndex = 9;
            this.addColumnButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addColumnButton.UseVisualStyleBackColor = true;
            this.addColumnButton.Click += new System.EventHandler(this.AddColumnButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteButton.BackgroundImage = global::LabExcel.Properties.Resources.bin;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.deleteButton.Location = new System.Drawing.Point(817, 46);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.MaximumSize = new System.Drawing.Size(45, 51);
            this.deleteButton.MinimumSize = new System.Drawing.Size(45, 51);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deleteButton.Size = new System.Drawing.Size(45, 51);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.acceptButton.BackgroundImage = global::LabExcel.Properties.Resources.acceptButton2;
            this.acceptButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.acceptButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.acceptButton.Location = new System.Drawing.Point(491, 54);
            this.acceptButton.Margin = new System.Windows.Forms.Padding(0);
            this.acceptButton.MaximumSize = new System.Drawing.Size(29, 31);
            this.acceptButton.MinimumSize = new System.Drawing.Size(29, 31);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.acceptButton.Size = new System.Drawing.Size(29, 31);
            this.acceptButton.TabIndex = 11;
            this.acceptButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 564);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addColumnButton);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.formulaTextBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(747, 492);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Table";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripButton;
        private ToolStripMenuItem generalSaveButton;
        private ToolStripMenuItem openAsButton;
        private ToolStripMenuItem infoButton;
        private DataGridViewTextBoxColumn A_Column;
        private TextBox formulaTextBox;
        private ToolStripMenuItem saveButton;
        private ToolStripMenuItem saveAsButton;
        private PictureBox pictureBox1;
        private Button addRowButton;
        private Button addColumnButton;
        private Button deleteButton;
        private Button acceptButton;
        private DataGridView dataGridView;
        private ToolStripMenuItem createNewTableButton;
    }
}