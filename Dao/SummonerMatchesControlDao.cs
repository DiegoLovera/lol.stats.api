using lol.stats.api.Config;
using lol.stats.api.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public class SummonerMatchesControlDao : ISummonerMatchesControlDao
    {
        private readonly DatabaseContext _context = null;

        public SummonerMatchesControlDao(IOptions<AppSettings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<SummonerMatchesControl> Create(SummonerMatchesControl document)
        {
            await _context.SummonerMatchesControl.InsertOneAsync(document);
            return document;
        }

        public async Task<List<SummonerMatchesControl>> Get()
        {
            IAsyncCursor<SummonerMatchesControl> matches = await _context.SummonerMatchesControl.FindAsync(_ => true);
            return await matches.ToListAsync();
        }

        public Task<SummonerMatchesControl> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<SummonerMatchesControl>> GetByAccountId(string accountId)
        {
            IAsyncCursor<SummonerMatchesControl> matches = await _context.SummonerMatchesControl.FindAsync(t => t.AccountId == accountId);
            return await matches.ToListAsync();
        }

        public async Task<SummonerMatchesControl> GetByAccountIdAndQueue(string accountId, int queue)
        {
            return (await _context.SummonerMatchesControl.FindAsync(t => t.AccountId == accountId && t.Queue == queue)).FirstOrDefault();
        }

        public async Task<SummonerMatchesControl> GetById(string Id)
        {
            return (await _context.SummonerMatchesControl.FindAsync(t => t.Id == Id)).FirstOrDefault();
        }

        public Task InsertMany(List<SummonerMatchesControl> documents)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(SummonerMatchesControl document)
        {
            await _context.SummonerMatchesControl.DeleteOneAsync(p => p.Id == document.Id);
        }

        public async Task Remove(string id)
        {
            await _context.SummonerMatchesControl.DeleteOneAsync(p => p.Id == id);
        }

        public Task Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(string id, SummonerMatchesControl document)
        {
            await _context.SummonerMatchesControl.ReplaceOneAsync(p => p.Id == id, document);
        }

        public Task Update(long id, SummonerMatchesControl document)
        {
            throw new System.NotImplementedException();
        }
    }
}
