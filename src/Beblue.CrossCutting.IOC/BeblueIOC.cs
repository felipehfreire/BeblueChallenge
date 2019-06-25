using AutoMapper;
using Beblue.Application.AutoMapper;
using Beblue.Application.Interfaces;
using Beblue.Application.Services.Discs;
using Beblue.Application.Services.Sales;
using Beblue.CrossCutting.IntegrationSpotify;
using Beblue.CrossCutting.IntegrationSpotify.Interfaces;
using Beblue.CrossCutting.Integrator;
using Beblue.Data.Context;
using Beblue.Data.Repositorys;
using Beblue.Data.UOW;
using Beblue.Domain.Core.Notifications;
using Beblue.Domain.Discs.Commands;
using Beblue.Domain.Discs.Repository;
using Beblue.Domain.Interfaces;
using Beblue.Domain.Sales.Commands;
using Beblue.Domain.Sales.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Beblue.CrossCutting.IOC
{
    public static class BeblueIOC
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            #region Application
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IDiscAppService, DiscAppService>();
            services.AddScoped<ISpotifyIntegrationAppService, SpotifyIntegrationAppService>();
            services.AddScoped<ISaleAppService, SaleAppService>();
            #endregion

            #region Domain

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<CreateDiscCommand, bool>, DiscCommandHandler>();
            services.AddScoped<IRequestHandler<CreateSaleCommand, bool>, SaleCommandHandler>();
            services.AddScoped<IRequestHandler<CreateCustomerCommand, bool>, SaleCommandHandler>();
            #endregion

            #region data
            services.AddScoped<IUnityOfWork, UnitOfWork>();
            services.AddScoped<BeblueContext>();
            #endregion

            #region Repositories
            services.AddScoped<IDiscRepository, DiscRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            #endregion

            #region SpotifyIntegration 
            services.AddScoped<ISpotiFyIntegrationService, SpotiFyIntegrationService>();
            #endregion

        }
    }
}
