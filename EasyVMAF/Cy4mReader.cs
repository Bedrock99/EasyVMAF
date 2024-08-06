#region Using...

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace EasyVMAF
{
    public class Cy4mReader
    {
        #region --- Variables ---

        string m_strFile = "";
        FileStream m_fsFileStream = null;

        public int StartFrameByte { get; private set; } = 0;
        public int FrameSize { get; private set; } = 0;
        public int FrameSizeLuminance { get; private set; } = 0;
        public int FrameSizeColor { get; private set; } = 0;

        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;
        public double FPS { get; private set; } = 0;
        public double ByteSize { get; private set; } = 0;
        public string YUV_Forma { get; private set; } = "";
        public int FrameCount { get; private set; } = 0;

        #endregion

        #region --- ReadFile ---

        public bool ReadFile(string strFile_)
        {
            m_strFile = strFile_;
            try
            {
                m_fsFileStream = new FileStream(m_strFile, FileMode.Open);
            }
            catch
            {
                return false;
            }

            ReadHeader();
            return true;
        }

        #region -- Read Header --

        void ReadHeader()
        {
            string strHeader = "";
            byte[] buffer = new byte[1024];
            while (m_fsFileStream.Read(buffer, 0, buffer.Length) > 0)
            {
                string strRed = Encoding.UTF8.GetString(buffer);
                if (!strRed.Contains("FRAME"))
                    strHeader += strRed;
                else
                {
                    strHeader = strRed.Substring(0, strRed.IndexOf("FRAME"));
                    break;
                }

            }

            StartFrameByte = strHeader.Length;

            //Header Example:
            //YUV4MPEG2 W1920 H1080 F24000:1001 Ip A1:1 C420mpeg2 XYSCSS=420MPEG2

            while (strHeader.Length > 0)
            {
                if (strHeader.StartsWith("W"))
                {
                    int iCut = strHeader.IndexOf(" ");
                    Width = int.Parse(strHeader.Substring(1, iCut - 1));
                    strHeader = strHeader.Substring(iCut);
                }
                else if (strHeader.StartsWith("H"))
                {
                    int iCut = strHeader.IndexOf(" ");
                    Height = int.Parse(strHeader.Substring(1, iCut - 1));
                    strHeader = strHeader.Substring(iCut);
                }
                else if (strHeader.StartsWith("F"))
                {
                    int iCut = strHeader.IndexOf(" ");
                    string[] splitted = strHeader.Substring(1, iCut - 1).Split(':');
                    FPS = double.Parse(splitted[0]) / double.Parse(splitted[1]);
                    strHeader = strHeader.Substring(iCut);
                }
                else if (strHeader.StartsWith("C"))
                {
                    int iCut = strHeader.IndexOf(" ");

                    YUV_Forma = strHeader.Substring(1, 3);
                    if (strHeader.Contains("alpha"))
                        YUV_Forma += "A";

                    switch (YUV_Forma)
                    {
                        case "444":
                            ByteSize = 3.0;
                            break;
                        case "422":
                            ByteSize = 2.0;
                            break;
                        case "420":
                        default:
                            ByteSize = 3.0 / 2.0;
                            break;
                    }


                    strHeader = strHeader.Substring(iCut);
                }
                else
                {
                    int iCut = strHeader.IndexOf(" ") + 1;
                    if (iCut == 0)
                        break;
                    strHeader = strHeader.Substring(iCut);
                }
            }
            FrameSize = Convert.ToInt32(Width * Height * ByteSize) + 6;
            FrameSizeLuminance = Convert.ToInt32(Width * Height);
            FrameSizeColor = Convert.ToInt32(Width / 2 * Height / 2);
            FrameCount = Convert.ToInt32(new FileInfo(m_strFile).Length / FrameSize);
        }

        #endregion

        #region -- Read Frame --

        public Bitmap ReadFrame(int iFrame_)
        {
            m_fsFileStream.Seek(StartFrameByte + (iFrame_ * (long)FrameSize) + 6, SeekOrigin.Begin);

            byte[] bufferLuminance = new byte[FrameSizeLuminance];
            m_fsFileStream.Read(bufferLuminance, 0, bufferLuminance.Length);

            m_fsFileStream.Seek(StartFrameByte + (iFrame_ * (long)FrameSize) + 6 + FrameSizeLuminance, SeekOrigin.Begin);
            byte[] bufferU = new byte[FrameSizeColor];
            m_fsFileStream.Read(bufferU, 0, bufferU.Length);

            m_fsFileStream.Seek(StartFrameByte + (iFrame_ * (long)FrameSize) + 6 + FrameSizeLuminance + FrameSizeColor, SeekOrigin.Begin);
            byte[] bufferV = new byte[FrameSizeColor];
            m_fsFileStream.Read(bufferV, 0, bufferV.Length);

            return GetImageFromYuvBytes(bufferLuminance, bufferU, bufferV);
        }

        #endregion

        #endregion

        #region --- Close ---

        public void Close()
        {
            if(m_fsFileStream != null)
                m_fsFileStream.Close();
        }

        #endregion

        #region --- Image from YUV Bytes ---

        Bitmap GetImageFromYuvBytes(byte[] byLuminance, byte[] byU, byte[] byV)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            int iLuminance = 0;
            int iColor = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    iColor = x / 2 + (y / 2) * Width / 2;
                    if (iColor >= byU.Length)
                        iColor = byU.Length - 1;
                    YUV_RGB yuv = new YUV_RGB(byLuminance[iLuminance], byU[iColor], byV[iColor]);
                    bmp.SetPixel(x, y, Color.FromArgb(255, yuv.R, yuv.G, yuv.B));
                    iLuminance++;
                }
            }
            return bmp;
        }

        #region -- YUV_RGB Helping Class --

        public class YUV_RGB
        {
            public int R;
            public int G;
            public int B;

            public YUV_RGB(int y, int u, int v)
            {
                R = Convert.ToInt32(y + 1.4075 * (v - 128));
                G = Convert.ToInt32(y - 0.3455 * (u - 128) - (0.7169 * (v - 128)));
                B = Convert.ToInt32(y + 1.7790 * (u - 128));
                R = Clamp(R, 0, 255);
                G = Clamp(G, 0, 255);
                B = Clamp(B, 0, 255);
            }
            int Clamp(int i, int min, int max)
            {
                if (i > max)
                    return max;
                if (i < min)
                    return min;
                return i;
            }
        }

        #endregion

        #endregion
    }
}
