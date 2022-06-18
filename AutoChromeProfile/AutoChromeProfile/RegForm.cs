using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoChromeProfile
{
    public partial class RegForm : Form
    {
        private Form1 form1;
        private List<HardDrive> hardDrives;
        public RegForm()
        {
            InitializeComponent();
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            GetAllDiskDrives();
            if (hardDrives == null || hardDrives.Count == 0)
            {
                Environment.Exit(0);
            }

            textBox1.Text = Secu.Base64Encode(hardDrives[0].SerialNo);

            string startDate = Properties.Settings.Default.StartDate;
            if (string.IsNullOrWhiteSpace(startDate))
            {
                return;
            }
            string endDate = Properties.Settings.Default.EndDate;
            if (string.IsNullOrWhiteSpace(endDate))
            {
                return;
            }
            string key = Properties.Settings.Default.Key;
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            DateTime dtStartDate = DateTime.ParseExact(Secu.Base64Decode(startDate), "ddMMyyyy", CultureInfo.InvariantCulture);
            DateTime dtEndDate = DateTime.ParseExact(Secu.Base64Decode(endDate), "ddMMyyyy", CultureInfo.InvariantCulture);
            if (DateTime.Now > dtEndDate)
            {
                return;
            }
            if (key != textBox1.Text)
            {
                return;
            }

            //form1 = new Form1();
            //form1.Show();
            //this.Hide();
        }

        private void GetAllDiskDrives()
        {
            hardDrives = new List<HardDrive>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] != null)
                {
                    HardDrive hd = new HardDrive();
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString().Trim();
                    hardDrives.Add(hd);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKey.Text))
                {
                    return;
                }
                string data = Secu.Base64Decode(txtKey.Text);
                string key = data.Split(new[] { "dhloc" }, StringSplitOptions.None)[0];
                int days = int.Parse(data.Split(new[] { "dhloc" }, StringSplitOptions.None)[1]);

                if (Secu.Base64Encode(key) != textBox1.Text)
                {
                    return;
                }
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(days);
                string strStartDate = Secu.Base64Encode(startDate.ToString("ddMMyyyy"));
                string strEndDate = Secu.Base64Encode(endDate.ToString("ddMMyyyy"));

                Properties.Settings.Default.Key = textBox1.Text;
                Properties.Settings.Default.StartDate = strStartDate;
                Properties.Settings.Default.EndDate = strEndDate;
                Properties.Settings.Default.Save();
                Application.Restart();
                Environment.Exit(0);
            }
            catch
            {

            }
        }
    }


    public class HardDrive
    {
        public string Model { get; set; }
        public string InterfaceType { get; set; }
        public string Caption { get; set; }
        public string SerialNo { get; set; }
    }
}
