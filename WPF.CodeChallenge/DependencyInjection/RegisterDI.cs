using Microsoft.Extensions.DependencyInjection;
using WPF.CodeChallenge.Services;
using WPF.CodeChallenge.Services.Contracts;

namespace WPF.CodeChallenge.DependencyInjection;

/// <summary>
/// Register DI class
/// </summary>
public static class RegisterDI
{
    /// <summary>
    /// Registers the di services.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void RegisterDIServices(IServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddSingleton<IShapeService, ShapeService>();
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IShapeDataServiceFactory, ShapeDataServiceFactory>();
        services.AddSingleton<IShapeDataService, TriangleDataService>();
        services.AddSingleton<IShapeDataService, LineDataService>();
        services.AddSingleton<IShapeDataService, CircleDataService>();
    }
};