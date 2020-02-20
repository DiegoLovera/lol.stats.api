using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Config
{
    public class MongoConfiguration
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
