namespace Watchdog.Forms.Settings
{
    partial class UserControlAllowedACAndCurrencies
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonNewAssetClass = new System.Windows.Forms.Button();
            this.buttonNewCurrency = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(72, 24);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(765, 46);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Erlaubte Asset-Klassen und Währungen";
            // 
            // buttonNewAssetClass
            // 
            this.buttonNewAssetClass.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewAssetClass.Location = new System.Drawing.Point(86, 110);
            this.buttonNewAssetClass.Name = "buttonNewAssetClass";
            this.buttonNewAssetClass.Size = new System.Drawing.Size(314, 95);
            this.buttonNewAssetClass.TabIndex = 5;
            this.buttonNewAssetClass.Text = "Neue Asset-Klasse";
            this.buttonNewAssetClass.UseVisualStyleBackColor = true;
            this.buttonNewAssetClass.Click += new System.EventHandler(this.ButtonNewAssetClassClick);
            // 
            // buttonNewCurrency
            // 
            this.buttonNewCurrency.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewCurrency.Location = new System.Drawing.Point(512, 110);
            this.buttonNewCurrency.Name = "buttonNewCurrency";
            this.buttonNewCurrency.Size = new System.Drawing.Size(314, 95);
            this.buttonNewCurrency.TabIndex = 6;
            this.buttonNewCurrency.Text = "Neue Währung";
            this.buttonNewCurrency.UseVisualStyleBackColor = true;
            this.buttonNewCurrency.Click += new System.EventHandler(this.ButtonNewCurrencyClick);
            // 
            // UserControlAllowedACAndCurrencies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNewCurrency);
            this.Controls.Add(this.buttonNewAssetClass);
            this.Controls.Add(this.labelTitle);
            this.Name = "UserControlAllowedACAndCurrencies";
            this.Size = new System.Drawing.Size(1358, 838);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonNewAssetClass;
        private System.Windows.Forms.Button buttonNewCurrency;
    }
}
