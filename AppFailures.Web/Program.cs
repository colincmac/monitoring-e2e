using AppFailures.Web.Configuration;
using AppFailures.Web.Services;
using Azure.Identity;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Key Vault
var vaultUri = Environment.GetEnvironmentVariable("VaultUri");
if (!string.IsNullOrEmpty(vaultUri))
{
    var keyVaultEndpoint = new Uri(vaultUri);
    builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
}

// Add services to the container.
builder.Services.AddControllersWithViews();

// OpenAPI (Swagger)
builder.Services.AddEndpointsApiExplorer();

// Application Insights
builder.Services.AddApplicationInsightsTelemetry();

// Redis Cache
var redisConfiguration = builder.Configuration.GetSection(RedisConfiguration.SectionName).Get<RedisConfiguration>();

if (redisConfiguration is not null && !string.IsNullOrEmpty(redisConfiguration.ConnectionString))
{
    builder.Services.AddSingleton(async _ => await RedisConnection.InitializeAsync(connectionString: redisConfiguration.ConnectionString));

    //builder.Services.AddDistributedRedisCache(option =>
    //{
    //    option.Configuration = redisConfiguration.ConnectionString;
    //});

}

// Health Checks
builder.Services.AddHealthChecks()
    .AddCheck("Sample", () => HealthCheckResult.Healthy("A healthy result."));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHealthChecks("/healthz");

app.Run();
