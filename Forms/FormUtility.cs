using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.DataGridView;

namespace Watchdog.Forms
{
    class FormUtility
    {
        public static int DataGridViewMouseDownContextMenu(DataGridView sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                HitTestInfo hitTest = sender.HitTest(e.X, e.Y);
                sender.ClearSelection();
                if (hitTest.RowIndex < 0)
                {
                    PreventContextMenu(sender, e);
                    return -1;
                }
                sender.Rows[hitTest.RowIndex].Selected = true;
                return hitTest.RowIndex;
            }
            return -1;
        }

        private static void PreventContextMenu(DataGridView dataGridView, MouseEventArgs e)
        {
            dataGridView.ContextMenuStrip.Opening += (s, i) =>
            {
                if (dataGridView.CurrentCell == null || dataGridView.CurrentCell.ReadOnly)
                {
                    i.Cancel = true;
                } else
                {
                    i.Cancel = false;
                }
            };
        }
    }
}
