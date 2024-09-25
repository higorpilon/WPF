using Microsoft.Win32;
using WPF.CodeChallenge.Domain.Models;
using WPF.CodeChallenge.Services.Contracts;

namespace WPF.CodeChallenge.Services;

/// <summary>
/// File Service
/// </summary>
/// <seealso cref="IFileService" />
/// <remarks>
/// Initializes a new instance of the <see cref="FileService"/> class.
/// </remarks>
/// <param name="shapeService">The shape service.</param>
internal class FileService(IShapeService shapeService) : IFileService
{
    private const string Filter = "JSON Files (*.json)|*.json";
    private readonly IShapeService _shapeService = shapeService;

    /// <inheritdoc />
    public IList<Shape> GetShapesFromFileDialog()
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = Filter
        };

        if (openFileDialog.ShowDialog() is true)
        {
            return _shapeService.GetShapes(openFileDialog.FileName);
        }

        return [];
    }
}
