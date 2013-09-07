// Copyright (c) 2013 Runxia Electronics Co. Ltd

// Some of the code are integrated from original Virtual Router Project
/*
* Virtual Router v1.0 - http://virtualrouter.codeplex.com
* Wifi Hot Spot for Windows 7 and 2008 R2
* Copyright (c) 2011 Chris Pietschmann (http://pietschsoft.com)
* Licensed under the Microsoft Public License (Ms-PL)
* http://virtualrouter.codeplex.com/license
*/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AQWiFi.Properties;

namespace AQWiFi
{
    public partial class MainForm : Form
    {
        WlanManager wlanManager = new WlanManager();
        IcsManager icsManager = new IcsManager();

        bool isStarted;

        public MainForm()
        {
            InitializeComponent();
        }

        public string GetRnd(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            wlanManager.HostedNetworkAvailable += wlanManager_HostedNetworkAvailable;
            wlanManager.StationJoin += wlanManager_StationJoin;

            RefreshConnection();

            if ((Settings.Default.SSID == "AQWiFi" && Settings.Default.Password == "12345678")
                || (Settings.Default.SSID == "" && Settings.Default.Password == ""))
            {
                Settings.Default.SSID = "AQ-" + GetRnd(6, true, false, true, false, "");
                Settings.Default.Password = GetRnd(8, true, false, false, false, "");
            }

            ssidTextBox.Text = Settings.Default.SSID;
            passwordTextBox.Text = Settings.Default.Password;

            foreach (IcsConnection connection in connectionComboBox.Items)
            {
                if (connection.Name == Settings.Default.Connection)
                {
                    connectionComboBox.SelectedItem = connection;
                    break;
                }
            }
        }

        void wlanManager_StationJoin(object sender, EventArgs e)
        {
            
        }

        void wlanManager_HostedNetworkAvailable(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.SSID = ssidTextBox.Text;
            Settings.Default.Password = passwordTextBox.Text;
            Settings.Default.Connection = connectionComboBox.Text;
            Settings.Default.Save();

            if (isStarted) Stop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;
            startButton.Enabled = false;
            ssidTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            connectionComboBox.Enabled = false;
            refreshConnectionButton.Enabled = false;
            startButton.Text = "稍等......";

            if (isStarted)
            {
                if (Stop())
                {
                    isStarted = false;
                    notifyIcon.ShowBalloonTip(5000, "AQWiFi", "无线热点已关闭", ToolTipIcon.Info);
                }
                else
                {
                    MessageBox.Show("无线热点不能关闭，请稍后再试。", "AQWiFi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                if (Start(ssidTextBox.Text, passwordTextBox.Text, (IcsConnection)connectionComboBox.SelectedItem, 16))
                {
                    isStarted = true;
                    WindowState = FormWindowState.Minimized;
                    notifyIcon.ShowBalloonTip(5000, "AQWiFi", "无线热点已开启", ToolTipIcon.Info);
                }
                else
                {
                    MessageBox.Show("无线热点不能开启，请检查硬件是否支持。", "AQWiFi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            notifyIcon.Icon = new Icon(isStarted ? "AQWiFiStarted.ico" : "AQWiFiStopped.ico");
            startButton.Text = isStarted ? "关闭无线热点" : "开启无线热点";
            
            ssidTextBox.Enabled = !isStarted;
            passwordTextBox.Enabled = !isStarted;
            connectionComboBox.Enabled = !isStarted;
            refreshConnectionButton.Enabled = !isStarted;
            startButton.Enabled = true;
        }

        private bool Start(string ssid, string password, IcsConnection connection, int maxClients)
        {
            try
            {
                Stop();

                wlanManager.SetConnectionSettings(ssid, 32);
                wlanManager.SetSecondaryKey(password);

                wlanManager.StartHostedNetwork();

                var privateConnectionGuid = wlanManager.HostedNetworkInterfaceGuid;

                icsManager.EnableIcs(connection.Guid, privateConnectionGuid);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool Stop()
        {
            try
            {
                if (this.icsManager.SharingInstalled)
                {
                    this.icsManager.DisableIcsOnAll();
                }

                this.wlanManager.StopHostedNetwork();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateFields()
        {
            if (ssidTextBox.Text.Length <= 0)
            {
                errorProvider.SetError(ssidTextBox, "请输入网络名称(SSID)");
                return false;
            }

            if (ssidTextBox.Text.Length > 32)
            {
                errorProvider.SetError(ssidTextBox, "网络名称(SSID)不能长于32个字符");
                return false;
            }

            if (passwordTextBox.Text.Length < 8)
            {
                errorProvider.SetError(ssidTextBox, "密码至少需要8个字符");
                return false;
            }

            if (passwordTextBox.Text.Length > 64)
            {
                errorProvider.SetError(ssidTextBox, "密码不能长于64个字符");
                return false;
            }

            return true;
        }

        private void refreshConnectionButton_Click(object sender, EventArgs e)
        {
            RefreshConnection();
        }

        private void RefreshConnection()
        {
            connectionComboBox.Items.Clear();

            foreach (var connection in icsManager.Connections)
            {
                if (connection.IsConnected && connection.IsSupported)
                {
                    connectionComboBox.Items.Add(connection);
                }
            }

            if (connectionComboBox.Items.Count > 0)
                connectionComboBox.SelectedIndex = 0;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            /*if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }*/
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
