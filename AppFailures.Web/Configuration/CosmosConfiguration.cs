﻿namespace AppFailures.Web.Configuration;

public class CosmosConfiguration
{
    public const string SectionName = "Cosmos";
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string ContainerName { get; set; } = string.Empty;
}
