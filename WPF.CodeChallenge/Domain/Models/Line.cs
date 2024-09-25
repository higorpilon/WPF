using System.Windows;

namespace WPF.CodeChallenge.Domain.Models;

/// <summary>
/// Line Class
/// </summary>
/// <seealso cref="Shape" />
public class Line : Shape
{
    /// <summary>
    /// Gets a.
    /// </summary>
    /// <value>
    /// a.
    /// </value>
    public required Point A { get; init; }

    /// <summary>
    /// Gets the b.
    /// </summary>
    /// <value>
    /// The b.
    /// </value>
    public required Point B { get; init; }
}
