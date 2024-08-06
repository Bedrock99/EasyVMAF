#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace EasyVMAF
{
    public partial class FormSettings : Form
    {
        #region --- Constructor ---

        public FormSettings()
        {
            InitializeComponent();
            Icon = Properties.Resources.EasyVMAFicon;
            cb_TempInSameFolderAsSource.Checked = CConfig.CreateTempFilesInSameFolderAsSourceFiles;
            tb_BrowseTempFilesFolder.Text = CConfig.TempFilesFolder;
            cb_AutoDeleteTempFiles.Checked = CConfig.AutoDeleteTempFiles;
        }

        #endregion

        #region --- Closing ---

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to save the changes?", "Save changes?", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;
            else if(dr == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            CConfig.CreateTempFilesInSameFolderAsSourceFiles = cb_TempInSameFolderAsSource.Checked;
            CConfig.TempFilesFolder = tb_BrowseTempFilesFolder.Text;
            CConfig.AutoDeleteTempFiles = cb_AutoDeleteTempFiles.Checked;
        }

        #endregion

        #region --- Events ---

        private void cb_TempInSameFolderAsSource_CheckedChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = !cb_TempInSameFolderAsSource.Checked;
        }

        private void btn_BrowseTempFilesFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please select the folder for the temporary files...";
            fbd.SelectedPath = tb_BrowseTempFilesFolder.Text;
            fbd.ShowNewFolderButton = true;
            if(fbd.ShowDialog() == DialogResult.OK)
                tb_BrowseTempFilesFolder.Text = fbd.SelectedPath;
        }

        #endregion
    }
}
