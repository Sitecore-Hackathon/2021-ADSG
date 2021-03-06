using ADSG.Foundation.Framework.Extensions;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using System;

namespace ADSG.Feature.StructuredData.Events
{
    using Helpers;

    public class RemoveIndexedLinksHandler
    {
        private LinkProvider _linkProvider;
        public RemoveIndexedLinksHandler(ProviderHelper<LinkProvider, LinkProviderCollection> providerHelper)
        {
            _linkProvider = providerHelper.Provider;
        }

        public void OnItemDeleting(object sender, EventArgs args)
        {
            Assert.ArgumentNotNull(sender, "sender");
            Assert.ArgumentNotNull(args, "args");

            Item item = Event.ExtractParameter(args, 0) as Item;

            if (item == null)
                return;

            if (item.Database.Name == "master")
                return;

            var urlOptions = new ItemUrlBuilderOptions() { AlwaysIncludeServerUrl = true };
            var deletedLink = item.GetIndexableLink(_linkProvider, urlOptions);
            if(!string.IsNullOrEmpty(deletedLink))
                IndexingAPIHelper.SendIndexingRequest(deletedLink, "URL_DELETED");
        }
    }
}