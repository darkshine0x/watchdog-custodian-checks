namespace Watchdog.Forms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxFundAttributes = new System.Windows.Forms.GroupBox();
            this.textBoxIsin = new System.Windows.Forms.TextBox();
            this.labelIsin = new System.Windows.Forms.Label();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            this.textBoxCustodyNr = new System.Windows.Forms.TextBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.labelCustodyNr = new System.Windows.Forms.Label();
            this.textBoxFundName = new System.Windows.Forms.TextBox();
            this.labelFundName = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridFunds = new System.Windows.Forms.DataGridView();
            this.columnFundName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCustodyNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIsin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxFundAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFunds)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFundAttributes
            // 
            this.groupBoxFundAttributes.Controls.Add(this.textBoxIsin);
            this.groupBoxFundAttributes.Controls.Add(this.labelIsin);
            this.groupBoxFundAttributes.Controls.Add(this.textBoxCurrency);
            this.groupBoxFundAttributes.Controls.Add(this.textBoxCustodyNr);
            this.groupBoxFundAttributes.Controls.Add(this.labelCurrency);
            this.groupBoxFundAttributes.Controls.Add(this.labelCustodyNr);
            this.groupBoxFundAttributes.Controls.Add(this.textBoxFundName);
            this.groupBoxFundAttributes.Controls.Add(this.labelFundName);
            this.groupBoxFundAttributes.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFundAttributes.Location = new System.Drawing.Point(81, 87);
            this.groupBoxFundAttributes.Name = "groupBoxFundAttributes";
            this.groupBoxFundAttributes.Size = new System.Drawing.Size(1152, 379);
            this.groupBoxFundAttributes.TabIndex = 0;
            this.groupBoxFundAttributes.TabStop = false;
            this.groupBoxFundAttributes.Text = "Fondsattribute";
            // 
            // textBoxIsin
            // 
            this.textBoxIsin.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIsin.Location = new System.Drawing.Point(267, 240);
            this.textBoxIsin.Name = "textBoxIsin";
            this.textBoxIsin.Size = new System.Drawing.Size(321, 45);
            this.textBoxIsin.TabIndex = 5;
            // 
            // labelIsin
            // 
            this.labelIsin.AutoSize = true;
            this.labelIsin.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsin.Location = new System.Drawing.Point(20, 243);
            this.labelIsin.Name = "labelIsin";
            this.labelIsin.Size = new System.Drawing.Size(83, 39);
            this.labelIsin.TabIndex = 4;
            this.labelIsin.Text = "ISIN";
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCurrency.Location = new System.Drawing.Point(267, 320);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(156, 45);
            this.textBoxCurrency.TabIndex = 7;
            // 
            // textBoxCustodyNr
            // 
            this.textBoxCustodyNr.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustodyNr.Location = new System.Drawing.Point(267, 161);
            this.textBoxCustodyNr.Name = "textBoxCustodyNr";
            this.textBoxCustodyNr.Size = new System.Drawing.Size(374, 45);
            this.textBoxCustodyNr.TabIndex = 3;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.Location = new System.Drawing.Point(20, 320);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(156, 39);
            this.labelCurrency.TabIndex = 6;
            this.labelCurrency.Text = "Währung";
            // 
            // labelCustodyNr
            // 
            this.labelCustodyNr.AutoSize = true;
            this.labelCustodyNr.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustodyNr.Location = new System.Drawing.Point(20, 164);
            this.labelCustodyNr.Name = "labelCustodyNr";
            this.labelCustodyNr.Size = new System.Drawing.Size(226, 39);
            this.labelCustodyNr.TabIndex = 2;
            this.labelCustodyNr.Text = "Depotnummer";
            // 
            // textBoxFundName
            // 
            this.textBoxFundName.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFundName.Location = new System.Drawing.Point(267, 69);
            this.textBoxFundName.Name = "textBoxFundName";
            this.textBoxFundName.Size = new System.Drawing.Size(849, 45);
            this.textBoxFundName.TabIndex = 1;
            // 
            // labelFundName
            // 
            this.labelFundName.AutoSize = true;
            this.labelFundName.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFundName.Location = new System.Drawing.Point(20, 72);
            this.labelFundName.Name = "labelFundName";
            this.labelFundName.Size = new System.Drawing.Size(192, 39);
            this.labelFundName.TabIndex = 0;
            this.labelFundName.Text = "Fondsname";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(1420, 124);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(456, 104);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "Bestätigen";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(1420, 251);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(456, 104);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // dataGridFunds
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFunds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridFunds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFunds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnFundName,
            this.columnCustodyNr,
            this.columnIsin,
            this.columnCurrency});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridFunds.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridFunds.Location = new System.Drawing.Point(86, 500);
            this.dataGridFunds.Name = "dataGridFunds";
            this.dataGridFunds.ReadOnly = true;
            this.dataGridFunds.RowHeadersWidth = 102;
            this.dataGridFunds.RowTemplate.Height = 40;
            this.dataGridFunds.Size = new System.Drawing.Size(1555, 389);
            this.dataGridFunds.TabIndex = 3;
            // 
            // columnFundName
            // 
            this.columnFundName.HeaderText = "Fondsname";
            this.columnFundName.MinimumWidth = 700;
            this.columnFundName.Name = "columnFundName";
            this.columnFundName.ReadOnly = true;
            this.columnFundName.Width = 700;
            // 
            // columnCustodyNr
            // 
            this.columnCustodyNr.HeaderText = "Depotnummer";
            this.columnCustodyNr.MinimumWidth = 12;
            this.columnCustodyNr.Name = "columnCustodyNr";
            this.columnCustodyNr.ReadOnly = true;
            this.columnCustodyNr.Width = 250;
            // 
            // columnIsin
            // 
            this.columnIsin.HeaderText = "ISIN";
            this.columnIsin.MinimumWidth = 12;
            this.columnIsin.Name = "columnIsin";
            this.columnIsin.ReadOnly = true;
            this.columnIsin.Width = 250;
            // 
            // columnCurrency
            // 
            this.columnCurrency.HeaderText = "Währung";
            this.columnCurrency.MinimumWidth = 12;
            this.columnCurrency.Name = "columnCurrency";
            this.columnCurrency.ReadOnly = true;
            this.columnCurrency.Width = 250;
            // 
            // AddFundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1936, 956);
            this.Controls.Add(this.dataGridFunds);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.groupBoxFundAttributes);
            this.Name = "AddFundForm";
            this.Text = "Fonds hinzufügen";
            this.groupBoxFundAttributes.ResumeLayout(false);
            this.groupBoxFundAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFunds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFundAttributes;
        private System.Windows.Forms.Label labelFundName;
        private System.Windows.Forms.TextBox textBoxCurrency;
        private System.Windows.Forms.TextBox textBoxCustodyNr;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Label labelCustodyNr;
        private System.Windows.Forms.TextBox textBoxFundName;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridFunds;
        private System.Windows.Forms.TextBox textBoxIsin;
        private System.Windows.Forms.Label labelIsin;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFundName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCustodyNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIsin;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCurrency;
    }
}