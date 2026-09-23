using System.ComponentModel.DataAnnotations;

namespace ecommerce.DTOs;
public class CategoryUpdateDto
{
    [Required (ErrorMessage = "Category name is required ")]
    [MinLength(1, ErrorMessage = "Name cannot be empty")]
    public string? Name {get;set;}

    [StringLength(1000,MinimumLength = 5, ErrorMessage = " maximu 1000 and minimum 5")]
    public string? Description{get;set;}
}