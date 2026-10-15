namespace Labaratory_L
{
    /// <summary>
    /// Base abstract class for all laboratory equipment.
    /// </summary>
    public abstract class LabEquipment
    {
        private readonly int _id;

        /// <summary>
        /// Equipment name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Measurement error: the smaller the value, the more precise the device.
        /// </summary>
        public double Accuracy { get; set; }

        /// <summary>
        /// Current status of the equipment. Ready by default.
        /// </summary>
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Ready;

        /// <summary>
        /// Unique identifier (read-only, stored in a private field).
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// True if the accuracy value is less than 0.01.
        /// </summary>
        public bool IsPrecise => Accuracy < 0.01;

        /// <summary>
        /// Creates equipment with all data specified.
        /// </summary>
        protected LabEquipment(int id, string name, double accuracy)
        {
            _id = id;
            Name = name;
            Accuracy = accuracy;
        }

        /// <summary>
        /// Creates equipment by name only (id = 0, accuracy = 1.0).
        /// </summary>
        protected LabEquipment(string name) : this(0, name, 1.0)
        {
        }

        /// <summary>
        /// Performs a measurement. Must be overridden in derived classes.
        /// </summary>
        public abstract void Measure();
    }
}