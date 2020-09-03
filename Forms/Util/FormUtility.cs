using System;
using System.Drawing;
using System.Windows.Forms;
using Watchdog.Persistence;
using static System.Windows.Forms.DataGridView;

namespace Watchdog.Forms.Util
{
    class FormUtility
    {
        public static int DataGridViewMouseDownContextMenu(DataGridView sender, MouseEventArgs e)
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

        public static Control BindObjectToControl(Control control, Persistable bindingObject)
        {
            if (bindingObject != null)
            {
                Binding binding = new Binding(string.Empty, bindingObject, string.Empty);
                control.DataBindings.Add(binding);
            }
            return control;
        }

        public static void ClearPanel(Panel panel)
        {
            panel.Controls.Clear();
        }

        public static void AddValidation(Button button, TextBox textBox, Func<bool> validation, bool closeAfterValidation = false)
        {
            textBox.BackColor = Color.Empty;
            button.Click += (sender, e) =>
            {
                if (!validation.Invoke())
                {
                    textBox.BackColor = Color.Red;
                    return;
                }

                if (closeAfterValidation)
                {
                    button.FindForm().Close();
                }
            };
        }
    }
}
