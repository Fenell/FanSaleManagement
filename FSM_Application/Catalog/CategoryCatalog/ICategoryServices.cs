using FSM_ViewModel.CategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Catalog.CategoryCatalog
{
    public interface ICategoryServices
    {
        Task<IEnumerable<GetAllCategory>> GetAllCategories();
        Task<GetAllCategory> GetAllCategoryById(Guid id);
        Task<Guid> CreateCategory(CreatedCategory createdCategory);
        Task<bool> UpdateCategory(UpdateCategory updateCategory);
        Task<bool> IsdeletedCategory(IsDeletedCategory category);

    }
}
