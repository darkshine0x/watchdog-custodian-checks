namespace Watchdog.Forms
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
            this.dataGridViewCurrencies = new System.Windows.Forms.DataGridView();
            this.isoCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.currencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridViewAssetClasses = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonNewAssetClass = new System.Windows.Forms.Button();
            this.buttonNewCurrency = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrencies)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCurrencies
            // 
            this.dataGridViewCurrencies.AllowUserToAddRows = false;
            this.dataGridViewCurrencies.AllowUserToDeleteRows = false;
            this.dataGridViewCurrencies.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCurrencies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCurrencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCurrencies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isoCodeDataGridViewTextBoxColumn});
            this.dataGridViewCurrencies.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewCurrencies.DataSource = this.currencyBindingSource;
            this.dataGridViewCurrencies.EnableHeadersVisualStyles = false;
            this.dataGridViewCurrencies.Location = new System.Drawing.Point(936, 246);
            this.dataGridViewCurrencies.Name = "dataGridViewCurrencies";
            this.dataGridViewCurrencies.ReadOnly = true;
            this.dataGridViewCurrencies.RowHeadersWidth = 102;
            this.dataGridViewCurrencies.RowTemplate.Height = 40;
            this.dataGridViewCurrencies.Size = new System.Drawing.Size(356, 554);
            this.dataGridViewCurrencies.TabIndex = 2;
            this.dataGridViewCurrencies.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetRowIndex);
            // 
            // isoCodeDataGridViewTextBoxColumn
            // 
            this.isoCodeDataGridViewTextBoxColumn.DataPropertyName = "IsoCode";
            this.isoCodeDataGridViewTextBoxColumn.HeaderText = "Währung";
            this.isoCodeDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.isoCodeDataGridViewTextBoxColumn.Name = "isoCodeDataGridViewTextBoxColumn";
            this.isoCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.isoCodeDataGridViewTextBoxColumn.Width = 250;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 52);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(205, 48);
            this.toolStripMenuItemDelete.Text = "Löschen";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.DeleteClick);
            // 
            // currencyBindingSource
            // 
            this.currencyBindingSource.DataSource = typeof(Watchdog.Entities.Currency);
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
            // dataGridViewAssetClasses
            // 
            this.dataGridViewAssetClasses.AllowUserToAddRows = false;
            this.dataGridViewAssetClasses.AllowUserToDeleteRows = false;
            this.dataGridViewAssetClasses.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAssetClasses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAssetClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssetClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewAssetClasses.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewAssetClasses.DataSource = this.assetClassBindingSource;
            this.dataGridViewAssetClasses.EnableHeadersVisualStyles = false;
            this.dataGridViewAssetClasses.Location = new System.Drawing.Point(80, 246);
            this.dataGridViewAssetClasses.Name = "dataGridViewAssetClasses";
            this.dataGridViewAssetClasses.ReadOnly = true;
            this.dataGridViewAssetClasses.RowHeadersWidth = 102;
            this.dataGridViewAssetClasses.RowTemplate.Height = 40;
            this.dataGridViewAssetClasses.Size = new System.Drawing.Size(704, 554);
            this.dataGridViewAssetClasses.TabIndex = 4;
            this.dataGridViewAssetClasses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetRowIndex);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Asset-Klasse";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 600;
            // 
            // assetClassBindingSource
            // 
            this.assetClassBindingSource.AllowNew = true;
            this.assetClassBindingSource.DataSource = typeof(Watchdog.Entities.AssetClass);
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
            this.buttonNewAssetClass.Click += new System.EventHandler(this.ButtonNewAssetClass_Click);
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
            this.buttonNewCurrency.Click += new System.EventHandler(this.ButtonNewCurrency_Click);
            // 
            // UserControlAllowedACAndCurrencies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNewCurrency);
            this.Controls.Add(this.buttonNewAssetClass);
            this.Controls.Add(this.dataGridViewAssetClasses);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewCurrencies);
            this.Name = "UserControlAllowedACAndCurrencies";
            this.Size = new System.Drawing.Size(1358, 838);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrencies)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetClassBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewCurrencies;
        private System.Windows.Forms.DataGridViewTextBoxColumn isoCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.BindingSource assetClassBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewAssetClasses;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonNewAssetClass;
        private System.Windows.Forms.Button buttonNewCurrency;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
    }
}
