using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using episerver_alloy.Models.Blocks;
using episerver_alloy.Models.Pages;
using episerver_alloy.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace episerver_alloy.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            if (SiteDefinition.Current.StartPage.CompareToIgnoreWorkID(currentPage.ContentLink)) // Check if it is the StartPage or just a page of the StartPage type.
            {
                //Connect the view models logotype property to the start page's to make it editable
                var editHints = ViewData.GetEditHints<PageViewModel<StartPage>, StartPage>();
                editHints.AddConnection(m => m.Layout.Logotype, p => p.SiteLogotype);
                editHints.AddConnection(m => m.Layout.ProductPages, p => p.ProductPageLinks);
                editHints.AddConnection(m => m.Layout.CompanyInformationPages, p => p.CompanyInformationPageLinks);
                editHints.AddConnection(m => m.Layout.NewsPages, p => p.NewsPageLinks);
                editHints.AddConnection(m => m.Layout.CustomerZonePages, p => p.CustomerZonePageLinks);

                if (currentPage.CustomBlock != null)
                {
                    var cr = ServiceLocator.Current.GetInstance<IContentRepository>();
                    var blockData = cr.Get<CustomBlock>(currentPage.CustomBlock);
                    if (blockData.ChartSettings != null)
                    {
                        var clone = blockData.CreateWritableClone() as CustomBlock;
                        var text = Guid.NewGuid().ToString();
                        clone.SomeText = text;
                        clone.ChartSettings.CommonSettings.Title = text;

                        cr.Save(clone as IContent, SaveAction.Publish, AccessLevel.NoAccess);

                    }
                }
            }

            return View(model);
        }

    }
}
