using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace Neo4jSharp
{
    public class Neo4JConnection
    {
        public Neo4JConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Neo4JConnection()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Neo4J"].ConnectionString;
        }

        public T Query<T>(Neo4JRequest query) where T : Neo4JResponse
        {
            var request = query.CreateRequest(connectionString);
            var response = request.GetResponse();
            return Neo4JResponse.Deserialize<T>(response.GetResponseStream());
        }

        private string connectionString;
    }



   

    

  
   

   
}
