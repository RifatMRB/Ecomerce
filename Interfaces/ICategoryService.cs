using ecommerce.DTOs;

namespace ecommerce.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryReadDto>> GetAllcategories();
    Task<CategoryReadDto?> GetCategorieById(Guid categoryId);

    Task<CategoryReadDto> CreateCategorie(CategoryCreateDto categoryData);

    Task<CategoryReadDto?> UpdateCategory(Guid id, CategoryUpdateDto categoryData);

    Task<bool> DeleteCategory(Guid id);
}