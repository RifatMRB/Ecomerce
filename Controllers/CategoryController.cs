using Microsoft.AspNetCore.Mvc;
using ecommerce.Models;
using ecommerce.DTOs;
using ecommerce.Services;
namespace ecommerce.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{


    private CategoryService _categoryService;
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    

    [HttpGet("{categoryId:guid}")]
    public IActionResult GetCategorieById(Guid categoryId)
    {
        var category = _categoryService.GetCategorieById(categoryId);

        if (category == null) return NotFound(ApiResponse<object>.
        ErrorResponse(new List<string>{"Categori is not found withe this id"},
        404,"Validation failed"));
        
        return Ok(ApiResponse<CategoryReadDto>.SuccessResponse(category,200,"found category successfully"));
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categoryList = _categoryService.GetAllcategories();
        return Ok(ApiResponse<List<CategoryReadDto>>.SuccessResponse(categoryList, 200, "successfully getting all categories"));
        //return Ok(new ApiResponse<List<CategoryReadDto>>(categoryList,200,"categories data return"));
        //return Ok(new ApiResponse<List<CategoryReadDto>>.SuccessResponse(categoryList,200,"successfully geting all categories"));
    }

    [HttpPost]
    public IActionResult CreateCategories(CategoryCreateDto categoryData)
    {
        var categoryReadDto = _categoryService.CreateCategorie(categoryData);
        return Created($"/api/categories/{categoryReadDto.ProductId}", ApiResponse<CategoryReadDto>.SuccessResponse(
            categoryReadDto,201,"successfully created"
        ));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCategory(Guid id, CategoryUpdateDto categoryData)
    {
        var category = _categoryService.UpdateCategory(id,categoryData);
        if (category == null) return NotFound(ApiResponse<object>.ErrorResponse(new List<string>{"Categori is not found withe this id"},
        404,"Validation failed"));
        return Ok(ApiResponse<CategoryReadDto>.SuccessResponse(category,200,"created successfully"));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCategory(Guid id)
    {
        
        var foundCategory = _categoryService.DeleteCategory(id);
        if (foundCategory == false) return NotFound(ApiResponse<object>.
        ErrorResponse(new List<string>{"Categori is not found withe this id"},
        404,"Validation failed"));
        
        return Ok(ApiResponse<object>.SuccessResponse(null,204,"Deleted successfully"));
    }
}

