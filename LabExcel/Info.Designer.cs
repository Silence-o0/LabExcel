namespace LabExcel
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.pictureInfo = new System.Windows.Forms.PictureBox();
            this.mainLabelInfo = new System.Windows.Forms.Label();
            this.labelMaxQuantity = new System.Windows.Forms.Label();
            this.labelSaveInfo = new System.Windows.Forms.Label();
            this.labelOperationInfo = new System.Windows.Forms.Label();
            this.labelCreatorInfo = new System.Windows.Forms.Label();
            this.labelDeleteInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureInfo
            // 
            this.pictureInfo.BackgroundImage = global::LabExcel.Properties.Resources.InfoWindow;
            resources.ApplyResources(this.pictureInfo, "pictureInfo");
            this.pictureInfo.Name = "pictureInfo";
            this.pictureInfo.TabStop = false;
            // 
            // mainLabelInfo
            // 
            resources.ApplyResources(this.mainLabelInfo, "mainLabelInfo");
            this.mainLabelInfo.Name = "mainLabelInfo";
            // 
            // labelMaxQuantity
            // 
            resources.ApplyResources(this.labelMaxQuantity, "labelMaxQuantity");
            this.labelMaxQuantity.Name = "labelMaxQuantity";
            // 
            // labelSaveInfo
            // 
            resources.ApplyResources(this.labelSaveInfo, "labelSaveInfo");
            this.labelSaveInfo.Name = "labelSaveInfo";
            // 
            // labelOperationInfo
            // 
            resources.ApplyResources(this.labelOperationInfo, "labelOperationInfo");
            this.labelOperationInfo.Name = "labelOperationInfo";
            // 
            // labelCreatorInfo
            // 
            resources.ApplyResources(this.labelCreatorInfo, "labelCreatorInfo");
            this.labelCreatorInfo.Name = "labelCreatorInfo";
            // 
            // labelDeleteInfo
            // 
            resources.ApplyResources(this.labelDeleteInfo, "labelDeleteInfo");
            this.labelDeleteInfo.Name = "labelDeleteInfo";
            // 
            // InfoForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDeleteInfo);
            this.Controls.Add(this.labelCreatorInfo);
            this.Controls.Add(this.labelOperationInfo);
            this.Controls.Add(this.labelSaveInfo);
            this.Controls.Add(this.labelMaxQuantity);
            this.Controls.Add(this.mainLabelInfo);
            this.Controls.Add(this.pictureInfo);
            this.Name = "InfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureInfo;
        private Label mainLabelInfo;
        private Label labelMaxQuantity;
        private Label labelSaveInfo;
        private Label labelOperationInfo;
        private Label labelCreatorInfo;
        private Label labelDeleteInfo;
    }
}