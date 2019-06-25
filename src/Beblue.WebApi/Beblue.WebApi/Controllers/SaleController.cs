using Beblue.Application.Interfaces;
using Beblue.Application.ViewModels;
using Beblue.Domain.Core.Notifications;
using Beblue.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Beblue.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SaleController : BaseApiController
    {
        private readonly ISaleAppService saleAppService;

        public SaleController(
            ISaleAppService saleAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            this.saleAppService = saleAppService;
        }

        /// <summary>
        ///  Registrar uma nova venda de discos calculando o valor total de cashback considerando a tabela.
        /// </summary>
        /// <param name="saleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            await saleAppService.AddCustomer(customerViewModel);
            return Response();

        }

        /// <summary>
        ///  Registrar uma nova venda de discos calculando o valor total de cashback considerando a tabela.
        /// </summary>
        /// <param name="saleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterSale([FromBody]SaleViewModel saleViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(saleViewModel);
            }

            await saleAppService.Add(saleViewModel);
            return Response();

        }
        /// <summary>
        /// Consultar uma venda pelo seu identificador;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSaleById(int id)
        {
            return Response(await saleAppService.GetById(id));

        }

        /// <summary>
        /// Consultar todas as vendas efetuadas de forma paginada, filtrando pelo range
        ///de datas(inicial e final) da venda e ordenando de forma decrescente pela data da venda;
        /// </summary>
        /// <param name="initialDate"></param>
        /// <param name="finalDate"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDiscPaged(DateTime initialDate, DateTime finalDate, int page, int size)
        {
            return Response(await saleAppService.GetSalesPagedAsync(initialDate, finalDate, page, size));
        }
    }
}
