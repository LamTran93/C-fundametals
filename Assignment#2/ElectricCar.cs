using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class ElectricCar : Car, IChargable
    {
        private DateTime _lastChargeTime;
        private int _chargePercent;

        public DateTime LastChargeTime { get => _lastChargeTime; }

        public ElectricCar() : base()
        {
            Type = CarType.Electric;
        }

        public void Charge(DateTime timeOfRefuel)
        {
            _lastChargeTime = timeOfRefuel;
            _chargePercent = 100;
            Console.WriteLine($"Electric car {Model} charged on {_lastChargeTime:yyyy-MM-dd HH:mm}");
        }
    }
}
