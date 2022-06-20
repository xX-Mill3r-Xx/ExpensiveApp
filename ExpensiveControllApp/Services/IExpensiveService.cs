using ExpensiveControllApp.Models.Expensives;

namespace ExpensiveControllApp.Services
{
    public interface IExpensiveService
    {
        Task Create(DTOs.CreateExpensiveDTO createExpensiveDTO);
        Task<List<Expensive>> FindBy(DateTime startDate, DateTime endDate);
    }
}
