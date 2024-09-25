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

namespace WPF.CodeChallenge.Services
{
    /// <summary>
    /// Circle Data Service
    /// </summary>
    /// <seealso cref="IShapeDataService" />
    internal class CircleDataService : IShapeDataService
    {
        /// <inheritdoc />
        public string Type => ShapeConstants.Circle;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleDataService"/> class.
        /// </summary>
        public CircleDataService()
        {
        }

        /// <inheritdoc />
        public Shape AddShape(ShapeDto dto, Color color)
        {
            return new Circle
            {
                Center = dto.Center!.ConvertToPoint(),
                Radius = dto.Radius!.Value,
                Filled = dto.Filled!.Value,
                Type = dto.Type,
                Color = color
            };
        }

        /// <inheritdoc />
        public void DrawCanvasShape(Shape shape, Canvas canvas)
        {
            // add explicit cast
            var circle = shape as Circle;

            var result = circle!.NeedsScaleDown(canvas);

            if (result.Item1)
            {
                circle = ScaleDown(circle!, result.Item2!);
            }

            // get the canvas center
            double centerX = canvas.ActualWidth / 2;
            double centerY = canvas.ActualHeight / 2;

            var ellipse = new Ellipse
            {
                Width = circle!.Radius * 2,
                Height = circle.Radius * 2,
                Stroke = new SolidColorBrush(circle.Color),
                StrokeThickness = 1,
                Fill = circle.Filled ? new SolidColorBrush(circle.Color) : null
            };

            // canvas is centered regarding the default postion of the canvas (top left)
            Canvas.SetLeft(ellipse, centerX + circle.Center.X - circle.Radius);
            Canvas.SetTop(ellipse, centerY - circle.Center.Y - circle.Radius);
            canvas.Children.Add(ellipse);
        }

        private static Circle ScaleDown(Circle circle, double scale)
        {
            return new Circle
            {
                Center = new Point(circle.Center.X * scale, circle.Center.Y * scale),
                Type = circle.Type,
                Radius = circle.Radius * scale,
                Color = circle.Color,
                Filled = circle.Filled
            };
        }
    }
}
