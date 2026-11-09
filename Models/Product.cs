using System.ComponentModel.DataAnnotations;

namespace BootstrapLesson.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Название — от 2 до 50 символов")]
    [Display(Name = "Название")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Выберите категорию")]
    [Display(Name = "Категория")]
    public string Category { get; set; } = string.Empty;

    [Range(1.0, 1_000_000.0, ErrorMessage = "Цена — от 1 до 1 000 000 рублей")]
    [Display(Name = "Цена")]
    public decimal Price { get; set; }

    [Display(Name = "В наличии")]
    public bool InStock { get; set; }
}