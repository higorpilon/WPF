using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF.CodeChallenge.Domain.Models;
using WPF.CodeChallenge.Helpers;
using WPF.CodeChallenge.Helpers.Constants;
using WPF.CodeChallenge.Services.Contracts;
using WPF.CodeChallenge.Services.Models;
using Shape = WPF.CodeChallenge.Domain.Models.Shape;

namespace WPF.CodeChallenge.Services;

/// <summary>
/// Triangle Data Service
/// </summary>
/// <seealso cref="IShapeDataService" />
internal class TriangleDataService : IShapeDataService
{
    /// <inheritdoc />
    public string Type => ShapeConstants.Triangle;

    /// <summary>
    /// Initializes a new instance of the <see cref="TriangleDataService"/> class.
    /// </summary>
    public TriangleDataService()
    {
    }

    /// <inheritdoc />
    public Shape AddShape(ShapeDto dto, Color color)
    {
        return new Triangle
        {
            A = dto.A!.ConvertToPoint(),
            B = dto.B!.ConvertToPoint(),
            C = dto.C!.ConvertToPoint(),
            Filled = dto.Filled!.Value,
            Type = dto.Type,
            Color = color
        };
    }

    /// <inheritdoc />
    public void DrawCanvasShape(Shape shape, Canvas canvas)
    {
        var triangle = shape as Triangle;

        var result = triangle!.NeedsScaleDown(canvas);

        if (result.Item1)
        {
            triangle = ScaleDown(triangle!, result.Item2!);
        }

        double centerX = canvas.ActualWidth / 2;
        double centerY = canvas.ActualHeight / 2;

        // Correct centering
        var centeredA = new Point(centerX + triangle!.A.X, centerY - triangle.A.Y);
        var centeredB = new Point(centerX + triangle.B.X, centerY - triangle.B.Y);
        var centeredC = new Point(centerX + triangle.C.X, centerY - triangle.C.Y);

        var polygon = new Polygon
        {
            Points = [centeredA, centeredB, centeredC],
            Stroke = new SolidColorBrush(triangle.Color),
            StrokeThickness = 1,
            Fill = triangle.Filled ? new SolidColorBrush(triangle.Color) : null
        };

        canvas.Children.Add(polygon);
    }

    private static Triangle ScaleDown(Triangle triangle, double scale)
    {
        return new Triangle
        {
            Type = triangle.Type,
            A = new Point(triangle.A.X * scale, triangle.A.Y * scale),
            B = new Point(triangle.B.X * scale, triangle.B.Y * scale),
            C = new Point(triangle.C.X * scale, triangle.C.Y * scale),
            Color = triangle.Color,
            Filled = triangle.Filled
        }; ;
    }
}
