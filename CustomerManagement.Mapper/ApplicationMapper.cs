using AutoMapper;
using CustomerManagement.DTO;
using CustomerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductDTO, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RoleDTO, UpdateRoleDTO>().ReverseMap();
            CreateMap<Role, UpdateRoleDTO>().ReverseMap();

            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<GenderDTO, UpdateGenderDTO>().ReverseMap();
            CreateMap<Gender, UpdateGenderDTO>().ReverseMap();

            /*
            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.GenderName))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleName)).ReverseMap();
            */
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<UserDTO, UpdateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            CreateMap<Order,UpdateOrderDTO>().ReverseMap();
            CreateMap<OrderDTO,UpdateOrderDTO>().ReverseMap();

            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<PaymentDTO, UpdatePaymentDTO>().ReverseMap();
            CreateMap<Payment, UpdatePaymentDTO>().ReverseMap();
            /*
                        CreateMap<Order, CreateOrderDTO>();
                        CreateMap<CreateOrderDTO, Order>();
                        CreateMap<OrderDTO, CreateOrderDTO>().ReverseMap();
                        CreateMap<OrderDTO, Order>().ReverseMap();
                        CreateMap<OrderDTO, Order>().ReverseMap();
            */

        }
    }
}
