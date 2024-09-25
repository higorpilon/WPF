using Newtonsoft.Json;
using System.Windows.Media;

namespace WPF.CodeChallenge.Domain.Models;

/// <summary>
/// Shape Abstract Class
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [JsonProperty("type")]
    public string Type { get; init; } = null!;

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    /// <value>
    /// The color.
    /// </value>
    public Color Color { get; set; }
}
