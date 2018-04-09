namespace Pyle.Core.Interfaces
{
    /// <summary>
    /// Interface from which access token providers should inherit.
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Gets the access token to be used in API requests.
        /// </summary>
        /// <returns></returns>
        string GetToken();
    }
}
