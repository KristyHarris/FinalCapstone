using FinalCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCapstone.Services
{
    public interface ICarsService
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> Get(int id);
        Task<IEnumerable<Car>> Search(Car car);
        Task Create(Car car);
        Task Edit(int id, Car car);
        Task Delete(int id);
    
    }
}
