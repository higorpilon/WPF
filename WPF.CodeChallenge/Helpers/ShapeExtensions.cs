using System.Windows;
using System.Windows.Controls;
using WPF.CodeChallenge.Domain.Models;

namespace WPF.CodeChallenge.Helpers
{
    /// <summary>
    /// Shape Extensions
    /// </summary>
    public static class ShapeExtensions
    {
        /// <summary>
        /// Converts to point.
        /// </summary>
        /// <param name="pointString">The point string.</param>
        /// <returns>The point.</returns>
        public static Point ConvertToPoint(this string pointString)
        {
            var coords = pointString.Split(';');
            return new Point(double.Parse(coords[0]), double.Parse(coords[1]));
        }

        /// <summary>
        /// Needses the scale down.
        /// </summary>
        /// <param name="circle">The circle.</param>
        /// <param name="canvas">The canvas.</param>
        /// <returns>If it's needed to be scaled down and the scale</returns>
        public static (bool, double) NeedsScaleDown(this Circle circle, Canvas canvas)
        {
            // here we need to know the canvas canter points X and Y
            var canvasCenterX = canvas.ActualWidth / 2;
            var canvasCenterY = canvas.ActualHeight / 2;

            //default 1 because it means it fits in the Canvas
            var scale = 1.0;

            var circleSize = circle.Radius * 2;

            //now we check if the the radius of the circle it exceeds the height or width having reference the center of the Canvas
            if (circleSize > canvasCenterX || circleSize > canvasCenterY)
            {
                //get the scale to calculate the circle in proportion
                scale = Math.Min(canvasCenterX / circleSize, canvasCenterY / circleSize);
               
                return (true, scale);
            }

            return (false, scale);
        }

        /// <summary>
        /// Needses the scale down.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="canvas">The canvas.</param>
        /// <returns>If it's needed to be scaled down and the scale</returns>
        public static (bool, double) NeedsScaleDown(this Line line, Canvas canvas)
        {
            // here we need to know the canvas canter points X and Y
            var canvasCenterX = canvas.ActualWidth / 2;
            var canvasCenterY = canvas.ActualHeight / 2;

            //default 1 because it means it fits in the Canvas
            var scale = 1.0;

            //check for absolutes because the values could not match regarding negative values
            var maxLineX = Math.Max(Math.Abs(line.A.X), Math.Abs(line.B.X));
            var maxLineY = Math.Max(Math.Abs(line.A.Y), Math.Abs(line.B.Y));

            if (maxLineX > canvasCenterX || maxLineY > canvasCenterY)
            {
                // same case, minimum value to fit in the canvas regarding proportion
                scale = Math.Min(canvasCenterX / maxLineX, canvasCenterY / maxLineY);
               
                return (true, scale);
            };

            return (false, scale);
        }

        /// <summary>
        /// Needses the scale down.
        /// </summary>
        /// <param name="triangle">The triangle.</param>
        /// <param name="canvas">The canvas.</param>
        /// <returns>If it's needed to be scaled down and the scale</returns>
        public static (bool, double) NeedsScaleDown(this Triangle triangle, Canvas canvas)
        {
            // here we need to know the canvas canter points X and Y
            var canvasCenterX = canvas.ActualWidth / 2;
            var canvasCenterY = canvas.ActualHeight / 2;

            //default 1 because it means it fits in the Canvas
            var scale = 1.0;

            //check for absolutes because the values could not match regarding negative values
            var maxTriangleX = Math.Max(Math.Abs(triangle.A.X), Math.Max(Math.Abs(triangle.B.X), Math.Abs(triangle.C.X)));
            var maxTriangleY = Math.Max(Math.Abs(triangle.A.Y), Math.Max(Math.Abs(triangle.B.Y), Math.Abs(triangle.C.Y)));

            if (maxTriangleX > canvasCenterX || maxTriangleY > canvasCenterY)
            {
                 //get the scale to calculate the triangle in proportion
                scale = Math.Min(canvasCenterX / maxTriangleX, canvasCenterY / maxTriangleY);

                return (true, scale);
            }

            return (false, scale);
        }
    }
}
