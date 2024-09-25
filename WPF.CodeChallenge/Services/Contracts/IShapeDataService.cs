using System.Windows.Controls;
using System.Windows.Media;
using WPF.CodeChallenge.Domain.Models;
using WPF.CodeChallenge.Services.Models;

namespace WPF.CodeChallenge.Services.Contracts;

/// <summary>
/// Interface for Shape Data Service
/// </summary>
internal interface IShapeDataService
{
    /// <summary>
    /// Gets the type.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    string Type { get; }

    /// <summary>
    /// Adds the shape.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <param name="color">The color.</param>
    /// <returns>The Shape.</returns>
    Shape AddShape(ShapeDto dto, Color color);

    /// <summary>
    /// Draws the canvas shape.
    /// </summary>
    /// <param name="shape">The shape.</param>
    /// <param name="canvas">The canvas.</param>
    void DrawCanvasShape(Shape shape, Canvas canvas);
}