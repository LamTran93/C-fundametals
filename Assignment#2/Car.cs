using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal abstract class Car
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public CarType Type { get; set; }
        public enum CarType
        {
            Electric,
            Fuel
        }

        public Car() { }

        public DateTime ScheduleMaintance()
        {
            return LastMaintenanceDate.Add(TimeSpan.FromDays(180));
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Car: {Make} ({Year})");
            Console.WriteLine($"Last Maintenance Date: {LastMaintenanceDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Next Maintenance Date: {ScheduleMaintance().ToString("yyyy-MM-dd")}");
        }
    }
}
