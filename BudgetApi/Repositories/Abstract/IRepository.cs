using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApi.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetEntity(int id);
        void CreateEntity(T Entity);
        void UpdateEntity(T Entity);
        void Commit();
    }
}
