using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("GameEngineContext");
            services.AddDbContext<GameEngineContext>(
                options => options.UseSqlServer(connection));

            services.AddCors();
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(x => x.MapControllers());

        }
    }
}
