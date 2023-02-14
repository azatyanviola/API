using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

[Route("api/Category")]
[ApiController]

    public class CategoryController : ControllerBase
    {


    // GET: api/Category
    [HttpGet]
        public IActionResult GetCategories()
          {
            return Ok(List.Categories);
          }


      // GET: api/Category/id
       [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = List.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


       // Post: api/Category
       [HttpPost]
        public IActionResult PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            category.Products = new List<Product>();
            List.Categories.Add(category);

          return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
    }


    // UPDATE: api/Category/id
    [HttpPut("{id}")]
        public IActionResult PutCategory(int id, [FromBody] Category category)
        {
            var existingCategory = List.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            return Ok(category);
        }

    // DELETE: api/Category/id
    [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = List.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            List.Categories.Remove(category);

            return Ok(category);
        }
    }


