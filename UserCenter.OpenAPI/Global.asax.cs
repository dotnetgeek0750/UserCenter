﻿using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using UserCenter.IServices;

namespace UserCenter.OpenAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitAutoFac();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        /// <summary>
        /// 注册Autofac
        /// </summary>
        private void InitAutoFac()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterWebApiFilterProvider(configuration);

            //也给Filter注入
            builder.RegisterType(typeof(UCAuthorizationFilter)).PropertiesAutowired();

            var services = Assembly.Load("UserCenter.Services");
            builder.RegisterAssemblyTypes(services)
            .Where(type => !type.IsAbstract && typeof(IServiceTag).IsAssignableFrom(type))
            .AsImplementedInterfaces().SingleInstance().PropertiesAutowired();
            var container = builder.Build();
            // Set the WebApi dependency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }
    }
}
