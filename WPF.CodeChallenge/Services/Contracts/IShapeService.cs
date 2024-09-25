using System.Windows.Controls;
using WPF.CodeChallenge.Domain.Models;

namespace WPF.CodeChallenge.Services.Contracts
{
    /// <summary>
    /// Interface for Shape Service
    /// </summary>
    public interface IShapeService
    {
        /// <summary>
        /// Gets the shapes.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The shapes list</returns>
        IList<Shape> GetShapes(string filePath);

        /// <summary>
        /// Draws the shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="canvas">The canvas.</param>
        void DrawCanvasShape(Shape shape, Canvas canvas);
    }
}
