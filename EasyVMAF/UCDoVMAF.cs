#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

#endregion

namespace EasyVMAF
{
    public partial class UCDoVMAF : UserControl
    {
        #region --- Variables ---

        public bool StopTask { get; set; } = false;
        public bool Finished { get; private set; } = false;
        public int Progress { get {  return lpb_File.Value; } }

        private string m_strOrgFile;
        private string m_strOrgFileDecoded;
        private string m_strConvFile;
        private string m_strConvFileDecoded;
        private string m_strConvFileVmaf;

        private CResult m_pResult;
        private static CResult m_pResultCompare = null;

        #endregion

        #region --- Constructor ---

        [DesignOnly(true)]
        public UCDoVMAF()
        {

        }

        public UCDoVMAF(string strOrgFile_, string strOrgFileDecoded_, string strConvFile_)
        {
            InitializeComponent();
            m_strOrgFile = strOrgFile_;
            m_strOrgFileDecoded = strOrgFileDecoded_;
            m_strConvFile = strConvFile_;
            m_strConvFileDecoded = Path.ChangeExtension(strConvFile_, ".y4m");
            if (!CConfig.CreateTempFilesInSameFolderAsSourceFiles)
                m_strConvFileDecoded = Path.Combine(CConfig.TempFilesFolder, Path.GetFileName(m_strConvFileDecoded));
            m_strConvFileVmaf = Path.ChangeExtension(strConvFile_, ".vmaf.xml");
            if (!CConfig.CreateTempFilesInSameFolderAsSourceFiles)
                m_strConvFileVmaf = Path.Combine(CConfig.TempFilesFolder, Path.GetFileName(m_strConvFileVmaf));
            lpb_File.AddText = Path.GetFileName(strConvFile_);
            Height = 30;
        }

        #endregion

        #region --- Run ---

        public Task Run()
        {
            Task t = new Task(() =>
            {
                if (!File.Exists(m_strConvFileDecoded) && !File.Exists(m_strConvFileVmaf))
                {

                    CProgressTask pDecode = CProcesses.RunFFMPEG_Decode(m_strConvFile, m_strConvFileDecoded);
                    while (pDecode.Status != TaskStatus.RanToCompletion)
                    {
                        pDecode.WantsStop = StopTask;
                        Invoke((MethodInvoker)delegate
                        {
                            lpb_File.Value = pDecode.Progress / 2;
                        });
                        Thread.Sleep(100);
                    }
                    if (StopTask)
                        return;
                }

                if (!File.Exists(m_strConvFileVmaf))
                {
                    CProgressTask pVMAF = CProcesses.RunVMAF(m_strOrgFileDecoded, m_strConvFileDecoded, m_strConvFileVmaf);
                    while (pVMAF.Status != TaskStatus.RanToCompletion)
                    {
                        pVMAF.WantsStop = StopTask;
                        Invoke((MethodInvoker)delegate
                        {
                            lpb_File.Value = (lpb_File.Maximum / 2) + pVMAF.Progress / 2;
                        });
                        Thread.Sleep(100);
                    }
                    if (StopTask)
                        return;
                }

                if(CConfig.AutoDeleteTempFiles && m_strConvFileDecoded != m_strOrgFileDecoded)
                    File.Delete(m_strConvFileDecoded);

                CalcAndShowResults();

                Invoke((MethodInvoker)delegate
                {
                    lpb_File.Value = lpb_File.Maximum;
                    if(File.Exists(m_strConvFileVmaf))
                        btn_ShowResult.Enabled = true;
                });
                Finished = true;
            });

            t.Start();
            return t;
        }

        #endregion

        #region --- Show Results ---

        private void CalcAndShowResults()
        {
            m_pResult = new CResult(m_strOrgFile, m_strConvFile, m_strConvFileDecoded, m_strConvFileVmaf);
            Invoke((MethodInvoker)delegate
            {
                Height = 50;
                lbl_VMAF_Score.Text = m_pResult.VMAF_Score;
                lbl_Filesize.Text = m_pResult.FileSize;
                lbl_BytesPerFrame.Text = m_pResult.Bitrate + "/frame";
                lbl_SizeDifference.Text = m_pResult.PercentageDifference;

                if(m_pResult.VMAF_Score == "ERROR")
                    lpb_File.ProgressColor = Color.Red;
            });
        }

        #endregion

        #region --- Buttons ---

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            compareToolStripMenuItem.Enabled = (m_pResultCompare != null);
        }

        private void setToCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_pResultCompare = m_pResult;
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormResult(m_pResult, m_pResultCompare, (FormMain)Parent.Parent).Show();
        }

        private void showResultChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormResult(m_strOrgFileDecoded, m_pResult, (FormMain)Parent.Parent).Show();
        }

        #endregion
    }
}
