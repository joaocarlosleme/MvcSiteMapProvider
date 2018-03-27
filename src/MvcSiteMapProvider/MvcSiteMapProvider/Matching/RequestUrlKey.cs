using MvcSiteMapProvider.Web;
using System;

namespace MvcSiteMapProvider.Matching
{
    /// <summary>
    /// Uses a root relative, application relative, or absolute URL and a host name to create a key 
    /// that can be used for matching relative or absolute URLs.
    /// </summary>
    public class RequestUrlKey
        : UrlKeyBase
    {
        public RequestUrlKey(
            string relativeOrAbsoluteUrl,
            string hostName,
            IUrlPath urlPath
            ) 
            : this(relativeOrAbsoluteUrl, hostName, urlPath, null)
        {
           
        }

        public RequestUrlKey(
            string relativeOrAbsoluteUrl,
            string hostName,
            IUrlPath urlPath,
            string urlAnchorHash
            )
            : base(urlPath)
        {
            if (string.IsNullOrEmpty(relativeOrAbsoluteUrl))
                throw new ArgumentNullException("relativeOrAbsoluteUrl");

            // Host name in absolute URL overrides this one.
            this.hostName = hostName;
            this.SetUrlValues(relativeOrAbsoluteUrl);
            this.UrlAnchorHash = UrlAnchorHash;
            
        }

    }
}
