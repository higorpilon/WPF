using System.Windows;

namespace WPF.CodeChallenge.Domain.Models
{
    /// <summary>
    /// Circle class
    /// </summary>
    /// <seealso cref="Shape" />
    public class Circle : Shape
    {
        /// <summary>
        /// Gets the center.
        /// </summary>
        /// <value>
        /// The center.
        /// </value>
        public Point Center { get; init; }

        /// <summary>
        /// Gets the radius.
        /// </summary>
        /// <value>
        /// The radius.
        /// </value>
        public double Radius { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Circle"/> is filled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if filled; otherwise, <c>false</c>.
        /// </value>
        public bool Filled { get; init; }
    }
}
