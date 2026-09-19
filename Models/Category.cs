namespace ecommerce.Models;
public class Category
{
    public Guid ProductId {get;set;}
    public string? Name {get;set;}
    public string? Description{get;set;}
    public DateTime CreatedAt {get;set;}
}