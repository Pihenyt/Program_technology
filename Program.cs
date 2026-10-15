using System;
using System.Collections.Generic;
using System.Globalization;

namespace LabApp
{
    /// <summary>
    /// Точка входа: демонстрирует полиморфизм на списке объектов базового типа.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        public static void Main(string[] args)
        {
            // Точка вместо запятой в числах (0.005, а не 0,005).
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            List<LabEquipment> equipment = new List<LabEquipment>
            {
                new Microscope(1, "Olympus", 0.005, 1000),
                new Centrifuge("Eppendorf", 15000),
                new Spectrometer(3, "Agilent", 0.002, 250)
            };

            foreach (LabEquipment item in equipment)
            {
                Console.WriteLine(item);
                Console.WriteLine($"  precise: {item.IsPrecise}");
                item.Measure();

                if (item is ICalibratable calibratable)
                {
                    calibratable.Calibrate();
                }
                else
                {
                    Console.WriteLine($"{item.Name} cannot be calibrated.");
                }

                Console.WriteLine(new string('-', 40));
            }
        }
    }
}