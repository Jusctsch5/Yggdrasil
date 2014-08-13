﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Dialogs;

using Yggdrasil.Helpers;

namespace Yggdrasil
{
    public partial class MainForm : Form
    {
        GameDataManager game;

        public MainForm()
        {
            InitializeComponent();

            SetFormTitle();

            tsslStatus.Text = "Ready";

            game = new GameDataManager();
        }

        private void SetFormTitle()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0} {1}", Application.ProductName, VersionManagement.CreateVersionString(Application.ProductVersion));
            if (game != null && game.IsInitialized) stringBuilder.AppendFormat(" - [{0}]", game.Header.GameTitle);
            this.Text = stringBuilder.ToString();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommonOpenFileDialog.IsPlatformSupported)
            {
                CommonOpenFileDialog ofd = new CommonOpenFileDialog();
                ofd.IsFolderPicker = true;
                ofd.InitialDirectory = Configuration.LastDataPath;
                ofd.Title = "Select game folder";
                if (ofd.ShowDialog() == CommonFileDialogResult.Ok) LoadGameData(ofd.FileName);
            }
            else
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Please select folder with extracted Etrian Odyssey game data.";
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) LoadGameData(fbd.SelectedPath);
            }
        }

        private void LoadGameData(string path)
        {
            game.ReadGameDirectory(Configuration.LastDataPath = path);
            SetFormTitle();

            InitializeTabPage(tabControl.SelectedTab);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.SaveAllChanges();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0} {1}\n\nWritten 2014 by xdaniel - https://github.com/xdanieldzd/", Application.ProductName, VersionManagement.CreateVersionString(Application.ProductVersion)),
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (game.DataHasChanged &&
                MessageBox.Show("Data has been changed. Discard changes and quit without saving?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No);
        }

        private void InitializeTabPage(TabPage tabPage)
        {
            if (tabPage.Tag == null)
            {
                if (tabPage == tpEquipment)
                {
                    cmbEquipment.DisplayMember = "Name";
                    cmbEquipment.DataSource = game.GetParsedData<Yggdrasil.TableParsers.EquipItemData>();
                    pgEquipment.SelectedObject = ((dynamic)cmbEquipment.DataSource)[0];
                }
                else if (tabPage == tpMessages)
                {
                    if (!messageEditor.IsInitialized) messageEditor.Initialize(game);
                }

                tabPage.Tag = game;
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            InitializeTabPage(e.TabPage);
        }

        private void cmbEquipment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pgEquipment.SelectedObject = (sender as ComboBox).SelectedItem;
        }
    }
}
