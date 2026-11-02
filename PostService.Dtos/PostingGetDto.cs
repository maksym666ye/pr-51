using PostService.CommonTypes;
namespace PostService.Dtos;

/// <summary>
/// Модель для відображення інформації про поштове відправлення.
/// </summary>
public class PostingGetDto
{
    /// <summary>Унікальний ідентифікатор відправлення.</summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>Адреса відправника.</summary>
    /// <example>м. Київ, вул. Хрещатик, 1</example>
    public string From { get; set; } = null!;

    /// <summary>Адреса отримувача.</summary>
    /// <example>м. Львів, вул. Городоцька, 15</example>
    public string To { get; set; } = null!;

    /// <summary>Опис вмісту посилки.</summary>
    /// <example>Документи та ноутбук</example>
    public string Content { get; set; } = null!;

    /// <summary>Тип доставки (0 - Поштомат, 1 - Кур'єр).</summary>
    public DeliveryType DeliveryType { get; set; }

    /// <summary>Вага відправлення.</summary>
    /// <example>2.5</example>
    public float Weight { get; set; }

    /// <summary>Ширина.</summary>
    /// <example>20</example>
    public float Width { get; set; }

    /// <summary>Висота.</summary>
    /// <example>15</example>
    public float Height { get; set; }

    /// <summary>Глибина.</summary>
    /// <example>10</example>
    public float Depth { get; set; }

    /// <summary>Оголошена цінність відправлення.</summary>
    /// <example>5000</example>
    public float Value { get; set; }

    /// <summary>Розрахована вартість доставки.</summary>
    /// <example>120</example>
    public float Price { get; set; }

    /// <summary>Дата та час створення запису.</summary>
    public DateTime CreatedAt { get; set; }
}