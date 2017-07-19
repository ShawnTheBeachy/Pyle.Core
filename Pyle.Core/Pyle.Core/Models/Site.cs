using Newtonsoft.Json;
using Pyle.Core.JsonConverters;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pyle.Core
{
    /// <summary>
    /// This type represents a site in the Stack Exchange network.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Site : BaseNotify
    {
        #region Aliases

        private IEnumerable<string> _aliases;
        /// <summary>
        /// A array of string aliases for the site. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("aliases")]
        public IEnumerable<string> Aliases { get { return _aliases; } set { Set(ref _aliases, value); } }

        #endregion Aliases

        #region ApiSiteParameter

        private string _apiSiteParameter;
        /// <summary>
        /// The string name to use in API calls referencing this site. Included in the default filter.
        /// </summary>
        [JsonProperty("api_site_parameter")]
        public string ApiSiteParameter { get { return _apiSiteParameter; } set { Set(ref _apiSiteParameter, value); } }

        #endregion ApiSiteParameter

        #region Audience

        private string _audience;
        /// <summary>
        /// A description of the audience this site targets. Included in the default filter.
        /// </summary>
        [JsonProperty("audience")]
        public string Audience { get { return _audience; } set { Set(ref _audience, value); } }

        #endregion Audience

        #region ClosedBetaDate

        private DateTime _closedBetaDate;
        /// <summary>
        /// The date on which this site entered closed beta. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("closed_beta_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime ClosedBetaDate { get { return _closedBetaDate; } set { Set(ref _closedBetaDate, value); } }

        #endregion ClosedBetaDate

        #region FaviconUrl

        private string _faviconUrl;
        /// <summary>
        /// The url to the favicon for this site. Included in the default filter.
        /// </summary>
        [JsonProperty("favicon_url")]
        public string FaviconUrl { get { return _faviconUrl; } set { Set(ref _faviconUrl, value); } }

        #endregion FaviconUrl

        #region HighResolutionIconUrl

        private string _highResolutionIconUrl;
        /// <summary>
        /// The url to the high resolution icon for this site. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("high_resolution_icon_url")]
        public string HighResolutionIconUrl { get { return _highResolutionIconUrl; } set { Set(ref _highResolutionIconUrl, value); } }

        #endregion HighResolutionIconUrl

        #region IconUrl

        private string _iconUrl;
        /// <summary>
        /// The url to the icon for this site. Included in the default filter.
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get { return _iconUrl; } set { Set(ref _iconUrl, value); } }

        #endregion IconUrl

        #region LaunchDate

        private DateTime _launchDate;
        /// <summary>
        /// The date on which this site launched. Included in the default filter.
        /// </summary>
        [JsonProperty("launch_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime LaunchDate { get { return _launchDate; } set { Set(ref _launchDate, value); } }

        #endregion LaunchDate

        #region LogoUrl

        private string _logoUrl;
        /// <summary>
        /// The url to the logo for this site. Included in the default filter.
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get { return _logoUrl; } set { Set(ref _logoUrl, value); } }

        #endregion LogoUrl

        #region MarkdownExtensions

        private IEnumerable<MarkdownExtensionTypes> _markdownExtensions;
        /// <summary>
        /// An array of Markdown extensions used on this site. May be absent. One of 'MathJax', 'Prettify', 'Balsamiq' or 'jTab.' Included in the default filter.
        /// </summary>
        [JsonProperty("markdown_extensions")]
        public IEnumerable<MarkdownExtensionTypes> MarkdownExtensions { get { return _markdownExtensions; } set { Set(ref _markdownExtensions, value); } }

        #endregion MarkdownExtensions

        #region Name

        private string _name;
        /// <summary>
        /// The name of this site. Included in the default filter.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get { return WebUtility.HtmlDecode(_name); } set { Set(ref _name, value); } }

        #endregion Name

        #region OpenBetaDate

        private DateTime _openBetaDate;
        /// <summary>
        /// The date on which this site entered open beta. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("open_beta_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime OpenBetaDate { get { return _openBetaDate; } set { Set(ref _openBetaDate, value); } }

        #endregion OpenBetaDate

        #region RelatedSites

        //private IEnumerable<RelatedSite> _relatedSites;
        ///// <summary>
        ///// An array of related sites. May be absent. Included in the default filter.
        ///// </summary>
        //[JsonProperty("related_sites")]
        //public IEnumerable<RelatedSite> RelatedSites { get { return _relatedSites; } set { Set(ref _relatedSites, value); } }

        #endregion RelatedSites

        #region SiteState

        private SiteStates _siteState;
        /// <summary>
        /// State of this site. One of 'normal', 'closed_beta', 'open_beta' or 'linked_meta.' Included in the default filter.
        /// </summary>
        [JsonProperty("site_state")]
        public SiteStates SiteState { get { return _siteState; } set { Set(ref _siteState, value); } }

        #endregion SiteState

        #region SiteType

        private SiteTypes _siteType;
        /// <summary>
        /// State of this site. One of 'main_site' or 'meta_site.' Included in the default filter.
        /// </summary>
        [JsonProperty("site_type")]
        public SiteTypes SiteType { get { return _siteType; } set { Set(ref _siteType, value); } }

        #endregion SiteType

        #region SiteUrl

        private string _siteUrl;
        /// <summary>
        /// URL to this site. Included in the default filter.
        /// </summary>
        [JsonProperty("site_url")]
        public string SiteUrl { get { return _siteUrl; } set { Set(ref _siteUrl, value); } }

        #endregion SiteUrl

        #region Styling

        //private Styling _styling;
        ///// <summary>
        ///// Styling used on this site. Included in the default filter.
        ///// </summary>
        //[JsonProperty("styling")]
        //public Styling Styling { get { return _styling; } set { Set(ref _styling, value); } }

        #endregion Styling

        #region TwitterAccount

        private string _twitterAccount;
        /// <summary>
        /// Twitter handle for this site. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("twitter_account")]
        public string TwitterAccount { get { return _twitterAccount; } set { Set(ref _twitterAccount, value); } }

        #endregion TwitterAccount

        /// <summary>
        /// A collection of Markdown extension types.
        /// </summary>
        public enum MarkdownExtensionTypes
        {
            EscapedMathJaxDelimiters,
            MathJax,
            Prettify,
            Balsamiq,
            jTab
        }

        /// <summary>
        /// Options for site state.
        /// </summary>
        public enum SiteStates
        {
            normal,
            closed_beta,
            open_beta,
            linked_meta
        }

        /// <summary>
        /// Options for site type.
        /// </summary>
        public enum SiteTypes
        {
            main_site,
            meta_site
        }
    }
}
