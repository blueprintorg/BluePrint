using AutoMapper;
using BluePrint.DependencyInjection.Extensions;
using BluePrint.DependencyInjection.Modules.Behaviors;
using BluePrint.DependencyInjection.Modules.Concretes;
using BluePrint.Idm.DataAccess.Persistence.Context;
using BluePrint.Idm.Model.Entities;
using BluePrint.Idm.WebApi.DependencyInversion;
using BluePrint.Idm.WebApi.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace BluePrint.Idm.WebApi
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration.GetValue<string>("IdentityServer:Authority");
                    options.RequireHttpsMetadata = false;

                    options.Audience = Configuration.GetValue<string>("IdentityServer:Audience");
                });

            services.AddDbContext<IdmContext>(options =>
           options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            //Identity Config
            services.AddIdentity<UserEntity, RoleEntity>(i =>
            {
                i.Password.RequiredLength = 5;
                i.Password.RequireNonAlphanumeric = false;
                i.Password.RequireLowercase = false;
                i.Password.RequireUppercase = false;
                i.Password.RequireDigit = false;

                i.User.RequireUniqueEmail = true;
            }).
            AddEntityFrameworkStores<IdmContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new OpenApiInfo
                {
                    Title = "Swagger on BluePrint IDM Framework",
                    Version = "1.0.0",
                    Description = "BluePrint on (.NET Core 3.0)",
                });
            });

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDependencyResolvers(new IBluePrintModule[]
            {
                new BluePrintModule(),
                new RegisterService()
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger()
          .UseSwaggerUI(c =>
          {
              c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger BluePrint v1");
          });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}