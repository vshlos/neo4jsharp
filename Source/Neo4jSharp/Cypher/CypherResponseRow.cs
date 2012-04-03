using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Neo4jSharp.Cypher
{

    [JsonConverter(typeof(CypherRowConverter))]
    public class CypherResponseRow
    {
        public object[] ItemArray { get; set; }

        public T Get<T>(int index)
        {
            return (T)ItemArray[index];
        }

    
    }

}
