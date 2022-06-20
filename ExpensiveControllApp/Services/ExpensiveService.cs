﻿using ExpensiveControllApp.Infra.Data;
using ExpensiveControllApp.Models.Expensives;
using Microsoft.EntityFrameworkCore;

namespace ExpensiveControllApp.Services
{
    public class ExpensiveService : IExpensiveService
    {
        private readonly DataContext _dbContext;

        public ExpensiveService(DataContext context)
        {
            _dbContext = context;
        }

        public async Task Create(DTOs.CreateExpensiveDTO createExpensiveDTO)
        {
            await _dbContext.Expensives.AddAsync(new Expensive()
            {
                Description = createExpensiveDTO.Description,
                Date = createExpensiveDTO.Date,
                Value = createExpensiveDTO.Value,
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Expensive>> FindBy(DateTime startDate, DateTime endDate)
        {
            if(startDate > endDate)
            {
                throw new Exception("Data final deve ser maior que data inicial");
            }

            var items = await _dbContext.Expensives.Where(e => e.Date >= startDate && e.Date <= endDate).AsNoTracking().ToListAsync();
            return items;
        }
    }
}
