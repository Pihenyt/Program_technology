using System;

namespace Labaratory_L
{
    /// <summary>
    /// Центрифуга: не калибруется, поэтому интерфейс ICalibratable не реализует.
    /// </summary>
    public class Centrifuge : LabEquipment
    {
        private readonly int _fastRpmThreshold = 10000;

        /// <summary>
        /// Скорость вращения, оборотов в минуту.
        /// </summary>
        public int Rpm { get; set; }

        /// <summary>
        /// Признак быстрой центрифуги: скорость достигает порогового значения.
        /// </summary>
        public bool IsFast => Rpm >= _fastRpmThreshold;

        /// <summary>
        /// Создаёт центрифугу с полным набором данных.
        /// </summary>
        public Centrifuge(int id, string name, double accuracy, int rpm)
            : base(id, name, accuracy)
        {
            Rpm = rpm;
        }

        /// <summary>
        /// Создаёт центрифугу по названию и скорости вращения.
        /// </summary>
        public Centrifuge(string name, int rpm)
            : base(name)
        {
            Rpm = rpm;
        }

        /// <summary>
        /// Выполняет измерение образца.
        /// </summary>
        public override void Measure()
        {
            Console.WriteLine($"{Name} measures sample.");
        }

        /// <summary>
        /// Возвращает текстовое описание центрифуги.
        /// </summary>
        public override string ToString()
        {
            return $"[Centrifuge] {Name}, rpm={Rpm}, status: {Status}";
        }
    }
}