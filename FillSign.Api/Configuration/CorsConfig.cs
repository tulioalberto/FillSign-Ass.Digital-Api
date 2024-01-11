namespace FillSign.Ds.Api.Configuration
{
    public static class CorsConfig
    {
        //O "this" significa que está criando esse método de externsão, dentro da classe WebApplicationBuilder, por mais que não tenha o código fonte.
        public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Development", builder =>
                builder.
                     AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                //options.AddPolicy("Production", builder =>
                //builder
                //     .WithOrigins("https://localhost:7127/")
                //    .WithMethods("POST")
                //    .AllowAnyHeader());
            });

            return builder;
        }
    }
}
