namespace LabExcel
{
    partial class RowOrColumnDelete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowOrColumnDelete));
            this.label1 = new System.Windows.Forms.Label();
            this.RowSelectButton = new System.Windows.Forms.Button();
            this.ColumnSelectButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(155, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Що ви хочете видалити?";
            // 
            // RowSelectButton
            // 
            this.RowSelectButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RowSelectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.RowSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RowSelectButton.Location = new System.Drawing.Point(100, 203);
            this.RowSelectButton.Name = "RowSelectButton";
            this.RowSelectButton.Size = new System.Drawing.Size(108, 36);
            this.RowSelectButton.TabIndex = 1;
            this.RowSelectButton.Text = "Рядок";
            this.RowSelectButton.UseVisualStyleBackColor = false;
            this.RowSelectButton.Click += new System.EventHandler(this.RowSelectButton_Click);
            // 
            // ColumnSelectButton
            // 
            this.ColumnSelectButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ColumnSelectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ColumnSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSelectButton.Location = new System.Drawing.Point(239, 203);
            this.ColumnSelectButton.Name = "ColumnSelectButton";
            this.ColumnSelectButton.Size = new System.Drawing.Size(108, 36);
            this.ColumnSelectButton.TabIndex = 2;
            this.ColumnSelectButton.Text = "Стовпчик";
            this.ColumnSelectButton.UseVisualStyleBackColor = false;
            this.ColumnSelectButton.Click += new System.EventHandler(this.ColumnSelectButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.returnButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Location = new System.Drawing.Point(389, 189);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(147, 64);
            this.returnButton.TabIndex = 3;
            this.returnButton.Text = "Повернутися назад";
            this.returnButton.UseVisualStyleBackColor = false;
            // 
            // RowOrColumnDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 302);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.ColumnSelectButton);
            this.Controls.Add(this.RowSelectButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RowOrColumnDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deletion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button RowSelectButton;
        private Button ColumnSelectButton;
        private Button returnButton;
    }
}