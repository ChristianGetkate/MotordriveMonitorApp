using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TwinCAT;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.Routes;

namespace MotordriveMonitorApp
{
    public partial class MotordriveMonitorMainForm : Form
    {
        private static readonly bool mDesignModeActive = Assembly.GetEntryAssembly() == null;

        public MotordriveMonitorMainForm()
        {
            InitializeComponent();
        }
        protected override bool ShowWithoutActivation
        {
            // Prevent focus stealing
            get { return true; }
        }
        /*
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (mDesignModeActive)
                return;

            AmsRoute localRoute = new AmsRoute("--Local--", "127.0.0.0.1.1", new byte[6]);
            Tuple<AmsRoute, string> localComboBoxItem = new Tuple<AmsRoute, string>(localRoute, $"--Local-- ({localRoute.GetAmsNetIdString()})");
            cmbAmsNetId.Items.Add(localComboBoxItem);

            List<AmsRoute> routes = TwinCatRouteHelper.GetAllExistingRoutes();
            foreach (AmsRoute route in routes)
            {
                Tuple<AmsRoute, string> comboBoxItem = new Tuple<AmsRoute, string>(route, $"{route.Address} ({route.GetAmsNetIdString()})");
                cmbAmsNetId.Items.Add(comboBoxItem);
            }

            cmbAmsNetId.DisplayMember = "Item2";
            cmbAmsNetId.ValueMember = "Item1";

            if (routes.Count > 0)
                cmbAmsNetId.SelectedIndex = 0;

            // Change default port for systems running TC3 X64
            if (Environment.Is64BitOperatingSystem)
            {
                nudPort.Value = 851;
            }
        }
        */

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string amsNetId = GetSelectedAmsNetId();
            MotordriveVariableSnifferForm motordriveVariableSnifferForm = new MotordriveVariableSnifferForm(amsNetId, (int)nudPort.Value);
            this.Hide();
            motordriveVariableSnifferForm.ShowDialog();

            GC.Collect();
        }

        private string GetSelectedAmsNetId()
        {
            int selectedIndex = cmbAmsNetId.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < cmbAmsNetId.Items.Count)
            {
                if (cmbAmsNetId.Items[selectedIndex] is Tuple<AmsRoute, string> comboBoxItem)
                    return comboBoxItem.Item1.GetAmsNetIdString();
            }

            if (cmbAmsNetId.SelectedValue is AmsRoute route)
                return route.GetAmsNetIdString();
            return cmbAmsNetId.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbAmsNetId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MotordriveMonitorMainForm_Load(object sender, EventArgs e)
        {

            if (mDesignModeActive)
                return;

            //AmsRoute localRoute = new AmsRoute("--Local--", AmsNetId.LocalHost.ToString(), new byte[6]);
            //Tuple<AmsRoute, string> localComboBoxItem = new Tuple<AmsRoute, string>(localRoute, $"--Local-- ({localRoute.GetAmsNetIdString()})");
            //cmbAmsNetId.Items.Add(localComboBoxItem);

            List<AmsRoute> routes = TwinCatRouteHelper.GetAllExistingRoutes();
            foreach (AmsRoute route in routes)
            {
                Tuple<AmsRoute, string> comboBoxItem = new Tuple<AmsRoute, string>(route, $"{route.Address} ({route.GetAmsNetIdString()})");
                cmbAmsNetId.Items.Add(comboBoxItem);
            }

            cmbAmsNetId.DisplayMember = "Item2";
            cmbAmsNetId.ValueMember = "Item1";

            if (routes.Count > 0)
                cmbAmsNetId.SelectedIndex = 0;

            // Change default port for systems running TC3 X64
            if (Environment.Is64BitOperatingSystem)
            {
                nudPort.Value = 851;
            }
        }
    }
}
