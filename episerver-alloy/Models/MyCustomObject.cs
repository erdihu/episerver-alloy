using Newtonsoft.Json;
using System;

namespace episerver_alloy.Models
{
    [Serializable]
    public class MyCustomObject
    {

        [JsonProperty("commonSettings")]
        public CommonSettings CommonSettings { get; set; }

        [JsonProperty("specific")]
        public SpecificSettings[] Specific { get; set; }

    }

    [Serializable]
    public class CommonSettings
    {
        [JsonProperty("title")]
        public string Title { get; set; }

    }

    [Serializable]
    public class SpecificSettings
    {


        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
