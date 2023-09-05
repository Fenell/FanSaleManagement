using AutoMapper;
using FSM_Data.Entities;
using FSM_ViewModel.BrandViewModel;
using FSM_ViewModel.CategoryViewModel;
using FSM_ViewModel.OrderViewModel;
using FSM_ViewModel.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.MappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Map Product

            CreateMap<CreateProduct, Product>();
            CreateMap<Product, GetAllProduct>();
            CreateMap<UpdateProduct, Product>();

            // Map Order

            CreateMap<Order, GetAllOrder>();
            CreateMap<CreateOrder, Order>();

            //Map Category
            CreateMap<Category, GetAllCategory>();
            CreateMap<CreatedCategory, Category>();
            CreateMap<UpdateCategory, Category>();

            //Map Brand
            CreateMap<Brand, GetAllBrands>();
            CreateMap<CreatedBrand, Brand>();
            CreateMap<UpdateBrand, Brand>();
        }
    }
}
