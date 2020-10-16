﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using PazzoApi.Service.DbContextFactory;
using PazzoApi.Service.Interface;
using PazzoApi.Service.Repository;
using PazzoApi.Service.Service;
using PazzoApi.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace PazzoApi.App_Start
{
    public class AutofacConfig
    {
        public static void Bootstrapper()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // 註冊DbContextFactory
            string connectionString =
                ConfigurationManager.ConnectionStrings["NorthwindEntities"].ConnectionString;
            builder.RegisterType<DbContextFactory>()
                .WithParameter("connectionString", connectionString)
                .As<IDbContextFactory>()
                .InstancePerHttpRequest();

            // 註冊 Repository UnitOfWork
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));

            // 註冊Services
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            builder.RegisterType<ProductsService>()
             .As<IProductsService>()
             .InstancePerLifetimeScope();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfigFile());
            });
            builder.RegisterInstance<IMapper>(mapperConfig.CreateMapper());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //// 解析容器內的型別
            //AutofacWebApiDependencyResolver resolverApi = new AutofacWebApiDependencyResolver(container);
            //AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);

            //// 建立相依解析器
            //GlobalConfiguration.Configuration.DependencyResolver = resolverApi;
            //DependencyResolver.SetResolver(resolver);
        }
    }
}