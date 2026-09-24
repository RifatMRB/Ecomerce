namespace ecommerce.Services;

using AutoMapper;
using ecommerce.Data;
using ecommerce.DTOs;
using ecommerce.Interfaces;
using ecommerce.Models;
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    //private static readonly List<Category> _categories = new();
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public CategoryService(AppDbContext appDbContext,IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<List<CategoryReadDto>> GetAllcategories()
    {
        // return _categories.Select(c => new CategoryReadDto
        // {
        //     CategoryId = c.CategoryId,
        //     Name = c.Name,
        //     Description = c.Description,
        //     CreatedAt = c.CreatedAt
        // }).ToList();
        var categories = await _appDbContext.Categories.ToListAsync();
        return _mapper.Map<List<CategoryReadDto>>(categories);
    }

    public async Task<CategoryReadDto?> GetCategorieById(Guid categoryId)
    {
        var foundCategory = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        if(foundCategory==null) return null;
        // return  new CategoryReadDto
        // {
        //     CategoryId = foundCategory.CategoryId,
        //     Name = foundCategory.Name,
        //     Description = foundCategory.Description,
        //     CreatedAt = foundCategory.CreatedAt
        // };
        return _mapper.Map<CategoryReadDto>(foundCategory);
    }

    public async Task<CategoryReadDto> CreateCategorie(CategoryCreateDto categoryData)
    {
        // var newCategory = new Category
        // {
        //     CategoryId = Guid.NewGuid(),
        //     Name = categoryData.Name,
        //     Description = categoryData.Description,
        //     CreatedAt = DateTime.UtcNow
        // };
        var newCategory = _mapper.Map<Category>(categoryData);
        newCategory.CategoryId = Guid.NewGuid();
        newCategory.CreatedAt = DateTime.UtcNow;

        await _appDbContext.Categories.AddAsync(newCategory);
        await _appDbContext.SaveChangesAsync();

        // return new CategoryReadDto
        // {
        //     CategoryId = newCategory.CategoryId,
        //     Name = newCategory.Name,
        //     Description=newCategory.Description,
        //     CreatedAt = newCategory.CreatedAt
        // };
        return _mapper.Map<CategoryReadDto>(newCategory);
    }

    public async Task<CategoryReadDto?> UpdateCategory(Guid id, CategoryUpdateDto categoryData)
    {
        var foundCategory = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        if (foundCategory == null) return null;
        // foundCategory.Name = categoryData.Name;
        // foundCategory.Description = categoryData.Description;
        _mapper.Map(categoryData,foundCategory);
        _appDbContext.Categories.Update(foundCategory);
        await _appDbContext.SaveChangesAsync();
        // return new CategoryReadDto
        // {
        //     CategoryId = foundCategory.CategoryId,
        //     Name = foundCategory.Name,
        //     Description=foundCategory.Description,
        //     CreatedAt = foundCategory.CreatedAt
        // };
        return _mapper.Map<CategoryReadDto>(foundCategory);
    }

    public async Task<bool> DeleteCategory(Guid id)
    {
        var foundCategory = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        if (foundCategory == null) return false;
        _appDbContext.Categories.Remove(foundCategory);
        return true;
    }
}