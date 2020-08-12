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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custodyAccountNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripFund = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditAA = new System.Windows.Forms.ToolStripMenuItem();
            this.fundBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxFundAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFunds)).BeginInit();
            this.contextMenuStripFund.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fundBindingSource)).BeginInit();
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
            this.groupBoxFundAttributes.Location = new System.Drawing.Point(81, 112);
            this.groupBoxFundAttributes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxFundAttributes.Name = "groupBoxFundAttributes";
            this.groupBoxFundAttributes.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxFundAttributes.Size = new System.Drawing.Size(1152, 489);
            this.groupBoxFundAttributes.TabIndex = 0;
            this.groupBoxFundAttributes.TabStop = false;
            this.groupBoxFundAttributes.Text = "Fondsattribute";
            // 
            // textBoxIsin
            // 
            this.textBoxIsin.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIsin.Location = new System.Drawing.Point(267, 310);
            this.textBoxIsin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxIsin.Name = "textBoxIsin";
            this.textBoxIsin.Size = new System.Drawing.Size(321, 45);
            this.textBoxIsin.TabIndex = 5;
            // 
            // labelIsin
            // 
            this.labelIsin.AutoSize = true;
            this.labelIsin.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsin.Location = new System.Drawing.Point(20, 314);
            this.labelIsin.Name = "labelIsin";
            this.labelIsin.Size = new System.Drawing.Size(83, 39);
            this.labelIsin.TabIndex = 4;
            this.labelIsin.Text = "ISIN";
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCurrency.Location = new System.Drawing.Point(267, 413);
            this.textBoxCurrency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(156, 45);
            this.textBoxCurrency.TabIndex = 7;
            // 
            // textBoxCustodyNr
            // 
            this.textBoxCustodyNr.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustodyNr.Location = new System.Drawing.Point(267, 208);
            this.textBoxCustodyNr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCustodyNr.Name = "textBoxCustodyNr";
            this.textBoxCustodyNr.Size = new System.Drawing.Size(374, 45);
            this.textBoxCustodyNr.TabIndex = 3;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.Location = new System.Drawing.Point(20, 413);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(156, 39);
            this.labelCurrency.TabIndex = 6;
            this.labelCurrency.Text = "Währung";
            // 
            // labelCustodyNr
            // 
            this.labelCustodyNr.AutoSize = true;
            this.labelCustodyNr.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustodyNr.Location = new System.Drawing.Point(20, 212);
            this.labelCustodyNr.Name = "labelCustodyNr";
            this.labelCustodyNr.Size = new System.Drawing.Size(226, 39);
            this.labelCustodyNr.TabIndex = 2;
            this.labelCustodyNr.Text = "Depotnummer";
            // 
            // textBoxFundName
            // 
            this.textBoxFundName.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFundName.Location = new System.Drawing.Point(267, 89);
            this.textBoxFundName.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.textBoxFundName.Name = "textBoxFundName";
            this.textBoxFundName.Size = new System.Drawing.Size(849, 45);
            this.textBoxFundName.TabIndex = 1;
            // 
            // labelFundName
            // 
            this.labelFundName.AutoSize = true;
            this.labelFundName.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFundName.Location = new System.Drawing.Point(20, 93);
            this.labelFundName.Name = "labelFundName";
            this.labelFundName.Size = new System.Drawing.Size(192, 39);
            this.labelFundName.TabIndex = 0;
            this.labelFundName.Text = "Fondsname";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(1420, 160);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(456, 134);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "Bestätigen";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(1420, 324);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(456, 134);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // dataGridFunds
            // 
            this.dataGridFunds.AllowUserToAddRows = false;
            this.dataGridFunds.AllowUserToDeleteRows = false;
            this.dataGridFunds.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFunds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridFunds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFunds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.isinDataGridViewTextBoxColumn,
            this.custodyAccountNumberDataGridViewTextBoxColumn,
            this.currencyDataGridViewTextBoxColumn});
            this.dataGridFunds.ContextMenuStrip = this.contextMenuStripFund;
            this.dataGridFunds.DataSource = this.fundBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridFunds.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridFunds.EnableHeadersVisualStyles = false;
            this.dataGridFunds.Location = new System.Drawing.Point(81, 644);
            this.dataGridFunds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridFunds.Name = "dataGridFunds";
            this.dataGridFunds.RowHeadersVisible = false;
            this.dataGridFunds.RowHeadersWidth = 102;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10);
            this.dataGridFunds.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridFunds.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridFunds.RowTemplate.Height = 65;
            this.dataGridFunds.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridFunds.Size = new System.Drawing.Size(1784, 916);
            this.dataGridFunds.TabIndex = 3;
            this.dataGridFunds.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridFundsMouseDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Fondsname";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 900;
            // 
            // isinDataGridViewTextBoxColumn
            // 
            this.isinDataGridViewTextBoxColumn.DataPropertyName = "Isin";
            this.isinDataGridViewTextBoxColumn.HeaderText = "ISIN";
            this.isinDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.isinDataGridViewTextBoxColumn.Name = "isinDataGridViewTextBoxColumn";
            this.isinDataGridViewTextBoxColumn.Width = 280;
            // 
            // custodyAccountNumberDataGridViewTextBoxColumn
            // 
            this.custodyAccountNumberDataGridViewTextBoxColumn.DataPropertyName = "CustodyAccountNumber";
            this.custodyAccountNumberDataGridViewTextBoxColumn.HeaderText = "Depotnummer";
            this.custodyAccountNumberDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.custodyAccountNumberDataGridViewTextBoxColumn.Name = "custodyAccountNumberDataGridViewTextBoxColumn";
            this.custodyAccountNumberDataGridViewTextBoxColumn.Width = 250;
            // 
            // currencyDataGridViewTextBoxColumn
            // 
            this.currencyDataGridViewTextBoxColumn.DataPropertyName = "Currency";
            this.currencyDataGridViewTextBoxColumn.HeaderText = "Währung";
            this.currencyDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.currencyDataGridViewTextBoxColumn.Name = "currencyDataGridViewTextBoxColumn";
            this.currencyDataGridViewTextBoxColumn.Width = 250;
            // 
            // contextMenuStripFund
            // 
            this.contextMenuStripFund.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStripFund.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditAA,
            this.toolStripMenuItemDelete});
            this.contextMenuStripFund.Name = "contextMenuStripFund";
            this.contextMenuStripFund.Size = new System.Drawing.Size(459, 100);
            // 
            // toolStripMenuItemEditAA
            // 
            this.toolStripMenuItemEditAA.Name = "toolStripMenuItemEditAA";
            this.toolStripMenuItemEditAA.Size = new System.Drawing.Size(458, 48);
            this.toolStripMenuItemEditAA.Text = "Asset Allocation bearbeiten";
            this.toolStripMenuItemEditAA.Click += new System.EventHandler(this.ClickEditAA);
            // 
            // fundBindingSource
            // 
            this.fundBindingSource.DataSource = typeof(Watchdog.Entities.Fund);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(458, 48);
            this.toolStripMenuItemDelete.Text = "Löschen";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.DeleteFundClick);
            // 
            // AddFundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1936, 1634);
            this.Controls.Add(this.dataGridFunds);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.groupBoxFundAttributes);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddFundForm";
            this.Text = "Fonds hinzufügen";
            this.groupBoxFundAttributes.ResumeLayout(false);
            this.groupBoxFundAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFunds)).EndInit();
            this.contextMenuStripFund.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fundBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource fundBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custodyAccountNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFund;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditAA;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
    }
}