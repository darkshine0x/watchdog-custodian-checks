using System;
using System.Windows.Forms;

namespace Watchdog.Forms
{
    public partial class OneAttributeForm : Form
    {
        public PassedForm originalForm;
        public string reference;

        public OneAttributeForm(PassedForm originalForm, string labelValue, string reference)
        {
            Text = labelValue;
            InitializeComponent();
            this.originalForm = originalForm;
            label.Text = labelValue;
            this.reference = reference;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 1)
            {
                MessageBox.Show("Feld darf nicht leer sein.");
                return;
            }
            originalForm.OnSubmit(textBox1.Text, reference);
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk.PerformClick();
            }
        }
    }
}
