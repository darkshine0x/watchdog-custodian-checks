using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Watchdog.Forms.Util;
using Watchdog.Persistence;
using Watchdog.Reporting.Duration;

namespace Watchdog.Forms.Settings
{
    public partial class AddDurationRecordForm : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxCurrency;
        private TextBox textBoxDuration;
        private Button submitButton;
        private Button cancelButton;
        private readonly IPassedObject<DurationRecord> passedObject;
        private readonly DurationRecord durationRecord;

        public AddDurationRecordForm(IPassedObject<DurationRecord> passedObject)
        {
            this.passedObject = passedObject;
            InitializeComponent();
            InitializeCustomComponents();
        }

        public AddDurationRecordForm(DurationRecord durationRecord, IPassedObject<DurationRecord> passedObject) : this(passedObject)
        {
            this.durationRecord = durationRecord;
            textBoxCurrency.Text = durationRecord.Currency;
            textBoxDuration.Text = durationRecord.TargetDuration.ToString();
        }

        private void InitializeCustomComponents()
        {
            tableLayoutPanel = FormUtility.CreateTableLayoutPanel(50, 80, 300, 800);
            tableLayoutPanel.BackColor = SystemColors.Control;
            textBoxCurrency = FormUtility.CreateTextBox();
            textBoxDuration = FormUtility.CreateTextBox();
            submitButton = FormUtility.CreateButton("Bestätigen", 80, 460);
            cancelButton = FormUtility.CreateButton("Abbrechen", 780, 460);
            FormUtility.AddValidation(submitButton, new Dictionary<TextBox, Func<bool>>
            {
                {
                    textBoxCurrency, () =>
                    {
                        if (textBoxCurrency.Text != "")
                        {
                            return true;
                        }
                        return false;
                    }
                },
                {
                    textBoxDuration, () =>
                    {
                        if (textBoxCurrency.Text != "")
                        {
                            return double.TryParse(textBoxDuration.Text, out double duration);
                        }
                        return false;
                    }
                }
            },
            () => AddDurationRecord()
            );

            cancelButton.Click += (sender, e) => Close();
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.Controls.Add(new Label { Text = "Währung", Height = 80, Width = 200 }, 0, 0);
            tableLayoutPanel.Controls.Add(textBoxCurrency, 1, 0);
            tableLayoutPanel.Controls.Add(new Label { Text = "Ziel-Duration", Height = 80, Width = 200 }, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxDuration, 1, 1);
            FormUtility.AddControlsToForm(this, tableLayoutPanel, submitButton, cancelButton);
        }

        private bool AddDurationRecord()
        {
            double.TryParse(textBoxDuration.Text, out double targetDuration);
            if (durationRecord != null)
            {
                durationRecord.Currency = textBoxCurrency.Text;
                durationRecord.TargetDuration = targetDuration;
                TableUtility tableUtility = new TableUtility();
                tableUtility.MergeTableRow(durationRecord);
                Close();
                return true;
            }
            DurationRecord newDurationRecord = new DurationRecord
            {
                Currency = textBoxCurrency.Text,
                TargetDuration = targetDuration
            };
            passedObject.OnSubmit(newDurationRecord);
            Close();
            return true;
        }
    }
}
