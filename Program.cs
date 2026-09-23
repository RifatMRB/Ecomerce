
using ecommerce.Controllers;
using ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<CategoryService>();
// builder.Services.AddControllers()
// .ConfigureApiBehaviorOptions(options =>
// {
//     options.SuppressModelStateInvalidFilter = true;
// });

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Where(e => e.Value!=null && e.Value.Errors.Count>0).
            SelectMany(e => e.Value!.Errors.Select(x=>x.ErrorMessage)).ToList();
            return new BadRequestObjectResult(ApiResponse<object>.ErrorResponse(errors,400,"validation Failed"));
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //dotnet add package Swashbuckle.AspNetCore
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



// app.MapGet("/api/categories", () =>
// {
//     return Results.Ok(categories);
// });


// app.MapPost("/api/categories", (Category categoryData) =>
// {
//     var newCategory = new Category
//     {
//         ProductId = Guid.NewGuid(),
//         Name = categoryData.Name,
//         Description = categoryData.Description,
//         CreatedAt = DateTime.UtcNow
//     };
//     categories.Add(newCategory);
//     return Results.Created($"/api/categories/{newCategory.ProductId}",newCategory);
// });

// app.MapPut("/api/categories/{id}", (Guid id,Category categoryData) =>
// {
//     var foundCategory=categories.FirstOrDefault(c=>c.ProductId==id);
//     if(foundCategory==null) return Results.NotFound();
//     foundCategory.Name=categoryData.Name;
//     return Results.NoContent();
// });

// app.MapDelete("/api/categories/{id}", (Guid id) =>
// {
//     var foundCategory=categories.FirstOrDefault(c=>c.ProductId==id);
//     if(foundCategory==null) return Results.NotFound();
//     categories.Remove(foundCategory);
//     return Results.NoContent();
// });




app.MapControllers();
app.Run();




