using FillSign.Ds.Application.CommandHandlers;
using FillSign.Ds.Data;
using FillSign.Ds.Services.Notification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FillSign.Ds.Api.Configuration
{
    public static class DbContextConfig
    {
        //O "this" significa que está criando esse método de externsão, dentro da classe WebApplicationBuilder, por mais que não tenha o código fonte.
        public static WebApplicationBuilder AddDbContextAndNotificationScopeConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<INotificationDomain<NotificationDomainMessage>, NotificationDomain>();
            builder.Services.AddScoped<IDocumentApplication, DocumentApplication>();
            builder.Services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            

            return builder;
        }
    }
}
