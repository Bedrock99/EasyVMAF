#region Using...

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace EasyVMAF
{
    public static class CProcesses
    {
        #region --- FFMPEG ---

        public static CProgressTask RunFFMPEG_Decode(string strIn_, string strOut_)
        {
            CProgressTask t = null;
            t = new CProgressTask(() =>
            {
                Process pDecode = new Process();
                pDecode.StartInfo.FileName = Path.Combine(Application.StartupPath, "binaries", "ffmpeg.exe");
                pDecode.StartInfo.Arguments = $"-y -i \"{strIn_}\" -pix_fmt yuv420p -vsync 0 \"{strOut_}\"";
                Console.WriteLine("ffmpag.exe " + pDecode.StartInfo.Arguments);
                pDecode.StartInfo.UseShellExecute = false;
                pDecode.StartInfo.RedirectStandardError = true;
                pDecode.StartInfo.CreateNoWindow = true;
                pDecode.Start();

                string strOutput = "";
                TimeSpan tsDuration = TimeSpan.Zero;
                int iX = 0;
                int iY = 0;
                double dblFps = 0;
                while (!pDecode.HasExited || !pDecode.StandardError.EndOfStream)
                {
                    while (!pDecode.StandardError.EndOfStream)
                    {
                        string strRed = pDecode.StandardError.ReadLine();
                        strOutput += strRed + "\r\n";
                        Console.WriteLine(strRed);
                        //TODO Error handling in reading output...
                        if(strRed.Contains("Stream #") && strRed.Contains("Video:"))
                        {
                            try
                            {
                                string strResolution = strRed.Substring(0, strRed.IndexOf("["));
                                strResolution = strResolution.Substring(strResolution.LastIndexOf(",") + 1);
                                strResolution = strResolution.Trim();
                                iX = int.Parse(strResolution.Substring(0, strResolution.IndexOf("x")));
                                iY = int.Parse(strResolution.Substring(strResolution.IndexOf("x") + 1));

                                string strFps = strRed.Substring(0, strRed.IndexOf(" fps,"));
                                strFps = strFps.Substring(strFps.LastIndexOf(",") + 1);
                                strFps = strFps.Trim();
                                dblFps = double.Parse(strFps, CultureInfo.InvariantCulture);

                                if (tsDuration != TimeSpan.Zero)
                                    CheckSize(iX, iY, dblFps, tsDuration, strOut_);
                            }
                            catch { }
                        }
                        if (strRed.Contains("Duration:"))
                        {
                            string duration = strRed.Substring(strRed.IndexOf("Duration: ") + "Duration: ".Length);
                            duration = duration.Substring(0, duration.IndexOf(","));
                            tsDuration = TimeSpan.Parse(duration);

                            if (iX != 0)
                                CheckSize(iX, iY, dblFps, tsDuration, strOut_);
                        }
                        else if (strRed.Contains("time=") && tsDuration != TimeSpan.Zero)
                        {
                            string duration = strRed.Substring(strRed.IndexOf("time=") + "time=".Length);
                            duration = duration.Substring(0, duration.IndexOf(" "));
                            TimeSpan tsCur = TimeSpan.Parse(duration);
                            t.Progress = Convert.ToInt32(100.0 / tsDuration.TotalMilliseconds * tsCur.TotalMilliseconds * 100.0);
                        }
                        if (t.WantsStop)
                        {
                            if (!pDecode.HasExited)
                            {
                                pDecode.StandardError.Close();
                                pDecode.Kill();
                            }
                            break;
                        }
                    }
                    if (t.WantsStop)
                    {
                        if (!pDecode.HasExited)
                            pDecode.Kill();
                        break;
                    }
                }

                if (pDecode.ExitCode != 0)
                {
                    FormError.ShowError($"FFMPEG closed with error code {pDecode.ExitCode}", strOutput);
                    return;
                }
            });

            t.Start();
            return t;
        }

        static void CheckSize(int iX_, int iY_, double dblFps_, TimeSpan tsDuration_, string strOutFile_)
        {
            double dblFrameSize = iX_ * iY_ * 3.0 / 2.0;
            double dblAllSize = dblFrameSize * tsDuration_.TotalSeconds * dblFps_;
            long lNeededBytes = Convert.ToInt64(dblAllSize);

            string strDrive = strOutFile_.Substring(0, strOutFile_.IndexOf("\\") + 1);
            long lDriveFreeSpace = GetTotalFreeSpace(strDrive);
            if (lNeededBytes > lDriveFreeSpace)
            {
                MessageBox.Show($"FFmpeg needs approximately {CResult.GetSizeHumanReadAble(lNeededBytes)} of " +
                    $"{CResult.GetSizeHumanReadAble(lDriveFreeSpace)} available hard drive space on drive {strDrive}!",
                    "Waring for hard drive space", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        static long GetTotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.TotalFreeSpace;
                }
            }
            return -1;
        }

        #endregion

        #region --- VMAF ---

        public static CProgressTask RunVMAF(string strOrg_, string strConv_, string strOut_)
        {
            CProgressTask t = null;
            t = new CProgressTask(() =>
            {
                Process pVmaf = new Process();
                pVmaf.StartInfo.FileName = Path.Combine(Application.StartupPath, "binaries", "vmaf.exe");
                pVmaf.StartInfo.Arguments = $"--threads {Environment.ProcessorCount} -r \"{strOrg_}\" -d \"{strConv_}\" -o \"{strOut_}\"";
                Console.WriteLine("vmaf.exe " + pVmaf.StartInfo.Arguments);
                pVmaf.StartInfo.UseShellExecute = false;
                pVmaf.StartInfo.RedirectStandardError = false;
                pVmaf.StartInfo.CreateNoWindow = false;
                pVmaf.Start();

                while (!pVmaf.HasExited)
                {
                    Thread.Sleep(100);
                    if(t.Progress < 10000)
                        t.Progress += 10;
                    //TODO For VMAF progress i would need to compile it myself and change the line:
                    // const int istty = isatty(fileno(stderr));
                    // in vmaf.c -> main() -> row 172
                    if (t.WantsStop)
                    {
                        if (!pVmaf.HasExited)
                            pVmaf.Kill();
                        break;
                    }
                }

            });

            t.Start();
            return t;
        }

        #endregion
    }
}
