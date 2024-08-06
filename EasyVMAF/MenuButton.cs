#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace EasyVMAF
{
    public class MenuButton : Button
    {
        #region --- Variables ---

        [DefaultValue(null)]
        public ContextMenuStrip Menu { get; set; }

        [DefaultValue(false)]
        public bool ShowMenuUnderCursor { get; set; }

        #endregion

        #region --- Mouse Down ---

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            if (Menu != null && mevent.Button == MouseButtons.Left)
            {
                Point menuLocation;

                if (ShowMenuUnderCursor)
                {
                    menuLocation = mevent.Location;
                }
                else
                {
                    menuLocation = new Point(0, Height - 1);
                }

                Menu.Show(this, menuLocation);
            }
        }

        #endregion

        #region --- On Paint ---

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (Menu != null)
            {
                int arrowX = ClientRectangle.Width - Padding.Right - 14;
                int arrowY = (ClientRectangle.Height / 2) - 1;

                Color color = Enabled ? ForeColor : SystemColors.ControlDark;
                using (Brush brush = new SolidBrush(color))
                {
                    Point[] arrows = new Point[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };
                    pevent.Graphics.FillPolygon(brush, arrows);
                }
            }
        }

        #endregion
    }
}
