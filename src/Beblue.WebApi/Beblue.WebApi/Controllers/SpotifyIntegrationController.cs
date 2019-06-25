using Beblue.Application.Interfaces;
using Beblue.Domain.Core.Notifications;
using Beblue.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beblue.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SpotifyIntegrationController : BaseApiController
    {
        private readonly IDiscAppService discAppService;
        private readonly ISpotifyIntegrationAppService spotifyIntegrationAppService;

        public SpotifyIntegrationController(IDiscAppService discAppService, 
            ISpotifyIntegrationAppService spotifyIntegrationAppService, 
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            this.discAppService = discAppService;
            this.spotifyIntegrationAppService = spotifyIntegrationAppService;
        }
        /// <summary>
        /// Alimenta o catálogo de discos utilizando a API do Spotify
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FillDiscs()
        {
            await spotifyIntegrationAppService.RecoverySpotifyDiscs();
            return Response();

        }
    }
}
