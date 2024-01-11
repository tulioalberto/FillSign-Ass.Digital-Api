using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FillSign.Ds.Domain.Entities;
using FillSign.Ds.Data;
using Microsoft.AspNetCore.Identity;

namespace FillSign.Ds.Api.Configuration
{
    public static class IdentityConfig
    {
        //O "this" significa que está criando esse método de externsão, dentro da classe WebApplicationBuilder, por mais que não tenha o código fonte.
        public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<ApiDbContext>();

            // Pegando o token e gerando a chave encodada
            var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettings>(JwtSettingsSection);

            var JwtSettings = JwtSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Segredo);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience= JwtSettings.Audiencia,
                    ValidIssuer = JwtSettings.Emissor
                };
            });

            return builder;
        }
    }
}
