using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usluga
{
    public partial class Service1 : ServiceBase
    {
        protected EventLog dziennik;

        public Service1()
        {
            InitializeComponent();
            
            this.CanHandlePowerEvent = true;

            dziennik = new EventLog();
            if (!EventLog.SourceExists(ConfigurationManager.AppSettings["Zrodlo"]))
            {
                EventLog.CreateEventSource(ConfigurationManager.AppSettings["Zrodlo"], ConfigurationManager.AppSettings["Dziennik"]);
            }
            dziennik.Source = ConfigurationManager.AppSettings["Zrodlo"];
            dziennik.Log = ConfigurationManager.AppSettings["Dziennik"];
        }

        protected override void OnStart(string[] args)
        {
            dziennik.WriteEntry("Uruchomiono usługę");
        }

        protected override void OnStop()
        {
            dziennik.WriteEntry("Zatrzymano usługę");
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            if (powerStatus == PowerBroadcastStatus.BatteryLow)
            {
                dziennik.WriteEntry("Stan baterii jest niski");
            }

            if (powerStatus == PowerBroadcastStatus.PowerStatusChange)
            {
                if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)
                {
                    dziennik.WriteEntry("Odłączono zasilacz");
                }
                if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
                {
                    dziennik.WriteEntry("Podłączono zasilacz");
                }
                if (SystemInformation.PowerStatus.BatteryLifePercent == 1)
                {
                    dziennik.WriteEntry("Bateria naładowana");
                }
            }

            return base.OnPowerEvent(powerStatus);
        }
    }
}
