using lol.stats.api.Config;
using lol.stats.api.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public class ControlDao : IControlDao
    {
        private readonly DatabaseContext _context = null;

        public ControlDao(IOptions<AppSettings> settings)
        {
            _context = new DatabaseContext(settings);
        }

        public async Task<Control> Create(Control document)
        {
            await _context.Control.InsertOneAsync(document);
            return document;
        }

        public async Task<Control> Get(string id)
        {
            return (await _context.Control.FindAsync(t => t.Id == id)).FirstOrDefault();
        }

        public async Task<List<Control>> Get()
        {
            IAsyncCursor<Control> matches = await _context.Control.FindAsync(_ => true);
            return await matches.ToListAsync();
        }

        public async Task<Control> GetByAccountIdAndQueue(string accountId, int queue)
        {
            return (await _context.Control.FindAsync(t => t.AccountId == accountId && t.Queue == queue)).FirstOrDefault();
        }

        public async Task<Control> GetById(string Id)
        {
            return (await _context.Control.FindAsync(t => t.Id == Id)).FirstOrDefault();
        }

        public Task InsertMany(List<Control> documents)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(Control document)
        {
            await _context.Control.DeleteOneAsync(p => p.Id == document.Id);
        }

        public async Task Remove(string id)
        {
            await _context.Control.DeleteOneAsync(p => p.Id == id);
        }

        public async Task Update(string id, Control document)
        {
            await _context.Control.ReplaceOneAsync(p => p.Id == id, document);
        }
    }
}
