using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watchdog.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            LoadTreeView();
        }

        private void LoadTreeView()
        {
            if (treeViewSettings.SelectedNode == null)
            {
                return;
            }
            string selectedView = treeViewSettings.SelectedNode.Name;

            switch (selectedView)
            {
                case "AC":
                    panel1.Controls.Add(new UserControlAllowedACAndCurrencies());
                    break;
            }
        }

        private void TreeViewSettings_MouseClick(object sender, MouseEventArgs e)
        {
            LoadTreeView();
        }
    }
}
