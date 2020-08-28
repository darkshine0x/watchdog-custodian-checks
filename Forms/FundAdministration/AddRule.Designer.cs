namespace Watchdog.Forms.FundAdministration
{
    partial class AddRule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lableTitle = new System.Windows.Forms.Label();
            this.comboBoxRuleKind = new System.Windows.Forms.ComboBox();
            this.ruleKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelUserControl = new System.Windows.Forms.Panel();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ruleKindBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lableTitle
            // 
            this.lableTitle.AutoSize = true;
            this.lableTitle.Font = new System.Drawing.Font("Arial", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableTitle.Location = new System.Drawing.Point(37, 42);
            this.lableTitle.Name = "lableTitle";
            this.lableTitle.Size = new System.Drawing.Size(791, 79);
            this.lableTitle.TabIndex = 0;
            this.lableTitle.Text = "Neue Regel hinzufügen";
            // 
            // comboBoxRuleKind
            // 
            this.comboBoxRuleKind.DataSource = this.ruleKindBindingSource;
            this.comboBoxRuleKind.DropDownHeight = 500;
            this.comboBoxRuleKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRuleKind.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRuleKind.FormattingEnabled = true;
            this.comboBoxRuleKind.IntegralHeight = false;
            this.comboBoxRuleKind.Location = new System.Drawing.Point(51, 172);
            this.comboBoxRuleKind.MaxDropDownItems = 15;
            this.comboBoxRuleKind.Name = "comboBoxRuleKind";
            this.comboBoxRuleKind.Size = new System.Drawing.Size(625, 48);
            this.comboBoxRuleKind.TabIndex = 1;
            this.comboBoxRuleKind.SelectedValueChanged += new System.EventHandler(this.LoadUserControl);
            // 
            // ruleKindBindingSource
            // 
            this.ruleKindBindingSource.DataSource = typeof(Watchdog.Entities.RuleKind);
            // 
            // panelUserControl
            // 
            this.panelUserControl.Location = new System.Drawing.Point(51, 274);
            this.panelUserControl.Name = "panelUserControl";
            this.panelUserControl.Size = new System.Drawing.Size(2602, 980);
            this.panelUserControl.TabIndex = 2;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(2073, 1345);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(273, 104);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Bestätigen";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(2380, 1345);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(273, 104);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // AddRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2719, 1529);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.panelUserControl);
            this.Controls.Add(this.comboBoxRuleKind);
            this.Controls.Add(this.lableTitle);
            this.Name = "AddRule";
            this.Text = "Neue Regel hinzufügen";
            ((System.ComponentModel.ISupportInitialize)(this.ruleKindBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableTitle;
        private System.Windows.Forms.ComboBox comboBoxRuleKind;
        private System.Windows.Forms.Panel panelUserControl;
        private System.Windows.Forms.BindingSource ruleKindBindingSource;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
    }
}