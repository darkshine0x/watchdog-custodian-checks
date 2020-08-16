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
            ClearPanel();
            switch (selectedView)
            {
                case "AC":
                    panel1.Controls.Add(new UserControlAllowedACAndCurrencies());
                    break;

                case "Ratings":
                    panel1.Controls.Add(new Ratings());
                    break;
            }
        }

        private void ClearPanel()
        {
            panel1.Controls.Clear();
        }

        private void NodeTreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadTreeView();
        }
    }
}
