using System.Windows.Forms;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.Settings
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
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
            FormUtility.ClearPanel(panel1);
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

        private void NodeTreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadTreeView();
        }
    }
}
