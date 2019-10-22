﻿using Newtonsoft.Json;

namespace RoosterPlanner.Service.DataModels.B2C
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SignInName
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "value")]
        public string Value { get; set; }

        //Constructor
        public SignInName()
        {
        }
    }
}
