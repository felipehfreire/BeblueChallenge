using AutoMapper;
using Beblue.Application.Interfaces;
using Beblue.Application.ViewModels;
using Beblue.CrossCutting.IntegrationSpotify.DTO;
using Beblue.CrossCutting.IntegrationSpotify.Interfaces;
using Beblue.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beblue.Application.Services.Discs
{
    public class SpotifyIntegrationAppService : ISpotifyIntegrationAppService
    {
        private readonly IUnityOfWork _uow;
        private readonly ISpotiFyIntegrationService spotiFyIntegrationService;
        private readonly IMapper mapper;
        private readonly IDiscAppService discAppService;

        public SpotifyIntegrationAppService(IUnityOfWork uow, ISpotiFyIntegrationService spotiFyIntegrationService,   IMapper mapper, IDiscAppService discAppService)
        { 
            this._uow = uow;
            this.spotiFyIntegrationService = spotiFyIntegrationService;
            this.mapper = mapper;
            this.discAppService = discAppService;
        }
        public async  Task<List<Item>> RecoverySpotifyDiscs()
        {
            var spotifysAlbums = mapper.Map<List<DiscViewModel>>(await spotiFyIntegrationService.RecoverySpotifyDiscs());
            foreach (var item in spotifysAlbums)
                await discAppService.Add(item);

            return null;
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
