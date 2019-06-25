using Beblue.CrossCutting.IntegrationSpotify.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beblue.CrossCutting.IntegrationSpotify.Interfaces
{
    public interface ISpotiFyIntegrationService
    {
        Task<List<Item>> RecoverySpotifyDiscs();
    }
}
