namespace Pyle.Core.Interfaces
{
    /// <summary>
    /// Interface from which quota handlers should inherit.
    /// </summary>
    public interface IQuotaHandler
    {
        /// <summary>
        /// Gets the threshold at which to call the OnQuotaLow method.
        /// </summary>
        /// <returns></returns>
        int GetQuotaLowThreshold();

        /// <summary>
        /// Called when the low quota threshold is reached.
        /// </summary>
        /// <param name="quotaRemaining">The remaining request quota.</param>
        void OnQuotaLow(int quotaRemaining);
    }
}
