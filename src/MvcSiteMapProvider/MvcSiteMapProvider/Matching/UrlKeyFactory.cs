using MvcSiteMapProvider.Web;
using System;

namespace MvcSiteMapProvider.Matching
{
    /// <summary>
    /// An abstract factory that creates new instances of 
    /// <see cref="T:MvcSiteMapProvider.Matching.IUrlKey"/> at runtime.
    /// </summary>
    public class UrlKeyFactory
        : IUrlKeyFactory
    {
        public UrlKeyFactory(
            IUrlPath urlPath
            )
        {
            if (urlPath == null)
                throw new ArgumentNullException("urlPath");

            this.urlPath = urlPath;
        }
        private readonly IUrlPath urlPath;

        public IUrlKey Create(ISiteMapNode node)
        {
            var hash = "";
            if (node.UnresolvedUrl.Contains("#"))
                hash = "#" + node.UnresolvedUrl.Split('#')[1];

            
            return new SiteMapNodeUrlKey(node, this.urlPath, hash);
        }

        public IUrlKey Create(string relativeOrAbsoluteUrl, string hostName)
        {
            return new RequestUrlKey(relativeOrAbsoluteUrl, hostName, this.urlPath, null);
        }

        public IUrlKey Create(string relativeOrAbsoluteUrl, string hostName, string urlAnchorHash) 
        {
            return new RequestUrlKey(relativeOrAbsoluteUrl, hostName, this.urlPath, urlAnchorHash);
        }
    }
}
