using AutoMapper;
using Beblue.Application.ViewModels;
using Beblue.CrossCutting.IntegrationSpotify.DTO;
using Beblue.Domain.Discs;
using Beblue.Domain.Sales;

namespace Beblue.Application.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {

            CreateMap<Disc, DiscViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<Sale, SaleViewModel>();
            CreateMap<Item, DiscViewModel>()
                .ConvertUsing(converter => new DiscViewModel()
                {
                    Name = converter.name,
                    Genre= converter.genre
                });



        }
    }
}
