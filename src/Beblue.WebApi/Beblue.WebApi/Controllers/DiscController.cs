using Beblue.Application.Interfaces;
using Beblue.Domain.Core.Notifications;
using Beblue.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beblue.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DiscController : BaseApiController
    {

        private readonly IDiscAppService discAppService;

        public DiscController(IDiscAppService discAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            this.discAppService = discAppService;
        }


        /// <summary>
        /// Consultar o catálogo de discos de forma paginada, filtrando por gênero e
        /// ordenando de forma crescente pelo nome do disco
        /// </summary>
        /// <param name="genre">fitro por gênero </param>
        /// <param name="page"> pagina á ser recuperada</param>
        /// <param name="size">tamanho da paginação</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDiscPaged(string genre, int page, int size)
        {
            return Response(await discAppService.GetDiscPagedAsync(genre,  page,  size));
        }

        /// <summary>
        /// Consultar o disco pelo seu identificador;        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDiscById( int id)
        {
            return Response(await discAppService.GetById(id));

        }
    }
}
