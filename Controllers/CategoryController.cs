using Microsoft.AspNetCore.Mvc;
using ecommerce.Models;

namespace ecommerce.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    List<Category> categories = new List<Category>();

    [HttpGet]
    public IActionResult GetCategories()
    {
        return Ok(categories);
    }

    [HttpPost]
    public IActionResult CreateCategories(Category categoryData)
    {
        var newCategory = new Category
        {
            ProductId = Guid.NewGuid(),
            Name = categoryData.Name,
            Description = categoryData.Description,
            CreatedAt = DateTime.UtcNow
        };
        categories.Add(newCategory);
        return Created($"/api/categories/{newCategory.ProductId}", newCategory);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(Guid id, Category categoryData)
    {
        var foundCategory = categories.FirstOrDefault(c => c.ProductId == id);
        if (foundCategory == null) return NotFound();
        foundCategory.Name = categoryData.Name;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(Guid id)
    {
        var foundCategory = categories.FirstOrDefault(c => c.ProductId == id);
        if (foundCategory == null) return NotFound();
        categories.Remove(foundCategory);
        return NoContent();
    }
}