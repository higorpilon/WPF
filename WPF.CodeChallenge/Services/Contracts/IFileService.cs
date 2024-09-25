using WPF.CodeChallenge.Domain.Models;

namespace WPF.CodeChallenge.Services.Contracts;

/// <summary>
/// Interface for File Service
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Gets the shapes from file dialog.
    /// </summary>
    /// <returns>List of Shapes</returns>
    IList<Shape> GetShapesFromFileDialog();
}
