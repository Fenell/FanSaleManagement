using FSM_Application.Catalog.CategoryCatalog;
using FSM_ViewModel.CategoryViewModel;
using FSM_ViewModel.ProductViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryServices.GetAllCategories();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoryServices.GetAllCategoryById(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreatedCategory([FromForm] CreatedCategory createdCategory)
        {
            var request = await _categoryServices.CreateCategory(createdCategory);

            if (request == null)
                return BadRequest();

            var newCategory = await _categoryServices.GetAllCategoryById(request);

            return CreatedAtAction(nameof(GetCategoryById), new { id = request }, newCategory);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, UpdateCategory updateCategory)
        {
            if (id != updateCategory.Id)
                return NotFound();

            var request = await _categoryServices.UpdateCategory(updateCategory);
            return Ok(request);
        }
        [HttpPut("idCategory")]
        public async Task<IActionResult> UpdateIsDeleted(Guid idCategory, IsDeletedCategory category)
        {
            if (idCategory != category.Id)
                return NotFound();
            var request = await _categoryServices.IsdeletedCategory(category);
            return Ok(request);
        }
    }
}
