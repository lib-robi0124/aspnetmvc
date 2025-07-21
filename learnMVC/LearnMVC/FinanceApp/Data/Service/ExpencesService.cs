using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service
{
    public class ExpencesService : IExpencesService
    {
        private readonly FinanceAppContext _context;
        public ExpencesService(FinanceAppContext context)
        {
            _context = context;
        }
        public async Task Add(Expence expence)
        {
            _context.Expences.Add(expence);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expence>> GetAll()
        {
            var expences = await _context.Expences.ToListAsync();
            return expences;
        }

        public IQueryable GetChartData()
        {
            var data = _context.Expences
                .GroupBy(e => e.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount)
                });
            return data;
        }
    }
}
