/*
 * Author: Jan Baumann
 * Version: 26.09.2020
 */

using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Forms.Util;
using Watchdog.Persistence;
using Watchdog.Reporting.Duration;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// User control for settings the parameters needed for the duration control.
    /// </summary>
    public partial class DurationSettings : UserControl, IPassedObject<DurationRecord>
    {
        private DataGridView dataGridView;
        private Button addNewRecord;
        private Button save;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DurationSettings()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDurationRecords();
        }

        /// <summary>
        /// Loads the existing duration records into the DataGridView
        /// </summary>
        private void LoadDurationRecords()
        {
            TableUtility tableUtility = new TableUtility();
            List<DurationRecord> list = tableUtility.ConvertRangesToObjects<DurationRecord>(tableUtility.ReadAllRows(DurationRecord.GetDefaultValue()));
            foreach (DurationRecord record in list)
            {
                FormUtility.GetBindingSource(dataGridView).Add(record);
            }
        }

        /// <summary>
        /// Initializes the programmatically added controls.
        /// </summary>
        private void InitializeCustomComponents()
        {
            save = FormUtility.CreateButton("Speichern", 50, 230);
            addNewRecord = FormUtility.CreateButton("Neuen Eintrag hinzufügen", 630, 0);
            addNewRecord.Click += (sender, e) => new AddDurationRecordForm(this).Visible = true;
            dataGridView = FormUtility.CreateDataGridView(typeof(DurationRecord), 630, 140, 300, 600);
            ToolStripMenuItem contextMenuItemDelete = FormUtility.CreateContextMenuItem("Löschen", (sender, e) =>
            {
                TableUtility tableUtility = new TableUtility();
                tableUtility.DeleteTableRow(GetSelectedRecord());
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            });
            ToolStripMenuItem contextMenuItemEdit = FormUtility.CreateContextMenuItem("Bearbeiten", (sender, e) =>
            {
                _ = new AddDurationRecordForm(GetSelectedRecord(), this)
                {
                    Visible = true
                };
            });
            FormUtility.AddContextMenu(dataGridView, contextMenuItemEdit, contextMenuItemDelete);
            FormUtility.AddControlsToForm(this, dataGridView, save, addNewRecord);
        }

        /// <summary>
        /// Get the selected record in the DataGridView
        /// </summary>
        /// <returns>Selected record</returns>
        private DurationRecord GetSelectedRecord()
        {
            return dataGridView.SelectedRows[0].DataBoundItem as DurationRecord;
        }

        /// <summary>
        /// Implementation of <see cref="IPassedObject{T}"/>
        /// 
        /// Takes the newly created <see cref="DurationRecord"/>, persists it and adds it to the DataGridView.
        /// </summary>
        /// <param name="obj">Passed DurationRecord</param>
        public void OnSubmit(DurationRecord obj)
        {
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(DurationRecord.GetDefaultValue());
            tableUtility.InsertTableRow(obj);
            FormUtility.GetBindingSource(dataGridView).Add(obj);
        }
    }
}
