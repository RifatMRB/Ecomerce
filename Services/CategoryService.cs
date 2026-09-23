namespace ecommerce.Services;

using ecommerce.DTOs;
using ecommerce.Models;

public class CategoryService
{
    private static readonly List<Category> _categories = new();
    public List<CategoryReadDto> GetAllcategories()
    {
        return _categories.Select(c => new CategoryReadDto
        {
            ProductId = c.ProductId,
            Name = c.Name,
            Description = c.Description,
            CreatedAt = c.CreatedAt
        }).ToList();
    }

    public CategoryReadDto? GetCategorieById(Guid categoryId)
    {
        var foundCategory = _categories.FirstOrDefault(c => c.ProductId == categoryId);
        if(foundCategory==null) return null;
        return  new CategoryReadDto
        {
            ProductId = foundCategory.ProductId,
            Name = foundCategory.Name,
            Description = foundCategory.Description,
            CreatedAt = foundCategory.CreatedAt
        };
    }

    public CategoryReadDto CreateCategorie(CategoryCreateDto categoryData)
    {
        var newCategory = new Category
        {
            ProductId = Guid.NewGuid(),
            Name = categoryData.Name,
            Description = categoryData.Description,
            CreatedAt = DateTime.UtcNow
        };

        _categories.Add(newCategory);

        return new CategoryReadDto
        {
            ProductId = newCategory.ProductId,
            Name = newCategory.Name,
            Description=newCategory.Description,
            CreatedAt = newCategory.CreatedAt
        };
    }

    public CategoryReadDto? UpdateCategory(Guid id, CategoryUpdateDto categoryData)
    {
        var foundCategory = _categories.FirstOrDefault(c => c.ProductId == id);
        if (foundCategory == null) return null;
        foundCategory.Name = categoryData.Name;
        foundCategory.Description = categoryData.Description;
        return new CategoryReadDto
        {
            ProductId = foundCategory.ProductId,
            Name = foundCategory.Name,
            Description=foundCategory.Description,
            CreatedAt = foundCategory.CreatedAt
        };
    }

    public bool DeleteCategory(Guid id)
    {
        var foundCategory = _categories.FirstOrDefault(c => c.ProductId == id);
        if (foundCategory == null) return false;
          _categories.Remove(foundCategory);
          return true;
    }
}