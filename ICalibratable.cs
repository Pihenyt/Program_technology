namespace Labaratory_L
{
    /// <summary>
    /// Контракт для оборудования, которое можно откалибровать.
    /// </summary>
    public interface ICalibratable
    {
        /// <summary>
        /// Выполняет калибровку оборудования.
        /// </summary>
        void Calibrate();
    }
}