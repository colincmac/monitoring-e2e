using AppFailures.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppFailures.Web.Controllers;
public class RedisController : Controller
{
    private readonly ILogger<RedisController> _logger;
    private readonly IConfiguration _configuration;
    private readonly Task<RedisConnection> _redisConnectionFactory;
    private RedisConnection? _redisConnection;

    public RedisController(ILogger<RedisController> logger, IConfiguration configuration, Task<RedisConnection> redisConnectionFactory)
    {
        _logger = logger;
        _configuration = configuration;
        _redisConnectionFactory = redisConnectionFactory;
    }

    public async Task<ActionResult> RedisCache()
    {
        _redisConnection = await _redisConnectionFactory;
        ViewBag.Message = "A simple example with Azure Cache for Redis on ASP.NET Core.";

        // Perform cache operations using the cache object...

        // Simple PING command
        ViewBag.command1 = "PING";
        ViewBag.command1Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.ExecuteAsync(ViewBag.command1))).ToString();

        // Simple get and put of integral data types into the cache
        var key = "Message";
        var value = "Hello! The cache is working from ASP.NET Core!";

        ViewBag.command2 = $"SET {key} \"{value}\"";
        ViewBag.command2Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.StringSetAsync(key, value))).ToString();

        ViewBag.command3 = $"GET {key}";
        ViewBag.command3Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.StringGetAsync(key))).ToString();

        key = "LastUpdateTime";
        value = DateTime.UtcNow.ToString();

        ViewBag.command4 = $"GET {key}";
        ViewBag.command4Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.StringGetAsync(key))).ToString();

        ViewBag.command5 = $"SET {key}";
        ViewBag.command5Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.StringSetAsync(key, value))).ToString();

        return View();
    }
}

