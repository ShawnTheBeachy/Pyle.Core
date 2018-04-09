namespace Pyle.Core.Models
{
    /// <summary>
    /// A response from the API.
    /// </summary>
    /// <typeparam name="T">The type to which the response shall be deserialized if the request was successful.</typeparam>
    public class ClientResponse<T>
    {
        /// <summary>
        /// The error which the request returned. Null if the request was successful.
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        /// When requesting a list of items, indicates whether there are more which were not returned.
        /// </summary>
        public bool HasMore { get; set; }

        /// <summary>
        /// The deserialized response. Null if the request was not successful.
        /// </summary>
        public T Response { get; set; }
    }
}
