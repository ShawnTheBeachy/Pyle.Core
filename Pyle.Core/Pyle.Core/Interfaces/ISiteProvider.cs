using Pyle.Core.Models;

namespace Pyle.Core.Interfaces
{
    /// <summary>
    /// Interface from which site providers should inherit.
    /// </summary>
    public interface ISiteProvider
    {
        /// <summary>
        /// Gets the site on which to perform operations.
        /// </summary>
        /// <returns>The site on which to perform operations.</returns>
        Site GetSite();
    }
}
