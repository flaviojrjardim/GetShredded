using GetShredded.Models;
using Microsoft.EntityFrameworkCore;

namespace GetShredded.Data
{
    public class GetShreddedContext : DbContext
    {
        public GetShreddedContext(DbContextOptions<GetShreddedContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Exercise> Exercises { get; set; }

    }
}