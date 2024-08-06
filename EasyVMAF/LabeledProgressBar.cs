#region Using...

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace EasyVMAF
{
    public class LabeledProgressBar : ProgressBar
    {
        #region --- Variables ---

        int m_iValForText;

        Timer m_MarqueeTimer = new Timer();
        double m_dblMarqueeStart = -1.0;
        Color m_pFontColor = Color.Black;

        public Color ProgressColor { get; set; } = Color.FromArgb(0, 200, 0);
        private string m_strAddText = "";
        public string AddText
        {
            get
            {
                return m_strAddText;
            }
            set
            {
                m_strAddText = value;
                Refresh();
            }
        }

        public Color FontColor
        {
            set
            {
                m_pFontColor = value;
                Refresh();
            }
            get
            {
                return m_pFontColor;
            }
        }

        public new int Value
        {
            set
            {
                if (value > Maximum)
                    base.Value = Maximum;
                else
                    base.Value = value;
                m_iValForText = value;
                base.Value = value;
                Refresh();
            }
            get
            {
                return base.Value;
            }
        }

        public new ProgressBarStyle Style
        {
            set
            {
                base.Style = value;
                Refresh();
            }
            get
            {
                return base.Style;
            }
        }

        #endregion

        #region --- Constructor ---

        public LabeledProgressBar()
        {
            ForeColor = Color.LightGray;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            m_MarqueeTimer.Interval = 16;
            m_MarqueeTimer.Tick += M_MarqueeTimer_Tick;
            Font = new Font("Consolas", Height - 10, GraphicsUnit.Pixel);
            m_iValForText = 0;
        }

        #endregion

        #region --- OnPaint ---

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            e.Graphics.DrawRectangle(new Pen(ForeColor), 0, 0, Width - 1, Height - 1);

            if (Style == ProgressBarStyle.Marquee)
            {
                Color pColor = ProgressColor;
                SolidBrush pBrush = new SolidBrush(pColor);

                if (m_dblMarqueeStart == -1.0)
                    m_dblMarqueeStart = 0.0 - ((double)Maximum / 20.0);

                int iMarqueeStart = Convert.ToInt32(m_dblMarqueeStart);
                int iMarqueeWidth = Maximum / 20;
                if (iMarqueeStart < 0)
                {
                    iMarqueeWidth = iMarqueeWidth + iMarqueeStart;
                    iMarqueeStart = 1;
                }
                if (iMarqueeStart + iMarqueeWidth >= Width - 1)
                    iMarqueeWidth = (Width - 1) - iMarqueeStart;

                e.Graphics.FillRectangle(pBrush, iMarqueeStart, 1, iMarqueeWidth, Height - 1);

                if (!m_MarqueeTimer.Enabled)
                    m_MarqueeTimer.Start();
            }
            else
            {
                SolidBrush pBrush = new SolidBrush(ProgressColor);

                int iProgressWidth = Convert.ToInt32(Math.Round((double)(Width - 1) / (double)Maximum * (double)Value));
                e.Graphics.FillRectangle(pBrush, 1, 1, iProgressWidth, Height - 1);

                string strText = "";
                if(!string.IsNullOrWhiteSpace(AddText))
                    strText = AddText + " - ";
                if (m_iValForText == 0)
                    strText += (100.0 / (double)Maximum * (double)Value).ToString("0.00") + " %";
                else
                    strText += (100.0 / (double)Maximum * (double)m_iValForText).ToString("0.00") + " %";
                SizeF sTextSize = e.Graphics.MeasureString(strText, Font);
                e.Graphics.DrawString(strText, Font, new SolidBrush(m_pFontColor), Width / 2 - sTextSize.Width / 2, Height / 2 - sTextSize.Height / 2);
            }
        }

        #endregion

        #region --- Marquee Timer Tick ---

        private void M_MarqueeTimer_Tick(object sender, EventArgs e)
        {
            m_dblMarqueeStart += (double)MarqueeAnimationSpeed / (double)Maximum * 5.0;
            if (m_dblMarqueeStart >= Width)
                m_dblMarqueeStart = 0.0 - ((double)Maximum / 20.0);

            if (Style != ProgressBarStyle.Marquee)
                m_MarqueeTimer.Stop();

            Refresh();
        }

        #endregion
    }
}
