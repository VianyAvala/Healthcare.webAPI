using Healthcare.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(int id);


        Task Create(T obj);

        Task<T> Update(int id, T obj);

        Task<T> Delete(int id);
    }
}
