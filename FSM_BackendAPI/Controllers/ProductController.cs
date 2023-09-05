using FSM_Application.Catalog.ProductCatalog;
using FSM_ViewModel.ProductViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var producs = await _productServices.GetAllProducts();
            return Ok(producs);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _productServices.GetAllProductById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreatedProduct([FromForm] CreateProduct createProduct)
        {
            var product = await _productServices.CreateProduct(createProduct);

            if (product == null)
                return BadRequest();

            var productNew = await _productServices.GetAllProductById(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product }, productNew);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProduct updateProduct)
        {
            if (id != updateProduct.Id)
                return NotFound();

            var result = await _productServices.UpdateProduct(updateProduct);
            return Ok(result);
        }
        [HttpPut("idProduct")]
        public async Task<IActionResult> IsDeletedProduct(Guid idProduct, IsDeletedDto isDeleted)
        {
            if (idProduct != isDeleted.Id)
                return NotFound();

            var result = await _productServices.UpdateIsDeleted(isDeleted);
            return Ok(result);
        }
    }
}
