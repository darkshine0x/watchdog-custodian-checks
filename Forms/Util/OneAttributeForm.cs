using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Watchdog.Forms.Util
{
    public partial class OneAttributeForm : Form
    {
        public IPassedForm originalForm;
        public string reference;

        public OneAttributeForm(IPassedForm originalForm, string labelValue, string reference)
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
            originalForm.OnSubmit(new List<string>{ textBox1.Text}, reference);
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
