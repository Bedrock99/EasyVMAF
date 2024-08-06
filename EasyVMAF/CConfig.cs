#region Using...

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace EasyVMAF
{
    public static class CConfig
    {
        #region --- Variables ---

        public static string AppFolder { get; private set; }
        private static Configuration m_pAppConfig;
        private static AppSettingsSection m_pAppSettings;
        private static bool m_bNeedsSave = false;

        public static bool CreateTempFilesInSameFolderAsSourceFiles = true; 
        public static string TempFilesFolder = Application.StartupPath;
        public static bool AutoDeleteTempFiles = false;

        #endregion

        #region --- Load ---

        public static void Load()
        {
            AppFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EasyVMAF");
            if (!Directory.Exists(AppFolder))
                Directory.CreateDirectory(AppFolder);

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppFolder, "EasyVMAF.config");
            m_pAppConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            m_pAppSettings = m_pAppConfig.AppSettings;

            CreateTempFilesInSameFolderAsSourceFiles = GetConfigValueBool("CreateTempFilesInSameFolderAsSourceFiles", CreateTempFilesInSameFolderAsSourceFiles);
            TempFilesFolder = GetConfigValue("TempFilesFolder", TempFilesFolder);
            AutoDeleteTempFiles = GetConfigValueBool("AutoDeleteTempFiles", AutoDeleteTempFiles);

            if (m_bNeedsSave || !File.Exists(fileMap.ExeConfigFilename))
                Save();
        }

        #endregion

        #region --- Save ---

        public static void Save()
        {
            m_pAppSettings.Settings["CreateTempFilesInSameFolderAsSourceFiles"].Value = CreateTempFilesInSameFolderAsSourceFiles.ToString();
            m_pAppSettings.Settings["TempFilesFolder"].Value = TempFilesFolder;
            m_pAppSettings.Settings["AutoDeleteTempFiles"].Value = AutoDeleteTempFiles.ToString();

            m_pAppConfig.Save(ConfigurationSaveMode.Full);
        }

        #endregion

        #region --- LoadForm ---

        public static void LoadForm(Form f_)
        {
            int nX = GetConfigValueInt("WINDOW_" + f_.Name + "_X", f_.Location.X);
            int nY = GetConfigValueInt("WINDOW_" + f_.Name + "_Y", f_.Location.Y);
            int nWidth = GetConfigValueInt("WINDOW_" + f_.Name + "_Width", f_.Size.Width);
            int nHeight = GetConfigValueInt("WINDOW_" + f_.Name + "_Height", f_.Size.Height);

            //Setze Größe
            if (nWidth != 0 && nHeight != 0)
                f_.Size = new System.Drawing.Size(nWidth, nHeight);

            //Setze Position
            int nMaxPosX = SystemInformation.VirtualScreen.Width - f_.Size.Width;
            int nMaxPosY = SystemInformation.VirtualScreen.Height - f_.Size.Height;
            if (nX > 0 && nY > 0 && nX < nMaxPosX && nY < nMaxPosY)
            {
                f_.StartPosition = FormStartPosition.Manual;
                f_.Location = new System.Drawing.Point(nX, nY);
            }
        }

        #endregion

        #region --- SaveForm ---

        public static void SaveForm(Form f_)
        {
            m_pAppSettings.Settings["WINDOW_" + f_.Name + "_X"].Value = f_.Location.X.ToString();
            m_pAppSettings.Settings["WINDOW_" + f_.Name + "_Y"].Value = f_.Location.Y.ToString();
            m_pAppSettings.Settings["WINDOW_" + f_.Name + "_Width"].Value = f_.Size.Width.ToString();
            m_pAppSettings.Settings["WINDOW_" + f_.Name + "_Height"].Value = f_.Size.Height.ToString();

            m_pAppConfig.Save(ConfigurationSaveMode.Full);

        }

        #endregion

        #region --- Get Config Values ---

        private static string GetConfigValue(string strValue_, string strDefault_)
        {
            try
            {
                return m_pAppSettings.Settings[strValue_].Value;
            }
            catch
            {
                m_pAppSettings.Settings.Add(strValue_, strDefault_);
                m_bNeedsSave = true;
            }
            return strDefault_;
        }

        private static int GetConfigValueInt(string strValue_, int iDefault_)
        {
            try
            {
                return Convert.ToInt32(m_pAppSettings.Settings[strValue_].Value);
            }
            catch
            {
                m_pAppSettings.Settings.Add(strValue_, iDefault_.ToString());
                m_bNeedsSave = true;
            }
            return iDefault_;
        }

        private static bool GetConfigValueBool(string strValue_, bool bDefault_)
        {
            try
            {
                return Convert.ToBoolean(m_pAppSettings.Settings[strValue_].Value);
            }
            catch
            {
                m_pAppSettings.Settings.Add(strValue_, bDefault_.ToString());
                m_bNeedsSave = true;
            }
            return bDefault_;
        }

        #endregion
    }
}
