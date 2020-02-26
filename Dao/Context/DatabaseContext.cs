using lol.stats.api.Config;
using lol.stats.api.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace lol.stats.api.Dao
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _database = null;

        public DatabaseContext(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.MongoConfiguration.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.MongoConfiguration.Database);
        }
 
        public IMongoCollection<MatchDetail> Match => _database.GetCollection<MatchDetail>("Matches");
        public IMongoCollection<Control> Control => _database.GetCollection<Control>("Control");
    }
}
