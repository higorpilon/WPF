using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF.CodeChallenge.Services.Contracts;
using WPF.CodeChallenge.Services.Models;
using Shape = WPF.CodeChallenge.Domain.Models.Shape;

namespace WPF.CodeChallenge.Services
{
    /// <summary>
    /// Shape Service
    /// </summary>
    /// <seealso cref="IShapeService" />
    internal class ShapeService : IShapeService
    {
        private const string ErrorMessage = "An error occurred while reading the file. Please check the file format and try again.";

        private readonly IShapeDataServiceFactory _shapeDataServiceFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeService"/> class.
        /// </summary>
        /// <param name="shapeDataServiceFactory">The shape data service factory.</param>
        public ShapeService(IShapeDataServiceFactory shapeDataServiceFactory)
        {
            _shapeDataServiceFactory = shapeDataServiceFactory;
        }

        /// <inheritdoc />
        public IList<Shape> GetShapes(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                var shapeList = JsonConvert.DeserializeObject<List<ShapeDto>>(json) ?? new List<ShapeDto>();

                return shapeList.Any() ? ConvertToShapes(shapeList) : new List<Shape>();
            }
            catch (Exception)
            {
                MessageBox.Show(ErrorMessage, MessageBoxImage.Error.ToString(),
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return new List<Shape>();
            }
        }

        /// <inheritdoc />
        public void DrawCanvasShape(Shape shape, Canvas canvas)
        {
            var specificShape = _shapeDataServiceFactory.GetShapeDataServiceByShapeType(shape.Type);

            specificShape!.DrawCanvasShape(shape, canvas);
        }

        private IList<Shape> ConvertToShapes(List<ShapeDto> shapeDtos)
        {
            var shapes = new List<Shape>();

            foreach (var dto in shapeDtos)
            {
                var color = GetARGBColorFromString(dto);

                var specificShapeService = _shapeDataServiceFactory.GetShapeDataServiceByShapeType(dto.Type);

                shapes.Add(specificShapeService!.AddShape(dto, color));
            }

            return shapes;
        }

        private static Color GetARGBColorFromString(ShapeDto dto)
        {
            var colorBytes = ConvertToBytes(dto.Color);

            return Color.FromArgb(colorBytes[0], colorBytes[1], colorBytes[2], colorBytes[3]);
        }

        private static IList<byte> ConvertToBytes(string color) => color.Split(';').Select(byte.Parse).ToList() ?? new List<byte> { 0, 0, 0, 0 };
    }
}
