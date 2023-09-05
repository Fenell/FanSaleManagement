using FSM_Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Repository
{
    public class AllRepositorys<T> : IAllRepositorys<T> where T : class
    {
        private readonly FSMDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public AllRepositorys(FSMDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<bool> AddItems(T items)
        {
            try
            {
                _dbSet.AddAsync(items);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteItems(T items)
        {
            try
            {
                _dbSet.Remove(items);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllItems()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetItemsById(dynamic id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateItems(T items)
        {
            try
            {
                _dbSet.Update(items);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
