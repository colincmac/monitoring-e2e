using StackExchange.Redis;

namespace AppFailures.Web.Services;

public class RedisService
{
    private readonly ILogger<RedisService> _logger;
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisService(ILogger<RedisService> logger, ConnectionMultiplexer redis)
    {
        _logger = logger;
        _redis = redis;
        _database = redis.GetDatabase();
    }
}
