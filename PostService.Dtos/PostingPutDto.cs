using PostService.CommonTypes;

namespace PostService.Dtos;

/// <summary>
/// Модель для оновлення існуючого поштового відправлення.
/// </summary>
public class PostingPutDto
{
    /// <summary>Унікальний ідентифікатор відправлення.</summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>Адреса відправника.</summary>
    /// <example>м. Київ, вул. Хрещатик, 1</example>
    public string From { get; set; } = string.Empty;

    /// <summary>Адреса отримувача.</summary>
    /// <example>м. Львів, вул. Городоцька, 15</example>
    public string To { get; set; } = string.Empty;

    /// <summary>Опис вмісту посилки.</summary>
    /// <example>Ноутбук</example>
    public string Content { get; set; } = string.Empty;

    /// <summary>Тип доставки.</summary>
    public DeliveryType DeliveryType { get; set; }

    /// <summary>Вага відправлення в кілограмах.</summary>
    /// <example>2.5</example>
    public float Weight { get; set; }

    /// <summary>Ширина в сантиметрах.</summary>
    /// <example>20</example>
    public float Width { get; set; }

    /// <summary>Висота в сантиметрах.</summary>
    /// <example>15</example>
    public float Height { get; set; }

    /// <summary>Глибина в сантиметрах.</summary>
    /// <example>10</example>
    public float Depth { get; set; }

    /// <summary>Оголошена цінність у гривнях.</summary>
    /// <example>5000</example>
    public float Value { get; set; }

    /// <summary>Розрахована вартість доставки у гривнях.</summary>
    /// <example>120</example>
    public float Price { get; set; }
}