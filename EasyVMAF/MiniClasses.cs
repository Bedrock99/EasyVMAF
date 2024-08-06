#region Using...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    public class PanelNoScroll : Panel
    {
        #region --- WndProc ---

        public event MouseEventHandler MyMouseWheel;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x20a)
            {
                MouseEventArgs e = new MouseEventArgs(MouseButtons.None,0,0,0, (int)m.WParam);
                MyMouseWheel?.Invoke(this, e);
                return;
            }
            base.WndProc(ref m);
        }

        #endregion
    }
}
