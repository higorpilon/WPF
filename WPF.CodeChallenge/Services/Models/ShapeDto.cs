using System.Text.Json.Serialization;

namespace WPF.CodeChallenge.Services.Models
{
    /// <summary>
    /// Shape DTO
    /// </summary>
    internal class ShapeDto
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; init; } = null!;

        /// <summary>
        /// Gets a.
        /// </summary>
        /// <value>
        /// a.
        /// </value>
        [JsonPropertyName("a")]
        public string? A { get; init; }

        /// <summary>
        /// Gets the b.
        /// </summary>
        /// <value>
        /// The b.
        /// </value>
        [JsonPropertyName("b")]
        public string? B { get; init; }

        /// <summary>
        /// Gets the c.
        /// </summary>
        /// <value>
        /// The c.
        /// </value>
        [JsonPropertyName("c")]
        public string? C { get; init; }

        /// <summary>
        /// Gets the center.
        /// </summary>
        /// <value>
        /// The center.
        /// </value>
        [JsonPropertyName("center")]
        public string? Center { get; init; }

        /// <summary>
        /// Gets the radius.
        /// </summary>
        /// <value>
        /// The radius.
        /// </value>
        [JsonPropertyName("radius")]
        public double? Radius { get; init; }

        /// <summary>
        /// Gets the filled.
        /// </summary>
        /// <value>
        /// The filled.
        /// </value>
        [JsonPropertyName("filled")]
        public bool? Filled { get; init; }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        [JsonPropertyName("color")]
        public string Color { get; init; } = null!;
    }
}
