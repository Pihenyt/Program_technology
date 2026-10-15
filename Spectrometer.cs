using System;

namespace Labaratory_L
{
    /// <summary>
    /// Спектрометр: поддерживает калибровку.
    /// </summary>
    public class Spectrometer : LabEquipment, ICalibratable
    {
        private readonly double _uvUpperBoundNm = 400.0;

        /// <summary>
        /// Рабочая длина волны в нанометрах.
        /// </summary>
        public double Wavelength { get; set; }

        /// <summary>
        /// Признак ультрафиолетового диапазона: длина волны меньше 400 нм.
        /// </summary>
        public bool IsUv => Wavelength < _uvUpperBoundNm;

        /// <summary>
        /// Создаёт спектрометр с полным набором данных.
        /// </summary>
        public Spectrometer(int id, string name, double accuracy, double wavelength)
            : base(id, name, accuracy)
        {
            Wavelength = wavelength;
        }

        /// <summary>
        /// Создаёт спектрометр по названию и длине волны.
        /// </summary>
        public Spectrometer(string name, double wavelength)
            : base(name)
        {
            Wavelength = wavelength;
        }

        /// <summary>
        /// Измеряет поглощение света на рабочей длине волны.
        /// </summary>
        public override void Measure()
        {
            Console.WriteLine($"{Name} measures light absorbance at {Wavelength} nm.");
        }

        /// <summary>
        /// Выполняет калибровку спектрометра.
        /// </summary>
        public void Calibrate()
        {
            Console.WriteLine($"{Name} calibrated.");
        }

        /// <summary>
        /// Возвращает текстовое описание спектрометра.
        /// </summary>
        public override string ToString()
        {
            return $"[Spectrometer] {Name}, accuracy={Accuracy}, wavelength={Wavelength} nm, status: {Status}";
        }
    }
}