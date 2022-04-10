using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutoChromeProfile
{
    public partial class Form1 : Form
    {
        private string folderProfileName = "AutofillRegex|AutofillStates|BrowserMetrics|CertificateRevocation|ClientSidePhishing|Crashpad|Crowd Deny|DesktopSharingHub|FileTypePolicies|FirstPartySetsPreloaded|Floc|GrShaderCache|hyphen-data|MEIPreload|Notification Resources|OnDeviceHeadSuggestModel|OptimizationGuidePredictionModels|OptimizationHints|OriginTrials|PKIMetadata|pnacl|PnaclTranslationCache|RecoveryImproved|Safe Browsing|SafetyTips|ShaderCache|SSLErrorAssistant|Subresource Filter|SwReporter|ThirdPartyModuleList64|TrustTokenKeyCommitments|Webstore Downloads|WidevineCdm|ZxcvbnData";

        List<string> listAllFolderProfile;
        bool bWaiting;
        public Form1()
        {
            InitializeComponent();
        }

        private string GetArgument(string linkPathName)
        {
            WshShell wshShell = (WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
            return ((IWshShortcut)(dynamic)wshShell.CreateShortcut(linkPathName)).Arguments.Replace("--profile-directory=", "").Replace("-profile-directory=", "").Replace("\"", "")
                .Trim();
        }


        private void btnSelectProfilesFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    listAllFolderProfile = new List<string>();
                    listViewNotRun.Items.Clear();
                    listViewRun.Items.Clear();
                    txtProfilesFolder.Text = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.profileFolderPath = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                    string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.lnk");
                    int maxlength = files.Max((string x) => x.Length);
                    files = files.OrderBy((string x) => x.PadLeft(maxlength, '0')).ToArray();
                    string[] array = files;
                    foreach (string text in array)
                    {
                        string[] items = new string[2] { Path.GetFileNameWithoutExtension(text), "Waiting" };
                        listViewNotRun.Items.Add(new ListViewItem(items));
                        listAllFolderProfile.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "User Data", GetArgument(text)));
                    }
                }
            }
        }

        private void btnSelectProfile_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem selectedItem in listViewNotRun.SelectedItems)
                {
                    string[] items = new string[2] { selectedItem.Text, "Waiting" };
                    listViewRun.Items.Add(new ListViewItem(items));
                    listViewNotRun.Items.Remove(selectedItem);
                }
                string[] source = (from x in listViewRun.Items.OfType<ListViewItem>()
                                   select x.Text).ToArray();
                int maxlength = source.Max((string x) => x.Length);
                source = source.OrderBy((string x) => x.PadLeft(maxlength, '0')).ToArray();
                listViewRun.Items.Clear();
                string[] array = source;
                foreach (string text in array)
                {
                    string[] items2 = new string[2] { text, "Waiting" };
                    listViewRun.Items.Add(new ListViewItem(items2));
                }
            }
            catch
            {
            }
        }

        private void btnRemoveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem selectedItem in listViewRun.SelectedItems)
                {
                    string[] items = new string[1] { selectedItem.Text };
                    listViewNotRun.Items.Add(new ListViewItem(items));
                    listViewRun.Items.Remove(selectedItem);
                }
                string[] source = (from x in listViewNotRun.Items.OfType<ListViewItem>()
                                   select x.Text).ToArray();
                int maxlength = source.Max((string x) => x.Length);
                source = source.OrderBy((string x) => x.PadLeft(maxlength, '0')).ToArray();
                listViewNotRun.Items.Clear();
                string[] array = source;
                foreach (string text in array)
                {
                    string[] items2 = new string[2] { text, "Waiting" };
                    listViewNotRun.Items.Add(new ListViewItem(items2));
                }
            }
            catch
            {
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewNotRun.Items.Count; i++)
            {
                string[] items = new string[2] { listViewNotRun.Items[i].Text, "Waiting" };
                listViewRun.Items.Add(new ListViewItem(items));
            }
            listViewNotRun.Items.Clear();
            string[] source = (from x in listViewRun.Items.OfType<ListViewItem>()
                               select x.Text).ToArray();
            int maxlength = source.Max((string x) => x.Length);
            source = source.OrderBy((string x) => x.PadLeft(maxlength, '0')).ToArray();
            listViewRun.Items.Clear();
            string[] array = source;
            foreach (string text in array)
            {
                string[] items2 = new string[2] { text, "Waiting" };
                listViewRun.Items.Add(new ListViewItem(items2));
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewRun.Items.Count; i++)
            {
                string[] items = new string[1] { listViewRun.Items[i].SubItems[0].Text };
                listViewNotRun.Items.Add(new ListViewItem(items));
            }
            listViewRun.Items.Clear();
            string[] source = (from x in listViewNotRun.Items.OfType<ListViewItem>()
                               select x.Text).ToArray();
            int maxlength = source.Max((string x) => x.Length);
            source = source.OrderBy((string x) => x.PadLeft(maxlength, '0')).ToArray();
            listViewNotRun.Items.Clear();
            string[] array = source;
            foreach (string text in array)
            {
                string[] items2 = new string[2] { text, "Waiting" };
                listViewNotRun.Items.Add(new ListViewItem(items2));
            }
        }

        private void CloseAllChromeDriver()
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName("chromedriver");
                if (processesByName != null && processesByName.Length != 0)
                {
                    Process[] array = processesByName;
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i].Kill();
                    }
                }
            }
            catch
            {
            }
        }

        private void CloseAllChrome()
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName("chrome");
                if (processesByName != null && processesByName.Length != 0)
                {
                    Process[] array = processesByName;
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i].Kill();
                    }
                }
            }
            catch
            {
            }
        }

        bool m_bRunning;
        int m_nRunningCount;

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPostLink.Text))
            {
                MessageBox.Show("Please Input Post Link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNumberGroup.Text))
            {
                MessageBox.Show("Please Input Number Of Groups Select", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (listViewRun.Items.Count <= 0)
            {
                MessageBox.Show("Please Select Profile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            CloseAllChrome();
            CloseAllChromeDriver();
            int numberAtTime = listViewRun.Items.Count;
            btnSelectAll.Enabled = false;
            btnSelectProfile.Enabled = false;
            btnSelectProfilesFolder.Enabled = false;
            txtPostLink.Enabled = false;
            btnRemoveAll.Enabled = false;
            btnStart.Enabled = false;
            btnRemoveProfile.Enabled = false;
            txtNumberGroup.Enabled = false;
            txtNAT.Enabled = false;
            string profileLink = txtProfilesFolder.Text;
            string profileName = string.Empty;
            if (int.Parse(txtNAT.Text) > numberAtTime)
            {
                txtNAT.Text = numberAtTime.ToString();
            }
            int nIndexRunning = 0;
            bWaiting = false;
            await Task.Run(delegate
            {
                m_bRunning = true;
                m_nRunningCount = 0;
                for (nIndexRunning = 0; nIndexRunning < int.Parse(txtNAT.Text); nIndexRunning++)
                {
                    listViewRun.Invoke((Action)delegate
                    {
                        profileName = listViewRun.Items[nIndexRunning].SubItems[0].Text;
                        listViewRun.Items[nIndexRunning].SubItems[1].Text = "Running";
                    });
                    Run(profileLink + "\\" + profileName + ".lnk", nIndexRunning, profileLink, profileName);
                    m_nRunningCount++;
                }
                nIndexRunning--;
                while (m_bRunning)
                {
                    while (m_nRunningCount >= int.Parse(txtNAT.Text) && m_bRunning && listViewRun.Items.OfType<ListViewItem>().FirstOrDefault((ListViewItem x) => x.SubItems[1].Text != "Can't load extension" && x.SubItems[1].Text != "Done" && x.SubItems[1].Text != "Died" && x.SubItems[1].Text != "Error" && x.SubItems[1].Text != "Posting") != null)
                    {
                        Thread.Sleep(1000);
                    }
                    if (m_bRunning)
                    {
                        nIndexRunning++;
                        m_nRunningCount++;
                        if (nIndexRunning < numberAtTime)
                        {
                            listViewRun.Invoke((Action)delegate
                            {
                                profileName = listViewRun.Items[nIndexRunning].SubItems[0].Text;
                                listViewRun.Items[nIndexRunning].SubItems[1].Text = "Running";
                            });
                            Run(profileLink + "\\" + profileName + ".lnk", nIndexRunning, profileLink, profileName);
                        }
                        if (listViewRun.Items.OfType<ListViewItem>().FirstOrDefault((ListViewItem x) => x.SubItems[1].Text != "Can't load extension" && x.SubItems[1].Text != "Done" && x.SubItems[1].Text != "Died" && x.SubItems[1].Text != "Error" && x.SubItems[1].Text != "Posting") == null)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                }
            });
            btnSelectAll.Enabled = true;
            btnSelectProfile.Enabled = true;
            btnSelectProfilesFolder.Enabled = true;
            txtPostLink.Enabled = true;
            btnRemoveAll.Enabled = true;
            btnStart.Enabled = true;
            btnRemoveProfile.Enabled = true;
            txtNumberGroup.Enabled = true;
            txtNAT.Enabled = true;
        }

        private void Run(string strProfile, int index, string profileLink, string shortcutprofileName)
        {
            new Thread((ThreadStart)delegate
            {
                try
                {
                    string pathLink = strProfile;
                    WshShell wshShell = (WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
                    IWshShortcut obj = (IWshShortcut)(dynamic)wshShell.CreateShortcut(pathLink);
                    string targetPath = obj.TargetPath;
                    _ = obj.Arguments;
                    if (Environment.Is64BitOperatingSystem)
                    {
                        targetPath = targetPath.Replace(" (x86)", "");
                    }
                    string text = "profiles\\" + GetArgument(strProfile);
                    string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "User Data");
                    if (Directory.Exists(text))
                    {
                        DeleteAll(text);
                        Directory.Delete(text, recursive: true);
                    }
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                        CopyFilesRecursivelyAAAAAAAA(text2, text);
                        CopyFilesRecursively(Path.Combine(text2, GetArgument(strProfile)), Path.Combine(text, GetArgument(strProfile)), all: false);
                        CopyFilesRecursively(Path.Combine(text2, "Default"), Path.Combine(text, "Default"), all: false);
                    }
                    RunAuto(text, GetArgument(strProfile), index, profileLink, shortcutprofileName);
                    if (Directory.Exists(text))
                    {
                        DeleteAll(text);
                        Directory.Delete(text, recursive: true);
                    }
                }
                catch
                {
                }
            }).Start();
        }


        private void DeleteAll(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                files[i].Delete();
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
                directories[i].Delete(recursive: true);
            }
        }

        private void CopyFilesRecursivelyAAAAAAAA(string sourcePath, string targetPath)
        {
            try
            {
                List<string> list = folderProfileName.Split('|').ToList();
                string[] files = Directory.GetFiles(sourcePath, "*", SearchOption.TopDirectoryOnly);
                foreach (string text in files)
                {
                    try
                    {
                        System.IO.File.Copy(text, text.Replace(sourcePath, targetPath), overwrite: true);
                    }
                    catch (Exception)
                    {
                    }
                }
                foreach (string item in list)
                {
                    string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "User Data", item);
                    try
                    {
                        Directory.CreateDirectory(text2.Replace(sourcePath, targetPath));
                    }
                    catch (Exception)
                    {
                    }
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "User Data", text2);
                    files = Directory.GetDirectories(text2, "*", SearchOption.AllDirectories);
                    foreach (string text3 in files)
                    {
                        try
                        {
                            Directory.CreateDirectory(text3.Replace(sourcePath, targetPath));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    List<string> list2 = new List<string>();
                    try
                    {
                        list2 = Directory.GetFiles(text2, "*.*", SearchOption.AllDirectories).ToList();
                    }
                    catch
                    {
                        continue;
                    }
                    foreach (string item2 in list2)
                    {
                        try
                        {
                            System.IO.File.Copy(item2, item2.Replace(sourcePath, targetPath), overwrite: true);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void CopyFilesRecursively(string sourcePath, string targetPath, bool all = true)
        {
            Directory.CreateDirectory(targetPath);
            List<string> list = Directory.GetDirectories(sourcePath).ToList();
            list.RemoveAll((string x) => x.Contains("Service Worker"));
            list.RemoveAll((string x) => x.Contains("Code Cache"));
            string[] files = Directory.GetFiles(sourcePath, "*", SearchOption.TopDirectoryOnly);
            foreach (string text in files)
            {
                try
                {
                    System.IO.File.Copy(text, text.Replace(sourcePath, targetPath), overwrite: true);
                }
                catch (Exception)
                {
                }
            }
            foreach (string item in list)
            {
                try
                {
                    Directory.CreateDirectory(item.Replace(sourcePath, targetPath));
                }
                catch (Exception)
                {
                }
                files = Directory.GetDirectories(item, "*", SearchOption.AllDirectories);
                foreach (string text2 in files)
                {
                    try
                    {
                        Directory.CreateDirectory(text2.Replace(sourcePath, targetPath));
                    }
                    catch (Exception)
                    {
                    }
                }
                List<string> list2 = Directory.GetFiles(item, "*.*", SearchOption.AllDirectories).ToList();
                if (!all)
                {
                    list2.RemoveAll((string x) => x.Contains("Service Worker"));
                    list2.RemoveAll((string x) => x.Contains("Code Cache"));
                }
                foreach (string item2 in list2)
                {
                    try
                    {
                        System.IO.File.Copy(item2, item2.Replace(sourcePath, targetPath), overwrite: true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public void RunAuto(string profilePath, string profileName, int index, string profileLink, string shortcutprofileName)
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-notifications");
            chromeOptions.AddArguments("--disable-infobars");
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddArguments("--user-data-dir=" + Environment.CurrentDirectory + "\\" + profilePath);
            chromeOptions.AddArguments("--profile-directory=" + profileName);
            chromeOptions.AddArguments("--load-extension=" + Environment.CurrentDirectory + "\\extensions");
            ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            try
            {
                chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(900.0);
                Thread.Sleep(1000);
                ((IJavaScriptExecutor)chromeDriver).ExecuteScript("window.open();", Array.Empty<object>());
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                Thread.Sleep(1000);
                chromeDriver.Navigate().GoToUrl("https://mobile.facebook.com/");
                Thread.Sleep(1000);
                try
                {
                    if (chromeDriver.FindElement(By.XPath("//button[@value='Log In']")) != null)
                    {
                        System.IO.File.Copy(Path.Combine(profileLink, shortcutprofileName + ".lnk"), Path.Combine("profiles_died", shortcutprofileName + ".lnk"));
                        System.IO.File.Delete(Path.Combine(profileLink, shortcutprofileName + ".lnk"));
                        listViewRun.Invoke((Action)delegate
                        {
                            listViewRun.Items[index].SubItems[1].Text = "Died";
                        });
                        try
                        {
                            chromeDriver.Close();
                            chromeDriver.Quit();
                        }
                        catch
                        {
                        }
                        m_nRunningCount--;
                        bWaiting = false;
                        return;
                    }
                }
                catch
                {
                }
                try
                {
                    if (chromeDriver.PageSource.Contains("Your account has been disabled"))
                    {
                        System.IO.File.Copy(Path.Combine(profileLink, shortcutprofileName + ".lnk"), Path.Combine("profiles_died", shortcutprofileName + ".lnk"));
                        System.IO.File.Delete(Path.Combine(profileLink, shortcutprofileName + ".lnk"));
                        listViewRun.Invoke((Action)delegate
                        {
                            listViewRun.Items[index].SubItems[1].Text = "Died";
                        });
                        try
                        {
                            chromeDriver.Close();
                            chromeDriver.Quit();
                        }
                        catch
                        {
                        }
                        m_nRunningCount--;
                        bWaiting = false;
                        return;
                    }
                }
                catch
                {
                }
                try
                {
                    if (chromeDriver.PageSource.Contains("This page isn’t working"))
                    {
                        System.IO.File.Copy(Path.Combine(profileLink, shortcutprofileName + ".lnk"), Path.Combine("profiles_died", shortcutprofileName + ".lnk"));
                        System.IO.File.Delete(Path.Combine(profileLink, shortcutprofileName + ".lnk"));
                        listViewRun.Invoke((Action)delegate
                        {
                            listViewRun.Items[index].SubItems[1].Text = "Died";
                        });
                        try
                        {
                            chromeDriver.Close();
                            chromeDriver.Quit();
                        }
                        catch
                        {
                        }
                        m_nRunningCount--;
                        bWaiting = false;
                        return;
                    }
                }
                catch
                {
                }
                try
                {
                    if (chromeDriver.PageSource.Contains("has been locked"))
                    {
                        System.IO.File.Copy(Path.Combine(profileLink, shortcutprofileName + ".lnk"), Path.Combine("profiles_died", shortcutprofileName + ".lnk"));
                        System.IO.File.Delete(Path.Combine(profileLink, shortcutprofileName + ".lnk"));
                        listViewRun.Invoke((Action)delegate
                        {
                            listViewRun.Items[index].SubItems[1].Text = "Died";
                        });
                        try
                        {
                            chromeDriver.Close();
                            chromeDriver.Quit();
                        }
                        catch
                        {
                        }
                        m_nRunningCount--;
                        bWaiting = false;
                        return;
                    }
                }
                catch
                {
                }
                try
                {
                    if (chromeDriver.Url.Contains("free"))
                    {
                        IJavaScriptExecutor javaScriptExecutor = chromeDriver;
                        foreach (IWebElement item in chromeDriver.FindElements(By.XPath("//a[@id='toggleHeaderButton']")))
                        {
                            try
                            {
                                javaScriptExecutor.ExecuteScript("arguments[0].click()", item);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            break;
                        }
                        IWebElement webElement = chromeDriver.FindElement(By.XPath("//input[@id='upsell_upgrade_confirm_button']"));
                        ((IJavaScriptExecutor)chromeDriver).ExecuteScript("arguments[0].click()", new object[1] { webElement });
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception)
                {
                }
                ((IJavaScriptExecutor)chromeDriver).ExecuteScript("window.open();", Array.Empty<object>());
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                chromeDriver.Navigate().GoToUrl("chrome://system/");
                try
                {
                    Thread.Sleep(5000);
                    string text = string.Empty;
                    (new string[1])[0] = "//div[@id='card']";
                    Thread.Sleep(3000);
                    chromeDriver.FindElement(By.XPath("//button[@id='extensions-value-btn']")).Click();
                    Thread.Sleep(100);
                    string[] array = chromeDriver.FindElement(By.XPath("//div[@id='extensions-value']")).Text.Split(new string[2] { ":", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].Contains("PRO AUTO GROUP POSTER"))
                        {
                            text = array[i - 1].Trim();
                            break;
                        }
                    }
                    chromeDriver.Close();
                    chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                    ((IJavaScriptExecutor)chromeDriver).ExecuteScript("window.open();", Array.Empty<object>());
                    chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                    chromeDriver.Navigate().GoToUrl("chrome-extension://" + text + "/index.html");
                }
                catch
                {
                    try
                    {
                        Thread.Sleep(5000);
                        string text2 = string.Empty;
                        (new string[1])[0] = "//div[@id='card']";
                        Thread.Sleep(3000);
                        chromeDriver.FindElement(By.XPath("//button[@id='extensions-value-btn']")).Click();
                        Thread.Sleep(100);
                        string[] array2 = chromeDriver.FindElement(By.XPath("//div[@id='extensions-value']")).Text.Split(new string[2] { ":", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < array2.Length; j++)
                        {
                            if (array2[j].Contains("PRO AUTO GROUP POSTER"))
                            {
                                text2 = array2[j - 1].Trim();
                                break;
                            }
                        }
                        chromeDriver.Close();
                        chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                        ((IJavaScriptExecutor)chromeDriver).ExecuteScript("window.open();", Array.Empty<object>());
                        chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                        chromeDriver.Navigate().GoToUrl("chrome-extension://" + text2 + "/index.html");
                    }
                    catch
                    {
                        try
                        {
                            Thread.Sleep(5000);
                            string text3 = string.Empty;
                            (new string[1])[0] = "//div[@id='card']";
                            Thread.Sleep(3000);
                            chromeDriver.FindElement(By.XPath("//button[@id='extensions-value-btn']")).Click();
                            Thread.Sleep(100);
                            string[] array3 = chromeDriver.FindElement(By.XPath("//div[@id='extensions-value']")).Text.Split(new string[2] { ":", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                            for (int k = 0; k < array3.Length; k++)
                            {
                                if (array3[k].Contains("PRO AUTO GROUP POSTER"))
                                {
                                    text3 = array3[k - 1].Trim();
                                    break;
                                }
                            }
                            chromeDriver.Close();
                            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                            ((IJavaScriptExecutor)chromeDriver).ExecuteScript("window.open();", Array.Empty<object>());
                            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                            chromeDriver.Navigate().GoToUrl("chrome-extension://" + text3 + "/index.html");
                            goto end_IL_06df;
                        }
                        catch
                        {
                            try
                            {
                                Thread.Sleep(5000);
                                string text4 = string.Empty;
                                (new string[1])[0] = "//div[@id='card']";
                                Thread.Sleep(3000);
                                chromeDriver.FindElement(By.XPath("//button[@id='extensions-value-btn']")).Click();
                                Thread.Sleep(100);
                                string[] array4 = chromeDriver.FindElement(By.XPath("//div[@id='extensions-value']")).Text.Split(new string[2] { ":", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                for (int l = 0; l < array4.Length; l++)
                                {
                                    if (array4[l].Contains("PRO AUTO GROUP POSTER"))
                                    {
                                        text4 = array4[l - 1].Trim();
                                        break;
                                    }
                                }
                                chromeDriver.Close();
                                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                                ((IJavaScriptExecutor)chromeDriver).ExecuteScript("window.open();", Array.Empty<object>());
                                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                                chromeDriver.Navigate().GoToUrl("chrome-extension://" + text4 + "/index.html");
                                goto end_IL_06df;
                            }
                            catch
                            {
                                try
                                {
                                    Thread.Sleep(5000);
                                    string text5 = string.Empty;
                                    (new string[1])[0] = "//div[@id='card']";
                                    Thread.Sleep(3000);
                                    chromeDriver.FindElement(By.XPath("//button[@id='extensions-value-btn']")).Click();
                                    Thread.Sleep(100);
                                    string[] array5 = chromeDriver.FindElement(By.XPath("//div[@id='extensions-value']")).Text.Split(new string[2] { ":", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                    for (int m = 0; m < array5.Length; m++)
                                    {
                                        if (array5[m].Contains("PRO AUTO GROUP POSTER"))
                                        {
                                            text5 = array5[m - 1].Trim();
                                            break;
                                        }
                                    }
                                    chromeDriver.Close();
                                    chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                                    ((IJavaScriptExecutor)chromeDriver).ExecuteScript("window.open();", Array.Empty<object>());
                                    chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                                    chromeDriver.Navigate().GoToUrl("chrome-extension://" + text5 + "/index.html");
                                    goto end_IL_06df;
                                }
                                catch
                                {
                                    Thread.Sleep(5000);
                                    string text6 = string.Empty;
                                    (new string[1])[0] = "//div[@id='card']";
                                    Thread.Sleep(3000);
                                    chromeDriver.FindElement(By.XPath("//button[@id='extensions-value-btn']")).Click();
                                    Thread.Sleep(100);
                                    string[] array6 = chromeDriver.FindElement(By.XPath("//div[@id='extensions-value']")).Text.Split(new string[2] { ":", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                    for (int n = 0; n < array6.Length; n++)
                                    {
                                        if (array6[n].Contains("PRO AUTO GROUP POSTER"))
                                        {
                                            text6 = array6[n - 1].Trim();
                                            break;
                                        }
                                    }
                                    chromeDriver.Close();
                                    chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                                    ((IJavaScriptExecutor)chromeDriver).ExecuteScript("window.open();", Array.Empty<object>());
                                    chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                                    chromeDriver.Navigate().GoToUrl("chrome-extension://" + text6 + "/index.html");
                                    goto end_IL_06df;
                                }
                            }
                        }
                    end_IL_06df:;
                    }
                }
                Thread.Sleep(15000);
                if (chromeDriver.Url.Contains("facebook"))
                {
                    System.IO.File.Copy(Path.Combine(profileLink, shortcutprofileName + ".lnk"), Path.Combine("profiles_died", shortcutprofileName + ".lnk"));
                    System.IO.File.Delete(Path.Combine(profileLink, shortcutprofileName + ".lnk"));
                    listViewRun.Invoke((Action)delegate
                    {
                        listViewRun.Items[index].SubItems[1].Text = "Died";
                    });
                    try
                    {
                        chromeDriver.Close();
                        chromeDriver.Quit();
                    }
                    catch
                    {
                    }
                    m_nRunningCount--;
                    bWaiting = false;
                    return;
                }
                int num = 0;
                while (true)
                {
                    try
                    {
                        if (chromeDriver.FindElement(By.XPath("//input[@class='form-checkbox h-5 w-5 text-red-600 haonima']")) != null)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        if (num >= 60)
                        {
                            System.IO.File.Copy(Path.Combine(profileLink, shortcutprofileName + ".lnk"), Path.Combine("profiles_not_done", shortcutprofileName + ".lnk"));
                            System.IO.File.Delete(Path.Combine(profileLink, shortcutprofileName + ".lnk"));
                            listViewRun.Invoke((Action)delegate
                            {
                                listViewRun.Items[index].SubItems[1].Text = "Can't load extension";
                            });
                            try
                            {
                                chromeDriver.Close();
                                chromeDriver.Quit();
                            }
                            catch
                            {
                            }
                            m_nRunningCount--;
                            bWaiting = false;
                            return;
                        }
                    }
                    finally
                    {
                        Thread.Sleep(1000);
                        num++;
                    }
                }
                chromeDriver.FindElement(By.XPath("//button[@class='px-4 py-2 rounded-md bg-red-100 text-red-500 clearpost']")).Click();
                Thread.Sleep(500);
                IAlert alert = chromeDriver.SwitchTo().Alert();
                Thread.Sleep(500);
                alert.Accept();
                Thread.Sleep(500);
                chromeDriver.FindElement(By.XPath("//button[@class='px-4 py-2 rounded-md bg-green-100 text-green-500 createpost']")).Click();
                Thread.Sleep(500);
                new SelectElement(chromeDriver.FindElement(By.XPath("//select[@class='w-full h-10 pl-3 pr-6 text-base placeholder-gray-600 border rounded-lg appearance-none focus:shadow-outline kil-mo']"))).SelectByText("LINK POSTS");
                Thread.Sleep(1000);
                IWebElement webElement2 = chromeDriver.FindElement(By.XPath("//input[@class='appearance-none w-full outline-none focus:outline-none active:outline-none']"));
                webElement2.Clear();
                webElement2.SendKeys(txtPostLink.Text);
                Thread.Sleep(int.Parse(txtTimeWaitPreview.Text) * 1000);
                IWebElement webElement3 = chromeDriver.FindElement(By.XPath("//button[@class='py-3 my-8 text-lg bg-gradient-to-r from-purple-500 to-indigo-600 rounded-xl text-white kill-add']"));
                IJavaScriptExecutor javaScriptExecutor2 = chromeDriver;
                javaScriptExecutor2.ExecuteScript("arguments[0].click()", webElement3);
                Thread.Sleep(1000);
                chromeDriver.FindElement(By.XPath("//button[@class='px-4 py-2 rounded-md bg-red-100 text-red-500 clear-list']")).Click();
                Thread.Sleep(500);
                IAlert alert2 = chromeDriver.SwitchTo().Alert();
                Thread.Sleep(500);
                alert2.Accept();
                Thread.Sleep(500);
                ReadOnlyCollection<IWebElement> readOnlyCollection = chromeDriver.FindElements(By.XPath("//input[@class='form-checkbox h-5 w-5 text-red-600 necheck']"));
                int num2 = int.Parse(txtNumberGroup.Text);
                for (int num3 = 0; num3 < num2; num3++)
                {
                    try
                    {
                        javaScriptExecutor2.ExecuteScript("arguments[0].click()", readOnlyCollection[num3]);
                    }
                    catch
                    {
                    }
                }
                Thread.Sleep(3000);
                IWebElement webElement4 = chromeDriver.FindElement(By.XPath("//button[@class='px-4 py-4 rounded-md shadow-lg text-center bg-yellow-500 text-white font-semibold hao-kill w-full']"));
                javaScriptExecutor2.ExecuteScript("arguments[0].click()", webElement4);
                listViewRun.Invoke((Action)delegate
                {
                    listViewRun.Items[index].SubItems[1].Text = "Posting";
                });
                m_nRunningCount--;
                bWaiting = false;
                string p;
                while (true)
                {
                    try
                    {
                        foreach (IWebElement item2 in chromeDriver.FindElement(By.XPath("//div[@class='inline-flex items-center bg-white leading-none text-gray-600 rounded-full p-2 shadow text-teal text-sm']")).FindElements(By.XPath(".//*")))
                        {
                            if (!item2.Text.Contains("post run successfully !!"))
                            {
                                continue;
                            }
                            listViewRun.Invoke((Action)delegate
                            {
                                listViewRun.Items[index].SubItems[1].Text = "Done";
                            });
                            using (StreamWriter streamWriter = System.IO.File.AppendText("Profiles_DONE.txt"))
                            {
                                p = string.Empty;
                                listViewRun.Invoke((Action)delegate
                                {
                                    p = listViewRun.Items[index].SubItems[0].Text;
                                });
                                streamWriter.WriteLine(p);
                            }
                            try
                            {
                                chromeDriver.Close();
                                chromeDriver.Quit();
                                return;
                            }
                            catch
                            {
                                return;
                            }
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception)
            {
                System.IO.File.Copy(Path.Combine(profileLink, shortcutprofileName + ".lnk"), Path.Combine("profiles_not_done", shortcutprofileName + ".lnk"));
                System.IO.File.Delete(Path.Combine(profileLink, shortcutprofileName + ".lnk"));
                listViewRun.Invoke((Action)delegate
                {
                    listViewRun.Items[index].SubItems[1].Text = "Error";
                });
                try
                {
                    chromeDriver.Close();
                    chromeDriver.Quit();
                }
                catch
                {
                }
                m_nRunningCount--;
                bWaiting = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.profileFolderPath))
            {
                listAllFolderProfile = new List<string>();
                txtProfilesFolder.Text = Properties.Settings.Default.profileFolderPath;
                string[] files = Directory.GetFiles(Properties.Settings.Default.profileFolderPath, "*.lnk");
                int maxlength = files.Max((string x) => x.Length);
                files = files.OrderBy((string x) => x.PadLeft(maxlength, '0')).ToArray();
                string[] array = files;
                foreach (string text in array)
                {
                    string[] items = new string[2]
                    {
                    Path.GetFileNameWithoutExtension(text),
                    "Waiting"
                    };
                    listViewNotRun.Items.Add(new ListViewItem(items));
                    listAllFolderProfile.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "User Data", GetArgument(text)));
                }
            }
        }

        private void txtTimeWaitPreview_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }
    }
}
