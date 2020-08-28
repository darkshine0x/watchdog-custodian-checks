namespace Watchdog.Forms.Settings
{
    partial class SettingsForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Asset-Klassen und Währungen");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Ratings");
            this.labelSettings = new System.Windows.Forms.Label();
            this.treeViewSettings = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Arial", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(91, 56);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(483, 79);
            this.labelSettings.TabIndex = 2;
            this.labelSettings.Text = "Einstellungen";
            // 
            // treeViewSettings
            // 
            this.treeViewSettings.Location = new System.Drawing.Point(105, 249);
            this.treeViewSettings.Name = "treeViewSettings";
            treeNode1.Checked = true;
            treeNode1.Name = "AC";
            treeNode1.Text = "Asset-Klassen und Währungen";
            treeNode2.Name = "Ratings";
            treeNode2.Text = "Ratings";
            this.treeViewSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeViewSettings.Size = new System.Drawing.Size(448, 741);
            this.treeViewSettings.TabIndex = 3;
            this.treeViewSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NodeTreeAfterSelect);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(668, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1367, 741);
            this.panel1.TabIndex = 4;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2155, 1061);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeViewSettings);
            this.Controls.Add(this.labelSettings);
            this.Name = "Settings";
            this.Text = "Einstellungen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.TreeView treeViewSettings;
        private System.Windows.Forms.Panel panel1;
    }
}