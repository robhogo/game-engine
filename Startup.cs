using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RoBHo_GameEngine.Contexts;
using RoBHo_GameEngine.Contexts.Converters;
using RoBHo_GameEngine.Contexts.DataModels;
using RoBHo_GameEngine.Models;
using RoBHo_GameEngine.Repositories;
using RoBHo_GameEngine.Requests;
using RoBHo_GameEngine.Services;

namespace RoBHo_GameEngine
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetValue<string>("ConnectionString");
            services.AddDbContext<GameEngineContext>(
                options => options.UseSqlServer(connection));

            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                      });
            });

            services.AddControllers();

            services.AddScoped<ICharacterLogic, CharacterLogic>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IDataModelConverter<CharacterDataModel, Character, CharacterCreateRequest>, CharacterConverter>();
            services.AddScoped<IDataModelConverter<CharacterLvlDataModel, CharacterLvl, LvlType>, CharacterLvlConverter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GameEngineContext context)
        {
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(x => x.MapControllers());

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "game-engine");
                // Serve the swagger UI at the app's root
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
