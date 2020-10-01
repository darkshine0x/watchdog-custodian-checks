namespace Watchdog.Forms.Settings
{
    partial class DurationSettings
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
            this.SuspendLayout();
            // 
            // DurationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DurationSettings";
            this.Size = new System.Drawing.Size(1205, 798);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox durPosValue;
        private System.Windows.Forms.TextBox durCurrency;
        private System.Windows.Forms.TextBox durTargetDur;
    }
}
