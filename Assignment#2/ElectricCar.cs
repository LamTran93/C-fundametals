using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class ElectricCar : Car, IChargable
    {
        private DateTime _lastRechargeTime;
        private int _chargePercent;

        public ElectricCar() : base() { }

        public void Charge(DateTime timeOfRefuel)
        {
            _lastRechargeTime = timeOfRefuel;
            _chargePercent = 100;
        }
    }
}
