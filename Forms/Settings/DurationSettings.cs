/*
 * Author: Jan Baumann
 * Version: 26.09.2020
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
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
        private TableLayoutPanel tableLayoutPanel;
        private DataGridView dataGridView;
        private Button addNewRecord;
        private Button save;
        private Dictionary<string, FieldMapping> currentFieldMapping;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DurationSettings()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDurationRecords();
            LoadSettings();
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
            tableLayoutPanel = FormUtility.CreateTableLayoutPanel(200, 550, 50, 0, 2, 3);
            tableLayoutPanel.BackColor = SystemColors.Control;
            tableLayoutPanel.Controls.Add(new Label { Text = "Feld Ziel-Duration", AutoSize = true }, 0, 0);
            durTargetDur = FormUtility.CreateTextBox(0, 0, 100, "durTargetDur");
            tableLayoutPanel.Controls.Add(durTargetDur, 1, 0);
            tableLayoutPanel.Controls.Add(new Label { Text = "Feld Positionswert", AutoSize = true }, 0, 1);
            durPosValue = FormUtility.CreateTextBox(0, 0, 100, "durPosValue");
            tableLayoutPanel.Controls.Add(durPosValue, 1, 1);
            tableLayoutPanel.Controls.Add(new Label { Text = "Feld Währung", AutoSize = true }, 0, 2);
            durCurrency = FormUtility.CreateTextBox(0, 0, 100, "durCurrency");
            tableLayoutPanel.Controls.Add(durCurrency, 1, 2);

            save = FormUtility.CreateButton("Speichern", 50, 230);
            FormUtility.AddValidation(save, new Dictionary<TextBox, Func<bool>>
            {
                {durTargetDur,  () => durTargetDur.Text != "" && durTargetDur.Text.Length == 1},
                {durPosValue,  () => durPosValue.Text != "" && durPosValue.Text.Length == 1},
                {durCurrency,  () => durCurrency.Text != "" && durCurrency.Text.Length == 1}
            }
            , () => SaveDurationSettings());


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
            FormUtility.AddControlsToForm(this, tableLayoutPanel, dataGridView, save, addNewRecord);
        }

        /// <summary>
        /// Loads the persisted settings. If there are none, then new <see cref="FieldMapping"/> objects 
        /// are loaded and persisted initially.
        /// </summary>
        private void LoadSettings()
        {
            currentFieldMapping = GetCurrentMappings();
            if (currentFieldMapping.Count != 0)
            {
                foreach (TextBox tb in GetAllSettingsTextBoxes())
                {
                    tb.Text = currentFieldMapping[tb.Name].InputFieldCell;
                }
            }
            else
            {
                TableUtility tableUtility = new TableUtility();
                foreach (TextBox tb in GetAllSettingsTextBoxes())
                {
                    FieldMapping fm = new FieldMapping(tb.Name, "", FieldMappingType.DURATION);
                    tableUtility.InsertTableRow(fm);
                    currentFieldMapping.Add(tb.Name, fm);
                }
            }
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

        /// <summary>
        /// Persists the duration field settings.
        /// </summary>
        public void SaveDurationSettings()
        {
            TableUtility tableUtility = new TableUtility();
            foreach (TextBox tb in GetAllSettingsTextBoxes())
            {
                FieldMapping fm = currentFieldMapping[tb.Name];
                fm.InputFieldCell = tb.Text;
                tableUtility.MergeTableRow(fm);
            }
        }

        /// <summary>
        /// Returns a <see cref="List{TextBox}"/>, so that text box scanning can be processed more easily.
        /// </summary>
        /// <returns>List with all settings text boxes</returns>
        private List<TextBox> GetAllSettingsTextBoxes()
        {
            return new List<TextBox>
            {
                durTargetDur,
                durPosValue,
                durCurrency
            };
        }

        /// <summary>
        /// Gets the current persisted <see cref="FieldMapping"/>s and loads them into a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>Dictionary with the field names as keys and the <see cref="FieldMapping"/> objects as values</returns>
        private Dictionary<string, FieldMapping> GetCurrentMappings()
        {
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(FieldMapping.GetDefaultValue());
            List<FieldMapping> mappingList = tableUtility.ConvertRangesToObjects<FieldMapping>(
                tableUtility.ReadTableRow(FieldMapping.GetDefaultValue(), new Dictionary<string, string>
                    {
                        {"FieldMappingType", ((int) FieldMappingType.DURATION).ToString() },

                    }, QueryOperator.OR)
            );
            Dictionary<string, FieldMapping> mappings = new Dictionary<string, FieldMapping>();
            foreach (FieldMapping mapping in mappingList)
            {
                mappings.Add(mapping.FieldName, mapping);
            }
            return mappings;
        }
    }
}
