using System;

namespace Labaratory_L
{
    /// <summary>
    /// Микроскоп: поддерживает калибровку.
    /// </summary>
    public class Microscope : LabEquipment, ICalibratable
    {
        private readonly int _highPowerThreshold = 500;

        /// <summary>
        /// Кратность увеличения.
        /// </summary>
        public int Magnification { get; set; }

        /// <summary>
        /// Признак сильного увеличения: кратность достигает порогового значения.
        /// </summary>
        public bool IsHighPower => Magnification >= _highPowerThreshold;

        /// <summary>
        /// Создаёт микроскоп с полным набором данных.
        /// </summary>
        public Microscope(int id, string name, double accuracy, int magnification)
            : base(id, name, accuracy)
        {
            Magnification = magnification;
        }

        /// <summary>
        /// Создаёт микроскоп по названию и кратности увеличения.
        /// </summary>
        public Microscope(string name, int magnification)
            : base(name)
        {
            Magnification = magnification;
        }

        /// <summary>
        /// Выполняет измерение образца.
        /// </summary>
        public override void Measure()
        {
            Console.WriteLine($"{Name} measures sample.");
        }

        /// <summary>
        /// Выполняет калибровку микроскопа.
        /// </summary>
        public void Calibrate()
        {
            Console.WriteLine($"{Name} calibrated.");
        }

        /// <summary>
        /// Возвращает текстовое описание микроскопа.
        /// </summary>
        public override string ToString()
        {
            return $"[Microscope] {Name}, accuracy={Accuracy}, magnification={Magnification}, status: {Status}";
        }
    }
}