using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioteka;

namespace BatteryStatusProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassLibrary cl = new ClassLibrary();

        ServiceController con = new ServiceController("MojaUslugaStanBaterii");
        
        public const string NazwaDziennika = "Dziennik stanu baterii";
        public const string NazwaZrodla = "Usluga";

        public EventLog dziennik = new EventLog(NazwaDziennika, ".", NazwaZrodla);
        
        public MainWindow()
        {
            InitializeComponent();

            batteryName.Content = cl.BatteryName;
            tag.Content = cl.Tag;
            remainingCapacity.Content = cl.RemainingCapacity + " mWh";
            if (cl.DischargeRate == 0 && cl.ChargeRate != 0)
            {
                remainingTime.Content = (int)(cl.RemainingCapacity / cl.ChargeRate * 60) + " minut";
            }
            else if (cl.ChargeRate == 0 && cl.DischargeRate != 0)
            {
                remainingTime.Content = (int)(cl.RemainingCapacity / cl.DischargeRate * 60) + " minut";
            }
            else
            {
                remainingTime.Content = "Bateria naładowana";
            }
            dischargeRate.Content = cl.DischargeRate + " mW";
            chargeRate.Content = cl.ChargeRate + " mW";
            voltage.Content = cl.Voltage / 1000 + " V";

            foreach(EventLogEntry l in dziennik.Entries)
            {
                eventlogEntries.Text += l.TimeWritten + " " + l.Message + "\n";
            }

            if(con.Status.ToString().Equals("Stopped"))
            {
                stopService.IsEnabled = false;
            }
            else if (con.Status.ToString().Equals("Running"))
            {
                startService.IsEnabled = false;
            }
        }

        private void Odswiez_Click(object sender, RoutedEventArgs e)
        {
            tag.Content = cl.Tag;
            remainingCapacity.Content = cl.RemainingCapacity + " mWh";
            if (cl.DischargeRate == 0 && cl.ChargeRate != 0)
            {
                remainingTime.Content = (int)(cl.RemainingCapacity / cl.ChargeRate * 60) + " minut";
            }
            else if (cl.ChargeRate == 0 && cl.DischargeRate != 0)
            {
                remainingTime.Content = (int)(cl.RemainingCapacity / cl.DischargeRate * 60) + " minut";
            }
            else
            {
                remainingTime.Content = "Bateria naładowana";
            }
            dischargeRate.Content = cl.DischargeRate + " mW";
            chargeRate.Content = cl.ChargeRate + " mW";
            voltage.Content = cl.Voltage / 1000 + " V";

            eventlogEntries.Clear();
            foreach (EventLogEntry l in dziennik.Entries)
            {
                eventlogEntries.Text += l.TimeWritten + " " + l.Message + "\n";
            }

            if (con.Status.Equals("Stopped"))
            {
                stopService.IsEnabled = false;
            }
            else if (con.Status.Equals("Running"))
            {
                startService.IsEnabled = false;
            }
        }

        private void startService_Click(object sender, RoutedEventArgs e)
        {
            con.Start();
            con.WaitForStatus(ServiceControllerStatus.Running);
            startService.IsEnabled = false;
            stopService.IsEnabled = true;
        }

        private void stopService_Click(object sender, RoutedEventArgs e)
        {
            con.Stop();
            con.WaitForStatus(ServiceControllerStatus.Stopped);
            stopService.IsEnabled = false;
            startService.IsEnabled = true;
        }
    }
}
