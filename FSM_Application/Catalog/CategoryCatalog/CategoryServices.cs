using AutoMapper;
using FSM_Application.Repository;
using FSM_Data.Entities;
using FSM_ViewModel.CategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Catalog.CategoryCatalog
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IMapper _mapper;
        private readonly IAllRepositorys<Category> _categoryRepositorys;
        public CategoryServices(IMapper mapper, IAllRepositorys<Category> categoryRepositorys)
        {
            _mapper = mapper;
            _categoryRepositorys = categoryRepositorys;
        }

        public async Task<Guid> CreateCategory(CreatedCategory createdCategory)
        {
            var category = _mapper.Map<CreatedCategory, Category>(createdCategory);
            category.CreatedAt = DateTime.Now;
            category.IsDeleted = true;
            var result = await _categoryRepositorys.AddItems(category);
            return category.Id;
        }

        public async Task<IEnumerable<GetAllCategory>> GetAllCategories()
        {
            var results = await _categoryRepositorys.GetAllItems();
            var categorys = _mapper.Map<IEnumerable<Category>, IEnumerable<GetAllCategory>>(results);
            return categorys;
        }

        public async Task<GetAllCategory> GetAllCategoryById(Guid id)
        {
            var categorie = await _categoryRepositorys.GetItemsById(id);
            var result = _mapper.Map<Category, GetAllCategory>(categorie);
            return result;
        }

        public async Task<bool> IsdeletedCategory(IsDeletedCategory category)
        {
            var request = await _categoryRepositorys.GetItemsById(category.Id);

            request.IsDeleted = category.IsDeleted;

            var updateIsdeleted = await _categoryRepositorys.UpdateItems(request);

            return updateIsdeleted;
        }

        public async Task<bool> UpdateCategory(UpdateCategory updateCategory)
        {
            var category = await _categoryRepositorys.GetItemsById(updateCategory.Id);
            category.UpdatedAt = DateTime.Now;

            var result = _mapper.Map<UpdateCategory, Category>(updateCategory, category);
            var update = await _categoryRepositorys.UpdateItems(result);
            return update;
        }
    }
}
