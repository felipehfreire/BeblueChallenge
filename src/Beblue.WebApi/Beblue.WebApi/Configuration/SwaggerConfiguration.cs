using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Beblue.WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Desafio técnico - Engenheiro back-end",
                    Description = "API do desafio ",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Felipe Henrique Freire", Email = "felipehfreire@gmail.com", Url = "https://www.linkedin.com/in/felipe-freire-ab458a8b/" },
                    License = new License { Name = "MIT", Url = "http://meusite.com/licensa" }
                });
            });
        }
    }
}
