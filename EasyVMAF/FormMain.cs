#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace EasyVMAF
{
    public partial class FormMain : Form
    {
        #region --- Variables ---

        const int SCROLLWIDTH = 25;

        private BindingList<CFile> m_lstConvertedFiles = new BindingList<CFile>();
        private Task m_MainTask = null;
        private bool m_bStopTask = false;
        private bool m_bMainFileDecodeFinished = false;

        #endregion

        #region --- Constructor and Closing ---

        public FormMain()
        {
            InitializeComponent();
            Icon = Properties.Resources.EasyVMAFicon;
            Text = Text + " - v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            CConfig.Load();
            CConfig.LoadForm(this);
            dgv_ConvertedFiles.DataSource = m_lstConvertedFiles;
            dgv_ConvertedFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

#if DEBUG
            tb_BrowseOrgFile.Text = @"Y:\_TEST_HANDBRAKE\TerminatorGenisys_1.mkv";
            m_lstConvertedFiles.Add(new CFile(@"Y:\_TEST_HANDBRAKE\TerminatorGenisys_1.mkv"));
            foreach(FileInfo f in new DirectoryInfo(@"Y:\_TEST_HANDBRAKE\AV1_5").GetFiles("*.mp4"))
                m_lstConvertedFiles.Add(new CFile(f.FullName));
            foreach (FileInfo f in new DirectoryInfo(@"Y:\_TEST_HANDBRAKE\x264_veryslow").GetFiles("*.mp4"))
                m_lstConvertedFiles.Add(new CFile(f.FullName));
            foreach (FileInfo f in new DirectoryInfo(@"Y:\_TEST_HANDBRAKE\x265_veryslow").GetFiles("*.mp4"))
                m_lstConvertedFiles.Add(new CFile(f.FullName));
            foreach (FileInfo f in new DirectoryInfo(@"Y:\_TEST_HANDBRAKE\AV1_1").GetFiles("*.mp4"))
                m_lstConvertedFiles.Add(new CFile(f.FullName));
            foreach (FileInfo f in new DirectoryInfo(@"Y:\_TEST_HANDBRAKE\AV1_NVENC").GetFiles("*.mp4"))
                m_lstConvertedFiles.Add(new CFile(f.FullName));
#endif
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            while(m_MainTask != null && m_MainTask.Status == TaskStatus.Running)
            {
                m_bStopTask = true;
                Application.DoEvents();
            }
            CConfig.Save();
            CConfig.SaveForm(this);
        }

        #endregion

        #region --- Menu items ----

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSettings().ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutBox_EasyVMAF().ShowDialog();
        }

        #endregion

        #region --- Buttons for Files ---

        private void btn_BrowseOrgFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video files|*.mp4;*.mkv";
            ofd.Multiselect = false;
            ofd.RestoreDirectory = string.IsNullOrEmpty(tb_BrowseOrgFile.Text);
            ofd.Title = "Please select original video file";
            if (File.Exists(tb_BrowseOrgFile.Text))
            {
                ofd.InitialDirectory = Path.GetDirectoryName(tb_BrowseOrgFile.Text);
                ofd.FileName = tb_BrowseOrgFile.Text;
            }
            if(ofd.ShowDialog() == DialogResult.OK)
                tb_BrowseOrgFile.Text = ofd.FileName;
        }

        private void btn_AddConvertedFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video files|*.mp4;*.mkv";
            ofd.Multiselect = true;
            ofd.RestoreDirectory = true;
            ofd.Title = "Please select original video file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                    m_lstConvertedFiles.Add(new CFile(file));
            }
        }

        private void btn_RemoveConvertedFiles_Click(object sender, EventArgs e)
        {
            while(dgv_ConvertedFiles.SelectedRows.Count > 0)
                dgv_ConvertedFiles.Rows.Remove(dgv_ConvertedFiles.SelectedRows[0]);
        }

        #endregion

        #region --- Run ---

        private void btn_Run_Click(object sender, EventArgs e)
        {
            if(btn_Run.Text == "Abort")
            {
                m_bStopTask = true;
                return;
            }
            else if(btn_Run.Text == "Reset")
            {
                lpb_MainFileDecode.Value = 0;
                lpb_Overall.Value = 0;
                for (int i = 0; i < flp_Tasks.Controls.Count; i++)
                {
                    if (flp_Tasks.Controls[i].GetType() == typeof(UCDoVMAF))
                    {
                        flp_Tasks.Controls.RemoveAt(i);
                        i--;
                    }
                }
                btn_Run.Text = "Run";
                EnableControl(true);
                return;
            }

            string strError = "";
            if(!File.Exists(tb_BrowseOrgFile.Text))
            {
                strError += $"- Main file '{tb_BrowseOrgFile.Text}' does not exist!\r\n";
            }
            if (m_lstConvertedFiles.Count <= 0)
            {
                strError += $"- No Files to compare to!\r\n";
            }
            else
            {
                foreach (CFile file in m_lstConvertedFiles)
                    if(!File.Exists(file.File))
                        strError += $"- Compare file '{file.File}' does not exist!\r\n";
            }

            if(!string.IsNullOrWhiteSpace(strError))
            {
                FormError.ShowError("Error", "Cannot run because of the following errors:\r\n" + strError);
                return;
            }

            m_bStopTask = false;
            btn_Run.Text = "Abort";
            EnableControl(false);
            string strMainFile = tb_BrowseOrgFile.Text;
            string strMainDecodedFile = Path.ChangeExtension(strMainFile, ".y4m");
            if(!CConfig.CreateTempFilesInSameFolderAsSourceFiles)
                strMainDecodedFile = Path.Combine(CConfig.TempFilesFolder, Path.GetFileName(strMainDecodedFile));
            foreach (CFile file in m_lstConvertedFiles)
            {
                UCDoVMAF uc = new UCDoVMAF(strMainFile, strMainDecodedFile, file.File);
                uc.Size = new Size(flp_Tasks.Width - SCROLLWIDTH, uc.Height);

                flp_Tasks.Controls.Add(uc);
            }
            UpdateSizes();

            m_MainTask = new Task(() =>
            {
                if (!File.Exists(strMainDecodedFile))
                {
                    CProgressTask pDecode = CProcesses.RunFFMPEG_Decode(strMainFile, strMainDecodedFile);
                    while (pDecode.Status != TaskStatus.RanToCompletion)
                    {
                        pDecode.WantsStop = m_bStopTask;
                        Invoke((MethodInvoker)delegate
                        {
                            lpb_MainFileDecode.Value = pDecode.Progress;
                        });
                        CalcOverallProgress();
                        Thread.Sleep(100);
                    }
                }

                m_bMainFileDecodeFinished = true;
                Invoke((MethodInvoker)delegate
                {
                    lpb_MainFileDecode.Value = lpb_MainFileDecode.Maximum;
                });
                CalcOverallProgress();

                //Run UCs (decode and vmaf)
                foreach (Control c in flp_Tasks.Controls)
                {
                    if (m_bStopTask)
                        break;

                    if (c.GetType() == typeof(UCDoVMAF))
                    {
                        UCDoVMAF uc = c as UCDoVMAF;
                        Task t = uc.Run();
                        while (t.Status != TaskStatus.RanToCompletion)
                        {
                            Thread.Sleep(100);
                            if (m_bStopTask)
                                uc.StopTask = true;

                            CalcOverallProgress();
                        }
                    }
                }

                if (CConfig.AutoDeleteTempFiles)
                    File.Delete(strMainDecodedFile);

                CalcOverallProgress();
                Invoke((MethodInvoker)delegate
                {
                    btn_Run.Text = "Reset";
                    btn_Run.Enabled = true;
                });
            });

            m_MainTask.Start();
        }

        #endregion

        #region --- Calc progress + EnableControl --

        void CalcOverallProgress()
        {
            Invoke((MethodInvoker)delegate 
            {
                int iCount = flp_Tasks.Controls.Count;
                int iCur = 1;
                int iProgress = lpb_MainFileDecode.Value;
                if (m_bMainFileDecodeFinished)
                {
                    iCur++;
                    foreach (Control c in flp_Tasks.Controls)
                    {
                        if (c.GetType() == typeof(UCDoVMAF))
                        {
                            iProgress += ((UCDoVMAF)c).Progress;
                            if (((UCDoVMAF)c).Finished)
                                iCur++;
                        }
                    }
                }
                lpb_Overall.Value = iProgress / iCount;
                if (iCur > iCount)
                    lpb_Overall.AddText = "All Tasks finished!";
                else
                    lpb_Overall.AddText = $"Task {iCur} of {iCount}";
            });
        }

        void EnableControl(bool bEnabled_)
        {
            menuStrip1.Enabled = bEnabled_;
            btn_BrowseOrgFile.Enabled = bEnabled_;
            btn_AddConvertedFiles.Enabled = bEnabled_;
            btn_RemoveConvertedFiles.Enabled = bEnabled_;
        }

        #endregion

        #region --- Resize ---

        private void FormMain_Resize(object sender, EventArgs e)
        {
            UpdateSizes();
            timer_Resize.Stop();
            timer_Resize.Start();
        }

        private void timer_Resize_Tick(object sender, EventArgs e)
        {
            UpdateSizes();
        }

        void UpdateSizes()
        {
            foreach (Control c in flp_Tasks.Controls)
                c.Size = new Size(flp_Tasks.Width - SCROLLWIDTH, c.Height);
        }

        #endregion
    }
}
