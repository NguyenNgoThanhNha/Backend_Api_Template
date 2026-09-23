using ServerApiTemplate.Application.Common.Interfaces;
using ServerApiTemplate.Infrastructure.Commons;
using ServerApiTemplate.Infrastructure.Logging;
using ServerApiTemplate.Infrastructure.Security;
using ServerApiTemplate.Infrastructure.Seed;
using ServerApiTemplate.Infrastructure.Services;
using ServerApiTemplate.Persistence;
using ServerApiTemplate.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServerApiTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration,
        bool enableBackgroundJobs = true)
    {
        services.AddSingleton(TimeProvider.System);
        services.AddMemoryCache();

        // --- Data: DbContext + audit interceptor + UnitOfWork (open generic, Scoped — chuẩn BE §5) ---
        services.AddScoped<AuditSaveChangesInterceptor>();
        services.AddDbContext<ServerApiTemplateDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"),
                    sql => sql.MigrationsAssembly(typeof(ServerApiTemplateDbContext).Assembly.FullName))
                .AddInterceptors(sp.GetRequiredService<AuditSaveChangesInterceptor>());
        });
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

        // --- Security ---
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        services.AddSingleton<IPasswordHasher, PasswordHasherAdapter>();
        services.AddSingleton<PermissionCacheVersion>();
        services.AddScoped<IPermissionService, PermissionService>();

        // --- External services ---
        services.Configure<FileStorageOptions>(configuration.GetSection(FileStorageOptions.SectionName));
        services.AddSingleton<IFileStorage, LocalFileStorage>();
        services.AddSingleton<IEmailSender, LoggingEmailSender>();
        services.AddTransient<LoggingDelegatingHandler>();

        // --- API logging (chuẩn BE §9.2) ---
        services.Configure<ApiLoggingOptions>(configuration.GetSection(ApiLoggingOptions.SectionName));
        services.AddSingleton<ApiLogQueue>();

        services.AddScoped<DataSeeder>();

        if (enableBackgroundJobs)
        {
            services.AddHostedService<ApiLogWriterService>();
            services.AddHostedService<ApiLogCleanupService>();
        }

        return services;
    }
}
