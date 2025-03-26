using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class FuelCar : Car, IFuelable
    {
        private DateTime _lastRefuelTime;
        private int _fuelPercent;

        public FuelCar() : base() { }
        
        public void Refuel(DateTime timeOfRefuel)
        {
            _lastRefuelTime = timeOfRefuel;
            _fuelPercent = 100;
        }
    }
}
