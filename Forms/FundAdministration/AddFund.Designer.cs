namespace Watchdog.Forms.FundAdministration
{
    partial class AddFundForm
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
            this.groupBoxFundAttributes = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            this.textBoxIsin = new System.Windows.Forms.TextBox();
            this.labelFundName = new System.Windows.Forms.Label();
            this.labelIsin = new System.Windows.Forms.Label();
            this.labelCustodyNr = new System.Windows.Forms.Label();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.textBoxCustodyNr = new System.Windows.Forms.TextBox();
            this.textBoxFundName = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxFundAttributes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFundAttributes
            // 
            this.groupBoxFundAttributes.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxFundAttributes.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFundAttributes.Location = new System.Drawing.Point(30, 37);
            this.groupBoxFundAttributes.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxFundAttributes.Name = "groupBoxFundAttributes";
            this.groupBoxFundAttributes.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxFundAttributes.Size = new System.Drawing.Size(432, 159);
            this.groupBoxFundAttributes.TabIndex = 0;
            this.groupBoxFundAttributes.TabStop = false;
            this.groupBoxFundAttributes.Text = "Fondsattribute";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.65961F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.34039F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxCurrency, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxIsin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelFundName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelIsin, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCustodyNr, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCurrency, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCustodyNr, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFundName, 1, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(392, 126);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxCurrency.Location = new System.Drawing.Point(97, 94);
            this.textBoxCurrency.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(61, 23);
            this.textBoxCurrency.TabIndex = 7;
            // 
            // textBoxIsin
            // 
            this.textBoxIsin.Location = new System.Drawing.Point(97, 63);
            this.textBoxIsin.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxIsin.Name = "textBoxIsin";
            this.textBoxIsin.Size = new System.Drawing.Size(123, 23);
            this.textBoxIsin.TabIndex = 5;
            // 
            // labelFundName
            // 
            this.labelFundName.AutoSize = true;
            this.labelFundName.Location = new System.Drawing.Point(1, 0);
            this.labelFundName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelFundName.Name = "labelFundName";
            this.labelFundName.Size = new System.Drawing.Size(67, 17);
            this.labelFundName.TabIndex = 0;
            this.labelFundName.Text = "Fondsname";
            // 
            // labelIsin
            // 
            this.labelIsin.AutoSize = true;
            this.labelIsin.Location = new System.Drawing.Point(1, 62);
            this.labelIsin.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelIsin.Name = "labelIsin";
            this.labelIsin.Size = new System.Drawing.Size(30, 17);
            this.labelIsin.TabIndex = 4;
            this.labelIsin.Text = "ISIN";
            // 
            // labelCustodyNr
            // 
            this.labelCustodyNr.AutoSize = true;
            this.labelCustodyNr.Location = new System.Drawing.Point(1, 31);
            this.labelCustodyNr.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelCustodyNr.Name = "labelCustodyNr";
            this.labelCustodyNr.Size = new System.Drawing.Size(78, 17);
            this.labelCustodyNr.TabIndex = 2;
            this.labelCustodyNr.Text = "Depotnummer";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(1, 93);
            this.labelCurrency.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(53, 17);
            this.labelCurrency.TabIndex = 6;
            this.labelCurrency.Text = "Währung";
            // 
            // textBoxCustodyNr
            // 
            this.textBoxCustodyNr.Location = new System.Drawing.Point(97, 32);
            this.textBoxCustodyNr.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxCustodyNr.Name = "textBoxCustodyNr";
            this.textBoxCustodyNr.Size = new System.Drawing.Size(143, 23);
            this.textBoxCustodyNr.TabIndex = 3;
            // 
            // textBoxFundName
            // 
            this.textBoxFundName.Location = new System.Drawing.Point(97, 1);
            this.textBoxFundName.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxFundName.Name = "textBoxFundName";
            this.textBoxFundName.Size = new System.Drawing.Size(286, 23);
            this.textBoxFundName.TabIndex = 1;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(532, 52);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(171, 44);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "Bestätigen";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(532, 105);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(171, 44);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // AddFundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(726, 531);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.groupBoxFundAttributes);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "AddFundForm";
            this.Text = "Fonds hinzufügen";
            this.groupBoxFundAttributes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFundAttributes;
        private System.Windows.Forms.Label labelFundName;
        private System.Windows.Forms.TextBox textBoxCurrency;
        private System.Windows.Forms.TextBox textBoxCustodyNr;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Label labelCustodyNr;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxIsin;
        private System.Windows.Forms.Label labelIsin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxFundName;
    }
}