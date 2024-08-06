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
                m_lstVmaf2.Add(x.YValues[0]);

            SetVideos(strOrgFile_, pCompare_.ConvertedFileDecoded);
        }

        private void SetVideos(string strVideo1_, string strVideo2_)
        { 
            if(!File.Exists(strVideo1_) || !File.Exists(strVideo2_))
            {
                lbl_CurFrame.ForeColor = Color.Red;
                lbl_CurFrame.Height = 30;
                lbl_CurFrame.Text = "One of the video files does not exist!\r\n";
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

            if (m_pReader1.FrameCount < m_pReader2.FrameCount)
                tb_Scroll.Maximum = m_pReader1.FrameCount - 1;
            else
                tb_Scroll.Maximum = m_pReader2.FrameCount - 1;
            tb_Scroll.TickFrequency = 100 / tb_Scroll.Maximum;

            ShowImage(pb_Image.Width / 2);
        }

        #endregion

        #region --- Show image ---

        private void tb_Scroll_ValueChanged(object sender, EventArgs e)
        {
            if(timerScroll.Enabled)
                timerScroll.Stop();
            timerScroll.Start();
        }

        private void timerScroll_Tick(object sender, EventArgs e)
        {
            ShowImage(pb_Image.Width / 2);
            timerScroll.Stop();
        }

        void ShowImage(int iPos_)
        {
            if (m_iLastPos == iPos_ && m_iLastFrame == tb_Scroll.Value)
                return;

            m_iLastPos = iPos_;
            tb_Scroll.Enabled = false;

            if (m_iLastFrame != tb_Scroll.Value)
            {
                m_pBitmap1 = m_pReader1.ReadFrame(tb_Scroll.Value);
                m_pBitmap2 = m_pReader2.ReadFrame(tb_Scroll.Value);
                m_iLastFrame = tb_Scroll.Value;
            }

            if (m_pBitmapDraw == null)
            {
                m_pBitmapDraw = (Bitmap)m_pBitmap1.Clone();
                m_pGraphicsDraw = Graphics.FromImage(m_pBitmapDraw);
                pb_Image.Image = m_pBitmapDraw;
                pb_Image.Size = m_pBitmapDraw.Size;
            }

            int iRealPos = Convert.ToInt32((double)m_pBitmapDraw.Width / (double)pb_Image.Width * (double)iPos_);

            m_pGraphicsDraw.Clear(Color.Black);
            m_pGraphicsDraw.DrawImage(m_pBitmap1, 0, 0, m_pBitmap1.Width, m_pBitmap1.Height);
            m_pGraphicsDraw.DrawImage(m_pBitmap2, iRealPos, 0, new Rectangle(iRealPos, 0, m_pBitmap2.Width - iRealPos, m_pBitmap2.Height), GraphicsUnit.Pixel);
            m_pGraphicsDraw.DrawLine(new Pen(Color.White), new Point(iRealPos, 0), new Point(iRealPos, m_pBitmapDraw.Height));


            pb_Image.Image = m_pBitmapDraw;

            tb_Scroll.Enabled = true;
            lbl_CurFrame.Text = $"Frame {tb_Scroll.Value + 1} of {tb_Scroll.Maximum + 1}";
            if (m_b1IsOrg)
                lbl_Vmaf1.Text = "VMAF1: Original";
            else
                lbl_Vmaf1.Text = "VMAF1: " + m_lstVmaf1[tb_Scroll.Value].ToString(); ;
                lbl_Vmaf2.Text = "VMAF2: " + m_lstVmaf2[tb_Scroll.Value].ToString(); ;
        }

        private void pb_Image_MouseMove(object sender, MouseEventArgs e)
        {
            ShowImage(e.X);

            if (e.Button == MouseButtons.Left)
            {
                MoveImageTo(
                    pb_Image.Location.X - Convert.ToInt32(Math.Floor((m_iInitMouseX - e.X) * m_dblZoom)),
                    pb_Image.Location.Y - Convert.ToInt32(Math.Floor((m_iInitMouseY - e.Y) * m_dblZoom)));
            }
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
    }
}
