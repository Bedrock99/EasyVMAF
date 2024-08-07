#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace EasyVMAF
{
    public partial class UCVideoViewer : UserControl
    {
        #region --- Variables ---

        const int SCROLLWIDTH = 20;
        const double ZOOMDELTA = 0.05;
        const double MIN_ZOOM = 0.2;
        const double MAX_ZOOM = 3.0;

        Cy4mReader m_pReader1 = new Cy4mReader();
        Cy4mReader m_pReader2 = new Cy4mReader();
        bool m_b1IsOrg = false;
        string m_strFile1 = "";
        string m_strFile2 = "";
        List<double> m_lstVmaf1 = new List<double>();
        List<double> m_lstVmaf2 = new List<double>();

        Bitmap m_pBitmapDraw = null;
        Graphics m_pGraphicsDraw = null;

        Bitmap m_pBitmap1 = null;
        Bitmap m_pBitmap2 = null;

        int m_iLastFrame = -1;
        int m_iLastPos = -1;
        double m_dblZoom = 1.0;
        int m_iInitMouseX = -1;
        int m_iInitMouseY = -1;

        #endregion

        #region --- Constructor / Close ---

        public UCVideoViewer()
        {
            InitializeComponent();
            p_Image.MyMouseWheel += p_Image_MouseWheel;
        }

        public void Close()
        {
            m_pReader1.Close();
            m_pReader2.Close();
        }

        #endregion

        #region --- Set videos ---

        public void SetVideos(CResult pOrg_, CResult pCompare_)
        {
            foreach (var x in pOrg_.Chart_Series_VMAF)
                m_lstVmaf1.Add(x.YValues[0]);

            foreach (var x in pCompare_.Chart_Series_VMAF)
                m_lstVmaf2.Add(x.YValues[0]);

            SetVideos(pOrg_.ConvertedFileDecoded, pCompare_.ConvertedFileDecoded);
        }

        public void SetVideos(string strOrgFile_, CResult pCompare_)
        {
            m_b1IsOrg = true;
            foreach (var x in pCompare_.Chart_Series_VMAF)
                m_lstVmaf1.Add(x.YValues[0]);

            SetVideos(pCompare_.ConvertedFileDecoded, strOrgFile_);
        }

        private void SetVideos(string strVideo1_, string strVideo2_)
        { 
            if(!File.Exists(strVideo1_) || !File.Exists(strVideo2_))
            {
                lbl_CurFrame.ForeColor = Color.Red;
                lbl_CurFrame.Height = 30;
                lbl_CurFrame.Text = "One of the video files does not exist!";
                if (CConfig.AutoDeleteTempFiles)
                    lbl_CurFrame.Text += "Please turn off 'Delete temporary files automatically' in settings.";
                tb_Scroll.Enabled = false;
                return;
            }

            if(!m_pReader1.ReadFile(strVideo1_) || !m_pReader2.ReadFile(strVideo2_))
            {
                lbl_CurFrame.ForeColor = Color.Red;
                lbl_CurFrame.Height = 30;
                lbl_CurFrame.Text = "Failed to read the files!";
                tb_Scroll.Enabled = false;
                return;
            }

            m_strFile1 = Path.GetFileNameWithoutExtension(strVideo1_);
            m_strFile2 = Path.GetFileNameWithoutExtension(strVideo2_);

            if (m_pReader1.FrameCount < m_pReader2.FrameCount)
                tb_Scroll.Maximum = m_pReader1.FrameCount - 1;
            else
                tb_Scroll.Maximum = m_pReader2.FrameCount - 1;
            tb_Scroll.TickFrequency = 100 / tb_Scroll.Maximum;

            ShowImage(tb_Scroll.Value, pb_Image.Width / 2);
        }

        #endregion

        #region --- Show image ---

        bool m_bLoadingFrame = false;
        bool m_bNeedsLoadingFrame = false;

        private void tb_Scroll_ValueChanged(object sender, EventArgs e)
        {
            lbl_CurFrame.Text = $"Frame\r\n{tb_Scroll.Value + 1} / {tb_Scroll.Maximum + 1}";
            if(m_bLoadingFrame)
            {
                m_bNeedsLoadingFrame = true;
                return;
            }
            m_bLoadingFrame = true;
            new Task(() =>
            {
                do
                {
                    m_bNeedsLoadingFrame = false;
                    int iFrame = 0;
                    int iPos = 0;
                    Invoke((MethodInvoker)delegate
                    {
                        iFrame = tb_Scroll.Value;
                        iPos = pb_Image.Width / 2;
                    });
                    ShowImage(iFrame, iPos);
                } while (m_bNeedsLoadingFrame);
                m_bLoadingFrame = false;
            }).Start();
        }

        void ShowImage(int iFrame_, int iPos_)
        {
            if (m_iLastPos == iPos_ && m_iLastFrame == iFrame_)
                return;

            m_iLastPos = iPos_;

            if (m_iLastFrame != iFrame_)
            {
                m_pBitmap1 = m_pReader1.ReadFrame(iFrame_);
                m_pBitmap2 = m_pReader2.ReadFrame(iFrame_);
                m_iLastFrame = iFrame_;
            }

            if (m_pBitmapDraw == null)
            {
                m_pBitmapDraw = (Bitmap)m_pBitmap1.Clone();
                m_pGraphicsDraw = Graphics.FromImage(m_pBitmapDraw);
                pb_Image.Image = m_pBitmapDraw;
                Invoke((MethodInvoker)delegate
                {
                    pb_Image.Size = m_pBitmapDraw.Size;
                });
            }

            int iRealPos = Convert.ToInt32((double)m_pBitmapDraw.Width / (double)pb_Image.Width * (double)iPos_);

            m_pGraphicsDraw.Clear(Color.Black);
            m_pGraphicsDraw.DrawImage(m_pBitmap1, 0, 0, m_pBitmap1.Width, m_pBitmap1.Height);
            m_pGraphicsDraw.DrawImage(m_pBitmap2, iRealPos, 0, new Rectangle(iRealPos, 0, m_pBitmap2.Width - iRealPos, m_pBitmap2.Height), GraphicsUnit.Pixel);
            m_pGraphicsDraw.DrawLine(new Pen(Color.White), new Point(iRealPos, 0), new Point(iRealPos, m_pBitmapDraw.Height));

            Invoke((MethodInvoker)delegate
            {
                pb_Image.Image = m_pBitmapDraw;

                tb_Scroll.Enabled = true;
                lbl_CurFrame.Text = $"Frame\r\n{tb_Scroll.Value + 1} / {tb_Scroll.Maximum + 1}";
                if (m_b1IsOrg)
                    lbl_Vmaf2.Text = "VMAF1: 100.0\r\n" + m_strFile2;
                else
                    lbl_Vmaf2.Text = "VMAF2: " + m_lstVmaf2[tb_Scroll.Value].ToString() + "\r\n" + m_strFile2;
                lbl_Vmaf1.Text = "VMAF1: " + m_lstVmaf1[tb_Scroll.Value].ToString() + "\r\n" + m_strFile1;
            });
            
        }

        private void pb_Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bLoadingFrame)
                return;

            m_bLoadingFrame = true;
            ShowImage(tb_Scroll.Value, e.X);

            if (e.Button == MouseButtons.Left)
            {
                MoveImageTo(
                    pb_Image.Location.X - Convert.ToInt32(Math.Floor((m_iInitMouseX - e.X) * m_dblZoom)),
                    pb_Image.Location.Y - Convert.ToInt32(Math.Floor((m_iInitMouseY - e.Y) * m_dblZoom)));
            }
            m_bLoadingFrame = false;
        }

        #endregion

        #region --- Zoom ---

        private void p_Image_MouseWheel(object sender, MouseEventArgs e)
        {
            double adjustedZoomFactor = ZOOMDELTA * m_dblZoom;

            if (e.Delta > 0)
                SetZoom(m_dblZoom + adjustedZoomFactor);
            else if (e.Delta < 0)
                SetZoom(m_dblZoom - adjustedZoomFactor);
        }

        void SetZoom(double dblZoom_)
        {
            double dblOldZoom = m_dblZoom;
            if (dblZoom_ < MIN_ZOOM)
                m_dblZoom = MIN_ZOOM;
            else if (dblZoom_ > MAX_ZOOM)
                m_dblZoom = MAX_ZOOM;
            else
                m_dblZoom = dblZoom_;

            pb_Image.Width = Convert.ToInt32(m_pBitmapDraw.Width * dblZoom_);
            pb_Image.Height = Convert.ToInt32(m_pBitmapDraw.Height * dblZoom_);

            p_Image.HorizontalScroll.Value = Convert.ToInt32(p_Image.HorizontalScroll.Value / dblOldZoom * m_dblZoom);
            p_Image.VerticalScroll.Value = Convert.ToInt32(p_Image.VerticalScroll.Value / dblOldZoom * m_dblZoom);
        }

        #endregion

        #region --- Move Image ---

        private void pb_Image_MouseDown(object sender, MouseEventArgs e)
        {
            m_iInitMouseX = e.X;
            m_iInitMouseY = e.Y;
            pb_Image_MouseMove(sender, e);
        }

        void MoveImageTo(int x, int y)
        {
            if (x > 0)
                x = 0;
            if (p_Image.Width < pb_Image.Width)
            {
                if (x < pb_Image.Width * -1 + p_Image.Width - SCROLLWIDTH)
                    x = pb_Image.Width * -1 + p_Image.Width - SCROLLWIDTH;
            }
            else
                x = 0;

            if (y > 0)
                y = 0;
            if (p_Image.Height < pb_Image.Height)
            {
                if (y < pb_Image.Height * -1 + p_Image.Height - SCROLLWIDTH)
                    y = pb_Image.Height * -1 + p_Image.Height - SCROLLWIDTH;
            }
            else
                y = 0;

            x = x * -1;
            y = y * -1;
            try
            {
                p_Image.HorizontalScroll.Value = x;
                p_Image.VerticalScroll.Value = y;
            }
            catch { }
        }

        #endregion

        #region --- Go to video frame ---

        public void GoToFrame(int iFrame_)
        {
            tb_Scroll.Value = iFrame_;
            ShowImage(iFrame_, pb_Image.Width / 2);
        }

        #endregion
    }
}
