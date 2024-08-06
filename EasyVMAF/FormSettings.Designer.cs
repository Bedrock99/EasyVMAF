namespace EasyVMAF
{
    partial class FormSettings
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
            this.cb_TempInSameFolderAsSource = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_BrowseTempFilesFolder = new System.Windows.Forms.Button();
            this.tb_BrowseTempFilesFolder = new System.Windows.Forms.TextBox();
            this.cb_AutoDeleteTempFiles = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_TempInSameFolderAsSource
            // 
            this.cb_TempInSameFolderAsSource.AutoSize = true;
            this.cb_TempInSameFolderAsSource.Location = new System.Drawing.Point(6, 19);
            this.cb_TempInSameFolderAsSource.Name = "cb_TempInSameFolderAsSource";
            this.cb_TempInSameFolderAsSource.Size = new System.Drawing.Size(170, 17);
            this.cb_TempInSameFolderAsSource.TabIndex = 0;
            this.cb_TempInSameFolderAsSource.Text = "Same folder as the source files";
            this.cb_TempInSameFolderAsSource.UseVisualStyleBackColor = true;
            this.cb_TempInSameFolderAsSource.CheckedChanged += new System.EventHandler(this.cb_TempInSameFolderAsSource_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Controls.Add(this.cb_TempInSameFolderAsSource);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 70);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folder for temporary files:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.Controls.Add(this.btn_BrowseTempFilesFolder, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_BrowseTempFilesFolder, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 20);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btn_BrowseTempFilesFolder
            // 
            this.btn_BrowseTempFilesFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_BrowseTempFilesFolder.Location = new System.Drawing.Point(448, 0);
            this.btn_BrowseTempFilesFolder.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btn_BrowseTempFilesFolder.Name = "btn_BrowseTempFilesFolder";
            this.btn_BrowseTempFilesFolder.Size = new System.Drawing.Size(100, 20);
            this.btn_BrowseTempFilesFolder.TabIndex = 3;
            this.btn_BrowseTempFilesFolder.Text = "Select folder";
            this.btn_BrowseTempFilesFolder.UseVisualStyleBackColor = true;
            this.btn_BrowseTempFilesFolder.Click += new System.EventHandler(this.btn_BrowseTempFilesFolder_Click);
            // 
            // tb_BrowseTempFilesFolder
            // 
            this.tb_BrowseTempFilesFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_BrowseTempFilesFolder.Location = new System.Drawing.Point(0, 0);
            this.tb_BrowseTempFilesFolder.Margin = new System.Windows.Forms.Padding(0);
            this.tb_BrowseTempFilesFolder.Name = "tb_BrowseTempFilesFolder";
            this.tb_BrowseTempFilesFolder.ReadOnly = true;
            this.tb_BrowseTempFilesFolder.Size = new System.Drawing.Size(445, 20);
            this.tb_BrowseTempFilesFolder.TabIndex = 0;
            // 
            // cb_AutoDeleteTempFiles
            // 
            this.cb_AutoDeleteTempFiles.AutoSize = true;
            this.cb_AutoDeleteTempFiles.Location = new System.Drawing.Point(12, 88);
            this.cb_AutoDeleteTempFiles.Name = "cb_AutoDeleteTempFiles";
            this.cb_AutoDeleteTempFiles.Size = new System.Drawing.Size(347, 17);
            this.cb_AutoDeleteTempFiles.TabIndex = 5;
            this.cb_AutoDeleteTempFiles.Text = "Delete temporary files automatically (Video comparision will not work)";
            this.cb_AutoDeleteTempFiles.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 111);
            this.Controls.Add(this.cb_AutoDeleteTempFiles);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(9999, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 150);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_TempInSameFolderAsSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_BrowseTempFilesFolder;
        private System.Windows.Forms.TextBox tb_BrowseTempFilesFolder;
        private System.Windows.Forms.CheckBox cb_AutoDeleteTempFiles;
    }
}