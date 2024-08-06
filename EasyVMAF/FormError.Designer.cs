namespace EasyVMAF
{
    partial class FormError
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
            this.tb_Error = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_Error
            // 
            this.tb_Error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Error.Location = new System.Drawing.Point(0, 0);
            this.tb_Error.Multiline = true;
            this.tb_Error.Name = "tb_Error";
            this.tb_Error.ReadOnly = true;
            this.tb_Error.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_Error.Size = new System.Drawing.Size(800, 450);
            this.tb_Error.TabIndex = 0;
            this.tb_Error.WordWrap = false;
            // 
            // FormError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_Error);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Shown += new System.EventHandler(this.FormError_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Error;
    }
}