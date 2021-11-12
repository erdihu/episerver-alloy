using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Helpers.Internal;
using EPiServer.Forms.Implementation.Elements;
using System.Linq;
using System.Text;

namespace episerver_alloy.Business.Forms
{
    [ContentType(
        DisplayName = "Multifield form element",
        GroupName = "Form Elements",
        GUID = "544AD5A7-965F-45FF-BF49-5633B83F2ECF")]
    public class MultipleFieldFormBlock : TextboxElementBlock
    {
        public virtual string Address { get; set; }
        public virtual string Postcode { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }

        public override string RenderDataList()
        {
            var elName = Content.GetElementName();
            var options = GetAutofillValues().ToArray();
            if (!options.Any())
            {
                return string.Empty;
            }

            var dataListBuilder = new StringBuilder();
            dataListBuilder.AppendFormat("<datalist id=\"{0}\">", Content.GetElementName());

            foreach (var item in options)
            {
                dataListBuilder.AppendFormat("<option value=\"{0}\" />", item);
            }

            dataListBuilder.Append("</datalist>");

            return dataListBuilder.ToString();
        }
    }


}
