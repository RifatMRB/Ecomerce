using ecommerce.DTOs;

namespace ecommerce.Interfaces;

public interface ICategoryService
{
    List<CategoryReadDto> GetAllcategories();
    CategoryReadDto? GetCategorieById(Guid categoryId);

    CategoryReadDto CreateCategorie(CategoryCreateDto categoryData);

    CategoryReadDto? UpdateCategory(Guid id, CategoryUpdateDto categoryData);

    bool DeleteCategory(Guid id);
}