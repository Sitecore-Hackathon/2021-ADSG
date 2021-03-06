﻿using ADSG.Foundation.Framework.Logging;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace ADSG.Website
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(ILogger), typeof(Logger));
        }
    }
}