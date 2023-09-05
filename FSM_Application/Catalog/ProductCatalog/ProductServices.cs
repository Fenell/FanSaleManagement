using AutoMapper;
using FSM_Application.Repository;
using FSM_Data.EF;
using FSM_Data.Entities;
using FSM_ViewModel.ProductViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Catalog.ProductCatalog
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IAllRepositorys<Product> _productRepo;
        public ProductServices(IAllRepositorys<Product> productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
        }
        public async Task<Guid> CreateProduct(CreateProduct result)
        {
            var products = _mapper.Map<Product>(result);
            products.CreatedAt = DateTime.Now;
            products.IsDeleted = true;
            var addProduct = await _productRepo.AddItems(products);
            return products.Id;
        }

        public async Task<GetAllProduct> GetAllProductById(Guid id)
        {
            var product = await _productRepo.GetItemsById(id);
            var result = _mapper.Map<Product, GetAllProduct>(product);
            return result;
        }

        public async Task<IEnumerable<GetAllProduct>> GetAllProducts()
        {
            var products = await _productRepo.GetAllItems();
            var result = _mapper.Map<IEnumerable<Product>, IEnumerable<GetAllProduct>>(products);
            return result;
        }

        public async Task<bool> UpdateIsDeleted(IsDeletedDto result)
        {
            var product = await _productRepo.GetItemsById(result.Id);
            product.IsDeleted = result.IsDeleted;
            var updateIsDeleted = await _productRepo.UpdateItems(product);
            return updateIsDeleted;
        }

        public async Task<bool> UpdateProduct(UpdateProduct result)
        {
            var product = await _productRepo.GetItemsById(result.Id);

            product.UpdatedAt = DateTime.Now;

            var mapProduct = _mapper.Map<UpdateProduct, Product>(result, product);

            var updateProduct = await _productRepo.UpdateItems(mapProduct);
            return updateProduct;
        }
    }
}
