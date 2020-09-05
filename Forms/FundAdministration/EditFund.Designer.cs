namespace Watchdog.Forms.FundAdministration
{
    partial class EditFund
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
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelFundName = new System.Windows.Forms.Label();
            this.labelIsin = new System.Windows.Forms.Label();
            this.labelCustodyNr = new System.Windows.Forms.Label();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.tableLayoutPanelFundProperties = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFundName = new System.Windows.Forms.TextBox();
            this.textBoxIsin = new System.Windows.Forms.TextBox();
            this.textBoxCustodyNr = new System.Windows.Forms.TextBox();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelFundProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(2079, 1158);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(251, 66);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "Bestätigen";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(2391, 1158);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(225, 66);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(31, 41);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(605, 79);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Fonds bearbeiten";
            // 
            // labelFundName
            // 
            this.labelFundName.AutoSize = true;
            this.labelFundName.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFundName.Location = new System.Drawing.Point(3, 0);
            this.labelFundName.Name = "labelFundName";
            this.labelFundName.Size = new System.Drawing.Size(92, 40);
            this.labelFundName.TabIndex = 4;
            this.labelFundName.Text = "Name";
            // 
            // labelIsin
            // 
            this.labelIsin.AutoSize = true;
            this.labelIsin.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsin.Location = new System.Drawing.Point(3, 124);
            this.labelIsin.Name = "labelIsin";
            this.labelIsin.Size = new System.Drawing.Size(72, 40);
            this.labelIsin.TabIndex = 6;
            this.labelIsin.Text = "ISIN";
            // 
            // labelCustodyNr
            // 
            this.labelCustodyNr.AutoSize = true;
            this.labelCustodyNr.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustodyNr.Location = new System.Drawing.Point(3, 248);
            this.labelCustodyNr.Name = "labelCustodyNr";
            this.labelCustodyNr.Size = new System.Drawing.Size(139, 40);
            this.labelCustodyNr.TabIndex = 7;
            this.labelCustodyNr.Text = "Depot-Nr.";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.Location = new System.Drawing.Point(3, 372);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(132, 40);
            this.labelCurrency.TabIndex = 8;
            this.labelCurrency.Text = "Währung";
            // 
            // tableLayoutPanelFundProperties
            // 
            this.tableLayoutPanelFundProperties.ColumnCount = 2;
            this.tableLayoutPanelFundProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.46206F));
            this.tableLayoutPanelFundProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.53794F));
            this.tableLayoutPanelFundProperties.Controls.Add(this.labelFundName, 0, 0);
            this.tableLayoutPanelFundProperties.Controls.Add(this.labelCurrency, 0, 3);
            this.tableLayoutPanelFundProperties.Controls.Add(this.labelIsin, 0, 1);
            this.tableLayoutPanelFundProperties.Controls.Add(this.labelCustodyNr, 0, 2);
            this.tableLayoutPanelFundProperties.Controls.Add(this.textBoxFundName, 1, 0);
            this.tableLayoutPanelFundProperties.Controls.Add(this.textBoxIsin, 1, 1);
            this.tableLayoutPanelFundProperties.Controls.Add(this.textBoxCustodyNr, 1, 2);
            this.tableLayoutPanelFundProperties.Controls.Add(this.textBoxCurrency, 1, 3);
            this.tableLayoutPanelFundProperties.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelFundProperties.Location = new System.Drawing.Point(45, 244);
            this.tableLayoutPanelFundProperties.Name = "tableLayoutPanelFundProperties";
            this.tableLayoutPanelFundProperties.RowCount = 4;
            this.tableLayoutPanelFundProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFundProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFundProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFundProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFundProperties.Size = new System.Drawing.Size(883, 497);
            this.tableLayoutPanelFundProperties.TabIndex = 9;
            // 
            // textBoxFundName
            // 
            this.textBoxFundName.Location = new System.Drawing.Point(218, 3);
            this.textBoxFundName.Name = "textBoxFundName";
            this.textBoxFundName.Size = new System.Drawing.Size(523, 45);
            this.textBoxFundName.TabIndex = 9;
            // 
            // textBoxIsin
            // 
            this.textBoxIsin.Location = new System.Drawing.Point(218, 127);
            this.textBoxIsin.Name = "textBoxIsin";
            this.textBoxIsin.Size = new System.Drawing.Size(523, 45);
            this.textBoxIsin.TabIndex = 10;
            // 
            // textBoxCustodyNr
            // 
            this.textBoxCustodyNr.Location = new System.Drawing.Point(218, 251);
            this.textBoxCustodyNr.Name = "textBoxCustodyNr";
            this.textBoxCustodyNr.Size = new System.Drawing.Size(523, 45);
            this.textBoxCustodyNr.TabIndex = 11;
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Location = new System.Drawing.Point(218, 375);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(153, 45);
            this.textBoxCurrency.TabIndex = 12;
            // 
            // Editfund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2686, 1284);
            this.Controls.Add(this.tableLayoutPanelFundProperties);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Name = "Editfund";
            this.Text = "Fonds bearbeiten";
            this.tableLayoutPanelFundProperties.ResumeLayout(false);
            this.tableLayoutPanelFundProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelFundName;
        private System.Windows.Forms.Label labelIsin;
        private System.Windows.Forms.Label labelCustodyNr;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFundProperties;
        private System.Windows.Forms.TextBox textBoxFundName;
        private System.Windows.Forms.TextBox textBoxIsin;
        private System.Windows.Forms.TextBox textBoxCustodyNr;
        private System.Windows.Forms.TextBox textBoxCurrency;
    }
}