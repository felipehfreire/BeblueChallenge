using AutoMapper;
using Beblue.Application.Interfaces;
using Beblue.Application.ViewModels;
using Beblue.Domain.Interfaces;
using Beblue.Domain.Sales;
using Beblue.Domain.Sales.Commands;
using Beblue.Domain.Sales.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beblue.Application.Services.Sales
{
    public class SaleAppService : ISaleAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediator;
        private readonly ISaleRepository saleRepository;

        public SaleAppService(IMapper mapper, IMediatorHandler mediator, ISaleRepository saleRepository)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.saleRepository = saleRepository;
        }
        public async Task Add(SaleViewModel saleViewModel)
        {
            var registerCommand = mapper.Map<CreateSaleCommand>(saleViewModel);
            registerCommand.Items = mapper.Map<List<OrderItem>>(saleViewModel.Items);
            await mediator.SendCommand(registerCommand);
        }

        public async Task<SaleViewModel> GetById(int id)
        {
            return mapper.Map<SaleViewModel>(await saleRepository.GetById(id));
        }

        public async Task<List<SaleViewModel>> GetSalesPagedAsync(DateTime initialDate, DateTime finalDate, int page, int size)
        {
            var salesFilter = await saleRepository.FindPaginated(p => p.Date.Date >= initialDate.Date && p.Date <= finalDate.Date,page, size );
            return mapper.Map<List<SaleViewModel>>(salesFilter.OrderByDescending(p => p.Date));
        }

        public void Dispose()
        {
            saleRepository.Dispose();
        }

        public async Task AddCustomer(CustomerViewModel customerViewModel)
        {
            var registerCommand = mapper.Map<CreateCustomerCommand>(customerViewModel);
            await mediator.SendCommand(registerCommand);
        }
    }
}
