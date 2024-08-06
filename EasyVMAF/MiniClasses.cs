#region Using...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace EasyVMAF
{
    public class CFile
    {
        #region --- Variables ---

        public string File { get; set; }

        #endregion

        #region --- Constructor ---

        public CFile(string strFile_)
        {
            File = strFile_;
        }

        #endregion
    }

    public class CProgressTask : Task
    {
        #region --- Variables ---

        public int Progress = 0;
        public bool WantsStop = false;

        #endregion

        #region --- Constructor ---

        public CProgressTask(Action action) : base(action)
        {

        }

        #endregion
    }
}
