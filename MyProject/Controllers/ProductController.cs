using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

[Route("api/Product")]
[ApiController]

public class ProductController : ControllerBase
{



    // GET: api/Product
    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        return Ok(List.Products);
    }



    // GET: api/Product/id
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = List.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }


    // POST: api/Product
    [HttpPost]
    public IActionResult PostProduct([FromBody] Product product)
    {
        var categoryId = product.CategoryId;
        var category = List.Categories.FirstOrDefault(c => c.Id == categoryId);
        if (category == null)
        {
            return BadRequest("Invalid category ID.");
        }

        List.Products.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

    }
   


    // PUT: api/Product/id
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        var product = List.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        product.Name = updatedProduct.Name;
        product.Description = updatedProduct.Description;
        product.Price = updatedProduct.Price;
        product.CategoryId = updatedProduct.CategoryId;

        return Ok(product);
    }

    // DELETE: api/Product/id
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = List.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        List.Products.Remove(product);

        return Ok(product);
    }
}




