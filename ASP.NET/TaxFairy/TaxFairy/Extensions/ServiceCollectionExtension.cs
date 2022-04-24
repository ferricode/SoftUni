﻿using Microsoft.EntityFrameworkCore;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.Services;
using TaxFairy.Infrastructure.Data;
using TaxFairy.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITaxFairyDbRepository, TaxFairyDbRepository>();
           // services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPrivacyService, PrivacyService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IVendorService, VendorService>();


            return services;
        }
        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}