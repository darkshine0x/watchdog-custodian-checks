/*
 * Author: Jan Baumann
 * Version: 01.10.2020
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Watchdog.Persistence;
using static System.Windows.Forms.DataGridView;

namespace Watchdog.Forms.Util
{
    /// <summary>
    /// This class provides various functionalities for creating standardized controls.
    /// </summary>
    public class FormUtility
    {
        /// <summary>
        /// Delegate for adding action to a context menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ContextMenuItemOnClick(object sender, EventArgs e);

        /// <summary>
        /// Delegate for getting the current selected row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CatchCurrentRowState(object sender, DataGridViewCellStateChangedEventArgs e);

        /// <summary>
        /// Delegate for executing an action after a row is validated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void RowValidated(object sender, DataGridViewCellEventArgs e);

        /// <summary>
        /// Delegate for deleting a row off an DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DeleteRow(object sender, KeyEventArgs e);

        /// <summary>
        /// Delegate for adding a function which is executed after all validations are clear.
        /// </summary>
        public delegate void ExecutingFunction();

        /// <summary>
        /// Makes sure, that the index of the effective clicked row of a DataGridView is returned.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Index of clicked row in a DataGridView</returns>
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

        /// <summary>
        /// Binds an <see cref="Persistable"/> object to a <see cref="Control"/>
        /// </summary>
        /// <param name="control">Control to be bound</param>
        /// <param name="bindingObject">Object to bind</param>
        /// <returns>Control with bound object</returns>
        public static Control BindObjectToControl(Control control, Persistable bindingObject)
        {
            if (bindingObject != null)
            {
                Binding binding = new Binding(string.Empty, bindingObject, string.Empty);
                control.DataBindings.Add(binding);
            }
            return control;
        }

        /// <summary>
        /// Clears a panel from all controls.
        /// </summary>
        /// <param name="panel">Panel to clear</param>
        public static void ClearPanel(Panel panel)
        {
            panel.Controls.Clear();
        }

        /// <summary>
        /// Validates a single textbox on a click on the specified button.
        /// 
        /// The textbox background will turn red if the validating function returns <code>false</code>.
        /// </summary>
        /// <param name="button">Button which invokes the validation on click</param>
        /// <param name="textBox">TextBox to be validated</param>
        /// <param name="validation">Validating function</param>
        /// <param name="closeAfterValidation"><code>True</code> if the form should close after successful validation</param>
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

        /// <summary>
        /// Validates multiple textboxes with multiple conditions on a certain button click.
        /// </summary>
        /// <param name="button">Button which invokes the validation on click</param>
        /// <param name="validatingFunctions"><see cref="Dictionary{TKey, TValue}"/> with the textboxes (keys) and its validating functions (values)</param>
        /// <param name="executingFunction"></param>
        public static void AddValidation(Button button, Dictionary<TextBox, Func<bool>> validatingFunctions, ExecutingFunction executingFunction)
        {
            IEnumerable<TextBox> keys = validatingFunctions.Keys;
            bool validationComplete = true;
            button.Click += (sender, e) =>
            {
                foreach (TextBox textBox in keys)
                {
                    textBox.BackColor = Color.Empty;
                    bool textBoxValidation = validatingFunctions[textBox].Invoke();
                    if (!textBoxValidation)
                    {
                        textBox.BackColor = Color.Red;
                    }
                    validationComplete = textBoxValidation;
                }
                if (validationComplete)
                {
                    executingFunction();
                }
            };
        }

        /// <summary>
        /// Creates a new <see cref="TableLayoutPanel"/>.
        /// </summary>
        /// <param name="height">Height of the whole panel</param>
        /// <param name="width">Width of the whole panel</param>
        /// <param name="xPos">x-Position of the panel</param>
        /// <param name="yPos">y-Position of the panel</param>
        /// <param name="columnCount">Number of columns (optional, standard = 1)</param>
        /// <param name="rowCount">Numer of rows (optional, standard = 1)</param>
        /// <returns>New <see cref="TableLayoutPanel"/></returns>
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

        /// <summary>
        /// Creates a new <see cref="Button"/>.
        /// </summary>
        /// <param name="text">Buttont text</param>
        /// <param name="xPos">x-Position</param>
        /// <param name="yPos">y-Position</param>
        /// <param name="height">Button height</param>
        /// <param name="width">Button width</param>
        /// <returns>New <see cref="Button"/></returns>
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

        /// <summary>
        /// Creates a new <see cref="TextBox"/>.
        /// </summary>
        /// <param name="xPos">x-Position (optional, can stay at zero when added to panel)</param>
        /// <param name="yPos">y-Position (optional, can stay at zero when added to panel)</param>
        /// <param name="width">Text box width (optional, standard = 250)</param>
        /// <param name="name"></param>
        /// <returns>New <see cref="TextBox"/></returns>
        public static TextBox CreateTextBox(int xPos = 0, int yPos = 0, int width = 250, string name = "")
        {
            TextBox textBox = new TextBox
            {
                Location = new Point(xPos, yPos),
                Width = width
            };
            if (name != "")
            {
                textBox.Name = name;
            }
            return textBox;
        }

        /// <summary>
        /// Creates a title <see cref="Label"/>
        /// </summary>
        /// <param name="text">Title text</param>
        /// <param name="font">Font (optional)</param>
        /// <returns><see cref="Label"/></returns>
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

        /// <summary>
        /// Creates a new <see cref="Font"/> object.
        /// 
        /// The font family is set to 'Arial Narrow'.
        /// </summary>
        /// <param name="size">Size in points</param>
        /// <param name="fontStyle"><see cref="FontStyle"/></param>
        /// <returns></returns>
        public static Font CreateFont(float size, FontStyle fontStyle)
        {
            return new Font("Arial Narrow", size, fontStyle, GraphicsUnit.Point, 0);
        }

        /// <summary>
        /// Adds multiple controls to a form, so they are shown eventually.
        /// </summary>
        /// <param name="form"><see cref="Form"/></param>
        /// <param name="controls"><see cref="Control"/>s</param>
        public static void AddControlsToForm(ContainerControl form, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                form.Controls.Add(control);
            }
        }

        /// <summary>
        /// Creates a new context menu item with an executing function.
        /// </summary>
        /// <param name="name">Name of the menu item</param>
        /// <param name="functionOnClick">Function to be executed on click</param>
        /// <returns><see cref="ToolStripMenuItem"/></returns>
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

        /// <summary>
        /// Adds a context menu to a <see cref="DataGridView"/>
        /// </summary>
        /// <param name="dataGridView"><see cref="DataGridView"/></param>
        /// <param name="contextMenuItems">All menu items</param>
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

        /// <summary>
        /// Adds a control with context menue to a <see cref="TableLayoutPanel"/>.
        /// </summary>
        /// <param name="tableLayoutPanel"><see cref="TableLayoutPanel"/></param>
        /// <param name="contextMenu"><see cref="ContextMenuStrip"/></param>
        /// <param name="control"><see cref="Control"/> to which the menu should be added.</param>
        /// <param name="col">Column to which the control should be added</param>
        /// <param name="row">Row to which the control should be added</param>
        public static void AddControlWithContextMenu(TableLayoutPanel tableLayoutPanel, ContextMenuStrip contextMenu, Control control, int col, int row)
        {
            tableLayoutPanel.Controls.Add(control, col, row);
            control.ContextMenuStrip = contextMenu;
        }

        /// <summary>
        /// Creates a new context menu.
        /// </summary>
        /// <param name="contextMenuItems">Context menu items</param>
        /// <returns><see cref="ContextMenuStrip"/></returns>
        public static ContextMenuStrip CreateContextMenu(params ToolStripMenuItem[] contextMenuItems)
        {
            if (contextMenuItems.Length == 0)
            {
                return null;
            }
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(contextMenuItems);
            return contextMenu;
        }

        /// <summary>
        /// Creates a new <see cref="DataGridViewColumn"/>.
        /// </summary>
        /// <param name="dataProperty">Name of the object property</param>
        /// <param name="headerText">Column header text</param>
        /// <param name="width">Column width</param>
        /// <returns><see cref="DataGridViewColumn"/></returns>
        private static DataGridViewTextBoxColumn CreateDataGridViewColumn(string dataProperty, string headerText, int width = 200)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataProperty,
                HeaderText = headerText,
                Width = width
            };
            return column;
        }

        /// <summary>
        /// Creates a new <see cref="DataGridView"/>.
        /// 
        /// All of the properties which should be added as columns, have to be marked by the <see cref="TableHeader"/> property.
        /// </summary>
        /// <param name="bindingType">Type to be bound to the DataGridView</param>
        /// <param name="xPos">x-Position</param>
        /// <param name="yPos">y-Position</param>
        /// <param name="height">DataGridView height</param>
        /// <param name="width">DataGridView width</param>
        /// <returns><see cref="DataGridView"/></returns>
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

        /// <summary>
        /// Gets the <see cref="BindingSource"/> from the specified <see cref="DataGridView"/>, 
        /// so objects can be added to the source.
        /// </summary>
        /// <param name="control"><see cref="DataGridView"/></param>
        /// <returns><see cref="BindingSource"/></returns>
        public static BindingSource GetBindingSource(DataGridView control)
        {
            return control.DataSource as BindingSource;
        }

        /// <summary>
        /// Returns a <see cref="Dictionary{PropertyInfo, TableHeader}"/> with the properties which 
        /// are marked with the <see cref="TableHeader"/> attribute.
        /// </summary>
        /// <param name="type"><see cref="Type"/></param>
        /// <returns><see cref="Dictionary{PropertyInfo, TableHeader}"/></returns>
        private static Dictionary<PropertyInfo, TableHeader> GetTableHeadersFromType(Type type)
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

        /// <summary>
        /// Creates a new <see cref="TableLayoutPanel"/>.
        /// </summary>
        /// <param name="xPos">x-Position</param>
        /// <param name="yPos">y-Position</param>
        /// <param name="height">Panel height</param>
        /// <param name="width">Panel width</param>
        /// <returns><see cref="TableLayoutPanel"/></returns>
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
        
        /// <summary>
        /// Adds all functionality to a <see cref="DataGridView"/>, so that it can be edited directly.
        /// </summary>
        /// <param name="dataGridView"><see cref="DataGridView"/></param>
        /// <param name="catchCurrentRowState"></param>
        /// <param name="rowValidated"></param>
        /// <param name="deleteRow"></param>
        public static void AddDataGridViewEditingHandlers(DataGridView dataGridView, CatchCurrentRowState catchCurrentRowState, RowValidated rowValidated, DeleteRow deleteRow)
        {
            dataGridView.CellStateChanged += (sender, e) =>
            {
                catchCurrentRowState(sender, e);
            };
            dataGridView.RowValidated += (sender, e) =>
            {
                rowValidated(sender, e);
            };
            dataGridView.KeyUp += (sender, e) =>
            {
                deleteRow(sender, e);
            };
        }

        /// <summary>
        /// Clears a row off a <see cref="TableLayoutPanel"/>, based on a <see cref="Control"/>.
        /// The row index is retrieved via the passed control.
        /// </summary>
        /// <param name="tableLayoutPanel"><see cref="TableLayoutPanel"/></param>
        /// <param name="control"><see cref="Control"/></param>
        public static void DeleteTableRow(TableLayoutPanel tableLayoutPanel, Control control)
        {
            int row = tableLayoutPanel.GetRow(control);
            for (int col = 0; col < tableLayoutPanel.ColumnCount; col++)
            {
                tableLayoutPanel.Controls.Remove(tableLayoutPanel.GetControlFromPosition(col, row));
            }
            tableLayoutPanel.RowCount--;
        }
    }
}
