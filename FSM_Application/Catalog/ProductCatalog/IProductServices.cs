using FSM_Data.Entities;
using FSM_ViewModel.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Catalog.ProductCatalog
{
    public interface IProductServices
    {
        Task<Guid> CreateProduct(CreateProduct result);
        Task<bool> UpdateProduct(UpdateProduct result);
        Task<bool> UpdateIsDeleted(IsDeletedDto result);
        Task<IEnumerable<GetAllProduct>> GetAllProducts();
        Task<GetAllProduct> GetAllProductById(Guid id);
    }
}
