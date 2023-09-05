using FSM_ViewModel.BrandViewModel;
using FSM_ViewModel.CategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Catalog.BrandCatalog
{
    public interface IBrandServices
    {
        Task<IEnumerable<GetAllBrands>> GetAllBrands();
        Task<GetAllBrands> GetAllBrandById(Guid id);
        Task<Guid> CreateBrand(CreatedBrand createdBrand);
        Task<bool> UpdateBrand(UpdateBrand updateBrand);
        Task<bool> IsdeletedBrand(IsDeletedBrand brand);
    }
}
