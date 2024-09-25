using Microsoft.Win32;
using WPF.CodeChallenge.Domain.Models;
using WPF.CodeChallenge.Services.Contracts;

namespace WPF.CodeChallenge.Services
{
    /// <summary>
    /// File Service
    /// </summary>
    /// <seealso cref="IFileService" />
    internal class FileService : IFileService
    {
        private const string Filter = "JSON Files (*.json)|*.json";
        private readonly IShapeService _shapeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/> class.
        /// </summary>
        /// <param name="shapeService">The shape service.</param>
        public FileService(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        /// <inheritdoc />
        public IList<Shape> GetShapesFromFileDialog()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Filter
            };

            if (openFileDialog.ShowDialog() == true)
            {
                return _shapeService.GetShapes(openFileDialog.FileName);
            }

            return new List<Shape>();
        }
    }
}
