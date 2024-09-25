using System.Windows;

namespace WPF.CodeChallenge.Domain.Models
{
    /// <summary>
    /// Tringle Class
    /// </summary>
    /// <seealso cref="Shape" />
    public class Triangle : Shape
    {
        /// <summary>
        /// Gets or sets a.
        /// </summary>
        /// <value>
        /// a.
        /// </value>
        public Point A { get; init; }

        /// <summary>
        /// Gets or sets the b.
        /// </summary>
        /// <value>
        /// The b.
        /// </value>
        public Point B { get; init; }

        /// <summary>
        /// Gets or sets the C.
        /// </summary>
        /// <value>
        /// The C.
        /// </value>
        public Point C { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Triangle"/> is filled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if filled; otherwise, <c>false</c>.
        /// </value>
        public bool Filled { get; init; }
    }
}
