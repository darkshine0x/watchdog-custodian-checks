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
            // Ratings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddRatingAgency);
            this.Controls.Add(this.labelTitle);
            this.Name = "Ratings";
            this.Size = new System.Drawing.Size(1313, 730);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonAddRatingAgency;
    }
}
