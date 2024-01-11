namespace FillSign.Ds.Api.Configuration
{
    //Classe de método de estensão do proprio builder.
    public static class ApiConfig
    {
        //O "this" significa que está criando esse método de externsão, dentro da classe WebApplicationBuilder, por mais que não tenha o código fonte.
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder) 
        {
            builder.Services.AddControllers();
            return builder;
        }
    }
}
