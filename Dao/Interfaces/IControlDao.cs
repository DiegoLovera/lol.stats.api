using lol.stats.api.Dtos;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public interface IControlDao : IBaseDao<Control, string>
    {
        Task<Control> GetByAccountIdAndQueue(string accountId, int queue);
    }
}
