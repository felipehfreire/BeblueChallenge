using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beblue.CrossCutting.IntegrationSpotify.DTO;

namespace Beblue.Application.Interfaces
{
    public interface ISpotifyIntegrationAppService : IDisposable
    {
        Task<List<Item>> RecoverySpotifyDiscs();
    }
}
