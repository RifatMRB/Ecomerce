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
            Description=c.Description,
            CreatedAt = c.CreatedAt
        }).ToList();
        return Ok(categoryList);
    }

    [HttpPost]
    public IActionResult CreateCategories(CategoryCreatDto categoryData)
    {
        var newCategory = new CategoryCreatDto
        {
            ProductId = Guid.NewGuid(),
            Name = categoryData.Name,
            Description = categoryData.Description,
            CreatedAt = DateTime.UtcNow
        };

        categories.Add(newCategory);
        return Created($"/api/categories/{newCategory.ProductId}", newCategory);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCategory(Guid id, Category categoryData)
    {
        var foundCategory = categories.FirstOrDefault(c => c.ProductId == id);
        if (foundCategory == null) return NotFound();
        foundCategory.Name = categoryData.Name;
        foundCategory.Description = categoryData.Description;
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCategory(Guid id)
    {
        var foundCategory = categories.FirstOrDefault(c => c.ProductId == id);
        if (foundCategory == null) return NotFound();
        categories.Remove(foundCategory);
        return NoContent();
    }
}

public class CategoryCreatDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}