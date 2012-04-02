using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Neo4jSharp.Cypher
{
    public class CypherResponse : Neo4JResponse
    {
        [JsonProperty("columns")]
        public string[] Columns { get; set; }

        [JsonProperty("data")]
        public CypherResponseRow[] Rows { get; set; }
    }
}
