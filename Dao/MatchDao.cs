using lol.stats.api.Config;
using lol.stats.api.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public class MatchDao : IBaseDao<MatchDetail>
    {
        private readonly DatabaseContext _context = null;

        public MatchDao(IOptions<AppSettings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<MatchDetail> Create(MatchDetail document)
        {
            await _context.Match.InsertOneAsync(document);
            return document;
        }

        public async Task<List<MatchDetail>> Get()
        {
            IAsyncCursor<MatchDetail> matches = await _context.Match.FindAsync(_ => true);
            return await matches.ToListAsync();
        }

        public async Task InsertMany(List<MatchDetail> documents)
        {
            await _context.Match.InsertManyAsync(documents);
        }

        public async Task<MatchDetail> Get(long id)
        {
            return (await _context.Match.FindAsync(pi => pi.GameId == id)).FirstOrDefault();
        }

        public async Task<List<MatchDetail>> Get(string accountId)
        {
            var filter = Builders<MatchDetail>.Filter.ElemMatch(
                                     f => f.ParticipantIdentities, item2 => item2.Player.CurrentAccountId == accountId);
            var matches = await _context.Match.FindAsync(filter);
            return await matches.ToListAsync();
        }

        public async Task Remove(MatchDetail document)
        {
            await _context.Match.DeleteOneAsync(p => p.GameId == document.GameId);
        }

        public async Task Remove(long id)
        {
            await _context.Match.DeleteOneAsync(item => item.GameId == id);
        }

        public async Task Update(long id, MatchDetail document)
        {
            await _context.Match.ReplaceOneAsync(p => p.GameId == id, document);
        }
    }
}
