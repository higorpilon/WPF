using System.Windows;
using System.Windows.Controls;
using WPF.CodeChallenge.Services.Contracts;
using Shape = WPF.CodeChallenge.Domain.Models.Shape;

namespace WPF.CodeChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Shape> _shapes;

        private readonly IShapeService _shapeService;
        private readonly IFileService _fileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="shapeService">The shape service.</param>
        /// <param name="fileService">The file service.</param>
        public MainWindow(IShapeService shapeService, IFileService fileService)
        {
            InitializeComponent();
            _shapeService = shapeService;
            _fileService = fileService;
            _shapes = new List<Shape>();
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _shapes = _fileService.GetShapesFromFileDialog();

            LoadShapes();
        }

        private void ShapeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShapeListBox.SelectedIndex >= 0)
            {
                ShapeCanvas.Children.Clear();
                var selectedShape = _shapes[ShapeListBox.SelectedIndex];

                _shapeService.DrawCanvasShape(selectedShape, ShapeCanvas);
            }
        }

        private void LoadShapes()
        {
            ShapeListBox.Items.Clear();

            foreach (var shape in _shapes)
                ShapeListBox.Items.Add(shape.GetType().Name);
        }
    }
}