using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using EnterprisePatterns.Api.Customers.Domain.Repository;
using EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Repository;
using AutoMapper;
using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Customers.Application.Assembler;
using EnterprisePatterns.Api.Users.Domain.Repository;
using EnterprisePatterns.Api.Users.Infrastructure.Persistence.NHibernate.Repository;
using EnterprisePatterns.Api.Projects.Domain.Repository;
using EnterprisePatterns.Api.Projects.Infrastructure.Persistence.NHibernate.Repository;
using EnterprisePatterns.Api.DepotOrders.Application.Assembler;
using EnterprisePatterns.Api.DepotOrders.Domain.Repository;
using EnterprisePatterns.Api.DepotOrders.Infrastructure.Persistence.NHibernate.Repository;
using DepotSystem.Api.DepotOrders.Application.Validations;
using DepotSystem.API.Application.Response;

namespace EnterprisePatterns.Api
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
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(new SessionFactory(Environment.GetEnvironmentVariable("MYSQL_STRCON_EXAMEN_PARCIAL")));
            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetService<IMapper>();
            services.AddSingleton(new CustomerAssembler(mapper));
            services.AddSingleton(new UserAssembler(mapper));
            services.AddSingleton(new ProjectAssembler(mapper));
            services.AddSingleton(new DepotOrderAssembler(mapper));
            services.AddSingleton(new DepotOrderEquipmentAssembler(mapper));
            services.AddSingleton<DepotOrderDtoValidator>();
            services.AddSingleton<ApiResponseHandler>();

            services.AddScoped<IUnitOfWork, UnitOfWorkNHibernate>();
            services.AddTransient<ICustomerRepository, CustomerNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new CustomerNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });
            services.AddTransient<IUserRepository, UserNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new UserNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });
            services.AddTransient<IProjectRepository, ProjectNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new ProjectNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });
            services.AddTransient<IDepotOrderRepository, DepotOrderNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new DepotOrderNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });
            services.AddTransient<IDepotOrderEquipmentRepository, DepotOrderEquipmentNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new DepotOrderEquipmentNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
