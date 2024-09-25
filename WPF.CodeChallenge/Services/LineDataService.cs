using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF.CodeChallenge.Helpers;
using WPF.CodeChallenge.Helpers.Constants;
using WPF.CodeChallenge.Services.Contracts;
using WPF.CodeChallenge.Services.Models;
using Line = WPF.CodeChallenge.Domain.Models.Line;
using Shape = WPF.CodeChallenge.Domain.Models.Shape;

namespace WPF.CodeChallenge.Services
{
    /// <summary>
    /// Line Data Service
    /// </summary>
    /// <seealso cref="IShapeDataService" />
    internal class LineDataService : IShapeDataService
    {
        /// <inheritdoc />
        public string Type => ShapeConstants.Line;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineDataService"/> class.
        /// </summary>
        public LineDataService()
        {
        }

        /// <inheritdoc />
        public Shape AddShape(ShapeDto dto, Color color)
        {
            return new Line
            {
                A = dto.A!.ConvertToPoint(),
                B = dto.B!.ConvertToPoint(),
                Type = dto.Type,
                Color = color
            };
        }

        /// <inheritdoc />
        public void DrawCanvasShape(Shape shape, Canvas canvas)
        {
            // add explicit cast again
            var line = shape as Line;

            var result = line!.NeedsScaleDown(canvas);

            if (result.Item1)
            {
                line = ScaleShape(line!, result.Item2!);
            }

            // canvas center points
            var centerX = canvas.ActualWidth / 2;
            var centerY = canvas.ActualHeight / 2;

            var lineShape = new System.Windows.Shapes.Line
            {
                X1 = line!.A.X + centerX,
                Y1 = centerY - line.A.Y,
                X2 = line.B.X + centerX,
                Y2 = centerY - line.B.Y,
                Stroke = new SolidColorBrush(line.Color),
                StrokeThickness = 1
            };

            canvas.Children.Add(lineShape);
        }

        private static Line ScaleShape(Line line, double scale)
        {
            return new Line
            {
                A = new Point(line.A.X * scale, line.A.Y * scale),
                B = new Point(line.B.X * scale, line.B.Y * scale),
                Color = line.Color
            };
        }
    }
}
