using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HostsUpdateTools.Properties;
using Microsoft.Win32;

namespace HostsUpdateTools
{
    public partial class MainFrm : Form
    {
        private string _hostsUri = Settings.Default.HostsUri;
        private string _localHostsPath = Settings.Default.TestHostsPath;
        private string _regexString = Settings.Default.RegexGetUpdateTime;
        private bool _isFastStart = Settings.Default.FastStart;

        public MainFrm()
        {
            InitializeComponent();

            // 处理启动参数：开机启动隐藏窗体
            if (Environment.GetCommandLineArgs().Length > 1) Hide();
        }

        private async void BtnUpdate_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Text = "UPDATE...";
                int result = await UpdateHosts(_hostsUri, _localHostsPath, _regexString, _isFastStart);
                if (result is 1)
                {
                    btnUpdate.Text = "Success!";
                    nico.ShowBalloonTip(1, "Success", "更新成功", ToolTipIcon.Info);
                }
                else
                {
                    btnUpdate.Text = "Not Update!";
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                OpenFileDialog open = new OpenFileDialog()
                {
                    InitialDirectory = _localHostsPath,
                    RestoreDirectory = true
                };
                if (open.ShowDialog() is DialogResult.OK)
                {
                    Settings.Default.HostsPath = _localHostsPath = open.FileName;
                    Settings.Default.Save();
                    MessageBox.Show("Hosts文件路径已保存，点击确定重新更新！", "保存成功");
                    btnUpdate.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await Task.Delay(2 * 1000);
                btnUpdate.Text = "UPDATE";
            }
        }

        private async Task<int> UpdateHosts(string uri, string path, string regex, bool fastStart)
        {
            // 获取远程HostsData
            string remoteHostsString = await Hosts.DownloadHostsStringAsync(uri);
            HostsData remoteData = Hosts.GetHostsData(remoteHostsString, _regexString);
            int result = 1;
            if (!fastStart)
            {
                // 获取本地HostsData
                string localHostsString = File.ReadAllText(path);
                HostsData localData = Hosts.GetHostsData(localHostsString, regex);
                result = remoteData.Equals(localData);
            }
            if (result is 1)
            {
                File.WriteAllText(path, remoteHostsString);
                Settings.Default.FastStart = _isFastStart = false;
                Settings.Default.Save();
            }
            return result;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!tsmlAutoUpdate.Checked)
            {
                timer.Stop();
                return;
            }

            timer.Interval = Settings.Default.AutoUpdateInterval;
            btnUpdate.PerformClick();
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        private void TsmlAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFastStart)
            {
                MessageBox.Show("重要提醒", "请先手动更新成功一次之后再开启自动更新！");
                return;
            }

            if (tsmlAutoUpdate.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }

            Settings.Default.IsAutoUpdate = tsmlAutoUpdate.Checked;
            Settings.Default.Save();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason is CloseReason.UserClosing)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        private void TsmlOpen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button is MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }

        private void TsmlExit_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void TsmlBoot_CheckedChanged(object sender, EventArgs e)
        {
            string subKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

            RegistryKey rkey = Registry.CurrentUser.CreateSubKey(subKey);
            try
            {
                if (tsmlBoot.Checked && rkey.GetValue(Name) is null)
                {
                    rkey.SetValue(Name, $"{Application.ExecutablePath} -m");
                }
                else
                {
                    rkey.DeleteValue(Name, false);
                }
            }
            finally
            {
                rkey.Close();
                Settings.Default.IsBoot = tsmlBoot.Checked;
                Settings.Default.Save();
            }
        }
    }
}
