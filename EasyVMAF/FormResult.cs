#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

#endregion

namespace EasyVMAF
{
    public partial class FormResult : Form
    {
        //TODO Show Video frame when going on chart?

        #region --- Variables ---

        private CResult m_pResult;
        private CResult m_pCompare;

        #endregion

        #region --- Constructor / Shown ---

        public FormResult(CResult pResult_, FormMain f_)
        {
            InitializeComponent();
            Icon = Properties.Resources.EasyVMAFicon;
            m_pResult = pResult_;
            Point p = new Point(f_.Left + f_.Width / 2 - Width / 2, f_.Top + f_.Height / 2 - Height / 2);
            Location = p;

            LoadInfos();
        }

        public FormResult(CResult pResult_, CResult pCompare_, FormMain f_)
        {
            InitializeComponent();
            Icon = Properties.Resources.EasyVMAFicon;
            m_pResult = pResult_;
            m_pCompare = pCompare_;
            Point p = new Point(f_.Left + f_.Width / 2 - Width / 2, f_.Top + f_.Height / 2 - Height / 2);
            Location = p;

            LoadCompare();
        }

        #endregion

        #region --- Load infos ---

        void LoadInfos()
        {
            Text = $"Results for {Path.GetFileName(m_pResult.ConvertedFile)}";

            lbl_VMAF_Version.Text = m_pResult.VMAF_Version;
            lbl_VMAF_Score.Text = m_pResult.VMAF_Score;
            lbl_FileSize.Text = m_pResult.FileSizeDifference;
            lbl_Bitrate.Text = m_pResult.BitrateDifference;

            AddChartSeries(Path.GetFileName(m_pResult.ConvertedFile), SeriesChartType.Area, m_pResult.Chart_Series_VMAF, Color.Green);
            AddChartSeries(Path.GetFileName(m_pResult.ConvertedFile) + " (Average 10)", SeriesChartType.Line, m_pResult.Chart_Series_VMAF10, Color.Blue);
            AddChartSeries(Path.GetFileName(m_pResult.ConvertedFile) + " (Average 100)", SeriesChartType.Line, m_pResult.Chart_Series_VMAF100, Color.Magenta);

            ChartArea chartArea = chart_vmaf.ChartAreas[0];
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisY.ScaleView.Zoomable = true;
            chartArea.CursorX.AutoScroll = true;
            chartArea.CursorY.AutoScroll = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorY.IsUserSelectionEnabled = true;
        }

        #endregion

        #region --- Load compare ---

        void LoadCompare()
        {
            Text = $"Results for {Path.GetFileName(m_pResult.ConvertedFile)} vs. {Path.GetFileName(m_pCompare.ConvertedFile)}";

            lbl_VMAF_Version.Text = m_pResult.VMAF_Version + " vs. " + m_pCompare.VMAF_Version;
            lbl_VMAF_Score.Text = m_pResult.VMAF_Score + " vs. " + m_pCompare.VMAF_Score;
            lbl_FileSize.Text = m_pResult.GetFileSizeDiff(m_pCompare);
            lbl_Bitrate.Text = m_pResult.GetBitrateSizeDiff(m_pCompare);

            if (double.Parse(m_pCompare.VMAF_Score) > double.Parse(m_pResult.VMAF_Score))
            {
                AddChartSeries(Path.GetFileName(m_pCompare.ConvertedFile), SeriesChartType.Area, m_pCompare.Chart_Series_VMAF, Color.Green);
                AddChartSeries(Path.GetFileName(m_pCompare.ConvertedFile) + " (Average 10)", SeriesChartType.Line, m_pCompare.Chart_Series_VMAF10, Color.FromArgb(64,64,255));
                AddChartSeries(Path.GetFileName(m_pCompare.ConvertedFile) + " (Average 100)", SeriesChartType.Line, m_pCompare.Chart_Series_VMAF100, Color.Magenta);
            }
            AddChartSeries(Path.GetFileName(m_pResult.ConvertedFile), SeriesChartType.Area, m_pResult.Chart_Series_VMAF, Color.Lime);
            AddChartSeries(Path.GetFileName(m_pResult.ConvertedFile) + " (Average 10)", SeriesChartType.Line, m_pResult.Chart_Series_VMAF10, Color.DarkBlue);
            AddChartSeries(Path.GetFileName(m_pResult.ConvertedFile) + " (Average 100)", SeriesChartType.Line, m_pResult.Chart_Series_VMAF100, Color.DeepPink);

            if (double.Parse(m_pCompare.VMAF_Score) <= double.Parse(m_pResult.VMAF_Score))
            {
                AddChartSeries(Path.GetFileName(m_pCompare.ConvertedFile), SeriesChartType.Area, m_pCompare.Chart_Series_VMAF, Color.Green);
                AddChartSeries(Path.GetFileName(m_pCompare.ConvertedFile) + " (Average 10)", SeriesChartType.Line, m_pCompare.Chart_Series_VMAF10, Color.FromArgb(64, 64, 255));
                AddChartSeries(Path.GetFileName(m_pCompare.ConvertedFile) + " (Average 100)", SeriesChartType.Line, m_pCompare.Chart_Series_VMAF100, Color.Magenta);
            }

            ChartArea chartArea = chart_vmaf.ChartAreas[0];
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisY.ScaleView.Zoomable = true;
            chartArea.CursorX.AutoScroll = true;
            chartArea.CursorY.AutoScroll = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorY.IsUserSelectionEnabled = true;
        }

        #endregion

        #region --- Add series to chart ---

        void AddChartSeries(string strName, SeriesChartType type_, List<DataPoint> lstPoints_, Color clr_)
        {
            chart_vmaf.Series.Add(strName);
            chart_vmaf.Series[strName].ChartType = type_;
            chart_vmaf.Series[strName].Color = clr_;
            foreach (DataPoint p in lstPoints_)
                chart_vmaf.Series[strName].Points.Add(p);
        }

        #endregion
    }
}
