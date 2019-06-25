using AutoMapper;
using Beblue.Application.ViewModels;
using Beblue.Domain.Discs;
using Beblue.Domain.Discs.Commands;
using Beblue.Domain.Sales;
using Beblue.Domain.Sales.Commands;

namespace Beblue.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap< DiscViewModel, Disc>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<OrderItemViewModel, OrderItem>();
            CreateMap<SaleViewModel, Sale>();
            CreateMap<DiscViewModel, CreateDiscCommand>()
                .ConstructUsing(c => new CreateDiscCommand(c.Name, c.Genre));

            CreateMap<SaleViewModel, CreateSaleCommand>()
               .ConstructUsing(c => new CreateSaleCommand(c.Date, c.CustomerId));

            CreateMap<CustomerViewModel, CreateCustomerCommand>()
             .ConstructUsing(c => new CreateCustomerCommand(c.Name));
        }
    }
}
