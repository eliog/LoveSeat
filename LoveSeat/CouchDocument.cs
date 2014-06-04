using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoveSeat.Interfaces;
using Newtonsoft.Json;

namespace LoveSeat
{
    public class CouchDocument : IBaseObject
    {
        public CouchDocument()
        {
            Attachments = new Dictionary<string, CouchAttachment>();
        }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("_rev")]
        public string Rev { get; set; }

        [JsonProperty("attachments")]
        internal Dictionary<string, CouchAttachment> Attachments;

        [JsonIgnore]
        public bool HasAttachment { get { return Attachments.Count > 0; } }

        public IEnumerable<string> GetAttachmentNames()
        {
            foreach (string key in Attachments.Keys)
                yield return key;
            yield break;
        }

    }
}
