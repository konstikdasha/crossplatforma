using Microsoft.EntityFrameworkCore;
using MvcValue.Models;

namespace MvcValue.Data
{
    public class MvcValueContext : DbContext
    {
        public MvcValueContext(DbContextOptions<MvcValueContext> options)
            : base(options)
        {
        }

        public DbSet<Value> Value { get; set; }
    }
}