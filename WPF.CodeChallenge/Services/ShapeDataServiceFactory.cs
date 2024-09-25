using WPF.CodeChallenge.Services.Contracts;

namespace WPF.CodeChallenge.Services
{
    /// <summary>
    /// Shape Data Service Factory
    /// </summary>
    /// <seealso cref="IShapeDataServiceFactory" />
    internal class ShapeDataServiceFactory : IShapeDataServiceFactory
    {
        private readonly IEnumerable<IShapeDataService> _shapeDataServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeDataServiceFactory"/> class.
        /// </summary>
        /// <param name="shapeDataServices">The shape data services.</param>
        public ShapeDataServiceFactory(IEnumerable<IShapeDataService> shapeDataServices)
        {
            _shapeDataServices = shapeDataServices;
        }

        /// <inheritdoc />
        public IShapeDataService? GetShapeDataServiceByShapeType(string type)
        {
            return _shapeDataServices.FirstOrDefault(ss => AppliesToShapeType(ss, type));;
        }

        private static bool AppliesToShapeType(IShapeDataService shapeDataService, string type) => string.Equals(type, shapeDataService.Type, StringComparison.OrdinalIgnoreCase);
    }
}
