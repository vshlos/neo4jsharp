using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Neo4jSharp.Cypher
{
    public class CypherQuery : Neo4JRequest
    {


        public CypherQuery()
            : base("/db/data/cypher", "POST")
        {

        }

        public CypherQuery(string query)
            : this()
        {

            this.Query = query;
        }


        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
