using AutoMapper;
using FSM_Application.Repository;
using FSM_Data.Entities;
using FSM_ViewModel.BrandViewModel;
using FSM_ViewModel.CategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Catalog.BrandCatalog
{
    public class BrandServices : IBrandServices
    {
        private readonly IMapper _mapper;
        private readonly IAllRepositorys<Brand> _brandRepositorys;
        public BrandServices(IMapper mapper, IAllRepositorys<Brand> brandRepositorys)
        {
            _mapper = mapper;
            _brandRepositorys = brandRepositorys;
        }
        public async Task<Guid> CreateBrand(CreatedBrand createdBrand)
        {
            var brand = _mapper.Map<CreatedBrand, Brand>(createdBrand);
            brand.CreatedAt = DateTime.Now;
            brand.IsDeleted = true;
            var result = await _brandRepositorys.AddItems(brand);
            return brand.Id;
        }

        public async Task<GetAllBrands> GetAllBrandById(Guid id)
        {
            var brands = await _brandRepositorys.GetItemsById(id);
            var result = _mapper.Map<Brand, GetAllBrands>(brands);
            return result;
        }

        public async Task<IEnumerable<GetAllBrands>> GetAllBrands()
        {
            var results = await _brandRepositorys.GetAllItems();
            var brands = _mapper.Map<IEnumerable<Brand>, IEnumerable<GetAllBrands>>(results);
            return brands;
        }

        public async Task<bool> IsdeletedBrand(IsDeletedBrand brand)
        {
            var request = await _brandRepositorys.GetItemsById(brand.Id);

            request.IsDeleted = brand.IsDeleted;

            var updateIsdeleted = await _brandRepositorys.UpdateItems(request);

            return updateIsdeleted;
        }

        public async Task<bool> UpdateBrand(UpdateBrand updateBrand)
        {
            var brand = await _brandRepositorys.GetItemsById(updateBrand.Id);
            brand.UpdatedAt = DateTime.Now;

            var result = _mapper.Map<UpdateBrand, Brand>(updateBrand, brand);
            var update = await _brandRepositorys.UpdateItems(result);
            return update;
        }
    }
}
