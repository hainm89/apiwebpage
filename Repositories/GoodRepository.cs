using Ass1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ass1.Repositories
{
    public class GoodRepository : IGoodRepository
    {
        private readonly GoodDbContext _context;

        public GoodRepository(GoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Good>> GetAllAsync()
        {
            return await _context.Goods.ToListAsync();
        }

        public async Task<Good?> GetByIdAsync(string id)
        {
            return await _context.Goods.FindAsync(id);
        }

        public async Task AddAsync(Good hangHoa)
        {
            _context.Goods.Add(hangHoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Good hangHoa)
        {
            _context.Goods.Update(hangHoa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa != null)
            {
                _context.Goods.Remove(hangHoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
