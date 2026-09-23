using ecommerce.DTOs;

namespace ecommerce.Interfaces;

public interface ICategoryService
{
    List<CategoryReadDto> GetAllCategories(int pageNumber, int pageSize,
    string? search=null,string? sortOrde=null);
    CategoryReadDto? GetCategoryById(Guid categoryId);

    CategoryReadDto CreateCategory(CategoryCreateDto categoryData);

    CategoryReadDto? UpdateCategoryById(Guid categoryId, CategoryUpdateDto categoryData);

    bool DeleteCategoryById(Guid categoryId);
}