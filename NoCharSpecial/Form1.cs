using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoCharSpecial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CheckUpdates();
        }

        private void ContentBox_TextChanged(object sender, EventArgs e)
        {
            ResultBox.Text = RCharSpecial.Remove(ContentBox.Text);
            ResultBox.Text = ResultBox.Text.ToUpper();
        }

        private void ResultBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private async void CheckUpdates()
        {
            UpdateManager manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/GabrielMarussi/NoSpecialChar");

            Text += " " + manager.CurrentlyInstalledVersion().ToString();

            var updateInfo = await manager.CheckForUpdate();

            if(updateInfo.ReleasesToApply.Count > 0)
            {
                await manager.UpdateApp();

                MessageBox.Show("Updated succesfuly!");
            }
        }
    }
}
