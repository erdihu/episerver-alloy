using EPiServer.Core;

namespace episerver_alloy.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
