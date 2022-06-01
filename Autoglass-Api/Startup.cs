using Autoglass_Application.Interfaces;
using Autoglass_Application.Services;
using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Infrastructure_data.Context;
using Autoglass_Infrastructure_data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using FluentValidation;
using Autoglass_Application.Dtos;
using Autoglass_Application.Validators;
using System;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using OData.Swagger.Services;
using Autoglas_Domain_Services.Services;

namespace Autoglass_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
         

            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];
            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(connection)
            );

            services.AddControllers().AddFluentValidation();

            services.AddOData();
            services.AddMvc(a => a.EnableEndpointRouting = false);
            services.AddOdataSwaggerSupport();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Autoglass_Api", Version = "v1" });
            });

            
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IFornecedorAppService, FornecedorAppService>();
            services.AddScoped<ProdutoService>();
            services.AddScoped<FornecedorService>();

            services.AddScoped<IValidator<CriarProdutoDto>, ProdutoValidator>();
            services.AddScoped<IValidator<AlterarProdutoDto>, AlterarProdutoValidator>();
          


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autoglass_Api v1"));
            }

            app.UseMvc(a =>
            {
                a.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                a.EnableDependencyInjection();
                a.MapODataServiceRoute("odata", "odata", GetEdmodel());
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
                //endpoints.EnableDependencyInjection();   
                //endpoints.MapODataRoute("odata", "odata", GetEdmodel());
            });
        }

        private static IEdmModel GetEdmodel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            return builder.GetEdmModel();
        }
    }
}
