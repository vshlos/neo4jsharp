using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Neo4jSharp
{
    public abstract class Neo4JResponse
    {
        public static T Deserialize<T>(Stream stream)
        {
            var serializer = new JsonSerializer();

            using (var readerStream = new StreamReader(stream))
            using (var reader = new JsonTextReader(readerStream))
                return serializer.Deserialize<T>(reader);
        }
    }

}
