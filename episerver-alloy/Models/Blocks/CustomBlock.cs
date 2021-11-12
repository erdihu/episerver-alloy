using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using episerver_alloy.Business.CustomProperties;
using System.ComponentModel.DataAnnotations;

namespace episerver_alloy.Models.Blocks
{
    [ContentType(DisplayName = "CustomBlock", GUID = "a12bf2a1-88c5-4524-80f1-1ef40033e5c2", Description = "")]
    public class CustomBlock : SiteBlockData
    {
        [Display(GroupName = "Custom", Order = 15, Name = "Custom")]
        [UIHint("MyCustomObject")]
        [BackingType(typeof(CustomProperty))]
        public virtual MyCustomObject ChartSettings { get; set; }


        public virtual string SomeText { get; set; }


    }
}