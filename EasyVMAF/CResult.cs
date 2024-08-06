#region Using...

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

#endregion

namespace EasyVMAF
{
    public class CResult
    {
        #region --- Variables ---

        public string OriginalFile { get; private set; }
        public string ConvertedFile { get; private set; } 
        public string ConvertedFileDecoded { get; private set; }
        public string VmafFile { get; private set; }

        public string VMAF_Version { get; private set; } = "ERROR";
        public string VMAF_Score { get; private set; } = "ERROR";
        public string FileSize { get; private set; } = "ERROR";
        public string FileSizeDifference { get; private set; } = "ERROR";
        public string Bitrate { get; private set; } = "ERROR";
        public string BitrateDifference { get; private set; } = "ERROR";
        public string PercentageDifference { get; private set; } = "ERROR";

        private long m_lFileSize = 0;
        private long m_lBitrate = 0;

        public List<DataPoint> Chart_Series_VMAF = new List<DataPoint>();
        public List<DataPoint> Chart_Series_VMAF10 = new List<DataPoint>();
        public List<DataPoint> Chart_Series_VMAF100 = new List<DataPoint>();

        #endregion

        #region --- Constructor ---

        public CResult(string strOrgFile_, string strConvFile_, string strConvFileDecoded_, string strVmafFile_)
        {
            OriginalFile = strOrgFile_;
            ConvertedFile = strConvFile_;
            ConvertedFileDecoded = strConvFileDecoded_;
            VmafFile = strVmafFile_;

            if (!File.Exists(strOrgFile_) || !File.Exists(ConvertedFile) || !File.Exists(VmafFile))
                return;

            //Vmaf
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            XDocument xDoc = XDocument.Load(VmafFile);
            IEnumerable<XElement> xFrames = from frame in xDoc.Root.Descendants("frame")
                                            select frame;

            VMAF_Version = xDoc.Root.Attribute("version").Value;

            int iCur = 0;
            double dblAverage10 = 0;
            double dblAverage100 = 0;
            double dblLowest = 100;
            foreach (XElement xFrame in xFrames)
            {
                int iFrame = int.Parse(xFrame.Attribute("frameNum").Value);
                double dblVmaf = double.Parse(xFrame.Attribute("vmaf").Value);
                if (dblVmaf < dblLowest)
                    dblLowest = dblVmaf;

                Chart_Series_VMAF.Add(new DataPoint(iFrame, dblVmaf));
                if (iCur == 0)
                {
                    Chart_Series_VMAF10.Add(new DataPoint(iFrame, dblVmaf));
                    Chart_Series_VMAF100.Add(new DataPoint(iFrame, dblVmaf));
                }
                if (iCur != 0 && iCur % 10 == 0)
                {
                    Chart_Series_VMAF10.Add(new DataPoint(iFrame, dblAverage10 / 10.0));
                    dblAverage10 = 0;
                }
                if (iCur != 0 && iCur % 100 == 0)
                {
                    Chart_Series_VMAF100.Add(new DataPoint(iFrame, dblAverage100 / 100.0));
                    dblAverage100 = 0;
                }
                dblAverage10 += dblVmaf;
                dblAverage100 += dblVmaf;
                iCur++;
            }
            Chart_Series_VMAF10.Add(new DataPoint(iCur, dblAverage10 / (iCur % 10)));
            Chart_Series_VMAF100.Add(new DataPoint(iCur, dblAverage100 / (iCur % 100)));


            IEnumerable<XElement> xMetrics = from metric in xDoc.Root.Descendants("metric") select metric;

            foreach (XElement xMetric in xMetrics)
            {
                if (xMetric.Attribute("name").Value == "vmaf")
                {
                    VMAF_Score = xMetric.Attribute("mean").Value;
                    break;
                }
            }

            //Filesize
            FileInfo fiOrg = new FileInfo(OriginalFile);
            FileInfo fiConv = new FileInfo(ConvertedFile);

            double dblPercent = 100.0 / fiOrg.Length * fiConv.Length;
            FileSizeDifference = $"{GetSizeHumanReadAble(fiConv.Length)} of {GetSizeHumanReadAble(fiOrg.Length)} ({dblPercent:0.00} %)";
            FileSize = $"{GetSizeHumanReadAble(fiConv.Length)}";
            m_lFileSize = fiConv.Length;
            PercentageDifference = $"{dblPercent:0.00} %";

            //Bitrate
            long lOrg = fiOrg.Length / xFrames.Count();
            m_lBitrate = fiConv.Length / xFrames.Count();
            dblPercent = 100.0 / lOrg * m_lBitrate;
            BitrateDifference = $"{GetSizeHumanReadAble(m_lBitrate)} of {GetSizeHumanReadAble(lOrg)} ({dblPercent:0.00} %)";
            Bitrate = $"{GetSizeHumanReadAble(m_lBitrate)}";
        }

        #endregion

        #region --- Get compared differences ---

        public string GetFileSizeDiff(CResult pCompare_)
        {
            double dblPercent = 100.0 / pCompare_.m_lFileSize * m_lFileSize;
            return $"{GetSizeHumanReadAble(m_lFileSize)} vs. {GetSizeHumanReadAble(pCompare_.m_lFileSize)} ({dblPercent:0.00} %)";
        }

        public string GetBitrateSizeDiff(CResult pCompare_)
        {
            double dblPercent = 100.0 / pCompare_.m_lBitrate * m_lBitrate;
            return $"{GetSizeHumanReadAble(m_lBitrate)} vs. {GetSizeHumanReadAble(pCompare_.m_lBitrate)} ({dblPercent:0.00} %)";
        }

        #endregion

        #region --- Get size human readable ---

        public static string GetSizeHumanReadAble(long lSize_, string format = "0.##")
        {
            string strType = " B";
            double dblReturn = Convert.ToDouble(lSize_);

            if (dblReturn / 1024.0 > 1)
            {
                dblReturn = dblReturn / 1024.0;
                strType = " KB";
                if (dblReturn / 1024.0 > 1)
                {
                    dblReturn = dblReturn / 1024.0;
                    strType = " MB";
                    if (dblReturn / 1024.0 > 1)
                    {
                        dblReturn = dblReturn / 1024.0;
                        strType = " GB";
                        if (dblReturn / 1024.0 > 1)
                        {
                            dblReturn = dblReturn / 1024.0;
                            strType = " TB";
                        }
                    }
                }
            }
            return dblReturn.ToString(format) + strType;
        }

        #endregion
    }
}
