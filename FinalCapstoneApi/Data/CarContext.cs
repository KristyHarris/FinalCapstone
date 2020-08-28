using FinalCapstoneApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalCapstoneApi.Data
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }
    }
}
