using PostService.CommonTypes;
namespace PostService.Dtos;

/// <summary>
/// Модель для створення нового поштового відправлення.
/// </summary>
public class PostingPostDto
{
    /// <summary>Адреса відправника.</summary>
    /// <example>м. Київ, вул. Хрещатик, 1</example>
    public string From { get; set; } = null!;

    /// <summary>Адреса отримувача.</summary>
    /// <example>м. Львів, вул. Городоцька, 15</example>
    public string To { get; set; } = null!;

    /// <summary>Опис вмісту посилки.</summary>
    /// <example>Книги</example>
    public string Content { get; set; } = null!;

    /// <summary>Тип доставки.</summary>
    public DeliveryType DeliveryType { get; set; }

    /// <summary>Вага відправлення.</summary>
    /// <example>1.0</example>
    public float Weight { get; set; }

    /// <summary>Ширина.</summary>
    /// <example>10</example>
    public float Width { get; set; }

    /// <summary>Висота.</summary>
    /// <example>10</example>
    public float Height { get; set; }

    /// <summary>Глибина.</summary>
    /// <example>10</example>
    public float Depth { get; set; }

    /// <summary>Оголошена цінність у гривнях.</summary>
    /// <example>200</example>
    public float Value { get; set; }
}