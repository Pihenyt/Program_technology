namespace Labaratory_L
{
    /// <summary>
    /// Абстрактный базовый класс для всего лабораторного оборудования.
    /// </summary>
    public abstract class LabEquipment
    {
        private readonly int _id;

        /// <summary>
        /// Название оборудования.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Погрешность измерений: чем меньше значение, тем точнее прибор.
        /// </summary>
        public double Accuracy { get; set; }

        /// <summary>
        /// Текущий статус оборудования. По умолчанию Ready.
        /// </summary>
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Ready;

        /// <summary>
        /// Уникальный идентификатор (только чтение, хранится в приватном поле).
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Признак точного прибора: погрешность меньше 0.01.
        /// </summary>
        public bool IsPrecise => Accuracy < 0.01;

        /// <summary>
        /// Создаёт оборудование с полным набором данных.
        /// </summary>
        protected LabEquipment(int id, string name, double accuracy)
        {
            _id = id;
            Name = name;
            Accuracy = accuracy;
        }

        /// <summary>
        /// Создаёт оборудование только по названию (id = 0, погрешность = 1.0).
        /// </summary>
        protected LabEquipment(string name) : this(0, name, 1.0)
        {
        }

        /// <summary>
        /// Выполняет измерение. Обязателен к переопределению в наследниках.
        /// </summary>
        public abstract void Measure();
    }
}