using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class ClassLibrary
    {
        static readonly PerformanceCounterCategory kategoria = new PerformanceCounterCategory("Battery Status");
        static readonly string[] instancje = kategoria.GetInstanceNames();

        readonly PerformanceCounter[] liczniki = kategoria.GetCounters(instancje[0]);
        //liczniki[0].CounterName - Charge Rate
        //liczniki[1].CounterName - Discharge Rate
        //liczniki[2].CounterName - Remaining Capacity
        //liczniki[3].CounterName - Tag
        //liczniki[4].CounterName - Voltage
        public string BatteryName
        {
            get { return instancje[0]; }
        }
        public float ChargeRate
        {
            get { return liczniki[0].RawValue; }
        }
        public float DischargeRate
        {
            get { return liczniki[1].RawValue; }
        }
        public float RemainingCapacity
        {
            get { return liczniki[2].RawValue; }
        }
        public float Tag
        {
            get { return liczniki[3].RawValue; }
        }
        public float Voltage
        {
            get { return liczniki[4].RawValue; }
        }
    }
}    