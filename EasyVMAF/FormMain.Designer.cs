namespace EasyVMAF
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_BrowseOrgFile = new System.Windows.Forms.Button();
            this.tb_BrowseOrgFile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_RemoveConvertedFiles = new System.Windows.Forms.Button();
            this.btn_AddConvertedFiles = new System.Windows.Forms.Button();
            this.dgv_ConvertedFiles = new System.Windows.Forms.DataGridView();
            this.btn_Run = new System.Windows.Forms.Button();
            this.lpb_Overall = new EasyVMAF.LabeledProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flp_Tasks = new System.Windows.Forms.FlowLayoutPanel();
            this.lpb_MainFileDecode = new EasyVMAF.LabeledProgressBar();
            this.timer_Resize = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConvertedFiles)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.flp_Tasks.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 41);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original file:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.Controls.Add(this.btn_BrowseOrgFile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_BrowseOrgFile, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 20);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btn_BrowseOrgFile
            // 
            this.btn_BrowseOrgFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_BrowseOrgFile.Location = new System.Drawing.Point(451, 0);
            this.btn_BrowseOrgFile.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btn_BrowseOrgFile.Name = "btn_BrowseOrgFile";
            this.btn_BrowseOrgFile.Size = new System.Drawing.Size(100, 20);
            this.btn_BrowseOrgFile.TabIndex = 3;
            this.btn_BrowseOrgFile.Text = "Select file";
            this.btn_BrowseOrgFile.UseVisualStyleBackColor = true;
            this.btn_BrowseOrgFile.Click += new System.EventHandler(this.btn_BrowseOrgFile_Click);
            // 
            // tb_BrowseOrgFile
            // 
            this.tb_BrowseOrgFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_BrowseOrgFile.Location = new System.Drawing.Point(0, 0);
            this.tb_BrowseOrgFile.Margin = new System.Windows.Forms.Padding(0);
            this.tb_BrowseOrgFile.Name = "tb_BrowseOrgFile";
            this.tb_BrowseOrgFile.ReadOnly = true;
            this.tb_BrowseOrgFile.Size = new System.Drawing.Size(448, 20);
            this.tb_BrowseOrgFile.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_RemoveConvertedFiles);
            this.groupBox2.Controls.Add(this.btn_AddConvertedFiles);
            this.groupBox2.Controls.Add(this.dgv_ConvertedFiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Converted files:";
            // 
            // btn_RemoveConvertedFiles
            // 
            this.btn_RemoveConvertedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RemoveConvertedFiles.Location = new System.Drawing.Point(454, 71);
            this.btn_RemoveConvertedFiles.Name = "btn_RemoveConvertedFiles";
            this.btn_RemoveConvertedFiles.Size = new System.Drawing.Size(100, 46);
            this.btn_RemoveConvertedFiles.TabIndex = 2;
            this.btn_RemoveConvertedFiles.Text = "Remove selected files";
            this.btn_RemoveConvertedFiles.UseVisualStyleBackColor = true;
            this.btn_RemoveConvertedFiles.Click += new System.EventHandler(this.btn_RemoveConvertedFiles_Click);
            // 
            // btn_AddConvertedFiles
            // 
            this.btn_AddConvertedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddConvertedFiles.Location = new System.Drawing.Point(454, 19);
            this.btn_AddConvertedFiles.Name = "btn_AddConvertedFiles";
            this.btn_AddConvertedFiles.Size = new System.Drawing.Size(100, 46);
            this.btn_AddConvertedFiles.TabIndex = 1;
            this.btn_AddConvertedFiles.Text = "Add files";
            this.btn_AddConvertedFiles.UseVisualStyleBackColor = true;
            this.btn_AddConvertedFiles.Click += new System.EventHandler(this.btn_AddConvertedFiles_Click);
            // 
            // dgv_ConvertedFiles
            // 
            this.dgv_ConvertedFiles.AllowUserToAddRows = false;
            this.dgv_ConvertedFiles.AllowUserToDeleteRows = false;
            this.dgv_ConvertedFiles.AllowUserToResizeColumns = false;
            this.dgv_ConvertedFiles.AllowUserToResizeRows = false;
            this.dgv_ConvertedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ConvertedFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ConvertedFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_ConvertedFiles.Location = new System.Drawing.Point(6, 19);
            this.dgv_ConvertedFiles.Name = "dgv_ConvertedFiles";
            this.dgv_ConvertedFiles.ReadOnly = true;
            this.dgv_ConvertedFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ConvertedFiles.Size = new System.Drawing.Size(442, 98);
            this.dgv_ConvertedFiles.TabIndex = 0;
            // 
            // btn_Run
            // 
            this.btn_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Run.Location = new System.Drawing.Point(466, 203);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(100, 41);
            this.btn_Run.TabIndex = 3;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // lpb_Overall
            // 
            this.lpb_Overall.AddText = "";
            this.lpb_Overall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lpb_Overall.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lpb_Overall.FontColor = System.Drawing.Color.Black;
            this.lpb_Overall.ForeColor = System.Drawing.Color.LightGray;
            this.lpb_Overall.Location = new System.Drawing.Point(3, 16);
            this.lpb_Overall.Maximum = 10000;
            this.lpb_Overall.Name = "lpb_Overall";
            this.lpb_Overall.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.lpb_Overall.Size = new System.Drawing.Size(442, 22);
            this.lpb_Overall.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lpb_Overall);
            this.groupBox4.Location = new System.Drawing.Point(12, 203);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 41);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Overall progress:";
            // 
            // flp_Tasks
            // 
            this.flp_Tasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_Tasks.AutoScroll = true;
            this.flp_Tasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_Tasks.Controls.Add(this.lpb_MainFileDecode);
            this.flp_Tasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Tasks.Location = new System.Drawing.Point(12, 250);
            this.flp_Tasks.Name = "flp_Tasks";
            this.flp_Tasks.Size = new System.Drawing.Size(560, 173);
            this.flp_Tasks.TabIndex = 6;
            this.flp_Tasks.WrapContents = false;
            // 
            // lpb_MainFileDecode
            // 
            this.lpb_MainFileDecode.AddText = "Original file decode";
            this.lpb_MainFileDecode.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lpb_MainFileDecode.FontColor = System.Drawing.Color.Black;
            this.lpb_MainFileDecode.ForeColor = System.Drawing.Color.LightGray;
            this.lpb_MainFileDecode.Location = new System.Drawing.Point(3, 3);
            this.lpb_MainFileDecode.Maximum = 10000;
            this.lpb_MainFileDecode.Name = "lpb_MainFileDecode";
            this.lpb_MainFileDecode.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.lpb_MainFileDecode.Size = new System.Drawing.Size(550, 23);
            this.lpb_MainFileDecode.TabIndex = 0;
            // 
            // timer_Resize
            // 
            this.timer_Resize.Interval = 500;
            this.timer_Resize.Tick += new System.EventHandler(this.timer_Resize_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem1.Text = "About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 435);
            this.Controls.Add(this.flp_Tasks);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormMain";
            this.Text = "Easy VMAF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConvertedFiles)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.flp_Tasks.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_BrowseOrgFile;
        private System.Windows.Forms.TextBox tb_BrowseOrgFile;
        private System.Windows.Forms.Button btn_RemoveConvertedFiles;
        private System.Windows.Forms.Button btn_AddConvertedFiles;
        private System.Windows.Forms.DataGridView dgv_ConvertedFiles;
        private System.Windows.Forms.Button btn_Run;
        private LabeledProgressBar lpb_Overall;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flp_Tasks;
        private LabeledProgressBar lpb_MainFileDecode;
        private System.Windows.Forms.Timer timer_Resize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
    }
}

