using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Watchdog.Persistence;
using static System.Windows.Forms.DataGridView;

namespace Watchdog.Forms.Util
{
    public class FormUtility
    {
        public delegate void ContextMenuItemOnClick(object sender, EventArgs e);

        public static int DataGridViewMouseDownContextMenu(DataGridView sender, MouseEventArgs e)
        {
            if (sender == null)
            {
                return -1;
            }
            HitTestInfo hitTest = sender.HitTest(e.X, e.Y);
            sender.ClearSelection();
            if (hitTest.RowIndex < 0)
            {
                return -1;
            }
            sender.Rows[hitTest.RowIndex].Selected = true;
            return hitTest.RowIndex;
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

        public static TableLayoutPanel CreateTableLayoutPanel(int height, int width, int xPos, int yPos, int columnCount = 1, int rowCount = 1)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Location = new Point(xPos, yPos),
                ColumnCount = columnCount,
                RowCount = rowCount,
                Height = height,
                Width = width,
                BackColor = Color.DarkGray,
                AutoScroll = true,
                Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Margin = Padding.Empty
            };
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            return tableLayoutPanel;
        }

        public static Button CreateButton(string text, int xPos = 0, int yPos = 0, int height = 110, int width = 340)
        {
            Button button = new Button
            {
                Text = text,
                Anchor = (AnchorStyles.Top | AnchorStyles.Left),
                Location = new Point(xPos, yPos),
                Height = height,
                Width = width
            };
            return button;
        }

        public static Label CreateTitle(string text, Font font = null)
        {
            Label label = new Label
            {
                AutoSize = true,
                Text = text,
                Location = new Point(15, 15),
                Margin = Padding.Empty
            };
            if (font != null)
            {
                label.Font = font;
            }
            else
            {
                label.Font = CreateFont(20f, FontStyle.Bold);
            }
            return label;
        }

        public static Font CreateFont(float size, FontStyle fontStyle)
        {
            return new Font("Arial Narrow", size, fontStyle, GraphicsUnit.Point, 0);
        }

        public static void AddControlsToForm(Form form, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                form.Controls.Add(control);
            }
        }

        public static ToolStripMenuItem CreateContextMenuItem(string name, ContextMenuItemOnClick functionOnClick) 
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem
            {
                Text = name,
            };
            menuItem.Click += (sender, e) =>
            {
                functionOnClick(sender, e);
            };
            return menuItem;
        }

        public static void AddContextMenu(DataGridView dataGridView, params ToolStripMenuItem[] contextMenuItems)
        {
            if (contextMenuItems.Length == 0)
            {
                return;
            }
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Opening += (sender, e) =>
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            };
            contextMenu.Items.AddRange(contextMenuItems);
            dataGridView.ContextMenuStrip = contextMenu;
            dataGridView.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewMouseDownContextMenu(dataGridView, e);
                } 
            };
        }

        public static DataGridViewTextBoxColumn CreateDataGridViewColumn(string dataProperty, string headerText, int width = 200)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataProperty,
                HeaderText = headerText,
                Width = width
            };
            return column;
        }

        public static DataGridView CreateDataGridView(Type bindingType, int xPos, int yPos, int height = 600, int width = 1700)
        {
            BindingSource binding = new BindingSource
            {
                DataSource = bindingType
            };
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = CreateFont(10, FontStyle.Bold)
            };
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                Font = CreateFont(10, FontStyle.Regular)
            };

            DataGridView dataGridView = new DataGridView
            {
                AutoGenerateColumns = false,
                Height = height,
                Width = width,
                Location = new Point(xPos, yPos),
                ColumnHeadersDefaultCellStyle = headerStyle,
                ColumnHeadersHeight = 40,
                EnableHeadersVisualStyles = false,
                RowsDefaultCellStyle = defaultCellStyle,
                BackgroundColor = Color.DarkGray,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };
            Dictionary<PropertyInfo, TableHeader> properties = GetTableHeadersFromType(bindingType);
            foreach (PropertyInfo property in properties.Keys)
            {
                TableHeader header = properties[property];
                dataGridView.Columns.Add(CreateDataGridViewColumn(property.Name, header.HeaderText, header.Size));
            }
            dataGridView.RowTemplate.Height = 40;
            dataGridView.DataSource = binding;
            return dataGridView;
        }

        public static BindingSource GetBindingSource(DataGridView control)
        {
            return control.DataSource as BindingSource;
        }

        public static Dictionary<PropertyInfo, TableHeader> GetTableHeadersFromType(Type type)
        {
            Dictionary<PropertyInfo, TableHeader> dict = new Dictionary<PropertyInfo, TableHeader>();
            foreach (PropertyInfo property in type.GetProperties())
            {
                TableHeader tableHeader = property.GetCustomAttribute<TableHeader>(true);
                if (tableHeader != null)
                {
                    dict.Add(property, tableHeader);
                }
            }
            return dict;
        }

        public static TableLayoutPanel CreateTableLayoutPanel(int xPos, int yPos, int height = 800, int width = 1600)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                AutoScroll = true,
                BackColor = SystemColors.ControlDark,
                ColumnCount = 1,
                RowCount = 1,
                Margin = Padding.Empty,
                Height = height,
                Width = width,
                Location = new Point(xPos, yPos),
                Font = CreateFont(8, FontStyle.Regular)
            };
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            return tableLayoutPanel;
        }
    }
}
