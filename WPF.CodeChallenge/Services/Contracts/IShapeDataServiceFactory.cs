namespace WPF.CodeChallenge.Services.Contracts
{
    /// <summary>
    /// Interface for Shape Data Service Factory
    /// </summary>
    internal interface IShapeDataServiceFactory
    {
        /// <summary>
        /// Gets the type of the shape data service by shape.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The specific shape Data Service</returns>
        IShapeDataService? GetShapeDataServiceByShapeType(string type);
    }
}
