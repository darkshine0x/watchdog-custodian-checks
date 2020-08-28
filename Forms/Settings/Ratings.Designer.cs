namespace Watchdog.Forms.Settings
{
    partial class Ratings
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonAddRatingAgency = new System.Windows.Forms.Button();
            this.dataGridViewRatingCodes = new System.Windows.Forms.DataGridView();
            this.dataGridViewRatingAgencies = new System.Windows.Forms.DataGridView();
            this.contextMenuStripRatingAgency = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingAgencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ratingCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingNumericValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRatingCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRatingAgencies)).BeginInit();
            this.contextMenuStripRatingAgency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingAgencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(31, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(285, 79);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Ratings";
            // 
            // buttonAddRatingAgency
            // 
            this.buttonAddRatingAgency.Location = new System.Drawing.Point(55, 136);
            this.buttonAddRatingAgency.Name = "buttonAddRatingAgency";
            this.buttonAddRatingAgency.Size = new System.Drawing.Size(271, 121);
            this.buttonAddRatingAgency.TabIndex = 1;
            this.buttonAddRatingAgency.Text = "Ratingagentur hinzufügen";
            this.buttonAddRatingAgency.UseVisualStyleBackColor = true;
            this.buttonAddRatingAgency.Click += new System.EventHandler(this.ButtonAddRatingAgency_Click);
            // 
            // dataGridViewRatingCodes
            // 
            this.dataGridViewRatingCodes.AutoGenerateColumns = false;
            this.dataGridViewRatingCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRatingCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ratingCodeDataGridViewTextBoxColumn,
            this.ratingNumericValueDataGridViewTextBoxColumn});
            this.dataGridViewRatingCodes.DataSource = this.ratingBindingSource;
            this.dataGridViewRatingCodes.Location = new System.Drawing.Point(787, 308);
            this.dataGridViewRatingCodes.Name = "dataGridViewRatingCodes";
            this.dataGridViewRatingCodes.RowHeadersVisible = false;
            this.dataGridViewRatingCodes.RowHeadersWidth = 102;
            this.dataGridViewRatingCodes.RowTemplate.Height = 40;
            this.dataGridViewRatingCodes.Size = new System.Drawing.Size(504, 394);
            this.dataGridViewRatingCodes.TabIndex = 4;
            this.dataGridViewRatingCodes.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.CatchCurrentRowState);
            this.dataGridViewRatingCodes.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.RowValidatedRatings);
            this.dataGridViewRatingCodes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DeleteRow);
            // 
            // dataGridViewRatingAgencies
            // 
            this.dataGridViewRatingAgencies.AllowUserToAddRows = false;
            this.dataGridViewRatingAgencies.AutoGenerateColumns = false;
            this.dataGridViewRatingAgencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRatingAgencies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewRatingAgencies.ContextMenuStrip = this.contextMenuStripRatingAgency;
            this.dataGridViewRatingAgencies.DataSource = this.ratingAgencyBindingSource;
            this.dataGridViewRatingAgencies.Location = new System.Drawing.Point(55, 308);
            this.dataGridViewRatingAgencies.Name = "dataGridViewRatingAgencies";
            this.dataGridViewRatingAgencies.ReadOnly = true;
            this.dataGridViewRatingAgencies.RowHeadersWidth = 102;
            this.dataGridViewRatingAgencies.RowTemplate.Height = 40;
            this.dataGridViewRatingAgencies.Size = new System.Drawing.Size(701, 394);
            this.dataGridViewRatingAgencies.TabIndex = 5;
            this.dataGridViewRatingAgencies.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickRatingAgencies);
            this.dataGridViewRatingAgencies.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridRatingAgenciesMouseDown);
            // 
            // contextMenuStripRatingAgency
            // 
            this.contextMenuStripRatingAgency.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStripRatingAgency.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDelete});
            this.contextMenuStripRatingAgency.Name = "contextMenuStripRatingAgency";
            this.contextMenuStripRatingAgency.Size = new System.Drawing.Size(361, 105);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(360, 46);
            this.toolStripMenuItemDelete.Text = "Löschen";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.DeleteRatingAgencyClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // ratingAgencyBindingSource
            // 
            this.ratingAgencyBindingSource.DataSource = typeof(Watchdog.Entities.RatingAgency);
            // 
            // ratingCodeDataGridViewTextBoxColumn
            // 
            this.ratingCodeDataGridViewTextBoxColumn.DataPropertyName = "RatingCode";
            this.ratingCodeDataGridViewTextBoxColumn.HeaderText = "Rating-Code";
            this.ratingCodeDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.ratingCodeDataGridViewTextBoxColumn.Name = "ratingCodeDataGridViewTextBoxColumn";
            this.ratingCodeDataGridViewTextBoxColumn.Width = 250;
            // 
            // ratingNumericValueDataGridViewTextBoxColumn
            // 
            this.ratingNumericValueDataGridViewTextBoxColumn.DataPropertyName = "RatingNumericValue";
            this.ratingNumericValueDataGridViewTextBoxColumn.HeaderText = "Nummer";
            this.ratingNumericValueDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.ratingNumericValueDataGridViewTextBoxColumn.Name = "ratingNumericValueDataGridViewTextBoxColumn";
            this.ratingNumericValueDataGridViewTextBoxColumn.Width = 250;
            // 
            // ratingBindingSource
            // 
            this.ratingBindingSource.DataSource = typeof(Watchdog.Entities.Rating);
            // 
            // Ratings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewRatingAgencies);
            this.Controls.Add(this.dataGridViewRatingCodes);
            this.Controls.Add(this.buttonAddRatingAgency);
            this.Controls.Add(this.labelTitle);
            this.Name = "Ratings";
            this.Size = new System.Drawing.Size(1313, 730);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRatingCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRatingAgencies)).EndInit();
            this.contextMenuStripRatingAgency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ratingAgencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonAddRatingAgency;
        private System.Windows.Forms.DataGridView dataGridViewRatingCodes;
        private System.Windows.Forms.DataGridView dataGridViewRatingAgencies;
        private System.Windows.Forms.BindingSource ratingAgencyBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingNumericValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ratingBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRatingAgency;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
    }
}
