namespace Labaratory_L
{
    /// <summary>
    /// Статус лабораторного оборудования.
    /// </summary>
    public enum EquipmentStatus
    {
        /// <summary>Оборудование готово к работе.</summary>
        Ready,

        /// <summary>Оборудование проходит калибровку.</summary>
        Calibrating,

        /// <summary>Оборудование неисправно.</summary>
        Broken
    }
}