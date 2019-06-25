using AutoMapper;
using Beblue.Application.Interfaces;
using Beblue.Application.ViewModels;
using Beblue.Domain.Discs.Commands;
using Beblue.Domain.Discs.Repository;
using Beblue.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beblue.Application.Services.Discs
{
    public class DiscAppService : IDiscAppService
    {
        private IDiscRepository discRepository;
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediator;

        public DiscAppService( IDiscRepository discRepository, IMapper mapper, IMediatorHandler mediator)
        {
            this.discRepository = discRepository;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task Add(DiscViewModel discViewModel)
        {
            var registerCommand = mapper.Map<CreateDiscCommand>(discViewModel);
            await mediator.SendCommand(registerCommand);
        }

        public async Task<DiscViewModel> GetById(int id)
        {
            return mapper.Map<DiscViewModel>(await discRepository.GetById(id));
        }

        public async Task<List<DiscViewModel>> GetAll()
        {
            return mapper.Map<List<DiscViewModel>>(await discRepository.GetAll());
        }

        public async Task Remove(int id)
        {
            await discRepository.Remove(id);
        }

        public void Dispose()
        {
            discRepository.Dispose();
        }

        public async Task<List<DiscViewModel>> GetDiscPagedAsync(string genre, int page, int size)
        {
            var discList = await discRepository.FindPaginated( p=> p.Genre.ToUpper() == genre.ToUpper(), page, size);
            return mapper.Map<List<DiscViewModel>>(discList.OrderBy(p=> p.Name));
        }
    }
}
