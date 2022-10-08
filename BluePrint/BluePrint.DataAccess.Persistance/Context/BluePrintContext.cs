using BluePrint.Model.Unit.Foundations.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePrint.DataAccess.Persistance.Context
{
    public class BluePrintContext : DbContext
    {
        public DbSet<DemoEntity> DemoEntities { get; set; }

        public BluePrintContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
    }
}
