namespace EasyVMAF
{
    partial class UCDoVMAF
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flp_Infos = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_VMAF_Score = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Filesize = new System.Windows.Forms.Label();
            this.lbl_BytesPerFrame = new System.Windows.Forms.Label();
            this.lbl_SizeDifference = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lpb_File = new EasyVMAF.LabeledProgressBar();
            this.btn_ShowResult = new EasyVMAF.MenuButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showResultChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setToCompareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flp_Infos.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_Infos
            // 
            this.flp_Infos.Controls.Add(this.label1);
            this.flp_Infos.Controls.Add(this.lbl_VMAF_Score);
            this.flp_Infos.Controls.Add(this.label2);
            this.flp_Infos.Controls.Add(this.lbl_Filesize);
            this.flp_Infos.Controls.Add(this.lbl_BytesPerFrame);
            this.flp_Infos.Controls.Add(this.lbl_SizeDifference);
            this.flp_Infos.Controls.Add(this.label6);
            this.flp_Infos.Location = new System.Drawing.Point(3, 32);
            this.flp_Infos.Name = "flp_Infos";
            this.flp_Infos.Size = new System.Drawing.Size(579, 21);
            this.flp_Infos.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VMAF:";
            // 
            // lbl_VMAF_Score
            // 
            this.lbl_VMAF_Score.AutoSize = true;
            this.lbl_VMAF_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VMAF_Score.Location = new System.Drawing.Point(48, 0);
            this.lbl_VMAF_Score.Name = "lbl_VMAF_Score";
            this.lbl_VMAF_Score.Size = new System.Drawing.Size(11, 13);
            this.lbl_VMAF_Score.TabIndex = 1;
            this.lbl_VMAF_Score.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File size:";
            // 
            // lbl_Filesize
            // 
            this.lbl_Filesize.AutoSize = true;
            this.lbl_Filesize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Filesize.Location = new System.Drawing.Point(118, 0);
            this.lbl_Filesize.Name = "lbl_Filesize";
            this.lbl_Filesize.Size = new System.Drawing.Size(10, 13);
            this.lbl_Filesize.TabIndex = 3;
            this.lbl_Filesize.Text = "-";
            // 
            // lbl_BytesPerFrame
            // 
            this.lbl_BytesPerFrame.AutoSize = true;
            this.lbl_BytesPerFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BytesPerFrame.Location = new System.Drawing.Point(134, 0);
            this.lbl_BytesPerFrame.Name = "lbl_BytesPerFrame";
            this.lbl_BytesPerFrame.Size = new System.Drawing.Size(10, 13);
            this.lbl_BytesPerFrame.TabIndex = 5;
            this.lbl_BytesPerFrame.Text = "-";
            // 
            // lbl_SizeDifference
            // 
            this.lbl_SizeDifference.AutoSize = true;
            this.lbl_SizeDifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SizeDifference.Location = new System.Drawing.Point(150, 0);
            this.lbl_SizeDifference.Name = "lbl_SizeDifference";
            this.lbl_SizeDifference.Size = new System.Drawing.Size(11, 13);
            this.lbl_SizeDifference.TabIndex = 7;
            this.lbl_SizeDifference.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(167, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "of original";
            // 
            // lpb_File
            // 
            this.lpb_File.AddText = "";
            this.lpb_File.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lpb_File.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lpb_File.FontColor = System.Drawing.Color.Black;
            this.lpb_File.ForeColor = System.Drawing.Color.LightGray;
            this.lpb_File.Location = new System.Drawing.Point(3, 3);
            this.lpb_File.Maximum = 10000;
            this.lpb_File.Name = "lpb_File";
            this.lpb_File.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.lpb_File.Size = new System.Drawing.Size(488, 23);
            this.lpb_File.TabIndex = 2;
            // 
            // btn_ShowResult
            // 
            this.btn_ShowResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShowResult.Enabled = false;
            this.btn_ShowResult.Location = new System.Drawing.Point(497, 3);
            this.btn_ShowResult.Menu = this.contextMenuStrip1;
            this.btn_ShowResult.Name = "btn_ShowResult";
            this.btn_ShowResult.Size = new System.Drawing.Size(85, 23);
            this.btn_ShowResult.TabIndex = 4;
            this.btn_ShowResult.Text = "Actions";
            this.btn_ShowResult.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showResultChartToolStripMenuItem,
            this.toolStripSeparator1,
            this.setToCompareToolStripMenuItem,
            this.compareToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showResultChartToolStripMenuItem
            // 
            this.showResultChartToolStripMenuItem.Name = "showResultChartToolStripMenuItem";
            this.showResultChartToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showResultChartToolStripMenuItem.Text = "Show result chart";
            this.showResultChartToolStripMenuItem.Click += new System.EventHandler(this.showResultChartToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // setToCompareToolStripMenuItem
            // 
            this.setToCompareToolStripMenuItem.Name = "setToCompareToolStripMenuItem";
            this.setToCompareToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setToCompareToolStripMenuItem.Text = "Set to compare";
            this.setToCompareToolStripMenuItem.Click += new System.EventHandler(this.setToCompareToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.compareToolStripMenuItem.Text = "Compare";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // UCDoVMAF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flp_Infos);
            this.Controls.Add(this.lpb_File);
            this.Controls.Add(this.btn_ShowResult);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCDoVMAF";
            this.Size = new System.Drawing.Size(585, 50);
            this.flp_Infos.ResumeLayout(false);
            this.flp_Infos.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private LabeledProgressBar lpb_File;
        private System.Windows.Forms.FlowLayoutPanel flp_Infos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_VMAF_Score;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Filesize;
        private System.Windows.Forms.Label lbl_BytesPerFrame;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_SizeDifference;
        private MenuButton btn_ShowResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setToCompareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showResultChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
