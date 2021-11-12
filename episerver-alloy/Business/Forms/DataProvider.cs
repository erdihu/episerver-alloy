using EPiServer.Forms.Core;
using EPiServer.Forms.Core.Internal.Autofill;
using EPiServer.Forms.Core.Internal.ExternalSystem;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace episerver_alloy.Business.Forms
{
    public class DataProvider : IExternalSystem, IAutofillProvider
    {
        public string Id => "DataProviderTest";

        public IEnumerable<IDatasource> Datasources
        {
            get
            {
                var source = new Datasource
                {
                    Id = "DataProviderTest",
                    Name = "Test data source",
                    OwnerSystem = this,
                    Columns = new Dictionary<string, string> {
                        { "text1", "autofilled name" },
                        { "text2", "autofilled mail" },
                        {"adressBlock",  "{\"address\":\"supergatan 10\",\"state\":\"gothenburg\",\"postalCode\":\"4567\",\"country\":\"swerje\"}"}
                    }
                };

                return new[] { source };
            }
        }

        public IEnumerable<string> GetSuggestedValues(IDatasource selectedDatasource, IEnumerable<RemoteFieldInfo> remoteFieldInfos, ElementBlockBase content,
            IFormContainerBlock formContainerBlock, HttpContextBase context)
        {
            if (selectedDatasource == null || remoteFieldInfos == null)
            {
                return Enumerable.Empty<string>();
            }

            if (this.Datasources.All(ds => ds.Id != selectedDatasource.Id))  // datasource belong to this system
            {
                return Enumerable.Empty<string>();
            }


            var activeRemoteFieldInfo = remoteFieldInfos.FirstOrDefault(mi => mi.DatasourceId == selectedDatasource.Id);

            if (activeRemoteFieldInfo == null) return Enumerable.Empty<string>();


            switch (activeRemoteFieldInfo.ColumnId)
            {
                case "text1":
                    return new List<string> {
                        "autofilled name",
                        "suggested name2",
                        "suggested name3"
                    };

                case "text2":
                    return new List<string> {
                        "email",
                        "aaa@aaa.com"
                    };
                case "addressBlock":
                    return new List<string>
                    {
                        "{\"address\":\"supergatan 10\",\"state\":\"gothenburg\",\"postalCode\":\"4567\",\"country\":\"swerje\"}"
                    };
                default:
                    return Enumerable.Empty<string>();
            }
        }
    }
}
