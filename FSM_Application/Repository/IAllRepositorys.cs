using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Repository
{
    public interface IAllRepositorys<T> where T : class
    {
        Task<bool> AddItems(T items);
        Task<bool> UpdateItems(T items);
        Task<bool> DeleteItems(T items);
        Task<T> GetItemsById(dynamic id);
        Task<IEnumerable<T>> GetAllItems();
    }
}
