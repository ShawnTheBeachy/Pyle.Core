namespace Pyle.Core.Interfaces
{
    /// <summary>
    /// The interface from which key providers should inherit.
    /// </summary>
    public interface IKeyProvider
    {
        /// <summary>
        /// Gets the client key to be used in API requests.
        /// </summary>
        /// <returns>The key to be used in API requests.</returns>
        string GetKey();
    }
}
