using System.ComponentModel.DataAnnotations;

namespace ecommerce.DTOs;

public class CategoryCreateDto
{
    [Required(ErrorMessage = "Category  name is required ")]
    [StringLength(100,MinimumLength = 5,ErrorMessage ="Category name need to be big ")]
    public string? Name {get;set;}

    [StringLength(100,ErrorMessage ="Category Description need to be big ")]
    public string? Description{get;set;}
}