namespace Watchdog.Forms
{
    partial class EditAssetAllocation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LabelAA = new System.Windows.Forms.Label();
            this.LabelFund = new System.Windows.Forms.Label();
            this.dataGridAssetAllocation = new System.Windows.Forms.DataGridView();
            this.ColumnAssetAllocation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAssetAllocation)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2012, 1159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 66);
            this.button1.TabIndex = 1;
            this.button1.Text = "Bestätigen";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2324, 1159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 66);
            this.button2.TabIndex = 2;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LabelAA
            // 
            this.LabelAA.AutoSize = true;
            this.LabelAA.Font = new System.Drawing.Font("Arial", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAA.Location = new System.Drawing.Point(31, 41);
            this.LabelAA.Name = "LabelAA";
            this.LabelAA.Size = new System.Drawing.Size(563, 79);
            this.LabelAA.TabIndex = 3;
            this.LabelAA.Text = "Asset Allocation";
            // 
            // LabelFund
            // 
            this.LabelFund.AutoSize = true;
            this.LabelFund.Font = new System.Drawing.Font("Arial", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFund.Location = new System.Drawing.Point(39, 157);
            this.LabelFund.Name = "LabelFund";
            this.LabelFund.Size = new System.Drawing.Size(124, 43);
            this.LabelFund.TabIndex = 4;
            this.LabelFund.Text = "Fonds";
            // 
            // dataGridAssetAllocation
            // 
            this.dataGridAssetAllocation.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAssetAllocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridAssetAllocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAssetAllocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAssetAllocation});
            this.dataGridAssetAllocation.EnableHeadersVisualStyles = false;
            this.dataGridAssetAllocation.Location = new System.Drawing.Point(47, 267);
            this.dataGridAssetAllocation.Name = "dataGridAssetAllocation";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAssetAllocation.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridAssetAllocation.RowHeadersVisible = false;
            this.dataGridAssetAllocation.RowHeadersWidth = 102;
            this.dataGridAssetAllocation.RowTemplate.Height = 40;
            this.dataGridAssetAllocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridAssetAllocation.Size = new System.Drawing.Size(2535, 788);
            this.dataGridAssetAllocation.TabIndex = 8;
            // 
            // ColumnAssetAllocation
            // 
            this.ColumnAssetAllocation.HeaderText = "Asset-Klassen";
            this.ColumnAssetAllocation.MinimumWidth = 12;
            this.ColumnAssetAllocation.Name = "ColumnAssetAllocation";
            this.ColumnAssetAllocation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAssetAllocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAssetAllocation.Width = 250;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1113, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(469, 39);
            this.comboBox1.TabIndex = 9;
            // 
            // EditAssetAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2658, 1258);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridAssetAllocation);
            this.Controls.Add(this.LabelFund);
            this.Controls.Add(this.LabelAA);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "EditAssetAllocation";
            this.Text = "Asset Allocation bearbeiten";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAssetAllocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LabelAA;
        private System.Windows.Forms.Label LabelFund;
        private System.Windows.Forms.DataGridView dataGridAssetAllocation;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnAssetAllocation;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}