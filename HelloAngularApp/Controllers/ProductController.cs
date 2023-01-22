using HelloAngularApp.Models.Context;
using HelloAngularApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HelloAngularApp.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    ApplicationContext db;

    public ProductController(ApplicationContext context)
    {
        db = context;
        if (!db.Products.Any())
        {
            db.Products.Add(new Product { Name = "iPhone X", Company = "Apple", Price = 79900 });
            db.Products.Add(new Product { Name = "Galaxy S8", Company = "Samsung", Price = 49900 });
            db.Products.Add(new Product { Name = "Pixel 2", Company = "Google", Price = 52900 });
            db.SaveChanges();
        }
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return db.Products.ToList();
    }

    [HttpGet("{id}")]
    public Product Get(int id)
    {
        Product product = db.Products.FirstOrDefault(x => x.Id == id);
        return product;
    }

    [HttpPost]
    public IActionResult Post(Product product)
    {
        if (ModelState.IsValid)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return Ok(product);
        }

        return BadRequest(ModelState);
    }

    [HttpPut]
    public IActionResult Put(Product product)
    {
        if (ModelState.IsValid)
        {
            db.Update(product);
            db.SaveChanges();
            return Ok(product);
        }

        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Product product = db.Products.FirstOrDefault(x => x.Id == id);
        if (product != null)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        return Ok(product);
    }
}