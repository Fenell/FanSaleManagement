using FSM_Application.Catalog.BrandCatalog;
using FSM_Application.Catalog.CategoryCatalog;
using FSM_ViewModel.BrandViewModel;
using FSM_ViewModel.CategoryViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandServices _brandServices;
        public BrandsController(IBrandServices brandServices)
        {
            _brandServices = brandServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var result = await _brandServices.GetAllBrands();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(Guid id)
        {
            var brand = await _brandServices.GetAllBrandById(id);
            return Ok(brand);
        }
        [HttpPost]
        public async Task<IActionResult> CreatedBrand([FromForm] CreatedBrand createdBrand)
        {
            var request = await _brandServices.CreateBrand(createdBrand);

            if (request == null)
                return BadRequest();

            var newBrand = await _brandServices.GetAllBrandById(request);

            return CreatedAtAction(nameof(GetBrandById), new { id = request }, newBrand);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(Guid id, UpdateBrand updateBrand)
        {
            if (id != updateBrand.Id)
                return NotFound();

            var request = await _brandServices.UpdateBrand(updateBrand);
            return Ok(request);
        }
        [HttpPut("idBrand")]
        public async Task<IActionResult> UpdateIsDeleted(Guid idBrand, IsDeletedBrand brand)
        {
            if (idBrand != brand.Id)
                return NotFound();
            var request = await _brandServices.IsdeletedBrand(brand);
            return Ok(request);
        }
    }
}
