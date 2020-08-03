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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LabelAA = new System.Windows.Forms.Label();
            this.LabelFund = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(49, 271);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2533, 814);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // EditAssetAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2628, 1257);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.LabelFund);
            this.Controls.Add(this.LabelAA);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "EditAssetAllocation";
            this.Text = "Asset Allocation bearbeiten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LabelAA;
        private System.Windows.Forms.Label LabelFund;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}