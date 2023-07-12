using AutoMapper;
using RM.Entities;

namespace RM.Services
{
    public class MappingsProfile : Profile
	{
		public MappingsProfile() 
		{
			CreateMap<Menu, MenuDto>();
			CreateMap<Order, OrderDto>();
			CreateMap<OrderMenu, OrderMenuDto>();
			CreateMap<MenuProduct, MenuProductDto>();
			CreateMap<Product, ProductDto>();
			CreateMap<Storage, StorageDto>();
			CreateMap<Customer, CustomerDto>();
			CreateMap<OnsiteTable, OnsiteTableDto>();
			CreateMap<User, UserDto>();

            CreateMap<MenuDto, Menu>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderMenuDto, OrderMenu>();
            CreateMap<MenuProductDto, MenuProduct>();
            CreateMap<ProductDto, Product>();
            CreateMap<StorageDto, Storage>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<OnsiteTableDto, OnsiteTable>();
            CreateMap<UserDto, User>();
        }
	}
}