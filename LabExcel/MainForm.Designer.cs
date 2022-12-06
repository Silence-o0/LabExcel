namespace LabExcel
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.A_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.I_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.infoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.formulaTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.A_Column,
            this.B_Column,
            this.C_Column,
            this.D_Column,
            this.E_Column,
            this.F_Column,
            this.G_Column,
            this.H_Column,
            this.I_Column,
            this.J_Column});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView.Location = new System.Drawing.Point(25, 106);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowHeadersWidth = 80;
            this.dataGridView.RowTemplate.Height = 33;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowCellToolTips = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(1032, 417);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDown);
            // 
            // A_Column
            // 
            this.A_Column.HeaderText = "A";
            this.A_Column.MinimumWidth = 8;
            this.A_Column.Name = "A_Column";
            this.A_Column.ReadOnly = true;
            this.A_Column.Width = 120;
            // 
            // B_Column
            // 
            this.B_Column.HeaderText = "B";
            this.B_Column.MinimumWidth = 8;
            this.B_Column.Name = "B_Column";
            this.B_Column.ReadOnly = true;
            this.B_Column.Width = 120;
            // 
            // C_Column
            // 
            this.C_Column.HeaderText = "C";
            this.C_Column.MinimumWidth = 8;
            this.C_Column.Name = "C_Column";
            this.C_Column.ReadOnly = true;
            this.C_Column.Width = 120;
            // 
            // D_Column
            // 
            this.D_Column.HeaderText = "D";
            this.D_Column.MinimumWidth = 8;
            this.D_Column.Name = "D_Column";
            this.D_Column.ReadOnly = true;
            this.D_Column.Width = 120;
            // 
            // E_Column
            // 
            this.E_Column.HeaderText = "E";
            this.E_Column.MinimumWidth = 8;
            this.E_Column.Name = "E_Column";
            this.E_Column.ReadOnly = true;
            this.E_Column.Width = 120;
            // 
            // F_Column
            // 
            this.F_Column.HeaderText = "F";
            this.F_Column.MinimumWidth = 8;
            this.F_Column.Name = "F_Column";
            this.F_Column.ReadOnly = true;
            this.F_Column.Width = 120;
            // 
            // G_Column
            // 
            this.G_Column.HeaderText = "G";
            this.G_Column.MinimumWidth = 8;
            this.G_Column.Name = "G_Column";
            this.G_Column.ReadOnly = true;
            this.G_Column.Width = 120;
            // 
            // H_Column
            // 
            this.H_Column.HeaderText = "H";
            this.H_Column.MinimumWidth = 8;
            this.H_Column.Name = "H_Column";
            this.H_Column.ReadOnly = true;
            this.H_Column.Width = 120;
            // 
            // I_Column
            // 
            this.I_Column.HeaderText = "I";
            this.I_Column.MinimumWidth = 8;
            this.I_Column.Name = "I_Column";
            this.I_Column.ReadOnly = true;
            this.I_Column.Width = 120;
            // 
            // J_Column
            // 
            this.J_Column.HeaderText = "J";
            this.J_Column.MinimumWidth = 8;
            this.J_Column.Name = "J_Column";
            this.J_Column.ReadOnly = true;
            this.J_Column.Width = 120;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripButton,
            this.infoButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1090, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripButton
            // 
            this.fileToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.saveAsButton,
            this.openAsButton});
            this.fileToolStripButton.Name = "fileToolStripButton";
            this.fileToolStripButton.Size = new System.Drawing.Size(69, 29);
            this.fileToolStripButton.Text = "Файл";
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(210, 34);
            this.saveButton.Text = "Зберегти";
            // 
            // saveAsButton
            // 
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(210, 34);
            this.saveAsButton.Text = "Зберегти як";
            // 
            // openAsButton
            // 
            this.openAsButton.Name = "openAsButton";
            this.openAsButton.Size = new System.Drawing.Size(210, 34);
            this.openAsButton.Text = "Відкрити як";
            // 
            // infoButton
            // 
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(93, 29);
            this.infoButton.Text = "Довідка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(649, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // formulaTextBox
            // 
            this.formulaTextBox.Location = new System.Drawing.Point(79, 54);
            this.formulaTextBox.Name = "formulaTextBox";
            this.formulaTextBox.Size = new System.Drawing.Size(297, 31);
            this.formulaTextBox.TabIndex = 6;
            this.formulaTextBox.TextChanged += new System.EventHandler(this.formulaTextBox_TextChanged);
            this.formulaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formulaTextBox_KeyDown);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 535);
            this.Controls.Add(this.formulaTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(579, 395);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Table";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripButton;
        private ToolStripMenuItem saveButton;
        private ToolStripMenuItem saveAsButton;
        private ToolStripMenuItem openAsButton;
        private ToolStripMenuItem infoButton;
        private Label label1;
        private DataGridViewTextBoxColumn A_Column;
        private DataGridViewTextBoxColumn B_Column;
        private DataGridViewTextBoxColumn C_Column;
        private DataGridViewTextBoxColumn D_Column;
        private DataGridViewTextBoxColumn E_Column;
        private DataGridViewTextBoxColumn F_Column;
        private DataGridViewTextBoxColumn G_Column;
        private DataGridViewTextBoxColumn H_Column;
        private DataGridViewTextBoxColumn I_Column;
        private DataGridViewTextBoxColumn J_Column;
        private TextBox formulaTextBox;
        public DataGridView dataGridView;
    }
}