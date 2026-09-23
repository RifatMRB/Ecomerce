using Microsoft.AspNetCore.Mvc;
using ecommerce.Models;
using ecommerce.DTOs;
namespace ecommerce.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly List<Category> categories = new();

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categoryList = categories.Select(c => new CategoryReadDto
        {
            ProductId = c.ProductId,
            Name = c.Name,
            Description = c.Description,
            CreatedAt = c.CreatedAt
        }).ToList();
        return Ok(ApiResponse<List<CategoryReadDto>>.SuccessResponse(categoryList, 200, "successfully getting all categories"));
        //return Ok(new ApiResponse<List<CategoryReadDto>>(categoryList,200,"categories data return"));
        //return Ok(new ApiResponse<List<CategoryReadDto>>.SuccessResponse(categoryList,200,"successfully geting all categories"));
    }

    [HttpPost]
    public IActionResult CreateCategories(CategoryCreateDto categoryData)
    {
        
        var newCategory = new Category
        {
            ProductId = Guid.NewGuid(),
            Name = categoryData.Name,
            Description = categoryData.Description,
            CreatedAt = DateTime.UtcNow
        };

        categories.Add(newCategory);

        var categoryReadDto = new CategoryReadDto
        {
            ProductId = newCategory.ProductId,
            Name = newCategory.Name,
            Description=newCategory.Description,
            CreatedAt = newCategory.CreatedAt
        };
        return Created($"/api/categories/{categoryReadDto.ProductId}", ApiResponse<CategoryReadDto>.SuccessResponse(
            categoryReadDto,201,"successfully created"
        ));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCategory(Guid id, CategoryUpdateDto categoryData)
    {
        var foundCategory = categories.FirstOrDefault(c => c.ProductId == id);
        if (foundCategory == null) return NotFound(ApiResponse<object>.ErrorResponse(new List<string>{"Categori is not found withe this id"},
        404,"Validation failed"));
        foundCategory.Name = categoryData.Name;
        foundCategory.Description = categoryData.Description;
        return Ok(ApiResponse<object>.SuccessResponse(null,204,"created successfully"));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCategory(Guid id)
    {
        var foundCategory = categories.FirstOrDefault(c => c.ProductId == id);
        if (foundCategory == null) return NotFound(ApiResponse<object>.ErrorResponse(new List<string>{"Categori is not found withe this id"},
        404,"Validation failed"));
        categories.Remove(foundCategory);
        return Ok(ApiResponse<object>.SuccessResponse(null,204,"Deleted successfully"));
    }
}

