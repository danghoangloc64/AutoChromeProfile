using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoChromeProfile
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isReg = true;
            try
            {
                List<HardDrive> hardDrives;
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

                string startDate = Properties.Settings.Default.StartDate;
                if (string.IsNullOrWhiteSpace(startDate))
                {
                    isReg = false;
                }
                string endDate = Properties.Settings.Default.EndDate;
                if (string.IsNullOrWhiteSpace(endDate))
                {
                    isReg = false;
                }
                string key = Properties.Settings.Default.Key;
                if (string.IsNullOrWhiteSpace(key))
                {
                    isReg = false;
                }

                DateTime dtStartDate = DateTime.ParseExact(Secu.Base64Decode(startDate), "ddMMyyyy", CultureInfo.InvariantCulture);
                DateTime dtEndDate = DateTime.ParseExact(Secu.Base64Decode(endDate), "ddMMyyyy", CultureInfo.InvariantCulture);
                if (DateTime.Now > dtEndDate)
                {
                    isReg = false;
                }
                if (key != Secu.Base64Encode(hardDrives[0].SerialNo))
                {
                    isReg = false;
                }
            }
            catch
            {
                isReg = false;
            }

            if (isReg)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new RegForm());
            }

        }

    }
}
