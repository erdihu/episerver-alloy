using EPiServer.Core;
using EPiServer.PlugIn;
using episerver_alloy.Models;
using Newtonsoft.Json;
using System;

namespace episerver_alloy.Business.CustomProperties
{
    [PropertyDefinitionTypePlugIn(DisplayName = "UVB Inställningar")]
    public class CustomProperty : PropertyLongString
    {

        public override Type PropertyValueType
        {
            get
            {
                return typeof(MyCustomObject);
            }
        }

        public override object Value
        {
            get
            {
                var value = base.Value as string;
                if (value == null) return null;


                return JsonConvert.DeserializeObject<MyCustomObject>(value);
            }

            set
            {
                if (value is MyCustomObject)
                {
                    base.Value = JsonConvert.SerializeObject(value);
                }
                else
                {
                    base.Value = value;
                }

            }
        }

        public override object SaveData(PropertyDataCollection properties)
        {
            return LongString;
        }
    }
}
