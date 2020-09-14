using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class AddCountryForm : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxName;
        private TextBox textBoxIsoCode;
        private Button submitButton;
        private Button cancelButton;
        private readonly IPassedObject<Country> passedObject;
        private readonly Country country;

        public AddCountryForm(IPassedObject<Country> passedObject)
        {
            this.passedObject = passedObject;
            InitializeComponent();
            InitializeCustomComponents();
        }

        public AddCountryForm(Country country, IPassedObject<Country> passedObject) : this(passedObject)
        {
            this.country = country;
            textBoxName.Text = country.Name;
            textBoxIsoCode.Text = country.IsoCode;
        }

        private void InitializeCustomComponents()
        {
            tableLayoutPanel = FormUtility.CreateTableLayoutPanel(50, 80, 300, 800);
            tableLayoutPanel.BackColor = SystemColors.Control;
            textBoxName = FormUtility.CreateTextBox();
            textBoxIsoCode = FormUtility.CreateTextBox();
            submitButton = FormUtility.CreateButton("Bestätigen", 80, 460);
            cancelButton = FormUtility.CreateButton("Abbrechen", 780, 460);
            FormUtility.AddValidation(submitButton, new Dictionary<TextBox, Func<bool>> 
            {
                {
                    textBoxName, () => 
                    {
                        if (textBoxName.Text != "") 
                        {
                            return true;
                        } 
                        return false; 
                    } 
                },
                {
                    textBoxIsoCode, () =>
                    {
                        if (textBoxIsoCode.Text != "")
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }, 
            () => AddCountry()
            );

            cancelButton.Click += (sender, e) => Close();
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.Controls.Add(new Label { Text = "Name", Height = 80, Width = 200 }, 0, 0);
            tableLayoutPanel.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanel.Controls.Add(new Label { Text = "ISO-Code", Height = 80, Width = 200 }, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxIsoCode, 1, 1);
            FormUtility.AddControlsToForm(this, tableLayoutPanel, submitButton, cancelButton);
        }

        private bool AddCountry()
        {
            if (country != null)
            {
                country.Name = textBoxName.Text;
                country.IsoCode = textBoxIsoCode.Text;
                TableUtility tableUtility = new TableUtility();
                tableUtility.MergeTableRow(country);
                Close();
                return true;
            }
            Country createdCountry = new Country(textBoxName.Text, textBoxIsoCode.Text);
            passedObject.OnSubmit(createdCountry);
            Close();
            return true;
        }
    }
}
