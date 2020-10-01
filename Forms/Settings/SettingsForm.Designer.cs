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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Durationsprüfung");
            this.labelSettings = new System.Windows.Forms.Label();
            this.treeViewSettings = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Arial", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(34, 23);
            this.labelSettings.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(196, 32);
            this.labelSettings.TabIndex = 2;
            this.labelSettings.Text = "Einstellungen";
            // 
            // treeViewSettings
            // 
            this.treeViewSettings.Location = new System.Drawing.Point(39, 104);
            this.treeViewSettings.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.treeViewSettings.Name = "treeViewSettings";
            treeNode1.Checked = true;
            treeNode1.Name = "AC";
            treeNode1.Text = "Asset-Klassen und Währungen";
            treeNode2.Name = "Ratings";
            treeNode2.Text = "Ratings";
            treeNode3.Name = "DurationControl";
            treeNode3.Text = "Durationsprüfung";
            this.treeViewSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeViewSettings.Size = new System.Drawing.Size(170, 313);
            this.treeViewSettings.TabIndex = 3;
            this.treeViewSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NodeTreeAfterSelect);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(250, 104);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 311);
            this.panel1.TabIndex = 4;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(808, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeViewSettings);
            this.Controls.Add(this.labelSettings);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "SettingsForm";
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