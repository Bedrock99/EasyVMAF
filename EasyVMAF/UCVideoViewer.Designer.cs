namespace EasyVMAF
{
    partial class UCVideoViewer
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
            this.tb_Scroll = new System.Windows.Forms.TrackBar();
            this.timerScroll = new System.Windows.Forms.Timer(this.components);
            this.pb_Image = new System.Windows.Forms.PictureBox();
            this.lbl_CurFrame = new System.Windows.Forms.Label();
            this.p_Image = new PanelNoScroll();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Vmaf2 = new System.Windows.Forms.Label();
            this.lbl_Vmaf1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Scroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).BeginInit();
            this.p_Image.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Scroll
            // 
            this.tb_Scroll.AutoSize = false;
            this.tb_Scroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_Scroll.Location = new System.Drawing.Point(0, 191);
            this.tb_Scroll.Name = "tb_Scroll";
            this.tb_Scroll.Size = new System.Drawing.Size(478, 26);
            this.tb_Scroll.TabIndex = 0;
            this.tb_Scroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_Scroll.ValueChanged += new System.EventHandler(this.tb_Scroll_ValueChanged);
            // 
            // timerScroll
            // 
            this.timerScroll.Interval = 500;
            this.timerScroll.Tick += new System.EventHandler(this.timerScroll_Tick);
            // 
            // pb_Image
            // 
            this.pb_Image.Location = new System.Drawing.Point(3, 3);
            this.pb_Image.Name = "pb_Image";
            this.pb_Image.Size = new System.Drawing.Size(97, 65);
            this.pb_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Image.TabIndex = 1;
            this.pb_Image.TabStop = false;
            this.pb_Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_Image_MouseDown);
            this.pb_Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_Image_MouseMove);
            // 
            // lbl_CurFrame
            // 
            this.lbl_CurFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_CurFrame.Location = new System.Drawing.Point(153, 0);
            this.lbl_CurFrame.Name = "lbl_CurFrame";
            this.lbl_CurFrame.Size = new System.Drawing.Size(172, 23);
            this.lbl_CurFrame.TabIndex = 2;
            this.lbl_CurFrame.Text = "Frame - of -";
            this.lbl_CurFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_Image
            // 
            this.p_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_Image.AutoScroll = true;
            this.p_Image.Controls.Add(this.pb_Image);
            this.p_Image.Location = new System.Drawing.Point(0, 0);
            this.p_Image.Name = "p_Image";
            this.p_Image.Size = new System.Drawing.Size(478, 165);
            this.p_Image.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Vmaf2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_CurFrame, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Vmaf1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 168);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 23);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbl_Vmaf2
            // 
            this.lbl_Vmaf2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Vmaf2.Location = new System.Drawing.Point(331, 0);
            this.lbl_Vmaf2.Name = "lbl_Vmaf2";
            this.lbl_Vmaf2.Size = new System.Drawing.Size(144, 23);
            this.lbl_Vmaf2.TabIndex = 4;
            this.lbl_Vmaf2.Text = "-";
            this.lbl_Vmaf2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Vmaf1
            // 
            this.lbl_Vmaf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Vmaf1.Location = new System.Drawing.Point(3, 0);
            this.lbl_Vmaf1.Name = "lbl_Vmaf1";
            this.lbl_Vmaf1.Size = new System.Drawing.Size(144, 23);
            this.lbl_Vmaf1.TabIndex = 3;
            this.lbl_Vmaf1.Text = "-";
            this.lbl_Vmaf1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCVideoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.p_Image);
            this.Controls.Add(this.tb_Scroll);
            this.Name = "UCVideoViewer";
            this.Size = new System.Drawing.Size(478, 217);
            ((System.ComponentModel.ISupportInitialize)(this.tb_Scroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).EndInit();
            this.p_Image.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar tb_Scroll;
        private System.Windows.Forms.PictureBox pb_Image;
        private System.Windows.Forms.Timer timerScroll;
        private System.Windows.Forms.Label lbl_CurFrame;
        private PanelNoScroll p_Image;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Vmaf2;
        private System.Windows.Forms.Label lbl_Vmaf1;
    }
}
