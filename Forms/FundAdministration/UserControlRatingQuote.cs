using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class UserControlRatingQuote : UserControl, IRuleUserControl
    {
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxName;
        private TextBox textBoxRatingClass;
        private TextBox textBoxNumericValue;

        public UserControlRatingQuote()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        public Rule InvokeSubmission(RuleKind ruleKind)
        {
            double.TryParse(textBoxRatingClass.Text, out double ratingClass);
            double.TryParse(textBoxNumericValue.Text, out double numericValue);
            RatingQuoteRule newRatingQuoteRule = new RatingQuoteRule(ratingClass, numericValue, RuleKind.MAX_RATING_RATIO, textBoxName.Text);
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(newRatingQuoteRule);
            tableUtility.InsertTableRow(newRatingQuoteRule);
            return newRatingQuoteRule;
        }

        private void InitializeCustomComponents()
        {
            textBoxName = FormUtility.CreateTextBox();
            textBoxRatingClass = FormUtility.CreateTextBox();
            textBoxNumericValue = FormUtility.CreateTextBox();
            tableLayoutPanel = FormUtility.CreateTableLayoutPanel(25, 25);
            tableLayoutPanel.BackColor = SystemColors.Control;
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.Controls.Add(new Label { Text = "Name", Height = 80, Width = 200 }, 0, 0);
            tableLayoutPanel.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanel.Controls.Add(new Label { Text = "Rating-Klasse", Height = 80, Width = 200 }, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxRatingClass, 1, 1);
            tableLayoutPanel.Controls.Add(new Label { Text = "Maximaler Anteil", Height = 80, Width = 200 }, 0, 2);
            tableLayoutPanel.Controls.Add(textBoxNumericValue, 1, 2);
            FormUtility.AddControlsToForm(this, tableLayoutPanel);
        }
    }
}
