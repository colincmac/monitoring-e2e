namespace AppFailures.Web;

public static class Extensions
{
    //public static IHealthChecksBuilder AddRedis(
    //this IHealthChecksBuilder builder,
    //string redisConnectionString,
    //string? name = default,
    //HealthStatus? failureStatus = default,
    //IEnumerable<string>? tags = default,
    //TimeSpan? timeout = default)
    //{
    //    return builder.AddRedis(_ => redisConnectionString, name, failureStatus, tags, timeout);
    //}

    //public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddHealthChecks()
    //        .AddRedis(_ => configuration.GetRequiredConnectionString("redis"), "redis", tags: new[] { "ready", "liveness" });

    //    return services;
    //}

    //public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    //{
    //    return services.AddSingleton(sp =>
    //    {
    //        var redisConfig = ConfigurationOptions.Parse(configuration, true);

    //        return ConnectionMultiplexer.Connect(redisConfig);
    //    });
    //}
}
