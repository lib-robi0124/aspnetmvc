using FinanceApp.Models;

namespace FinanceApp.Data.Service
{
    public interface IExpencesService
    {
        Task<IEnumerable<Expence>> GetAll();
        //Task<Expence> GetByIdAsync(int id);
        Task Add(Expence expence);
        //Task UpdateAsync(Expence expence);
        //Task DeleteAsync(int id);
        IQueryable GetChartData();
    }
}
