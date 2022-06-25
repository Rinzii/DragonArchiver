using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
//using ImageMagitek.Colors;
//using ImageMagitek.Project.Serialization;
using Microsoft.Extensions.Logging;

namespace DragonArchiver.Core.Services;


/// <summary>
/// Bootstraps the full ImageMagitek environment 
/// </summary>
public class BootstrapService
{
    private readonly ILogger _logger;

    
    public BootstrapService(ILogger logger)
    {
        _logger = logger;
    }




    /*public virtual ICodecService CreateCodecService(string codecsPath, string schemaFileName)
    {
        var _codecService = new CodecService(schemaFileName);
        var result = _codecService.LoadXmlCodecs(codecsPath);

        if (result.Value is MagitekResults.Failed fail)
        {
            _logger.LogError(string.Join(Environment.NewLine, fail.Reasons));
        }

        return _codecService;
    }

    public virtual IPluginService CreatePluginService(string pluginPath, ICodecService codecService)
    {
        var pluginService = new PluginService();
        var fullPluginPath = Path.GetFullPath(pluginPath);

        if (Directory.Exists(fullPluginPath))
        {
            pluginService.LoadCodecPlugins(fullPluginPath);
            foreach (var codecPlugin in pluginService.CodecPlugins)
            {
                codecService.AddOrUpdateCodec(codecPlugin.Value);
            }
        }

        return pluginService;
    }*/


}