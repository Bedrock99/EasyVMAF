namespace EasyVMAF
{
    partial class FormResult
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart_vmaf = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Bitrate = new System.Windows.Forms.Label();
            this.lbl_VMAF_Score = new System.Windows.Forms.Label();
            this.lbl_FileSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_VMAF_Version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_vmaf)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_vmaf
            // 
            this.chart_vmaf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_vmaf.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Legend:";
            this.chart_vmaf.Legends.Add(legend1);
            this.chart_vmaf.Location = new System.Drawing.Point(12, 75);
            this.chart_vmaf.Name = "chart_vmaf";
            this.chart_vmaf.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart_vmaf.Size = new System.Drawing.Size(760, 327);
            this.chart_vmaf.TabIndex = 0;
            this.chart_vmaf.Text = "chart_VMAF";
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title1.Name = "Title1";
            title1.Text = "Zoom with mouse left click -  Hold button and drag the area to zoom in";
            this.chart_vmaf.Titles.Add(title1);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bytes / Frame:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(443, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "VMAF Score:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "File size:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Bitrate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_VMAF_Score, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_FileSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_VMAF_Version, 3, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 57);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lbl_Bitrate
            // 
            this.lbl_Bitrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Bitrate.Location = new System.Drawing.Point(123, 0);
            this.lbl_Bitrate.Name = "lbl_Bitrate";
            this.lbl_Bitrate.Size = new System.Drawing.Size(314, 28);
            this.lbl_Bitrate.TabIndex = 4;
            this.lbl_Bitrate.Text = "-";
            this.lbl_Bitrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_VMAF_Score
            // 
            this.lbl_VMAF_Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_VMAF_Score.Location = new System.Drawing.Point(563, 0);
            this.lbl_VMAF_Score.Name = "lbl_VMAF_Score";
            this.lbl_VMAF_Score.Size = new System.Drawing.Size(194, 28);
            this.lbl_VMAF_Score.TabIndex = 5;
            this.lbl_VMAF_Score.Text = "-";
            this.lbl_VMAF_Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FileSize
            // 
            this.lbl_FileSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_FileSize.Location = new System.Drawing.Point(123, 28);
            this.lbl_FileSize.Name = "lbl_FileSize";
            this.lbl_FileSize.Size = new System.Drawing.Size(314, 29);
            this.lbl_FileSize.TabIndex = 6;
            this.lbl_FileSize.Text = "-";
            this.lbl_FileSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(443, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "VMAF Version:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_VMAF_Version
            // 
            this.lbl_VMAF_Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_VMAF_Version.Location = new System.Drawing.Point(563, 28);
            this.lbl_VMAF_Version.Name = "lbl_VMAF_Version";
            this.lbl_VMAF_Version.Size = new System.Drawing.Size(194, 29);
            this.lbl_VMAF_Version.TabIndex = 8;
            this.lbl_VMAF_Version.Text = "-";
            this.lbl_VMAF_Version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 414);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.chart_vmaf);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 300);
            this.Name = "FormResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Result for ...";
            ((System.ComponentModel.ISupportInitialize)(this.chart_vmaf)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_vmaf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_FileSize;
        private System.Windows.Forms.Label lbl_VMAF_Score;
        private System.Windows.Forms.Label lbl_Bitrate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_VMAF_Version;
    }
}