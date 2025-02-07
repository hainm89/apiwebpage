using Ass1.Models;

namespace Ass1.Repositories
{
    public interface IGoodRepository
    {
        Task<IEnumerable<Good>> GetAllAsync();
        Task<Good?> GetByIdAsync(string id);
        Task AddAsync(Good hangHoa);
        Task UpdateAsync(Good hangHoa);
        Task DeleteAsync(string id);
    }
}
