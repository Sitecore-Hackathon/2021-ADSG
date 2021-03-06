using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using Sitecore.Sites;
using System;
using System.Linq;

namespace ADSG.Foundation.Framework.Extensions
{
    public static partial class ItemExtensions
    {
        public static string GetIndexableLink(this Item item, LinkProvider linkProvider, ItemUrlBuilderOptions urlBuilderOptions)
        {
            if (item.IsShortLivedContent())
            {
                using (new SiteContextSwitcher(item.GetSiteContext()))
                {
                    return linkProvider.GetItemUrl(item, urlBuilderOptions);
                }
            }
            return string.Empty;
        }

        public static SiteContext GetSiteContext(this Item item)
        {
            string itemPath = item.Paths.FullPath;
            var site = SiteContextFactory.Sites
                .Where(s => !string.IsNullOrEmpty(s.RootPath) && itemPath.StartsWith(s.RootPath, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(s => s.RootPath.Length)
                .FirstOrDefault();
            if (site != null)
            {
                SiteContext siteContext = Factory.GetSite(site.Name);
                return siteContext;
            }
            return null;
        }

        public static bool IsShortLivedContent(this Item item)
        {
            if (item != null)
            {
                DeviceRecords devices = item.Database.Resources.Devices;
                DeviceItem defaultDevice = devices.GetAll().Where(d => d.Name.ToLower() == "default").First();

                return item.Visualization.GetRenderings(defaultDevice, false).Any(r =>
                    r.RenderingID.ToString().Equals(Constants.StructuredDataRenderingsIDs.VideoBroadcastEventRenderingID) ||
                    r.RenderingID.ToString().Equals(Constants.StructuredDataRenderingsIDs.JobPostingRenderingID)
                );
            }
            return false;
        }
    }
}