namespace Bank;

/// <summary>
/// Статус клиента банка для расчета условий обслуживания и привилегий.
/// </summary>
public enum CustomerStatus
{
    /// <summary>Обычный клиент.</summary>
    Regular,
    /// <summary>Премиальный клиент.</summary>
    Premium,
    /// <summary>VIP-клиент.</summary>
    VIP
}