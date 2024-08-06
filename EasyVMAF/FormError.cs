#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace EasyVMAF
{
    public partial class FormError : Form
    {
        #region --- Constructor / Shown ---

        private FormError()
        {
            InitializeComponent();
            Icon = Properties.Resources.EasyVMAFicon;
        }

        private void FormError_Shown(object sender, EventArgs e)
        {
            tb_Error.SelectionStart = tb_Error.Text.Length;
        }

        #endregion

        #region --- ShowError --

        public static DialogResult ShowError(string strTitle_, string strError_)
        {
            FormError fe = new FormError();
            fe.Text = strTitle_;
            fe.tb_Error.Text = strError_;
            return fe.ShowDialog();
        }

        #endregion
    }
}
