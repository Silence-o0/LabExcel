namespace LabExcel
{
    partial class DeleteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteForm));
            this.deleteOne = new System.Windows.Forms.CheckBox();
            this.deleteFew = new System.Windows.Forms.CheckBox();
            this.acceptDelete = new System.Windows.Forms.Button();
            this.textBoxSingleElement = new System.Windows.Forms.TextBox();
            this.textBoxFirstElement = new System.Windows.Forms.TextBox();
            this.textBoxLastElement = new System.Windows.Forms.TextBox();
            this.labelDash = new System.Windows.Forms.Label();
            this.labelArticleDeletion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deleteOne
            // 
            this.deleteOne.AutoSize = true;
            this.deleteOne.Location = new System.Drawing.Point(92, 133);
            this.deleteOne.Name = "deleteOne";
            this.deleteOne.Size = new System.Drawing.Size(218, 29);
            this.deleteOne.TabIndex = 0;
            this.deleteOne.Text = "Видалити один рядок:";
            this.deleteOne.UseVisualStyleBackColor = true;
            this.deleteOne.CheckedChanged += new System.EventHandler(this.DeleteOne_CheckedChanged);
            // 
            // deleteFew
            // 
            this.deleteFew.AutoSize = true;
            this.deleteFew.Location = new System.Drawing.Point(92, 240);
            this.deleteFew.Name = "deleteFew";
            this.deleteFew.Size = new System.Drawing.Size(171, 29);
            this.deleteFew.TabIndex = 1;
            this.deleteFew.Text = "Видалити рядки:";
            this.deleteFew.UseVisualStyleBackColor = true;
            this.deleteFew.CheckedChanged += new System.EventHandler(this.DeleteFew_CheckedChanged);
            // 
            // acceptDelete
            // 
            this.acceptDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptDelete.Location = new System.Drawing.Point(208, 352);
            this.acceptDelete.Name = "acceptDelete";
            this.acceptDelete.Size = new System.Drawing.Size(132, 45);
            this.acceptDelete.TabIndex = 2;
            this.acceptDelete.Text = "Видалити";
            this.acceptDelete.UseVisualStyleBackColor = true;
            this.acceptDelete.Click += new System.EventHandler(this.AcceptDelete_Click);
            // 
            // textBoxSingleElement
            // 
            this.textBoxSingleElement.BackColor = System.Drawing.Color.White;
            this.textBoxSingleElement.Location = new System.Drawing.Point(346, 133);
            this.textBoxSingleElement.MaxLength = 1;
            this.textBoxSingleElement.Name = "textBoxSingleElement";
            this.textBoxSingleElement.Size = new System.Drawing.Size(38, 31);
            this.textBoxSingleElement.TabIndex = 3;
            // 
            // textBoxFirstElement
            // 
            this.textBoxFirstElement.BackColor = System.Drawing.Color.White;
            this.textBoxFirstElement.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxFirstElement.Location = new System.Drawing.Point(310, 240);
            this.textBoxFirstElement.MaxLength = 1;
            this.textBoxFirstElement.Name = "textBoxFirstElement";
            this.textBoxFirstElement.Size = new System.Drawing.Size(38, 31);
            this.textBoxFirstElement.TabIndex = 4;
            // 
            // textBoxLastElement
            // 
            this.textBoxLastElement.BackColor = System.Drawing.Color.White;
            this.textBoxLastElement.Location = new System.Drawing.Point(390, 240);
            this.textBoxLastElement.MaxLength = 1;
            this.textBoxLastElement.Name = "textBoxLastElement";
            this.textBoxLastElement.Size = new System.Drawing.Size(38, 31);
            this.textBoxLastElement.TabIndex = 5;
            // 
            // labelDash
            // 
            this.labelDash.AutoSize = true;
            this.labelDash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelDash.Location = new System.Drawing.Point(354, 243);
            this.labelDash.Name = "labelDash";
            this.labelDash.Size = new System.Drawing.Size(30, 25);
            this.labelDash.TabIndex = 6;
            this.labelDash.Text = "—";
            // 
            // labelArticleDeletion
            // 
            this.labelArticleDeletion.AutoSize = true;
            this.labelArticleDeletion.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.labelArticleDeletion.Location = new System.Drawing.Point(208, 31);
            this.labelArticleDeletion.Name = "labelArticleDeletion";
            this.labelArticleDeletion.Size = new System.Drawing.Size(132, 32);
            this.labelArticleDeletion.TabIndex = 7;
            this.labelArticleDeletion.Text = "Видалення";
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 456);
            this.Controls.Add(this.labelArticleDeletion);
            this.Controls.Add(this.labelDash);
            this.Controls.Add(this.textBoxLastElement);
            this.Controls.Add(this.textBoxFirstElement);
            this.Controls.Add(this.textBoxSingleElement);
            this.Controls.Add(this.acceptDelete);
            this.Controls.Add(this.deleteFew);
            this.Controls.Add(this.deleteOne);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(568, 512);
            this.MinimumSize = new System.Drawing.Size(568, 512);
            this.Name = "DeleteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deletion";
            this.Load += new System.EventHandler(this.DeleteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox deleteOne;
        private CheckBox deleteFew;
        private Button acceptDelete;
        private TextBox textBoxSingleElement;
        private TextBox textBoxFirstElement;
        private TextBox textBoxLastElement;
        private Label labelDash;
        private Label labelArticleDeletion;
    }
}