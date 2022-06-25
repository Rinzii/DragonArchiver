using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DragonArchiver.Core.Services;
using Microsoft.Extensions.Logging;

namespace DragonArchiver.Core.Services;

/// <summary>
/// Bootstraps the full ImageMagitek environment 
/// </summary>
public class BootstrapService
{
    private readonly ILogger _logger;

    public static string DefaultLogFileName { get; } = "errorlog.txt";
    public static string DefaultConfigurationFileName { get; } = "appsettings.json";
    
    public BootstrapService(ILogger logger)
    {
        _logger = logger;
    }

    public virtual AppSettings ReadConfiguration(string jsonFileName)
    {
        try
        {
            var json = File.ReadAllText(jsonFileName);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var settings = JsonSerializer.Deserialize<AppSettings>(json, options);

            var lowerDict = new Dictionary<string, string>();

            return settings;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, $"Failed to read the configuration file '{jsonFileName}'");
            throw;
        }
    }






}