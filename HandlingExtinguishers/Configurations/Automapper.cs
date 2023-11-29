using AutoMapper;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguisher.Dto.Employees;
using HandlingExtinguishers.Dto.Company;
using HandlingExtinguishers.Dto.Models;
using ManagementFireEstinguisher.Dto;
using ManagementFireEstinguisher.Dto.Credit;
using ManagementFireEstinguisher.Dto.Expenses;
using ManagementFireEstinguisher.Dto.Extinguishers;
using ManagementFireEstinguisher.Dto.Inventories;
using ManagementFireEstinguisher.Dto.Prices;
using ManagementFireEstinguisher.Dto.Products;
using ManagementFireEstinguisher.Dto.Services;
using ManagementFireEstinguisher.Dto.Users;

namespace HandlingExtinguishers.WebApi.Configurations
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Users, RegisterUserDto>().ReverseMap();

            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, BaseClient>().ReverseMap();

            CreateMap<CreditService, CreditoServicioBase>().ReverseMap();
            CreateMap<CreditService, CreditoServiciosDTO>()
                .ForMember(x => x.Servicio, y => y.MapFrom(z => z.Service));

            CreateMap<DetailService, DetalleServicioDTO>()
                .ForMember(x => x.Inventarios, y => y.MapFrom(z => z.Inventories))
                .ForMember(x => x.PesoExtintor, y => y.MapFrom(z => z.WeightExtinguisher))
                .ForMember(x => x.Precios, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.TipoExtintor, y => y.MapFrom(z => z.TypeExtinguisher));
            CreateMap<DetailService, DetalleServicioBase>().ReverseMap();

            CreateMap<DetailExtinguisherClient, BaseDetailExtinguisherClient>().ReverseMap();
            CreateMap<DetailExtinguisherClient, DetailExtinguisherClientDto>()
                .ForMember(x => x.Client, y => y.MapFrom(z => z.Clientes));

            CreateMap<Companies, CompanyDto>().ReverseMap();
            CreateMap<Companies, CompanyBase>().ReverseMap();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.Empresa, y => y.MapFrom(z => z.Company));
            CreateMap<Employee, EmployeeBase>().ReverseMap();

            CreateMap<Inventory, InventarioDTO>()
                .ForMember(x => x.Producto, y => y.MapFrom(z => z.Product))
                .ForMember(x => x.PesoExtintor, y => y.MapFrom(z => z.WeightExtinguisher))
                .ForMember(x => x.TipoExtintor, y => y.MapFrom(z => z.TypeExtinguisher));
            CreateMap<Inventory, InventarioBase>().ReverseMap();


            CreateMap<Expense, GastosBase>().ReverseMap();
            CreateMap<Expense, GastosDTO>().ReverseMap();

            CreateMap<Price, PrecioBase>().ReverseMap();
            CreateMap<Price, PrecioDTO>()
                .ForMember(x => x.Producto, y => y.MapFrom(z => z.Product));

            CreateMap<Product, ProductoBase>().ReverseMap();
            CreateMap<Product, ProductoDTO>()
                .ForMember(x => x.TipoExtintor, y => y.MapFrom(z => z.TypeExtinguisher))
                .ForMember(x => x.PesoExtintor, y => y.MapFrom(z => z.WeightExtinguisher));

            CreateMap<WeightExtinguisher, PesoExtintorBase>().ReverseMap();
            CreateMap<WeightExtinguisher, PesoExtintorDTO>().ReverseMap();

            CreateMap<TypeExtinguisher, TipoExtintorBase>().ReverseMap();
            CreateMap<TypeExtinguisher, TipoExtintorDTO>().ReverseMap();

            CreateMap<Service, ServicioBase>().ReverseMap();
            CreateMap<Service, ModificarEstado>().ReverseMap();
            CreateMap<Service, ServicioDTO>()
                .ForMember(x => x.Cliente, y => y.MapFrom(z => z.Client))
                .ForMember(x => x.Empleado, y => y.MapFrom(z => z.Employee));
        }
    }
}
